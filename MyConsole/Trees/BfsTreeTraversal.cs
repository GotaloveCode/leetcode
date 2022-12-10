using System;
using System.Collections.Generic;

namespace MyConsole
{
    public class BfsTreeTraversal
    {
        static void traverse(TreeNode node)
        {
            Console.WriteLine("______Traverse BfsTraversal______");
            Queue<TreeNode> q = new Queue<TreeNode>();
            q.Enqueue(node);
            while (q.Count > 0)
            {
                var currentNode = q.Dequeue();
                Console.WriteLine(currentNode.val);
                
                if(currentNode.left != null)
                    traverse(currentNode);
                if(currentNode.right != null)
                    traverse(currentNode);
            }
        }
    }
}