using System.Collections.Generic;

namespace MyConsole
{
    // https://leetcode.com/problems/lru-cache/submissions/847894061/
    public class LRUCache
    {
        public class DoublyLinkedList {
            public int _key;
            public int _value;
            public DoublyLinkedList next;
            public DoublyLinkedList prev;
        
            public DoublyLinkedList(int key, int val) {
                _key = key;
                _value = val;
                //next = null;
                //prev = null;
            }
        
        }
    
        int _capacity = 0;
        Dictionary<int, DoublyLinkedList> _dict;
        DoublyLinkedList head;
        DoublyLinkedList tail;
    
        public LRUCache(int capacity) {
            _capacity = capacity;
            _dict = new Dictionary<int, DoublyLinkedList>();
            head = new DoublyLinkedList(0,0);
            tail = new DoublyLinkedList(0,0);
            head.next = tail;
            tail.prev = head;
        }
    
        public int Get(int key) {
            if(_dict.ContainsKey(key)){
                DoublyLinkedList node = _dict[key];
                RemoveNode(node);
                AddNode(node);
                return node._value;
            }
            else
                return -1;
        }
    
        public void Put(int key, int value) {
            if(_dict.ContainsKey(key)) {
                RemoveNode(_dict[key]);
            } 
            if(_dict.Count == _capacity) {
                RemoveNode(tail.prev);
            }
            AddNode(new DoublyLinkedList(key, value));
        }
    
        public void AddNode(DoublyLinkedList node) {
            _dict.Add(node._key, node);
            DoublyLinkedList headNext = head.next;
            head.next = node;
            node.prev = head;
            headNext.prev = node;
            node.next = headNext;
        }
        
        public void RemoveNode(DoublyLinkedList node) {
            _dict.Remove(node._key);
            node.prev.next = node.next;
            node.next.prev = node.prev;
        }
    }
}