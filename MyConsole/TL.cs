using System;
using System.Collections.Generic;

namespace MyConsole
{
    public class TL
    {
    }

    public class Solution
    {
        public IList<IList<int>> LevelOrder(TreeNode root)
        {
            var results = new List<IList<int>>();
            var q = new Queue<List<KeyValuePair<TreeNode, int>>>();
            if (root == null)
                return results;
            var item = new List<KeyValuePair<TreeNode, int>>();
            item.Add(new KeyValuePair<TreeNode, int>(root, 0));
            q.Enqueue(item); //[root,0]
            int previousLevel = 0;
            var lst = new List<int>();
            while (q.Count != 0)
            {
                var listItem = q.Dequeue();
                var node = listItem[0].Key;
                var level = listItem[0].Value;
                if (previousLevel != level)
                {
                    previousLevel = level;
                    results.Add(lst);
                    lst = new List<int>();
                }
                lst.Add(node.val); // current
                if (node.left != null)
                {
                    item.Add(new KeyValuePair<TreeNode, int>(node.left, level));
                    q.Enqueue(item);
                }

                if (node.right != null)
                {
                    item.Add(new KeyValuePair<TreeNode, int>(node.right, level));
                    q.Enqueue(item);
                }
                level++;
            }


            return results;
        }
    }
}