using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using Ro.Common.Args;
using Ro.Common.EnumType;
using Ro.Common.UserType.GuiType;
using Ro.Common.UserType.ScriptsLogicType;
using Ro.Interpreter;
using Ro.Interpreter.ConfigsCore;

namespace Ro.GuiRun.Assist
{
    public class GuiCore
    {
        public GuiCore(TreeNode rootNode)
        {
            //初始化UResultType，在UI启动一次后不再做初始化
            ComArgs.ResultType = new UResultType();
            //初始化UResultType，在UI启动一次后不再做初始化
            ComArgs.SigTestStep = new TestStep();

            RunSelectedRos(rootNode, ComArgs.GuiUsePath.RosPath); //正式执行脚本
        }


        /// <summary>
        /// 递归方法
        /// 运行已选择的ros脚本
        /// <para>核心方法</para>
        /// </summary>
        /// <param name="treeNode">Tree下的根节点</param>
        /// <param name="path">给定的母路径</param>
        private void RunSelectedRos(TreeNode treeNode, string path)
        {
            //循环节点,循环外层
            foreach (TreeNode signode in treeNode.Nodes)
            {
                //如果下属子节点存在，属性为folder
                if (signode.Name == "folder")
                {
                    string newpath = path + "/" + signode.Text;
                    RunSelectedRos(signode, newpath); //递归查询
                }
                else
                {
                    //如果是ros脚本
                    if (signode.Text.Contains(".ros") && signode.Checked)
                    {
                        //更新路径
                        string newpath = path + "/" + signode.Text;
                        //检查和创建临时文件夹
                        ComArgs.UseRosName = Path.GetFileNameWithoutExtension(newpath);

                        ComArgs.RoLog.WriteLog(LogStatus.LInfo, "===========================================================");
                        ComArgs.RoLog.WriteLog(LogStatus.LInfo, $"          脚本{ComArgs.UseRosName}开始执行...");
                        ComArgs.RoLog.WriteLog(LogStatus.LInfo, "===========================================================");
                        AnalysisRoc(ComArgs.GuiUsePath.RocPath); //解析配置文件
                        //执行脚本
                        MainEntrance mainEntrance = new MainEntrance(newpath);

                        ComArgs.RoLog.WriteLog(LogStatus.LInfo, "===========================================================");
                        ComArgs.RoLog.WriteLog(LogStatus.LInfo, $"          脚本{ComArgs.UseRosName}执行完成...");
                        ComArgs.RoLog.WriteLog(LogStatus.LInfo, "===========================================================");
                    }
                    //非ros脚本不处理
                }
            }
        }


        /// <summary>
        /// 递归方法
        /// 解析roc文件
        /// </summary>
        /// <param name="rocpath">roc文件夹路径</param>
        private void AnalysisRoc(string rocpath)
        {
            ComArgs.PropertiesDic = new Dictionary<string, string>();
            ComArgs.LanguageDic = new Dictionary<string, List<string>>();
            ComArgs.MacroDic = new Dictionary<string, Queue<TestStep>>();

            try
            {
                DirectoryInfo directoryInfo = new DirectoryInfo(rocpath);
                foreach (FileInfo sigfile in directoryInfo.GetFiles())
                {
                    //配置roc文件
                    ComArgs.RoLog.WriteLog(LogStatus.LInfo, $"脚本执行工具载入{sigfile.Name}配置文件...");
                    ConfigEntrance configEntrance = new ConfigEntrance(sigfile.FullName);
                    //获取到的每个配置信息，需要将对应信息写入全局字典中
                    if (configEntrance.PropertiesDic != null && configEntrance.PropertiesDic.Count > 0)
                    {
                        foreach (KeyValuePair<string, string> variable in configEntrance.PropertiesDic)
                        {
                            ComArgs.PropertiesDic.Add(variable.Key, variable.Value);
                        }
                    }
                    /*
                     foreach (var variable in configEntrance.LanguageDic)
                    {
                      ComArgs.LanguageDic.Add(variable.Key, variable.Value);
                    }
                    */

                    if (configEntrance.MacroDic != null && configEntrance.MacroDic.Count > 0)
                    {
                        foreach (KeyValuePair<string, Queue<TestStep>> variable in configEntrance.MacroDic)
                        {
                            ComArgs.MacroDic.Add(variable.Key, variable.Value);
                        }
                    }
                }
                ComArgs.RoLog.WriteLog(LogStatus.LInfo, $"当前参数字典共计 {ComArgs.PropertiesDic.Count} 个数据...");
                ComArgs.RoLog.WriteLog(LogStatus.LInfo, $"当前宏字典共计 {ComArgs.MacroDic.Count} 个数据...");
            }
            catch (Exception e)
            {
                ComArgs.RoLog.WriteLog(LogStatus.LExpt, $"脚本执行工具载入配置文件出现异常...", e.ToString());
            }
        }
    }
}
