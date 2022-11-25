using System.Collections.Generic;

namespace MyConsole
{
    public class DfsGetAllPaths
    {
        private int ROWS;
        private int COLS;
        private int invalid = -1;
        private int count = 0;

        int DfsPaths(int[][] grid)
        {
            ROWS = grid.Length;
            COLS = grid[0].Length;
            HashSet<string> visit = new HashSet<string>();
            Dfs(0, 0, grid, visit);
            return count;
        }

        private void Dfs(int row, int col, int[][] grid, HashSet<string> visit)
        {
            if (row < 0 || col < 0 || row == ROWS || col == COLS
                || visit.Contains($"{row},{col}")
                || grid[row][col] == -1)
                return;

            if (grid[row][col] == grid[ROWS - 1][COLS - 1])
            {
                count = count + 1;
                return;
            }

            visit.Add($"{row},{col}");

            Dfs(row + 1, col, grid, visit);
            Dfs(row, col + 1, grid, visit);
        }
    }
}