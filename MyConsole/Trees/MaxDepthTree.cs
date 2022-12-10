using System;

namespace MyConsole
{
    // Given the root of a binary tree, return its maximum depth.
    // A binary tree's maximum depth is the number of nodes along
    // the longest path from the root node down to the farthest leaf node.
    // https://leetcode.com/problems/maximum-depth-of-binary-tree/
    // https://leetcode.com/submissions/detail/810788659/
    
    public class MaxDepthTree
    {
        public int MaxDepth(TreeNode root) {
            if(root == null)
                return 0;
        
            return Math.Max(MaxDepth(root.left),MaxDepth(root.right)) + 1;
        }
    }
}