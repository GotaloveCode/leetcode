using System;
using System.Collections.Generic;

namespace MyConsole
{
    public class AddNumberLinkedList
    {
        // https://leetcode.com/problems/add-two-numbers/submissions/902101896/
        public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            var list1 = new List<int>();
            var list2 = new List<int>();
            var resList = new List<int>();

            while (l1 != null)
            {
                list1.Add(l1.val);
                l1 = l1.next;
            }

            while (l2 != null)
            {
                list2.Add(l2.val);
                l2 = l2.next;
            }

            list1.Reverse();
            list2.Reverse();
            int minCount = Math.Min(list1.Count, list2.Count);
            int lst1Index = list1.Count - 1;
            int lst2Index = list2.Count - 1;
            int carry = 0;
            int sum = 0;
            for (int i = 0; i < minCount; i++)
            {
                sum = list1[lst1Index - i] + list2[lst2Index - i] + carry;
                if (sum > 9)
                {
                    resList.Add(sum - 10);
                    carry = 1;
                }
                else
                {
                    resList.Add(sum);
                    carry = 0;
                }
            }

            sum = 0;

            if (list1.Count > list2.Count)
            {
                //loop the diff and add to resList
                for (int i = lst1Index - (lst2Index + 1); i >= 0; i--)
                {
                    sum = list1[i] + carry;
                    if (sum > 9)
                    {
                        resList.Add(sum - 10);
                        carry = 1;
                    }
                    else
                    {
                        resList.Add(sum);
                        carry = 0;
                    }
                }
            }

            if (list1.Count < list2.Count)
            {
                for (int i = lst2Index - (lst1Index + 1); i >= 0; i--)
                {
                    sum = list2[i] + carry;
                    if (sum > 9)
                    {
                        resList.Add(sum - 10);
                        carry = 1;
                    }
                    else
                    {
                        resList.Add(sum);
                        carry = 0;
                    }
                }
            }

            if (carry > 0)
            {
                resList.Add(carry);
            }

            var resNode = new ListNode(0);

            var tempNode = resNode;

            for (int i = 0; i < resList.Count; i++)
            {
                tempNode.next = new ListNode(resList[i]);
                tempNode = tempNode.next;
            }

            return resNode.next;
        }
    }
}