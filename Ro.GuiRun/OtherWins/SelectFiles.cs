using System;
using System.IO;
using System.Windows.Forms;
using DMSkin;
using Ro.Common.Args;
using Ro.Common.UserType.GuiType;

namespace Ro.GuiRun.OtherWins
{
    public partial class SelectFiles : DMSkinForm
    {
        public SelectFiles()
        {
            InitializeComponent();
            ComArgs.GuiType = new GuiType();
        }


        /// <summary>
        /// 选择脚本文件夹
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rosB_Click(object sender, EventArgs e)
        {
            //弹出文件夹选择框
            FolderBrowserDialog fbd = new FolderBrowserDialog
            {
                Description = @"选取Ros文件夹",
                ShowNewFolderButton = false
            };
            if (fbd.ShowDialog() == DialogResult.OK || fbd.ShowDialog() == DialogResult.Yes)
            {
                ComArgs.GuiType.RosPath = fbd.SelectedPath;
                rosT.Text = ComArgs.GuiType.RosPath;
            }
            else
            {
                MessageBox.Show(@"没有选择测试脚本文件", @"警告");
            }
        }


        /// <summary>
        /// 选择元素集文件夹
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void roiB_Click(object sender, EventArgs e)
        {
            //弹出文件夹选择框
            FolderBrowserDialog fbd = new FolderBrowserDialog
            {
                Description = @"选取Roi文件夹",
                ShowNewFolderButton = false
            };
            if (fbd.ShowDialog() == DialogResult.OK || fbd.ShowDialog() == DialogResult.Yes)
            {
                ComArgs.GuiType.RoiPath = fbd.SelectedPath;
                roiT.Text = ComArgs.GuiType.RoiPath;
            }
            else
            {
                MessageBox.Show(@"没有选择测试脚本文件", @"警告");
            }
        }


        /// <summary>
        /// 选择配置文件夹
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rocB_Click(object sender, EventArgs e)
        {
            //弹出文件夹选择框
            FolderBrowserDialog fbd = new FolderBrowserDialog
            {
                Description = @"选取Roc文件夹",
                ShowNewFolderButton = false
            };
            if (fbd.ShowDialog() == DialogResult.OK || fbd.ShowDialog() == DialogResult.Yes)
            {
                ComArgs.GuiType.RocPath = fbd.SelectedPath;
                rocT.Text = ComArgs.GuiType.RocPath;
            }
            else
            {
                MessageBox.Show(@"没有选择测试脚本文件", @"警告");
            }
        }


        /// <summary>
        /// 选择并保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Save_Click(object sender, EventArgs e)
        {
            if (ComArgs.GuiType == null || ComArgs.GuiType.RosPath == null || ComArgs.GuiType.RocPath == null || ComArgs.GuiType.RoiPath == null)
            {
                MessageBox.Show(@"没有选择测试脚本文件,请重新选择", @"警告");
            }
            else
            {
                MessageBox.Show(
                    $@"Ros路径:{new DirectoryInfo(ComArgs.GuiType.RosPath).Name}" 
                    +"\r\n"+ $@"Roi路径:{new DirectoryInfo(ComArgs.GuiType.RoiPath).Name}"
                    + "\r\n" + $@"Roc路径:{new DirectoryInfo(ComArgs.GuiType.RocPath).Name}", @"信息");
                Close();
            }
        }
    }
}
