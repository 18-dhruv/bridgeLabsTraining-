namespace Operator_overloading;

using System;
    public class Node {
        int key, value;
        Node prev, next;
        Node(int key, int value) 
        {
            this.key = key;
            this.value = value;
        }
        public class LRUCache {
            private  int capacity;
            private  Dictionary<int, Node> map;
            private  Node head, tail;
            public LRUCache(int capacity) {
                this.capacity = capacity;
                this.map = new Dictionary<int,Node>();
                head = new Node(0, 0);
                tail = new Node(0, 0);
                head.next = tail;
                tail.prev = head;
            }
    
            public int Get(int key) {
                if (!map.ContainsKey(key)) return -1;
                Node node = map[key];
                remove(node);
                insertAtFront(node);
                return node.value;  
            }
    
            public void Put(int key, int value)
            {
                if (map.ContainsKey(key))
                {
                    Node node = map[key];
                    node.value = value;
                    remove(node);
                    insertAtFront(node);
                } 
                else
                {
                    if (map.Count == capacity) 
                    {
                        Node lru = tail.prev;
                        remove(lru);
                        map.Remove(lru.key);
                    }
                    Node newNode = new Node(key, value);
                    insertAtFront(newNode);
                    map.Add(key,newNode);
                } 
            }
            private void remove(Node node) 
            {
                node.prev.next = node.next;
                node.next.prev = node.prev;
            }
            private void insertAtFront(Node node) 
            {
                node.next = head.next;
                node.prev = head;
                head.next.prev = node;
                head.next = node;
            }
        }
        public static void Main(string[] args)
        {
            LRUCache cache = new LRUCache(2);
            cache.Put(1, 10);
            cache.Put(2, 20);
            Console.WriteLine(cache.Get(1));
            cache.Put(3, 30); 
            Console.WriteLine(cache.Get(2)); 
            Console.WriteLine(cache.Get(3)); 
            cache.Put(4, 40);
            Console.WriteLine(cache.Get(1)); 
            Console.WriteLine(cache.Get(3)); 
            Console.WriteLine(cache.Get(4)); 
        }
    }
