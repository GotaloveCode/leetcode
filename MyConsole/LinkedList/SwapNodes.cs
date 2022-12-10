namespace MyConsole
{
    //https://leetcode.com/problems/swap-nodes-in-pairs/solutions/11021/my-c-solution-132ms/
    public class SwapNodes
    {
        public ListNode SwapPairs(ListNode head)
        {
            if (head==null || head.next==null)
                return head;
        
            ListNode localHead = head.next; 
            ListNode local, prev = null;
            while(head!=null && head.next!=null)
            {
                // swap 2 nodes
                local = head.next;           
                head.next = local.next;  
                local.next = head;          
                if (prev!=null)
                    prev.next = local;
                // next loop
                prev = head;
                head = head.next;
            }
            return localHead;
        }
    }
}