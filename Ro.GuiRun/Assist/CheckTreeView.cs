using System.Windows.Forms;

namespace Ro.GuiRun.Assist
{
    /// <summary>
    /// 针对Tree中的勾选进行协助
    /// <para>
    /// 勾选父节点，子节点会全部勾选
    /// 取消勾选父节点，子节点会全部取消
    /// </para>
    /// <para>
    /// 勾选子节点，父节点会勾选
    /// 取消勾选子节点，父节点会全部取消
    /// </para>
    /// </summary>
    public class CheckTreeView
    {
        /// <summary>
        /// 勾选所有的TreeNode
        /// 递归方法
        /// </summary>
        /// <param name="treeNode">Tree下的根节点</param>
        public static void CheckAllTreeNodes(TreeNode treeNode)
        {
            treeNode.Checked = true; //提前勾选一次，防止丢失
            foreach (TreeNode signode in treeNode.Nodes)
            {
                //如果下属子节点存在
                if (signode.Nodes.Count > 0)
                {
                    CheckAllTreeNodes(signode); //递归查询
                }
                signode.Checked = true; //勾选文件/文件夹
            }
        }


        /// <summary>
        /// 取消节点选中状态后，取消所有父节点的的选中状态
        /// <para>递归查询</para>
        /// </summary>
        /// <param name="currNode">被选中的节点</param>
        /// <param name="state">节点状态</param>
        public static void SetParentNodeCheckedState(TreeNode currNode, bool state)
        {
            TreeNode parentNode = currNode.Parent;
            parentNode.Checked = state;
            if (currNode.Parent.Parent != null)
            {
                SetParentNodeCheckedState(currNode.Parent, state);
            }
        }


        /// <summary>
        /// 选中节点后，选中节点的所有子节点
        /// <para>递归查询</para>
        /// </summary>
        /// <param name="currNode">被选中的节点</param>
        /// <param name="state">当前节点状态</param>
        public static void SetChildNodeCheckedState(TreeNode currNode, bool state)
        {
            TreeNodeCollection nodes = currNode.Nodes;
            if (nodes.Count > 0)
            {
                foreach (TreeNode tn in nodes)
                {
                    tn.Checked = state;
                    SetChildNodeCheckedState(tn, state);
                }
            }
        }
    }
}
