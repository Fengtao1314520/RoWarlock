using System.IO;
using System.Windows.Forms;

namespace Ro.GuiRun.Assist
{
    public class GetAllRosFile
    {
        public TreeNode RootNode { get; }

        /// <summary>
        /// 构造函数，获取整个ros文件 包含子文件夹下
        /// </summary>
        /// <param name="rospath">rcs文件夹路径</param>
        public GetAllRosFile(string rospath)
        {
            DirectoryInfo tcsDirectoryInfo = new DirectoryInfo(rospath);
            //使用递归
            RootNode = new TreeNode
            {
                Text = tcsDirectoryInfo.Name,
                ImageIndex = 0,
                SelectedImageIndex = 0
            };
            RootNode = RecRosFile(tcsDirectoryInfo, RootNode);
        }

        /// <summary>
        /// 私有方法
        /// <para>递归函数</para>
        /// </summary>
        /// <param name="tcsDirectoryInfo">需要递归的文件夹</param>
        /// <param name="sigNode">当前节点</param>
        private TreeNode RecRosFile(DirectoryInfo tcsDirectoryInfo, TreeNode sigNode)
        {
            FileInfo[] allFile = tcsDirectoryInfo.GetFiles();
            foreach (FileInfo fi in allFile)
            {
                sigNode.Nodes.Add("file", fi.Name, 1, 1);
            }
            DirectoryInfo[] allDir = tcsDirectoryInfo.GetDirectories();
            foreach (DirectoryInfo d in allDir)
            {
                TreeNode tempNode = sigNode.Nodes.Add("folder", d.Name, 0, 0);
                sigNode.Checked = true;
                RecRosFile(d, tempNode);
            }

            return RootNode;
        }
    }
}
