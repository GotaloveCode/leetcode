namespace MyConsole.LinkedList
{
    //19. Remove Nth Node From End of List
    // https://leetcode.com/problems/remove-nth-node-from-end-of-list/submissions/851288558/
    public class RemoveNthFromEndSolution
    {
        ListNode currentNode;
        public ListNode RemoveNthFromEnd(ListNode head, int n)
        {
            currentNode = head;
            int count = 0;

            while (currentNode != null)
            {
                count++;
                currentNode = currentNode.next;
            }

            if (n > count) return head;
            if (n == count) return head.next;

            currentNode = head;
            int diff = count - n;
            ListNode prev = null;
            ListNode curr = head;

            for (int i = 0; i < diff; i++)
            {
                prev = curr;
                curr = curr.next;
            }

            prev.next = curr.next;

            return head;
        }
    }
}
