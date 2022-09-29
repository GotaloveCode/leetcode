using System.Collections.Generic;

namespace MyConsole
{
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