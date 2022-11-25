namespace MyConsole
{
    public class LinkedListRemoveNode
    {
        Node currentNode;
        Node head;
        
        
        Node remove(int n, Node currentNode)
        {
            head = currentNode;
            var totalCount = 0;
            
            //traverse linkedlist to get steps
            while (currentNode != null)
            {
                currentNode = currentNode.next;
                totalCount++;
            }
            
            var currentStep = totalCount - n;
            
            while (currentNode != null && currentStep <= n)
            {
                if (currentStep == n-1)
                {
                    var tempNode = currentNode.next;
                    if (tempNode.next != null)
                    {
                        currentNode.next = tempNode.next;
                    }
                    break;
                }
                currentNode = currentNode.next;
                currentStep++;
            }
            
            return head;
        }
    }

    public class Node
    {
        public int val;
        public Node next;

        public Node(int _val)
        {
            val = _val;
        }

    }
}