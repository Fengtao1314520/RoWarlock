using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using DMSkin;
using Ro.Assist.AssistBot;
using Ro.Common.Args;
using Ro.Common.EnumType;
using Ro.Common.UserType.GuiType;
using Ro.GuiRun.Assist;
using Ro.GuiRun.OtherWins;
using Ro.GuiRun.Resource;

namespace Ro.GuiRun
{
    public partial class RoMain : DMSkinForm
    {
        public RoMain()
        {
            InitializeComponent();
            InitRosTreeIcon.RosTreeIcon(RosTree); //初始化图片资源
            ComArgs.RoLog.CreateLog("RoUIA"); //创建log
            ComArgs.RoLog.WriteLog(LogStatus.LInfo, "脚本执行工具正式开始工作..."); //起始log语句

            //this.WindowState = FormWindowState.Maximized;
        }


        /// <summary>
        /// 选择文件
        /// ROS/ROC/ROI三类
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SelectFile_Click(object sender, System.EventArgs e)
        {
            ComArgs.RoLog.WriteLog(LogStatus.LInfo, "准备勾选ros/roi/roc文件夹...");
            SelectFiles selectFiles = new SelectFiles();
            selectFiles.ShowDialog(); //执行完毕后，再更新rostree
            GetAllRosFile getAllRosFile = new GetAllRosFile(ComArgs.GuiType.RosPath);
            RosTree.Nodes.Add(getAllRosFile.RootNode);
            RosTree.ExpandAll(); //全展开
            CheckTreeView.CheckAllTreeNodes(getAllRosFile.RootNode); //默认全部勾选
        }


        /// <summary>
        /// 勾选后的事件处理
        /// <para>勾选父节点，子节点全部勾选</para>
        /// <para>取消时，勾选子节点，父节点取消</para>
        /// <para>取消时，勾选父节点，子节点全部取消</para>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RosTree_AfterCheck(object sender, TreeViewEventArgs e)
        {
            if (e.Action == TreeViewAction.ByMouse)
            {
                if (e.Node.Checked)
                {
                    //选中节点，选中其子节点
                    CheckTreeView.SetChildNodeCheckedState(e.Node, true);
                }
                else
                {
                    //取消选中，取消其子节点
                    CheckTreeView.SetChildNodeCheckedState(e.Node, false);
                    if (e.Node.Parent != null)
                    {
                        //如果存在父节点，则取消对应的父节点
                        CheckTreeView.SetParentNodeCheckedState(e.Node, false);
                    }
                }
            }
        }


        /// <summary>
        /// 开始运行
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Start_Click(object sender, System.EventArgs e)
        {
            ComArgs.RoLog.WriteLog(LogStatus.LInfo, "脚本执行工具准备开始执行脚本...");
            ResultView.Items.Clear(); //清除结果view
            TotalSteps.Text = @"当前步骤数:0";
            SucSteps.Text = @"成功步骤数:0";
            FailSteps.Text = @"失败步骤数:0";
            SucCover.Text = @"成功率:0.00%";


            //Start.Text = @"Stop";
            TreeNode root = RosTree.Nodes[0]; //拉取整个树形链
            _runThread = new Thread(RunT) {IsBackground = true};
            _runThread.Start(root);
        }


        #region 私有方法 AND 本地参数(变量)

        /// <summary>
        /// 运行脚本线程
        /// </summary>
        private Thread _runThread;

        /// <summary>
        /// 运行执行
        /// </summary>
        /// <param name="rootNode">树形结构</param>
        private void RunT(object rootNode)
        {
            GuiViewEvent.UiViewResult += ChangeResult; //绑定事件
            GuiViewEvent.UiViewSteps += ChangeView;//绑定事件

            ComArgs.RoLog.WriteLog(LogStatus.LInfo, "脚本执行工具执行GuiCore方法...");
            GuiCore guiCore = new GuiCore(rootNode as TreeNode); //正式开始执行脚本
            MessageBox.Show(@"运行完成！", @"通知");
            ComArgs.RoLog.DisposeLog(); //RoLog完成生命周期
            GC.Collect(); //释放资源

            GuiViewEvent.UiViewResult -= ChangeResult; //解绑事件
            GuiViewEvent.UiViewSteps -= ChangeView;//解绑事件
        }


        /// <summary>
        /// 一键选择文件夹
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OneKey_Click(object sender, System.EventArgs e)
        {
            //弹出文件夹选择框
            FolderBrowserDialog fbd = new FolderBrowserDialog
            {
                Description = @"选取Ros/Roi/Roc文件的父层文件夹",
                ShowNewFolderButton = false
            };
            if (fbd.ShowDialog() == DialogResult.OK || fbd.ShowDialog() == DialogResult.Yes)
            {
                ComArgs.GuiType = new GuiType
                {
                    RosPath = $"{fbd.SelectedPath}/Scripts",
                    RoiPath = $"{fbd.SelectedPath}/UIMaps",
                    RocPath = $"{fbd.SelectedPath}/Config"
                };
                GetAllRosFile getAllRosFile = new GetAllRosFile(ComArgs.GuiType.RosPath);
                RosTree.Nodes.Add(getAllRosFile.RootNode);
                RosTree.ExpandAll(); //全展开
                CheckTreeView.CheckAllTreeNodes(getAllRosFile.RootNode); //默认全部勾选
            }
            else
            {
                MessageBox.Show(@"没有选择测试脚本文件", @"警告");
            }
        }

        #endregion

        #region UI更新的绑定事件

        /// <summary>
        /// 更新view控件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="item"></param>
        private void ChangeView(object sender, UViewType item)
        {
            if (ResultView.InvokeRequired)
            {
                GuiViewEvent.ViewSteps invokeSteps = ChangeView;
                Invoke(invokeSteps, sender, item);
            }
            else
            {
                ListViewItem lvi = ResultView.Items.Add((ResultView.Items.Count + 1) + "");
                lvi.UseItemStyleForSubItems = false;
                if (item.Result=="失败")
                {
                    lvi.BackColor=Color.Red;
                }
                else
                {
                    lvi.BackColor=Color.LimeGreen;
                }
                lvi.SubItems.Add(item.StepName);
                lvi.SubItems.Add(item.ControlId);
                lvi.SubItems.Add(item.Result);
                lvi.SubItems.Add(item.ExtraInfo);
                lvi.EnsureVisible();
            }
        }

        /// <summary>
        /// 更新statustrips控件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="item"></param>
        private void ChangeResult(object sender, UResultType item)
        {

            if (GuiStrip.InvokeRequired)
            {
                GuiViewEvent.ViewResult invokeResult = ChangeResult;
                Invoke(invokeResult, sender, item);
            }
            else
            {
                TotalSteps.Text = $@"当前步骤数:{item.NowNums}";
                SucSteps.Text = $@"成功步骤数:{item.SuccNums}";
                FailSteps.Text = $@"失败步骤数:{item.FailNums}";
                SucCover.Text = $@"成功率:{item.Cover}%";
            }

        }

        #endregion
    }
}
