using System;
using System.Collections.Generic;

namespace MyConsole
{
    // https://leetcode.com/problems/course-schedule-ii/submissions/834721820/
    public class OrderCourses
    {
        public int[] FindOrder(int numCourses, int[][] prerequisites)
        {
            //create adj list
            var adj = CreateGraph(numCourses, prerequisites);
            // initialize connected nodes count
            var nodes= new int[numCourses];
            for(var i = 0; i < numCourses; i++){
                foreach(var n in adj[i]){
                    nodes[n]++; //increase incoming edges
                }
            }

            var q = new Queue<int>();

            for (var i = 0; i < numCourses; i++)
            {
                if (nodes[i] == 0) //get root nodes
                    q.Enqueue(i);
            }

            var results = new List<int>();

            while (q.Count > 0)
            {
                int node = q.Dequeue();
                results.Add(node);
                foreach(int n in adj[node]){
                    nodes[n]--; //decrease incoming edges
                    if (nodes[n] == 0) 
                        q.Enqueue(n);
                }
            }

            return results.Count == numCourses ? results.ToArray() : Array.Empty<int>();
        }
        
        private List<int>[] CreateGraph(int n , int[][] edges)
        {
            var adj = new List<int>[n];
            for (var row = 0; row < n; row++)
            {
                adj[row] = new List<int>();
            }
            
            foreach(int[] edge in edges)
            {
                int v = edge[0];
                int u = edge[1];
                adj[u].Add(v);
            }
            return adj;
        }
        
        public void Execute()
        {
            //0,[1]
            //1 [0]
            //2[1,2]
            //3
            var numCourses = 4;
            var prerequisites = new[]
            {
                new[] {1, 0}, new [] {2, 0}, new [] {3, 1}, new [] {3, 2}
            };
            var ol = FindOrder(numCourses, prerequisites);
            Console.WriteLine(String.Join(",", ol));
        }
    }
}