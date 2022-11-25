using System.Collections.Generic;
using System.Text;

namespace MyConsole
{
    public class Paintfill
    {
        private int ROWS;
        private int COLS;
        private int newColor = 3;

        int[][] PaintfillMethod(int x, int y, int[][] screen)
        {
            ROWS = screen.Length;
            COLS = screen[0].Length;
            HashSet<string> visit = new HashSet<string>();
            Dfs(x, y, visit, screen);

            return screen;
        }

        void Dfs(int row, int col, HashSet<string> visit, int[][] screen)
        {
            if (visit.Contains($"{row},{col}")
                || row < 0 || col < 0 || row == ROWS || col == COLS
                || (screen[row][col] == newColor))
                return;

            screen[row][col] = newColor;
            visit.Add($"{row},{col}");

            Dfs(row + 1, col, visit, screen);
            Dfs(row - 1, col, visit, screen);
            Dfs(row, col + 1, visit, screen);
            Dfs(row, col - 1, visit, screen);
        }
    }
}