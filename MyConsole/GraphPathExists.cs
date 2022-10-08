namespace MyConsole
{
    public class GraphPathExists
    {
        // var n = 3;
        // var edges = new int[,] {{0, 1}, {1, 2}, {2, 0}};
        // var source = 0;
        // var destination = 2;

        public bool ValidPath(int n, int[][] edges, int source, int destination)
        {
            bool[] visited = new bool[n];

            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < 2; col++)
                {
                    System.Console.WriteLine(row+","+col + " : "+ edges[row, col]);
                }
            }
            // foreach (var b in visited)
            // {
            //     System.Console.WriteLine(b);
            // }
            
            return true;
        }
    }
}