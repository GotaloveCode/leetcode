using System.Collections.Generic;

namespace MyConsole
{
    // https://leetcode.com/problems/binary-tree-inorder-traversal/submissions/809826702/
    public class InorderTraversalSol
    {
        List<int> listTree = new List<int>();
    
        public IList<int> InorderTraversal(TreeNode root) {
            if (root == null){
                return listTree;
            }

            InorderTraversal(root.left);
            listTree.Add(root.val);
            InorderTraversal(root.right);

            return listTree;
        }
    }
}