using System.Collections.Generic;
using System.Linq;

namespace MyConsole
{
    // var n = 3;
    // var edges = new int[,] {{0, 1}, {1, 2}, {2, 0}};
    // var source = 0;
    // var destination = 2;
    //1971. Find if Path Exists in Graph
    // https://leetcode.com/problems/find-if-path-exists-in-graph/submissions/819605256/
    public class GraphPathExists
    {
        List<bool> visited = new List<bool>();
        private List<List<int>> graph = new List<List<int>>();

        public bool ValidPath(int n, int[][] edges, int source, int destination)
        {
            visited = new bool[n].ToList();

            graph = CreateAdjacencyLists(n, edges);

            if (HasPath(source, destination))
                return true;
            
            return false;
        }

        List<List<int>> CreateAdjacencyLists(int n, int[][] edges)
        {
            var list = new List<List<int>>();
            //initialize list
            for (int i = 0; i < n; i++)
            {
                list.Add(new List<int>());
            }

            //iterate over edges
            foreach (int[] edge in edges)
            {
                list[edge[0]].Add(edge[1]);
                list[edge[1]].Add(edge[0]);
            }

            return list;
        }

        bool HasPath(int source, int destination)
        {
            Dfs(source);
            return visited[destination];
        }

        void Dfs(int index)
        {
            Stack<int> stack = new Stack<int>();
            stack.Push(index);
            visited[index] = true;
            while (stack.Count > 0)
            {
                int nodeIndex = stack.Pop();
                visited[nodeIndex] = true;

                List<int> neighboursList = graph[nodeIndex];

                foreach (int neighbour in neighboursList)
                {
                    if (!visited[neighbour])
                    {
                        stack.Push(neighbour);
                    }
                }
            }
        }
    }
}