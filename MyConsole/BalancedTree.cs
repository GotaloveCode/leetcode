using System;

namespace MyConsole{
    
    // Given a binary tree, determine if it is height-balanced.
    // For this problem, a height-balanced binary tree is defined as:
    // a binary tree in which the left and right subtrees of every node differ in height by no more than 1.
    // https://leetcode.com/problems/balanced-binary-tree/
    // https://leetcode.com/submissions/detail/810695005/
    public class BalancedTree
    {
        private bool balanced = true;
        
        public bool IsBalanced(TreeNode root) {
            if(root == null)
                return true;
            GetHeight(root);
            return balanced;
        }
        
        
        
        int GetHeight(TreeNode root) {
            if(root == null)
                return 0;
            //height of left subtree
            var leftHeight = GetHeight(root.left);
            //height of right subtree
            var rightHeight = GetHeight(root.right);

            if (Math.Abs(leftHeight - rightHeight) > 1)
            {
                balanced = false;
            }
            // return to the parent node the max between left and right 
            return Math.Max(leftHeight, rightHeight) + 1;  // plus one
        }
        
    }
}