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


        //solution 2
        public bool ValidPath2(int n, int[][] edges, int source, int destination)
        {
            visited = new bool[n].ToList();

            graph = CreateAdjacencyLists(n, edges);

            var set = new HashSet<int>();

            return Dfs2(graph, source, destination, set);
        }

        bool Dfs2(List<List<int>> graph, int node, int dest, HashSet<int> visited)
        {
            if (node == dest) return true;
            if (visited.Contains(node)) return false;

            visited.Add(node);

            foreach (int neighbour in graph[node])
            {
                if (Dfs2(graph, neighbour, dest, visited))
                {
                    return true;
                }
            }

            return false;
        }

        //solution 3
        public bool ValidPath3(int n, int[][] edges, int source, int destination)
        {
            //create adjacency list
            var adj = CreateAdjacencyLists(n, edges);

            //bfs
            return hasPathBfs(adj, source, destination, new HashSet<int>());
        }

        bool hasPathBfs(List<List<int>> graph, int source, int destination, HashSet<int> visited)
        {
            if (source == destination) return true;
            if (visited.Contains(source)) return false;

            visited.Add(source);

            var queue = new Queue<int>();
            queue.Enqueue(source);

            while (queue.Count > 0)
            {
                var current = queue.Dequeue();
                if (current == destination) return true;
                //Add to visited the dequeued element before visiting its neighbors
                visited.Add(current);

                foreach (var neighbor in graph[current])
                {
                    if (!visited.Contains(neighbor))
                    {
                        queue.Enqueue(neighbor);
                    }
                }
            }

            return false;
        }
    }
}