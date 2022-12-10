using System;
using System.Collections.Generic;

namespace MyConsole
{
    public class Graph
    {
        private int vertices;
        private List<int>[] adj;

        private Graph(int v)
        {
            vertices = v;
            adj = new List<int>[v];
            for (int i = 0; i < v; i++)
            {
                adj[i] = new List<int>();
            }
        }

        void AddEdge(int source, int destination)
        {
            adj[source].Add(destination);
        }

        void DfsIterative(int v)
        {
            bool[] visited = new bool[vertices];
            Stack<int> stack = new Stack<int>();
            visited[v] = true;
            stack.Push(v);

            while (stack.Count > 0)
            {
                var current = stack.Pop();
                Console.WriteLine($"Next -> {current}");
                foreach( int neighbor in adj[current])
                {
                    if (!visited[neighbor])
                    {
                        visited[neighbor] = true;
                        stack.Push(neighbor);
                    }
                }
            }

        }

        void DfsRecursive(int source)
        {
            Console.WriteLine($"Next {source}");
            foreach (var neighor in adj[source])
            {
                DfsRecursive(neighor);
            }
        }

        void Bfs(int source)
        {
            var queue = new Queue<int>();
            queue.Enqueue(source);
            while (queue.Count > 0)
            {
                var current = queue.Dequeue();
                Console.WriteLine($"Next -> {current}");
                foreach (var neighbor in adj[current])
                {
                    queue.Enqueue(neighbor);
                }
            }
        }

        public static void DfsRun()
        {
            Graph g = new Graph(4);
            g.AddEdge(1,2);
            g.AddEdge(1,3);
            Console.WriteLine("---DfsIterative----");
            g.DfsIterative(1);
            Console.WriteLine("---End DfsIterative----");
            Console.WriteLine("---DfsRecursive----");
            g.DfsIterative(1);
            Console.WriteLine("---End DfsRecursive----");
            Console.WriteLine("---Bfs----");
            g.Bfs(1);
            Console.WriteLine("---End Bfs----");
        }
    }
}