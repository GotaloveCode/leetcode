namespace MyConsole
{
    // 129. Sum Root to Leaf Numbers
    // You are given the root of a binary tree containing digits from 0 to 9 only.
    // Each root-to-leaf path in the tree represents a number.
    // For example, the root-to-leaf path 1 -> 2 -> 3 represents the number 123.
    // Return the total sum of all root-to-leaf numbers. Test cases are generated so that the answer will fit in a 32-bit integer.
    //  A leaf node is a node with no children.
    // https://leetcode.com/problems/sum-root-to-leaf-numbers/submissions/815110775/
    public class SumRootToLeaf
    {
        private int totalSum = 0;
        
        public int SumNumbers(TreeNode root)
        {
            SumOfNodes(root);
            return totalSum;
        }

        void SumOfNodes(TreeNode root, int sum = 0)
        {
            if (root == null)
            {
                return;   
            }

            sum = sum * 10 + root.val;

            SumOfNodes(root.left, sum);
            SumOfNodes(root.right, sum);
        }
    }
}