using System.Collections.Generic;

namespace MyConsole
{
    // https://leetcode.com/problems/binary-tree-postorder-traversal/submissions/809816108/
    public class PostOrderTraverseTree
    {
        List<int> listTree = new List<int>();

        public List<int> postorderTraversal(TreeNode root)
        {
            if (root == null)
            {
                return listTree;
            }

            postorderTraversal(root.left);
            postorderTraversal(root.right);

            listTree.Add(root.val);

            return listTree;
        }
        
        
    }
}