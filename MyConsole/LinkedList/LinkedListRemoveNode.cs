namespace MyConsole
{
    public class LinkedListRemoveNode
    {
        //https://leetcode.com/problems/remove-nth-node-from-end-of-list/submissions/851288558/
        public ListNode RemoveNthFromEnd(ListNode head, int n) {
            int len = 0;
            ListNode tmp = head;
            while (tmp != null)
            {
                len++;
                tmp = tmp.next;
            }
            if (n > len)
            {
                return head;
            }
            else if (n == len)
            {
                return head.next;
            }
            else
            {
                int diff = len - n;
                ListNode prev= null;    
                ListNode curr = head;        
                for(int i = 0; i < diff; i++)
                {
                    prev = curr;        
                    curr = curr.next;    
                }
                prev.next = curr.next;
                return head;
            }
        }
    }
}