namespace MyConsole
{
    // 98. Validate Binary Search Tree
    // Given the root of a binary tree, determine if it is a valid binary search tree (BST).
    // A valid BST is defined as follows:
    // The left subtree of a node contains only nodes with keys less than the node's key.
    // The right subtree of a node contains only nodes with keys greater than the node's key.
    // Both the left and right subtrees must also be binary search trees.
    // https://leetcode.com/problems/validate-binary-search-tree/submissions/
    // https://leetcode.com/submissions/detail/811296099/
    public class BinarySearchTree
    {
        private int? prev = null;
    
        public bool IsValidBST(TreeNode root) {
            //preorder traversal lrtr
            if(root == null){
                return true;
            }
        
            if(!IsValidBST(root.left)){
                return false;
            }
        
            if(prev != null && root.val <= prev){
                return false;
            }
            prev = root.val;
        
            return IsValidBST(root.right);
        }
    }
}