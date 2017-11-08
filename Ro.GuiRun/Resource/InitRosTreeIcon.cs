using System.Windows.Forms;

namespace Ro.GuiRun.Resource
{
    public class InitRosTreeIcon
    {
        /// <summary>
        /// 初始化RosTree的icon
        /// </summary>
        /// <param name="treeView"></param>
        public static void RosTreeIcon(TreeView treeView)
        {
            treeView.ImageList = new ImageList();
            treeView.ImageList.Images.Add("folder", RosIcon.folder);
            treeView.ImageList.Images.Add("file", RosIcon.file);
        }
    }
}
