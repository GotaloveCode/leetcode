using System;
using System.Collections.Generic;

namespace MyConsole.LinkedList
{
    //23. Merge k Sorted Lists
    // https://leetcode.com/problems/merge-k-sorted-lists/submissions/901544271/
    public class MergeKSortedListSolution
    {
        public ListNode MergeKLists(ListNode[] lists)
        {
            var lstVals = new List<int>();
            foreach (ListNode l in lists)
            {
                if (l != null)
                {
                    var lNode = l;
                    while (lNode != null)
                    {
                        lstVals.Add(lNode.val);
                        lNode = lNode.next;
                    }
                }
            }

            lstVals.Sort();

            var tempNode = new ListNode(0);
            var result = tempNode;
            foreach (int item in lstVals)
            {
                tempNode.next = new ListNode(item);
                tempNode = tempNode.next;
            }

            return result.next;
        }
    }
}
