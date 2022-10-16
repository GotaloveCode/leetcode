using System.Collections.Generic;


namespace MyConsole
{
    
    // 417. Pacific Atlantic Water Flow
    // Input: heights = [[1,2,2,3,5],[3,2,3,4,4],[2,4,5,3,1],[6,7,1,4,5],[5,1,1,2,4]]
    // https://leetcode.com/problems/pacific-atlantic-water-flow/submissions/819544738/
    public class PacificAtlantics
    {
        private int ROWS;
        private int COLS;
        private int[][] heightsMatrix;

        public IList<IList<int>> PacificAtlantic(int[][] heights)
        {
            heightsMatrix = heights;
            ROWS = heights.Length;
            COLS = heights[0].Length;
            var pac = new HashSet<string>();
            var atl = new HashSet<string>();
            var res = new List<IList<int>>();

            for (int col = 0; col < COLS; col++)
            {
                //pacific - all in top row of matrix
                Dfs(0, col, pac, heights[0][col]);
                // Atlantic - all in bottom row of matrix
                Dfs(ROWS - 1, col, atl, heights[ROWS - 1][col]);
            }

            for (int row = 0; row < ROWS; row++)
            {
                //pacific - all in 1st column
                Dfs(row, 0, pac, heights[row][0]);
                //atlantic - all in last column
                Dfs(row, COLS - 1, atl, heights[row][COLS - 1]);
            }

            for (int row = 0; row < ROWS; row++)
            {
                for (int col = 0; col < COLS; col++)
                {
                    if (pac.Contains($"{row},{col}") && atl.Contains($"{row},{col}"))
                    {
                        res.Add(new List<int> {row, col});
                    }
                }
            }
            

            return res;
        }

        void Dfs(int row, int col, HashSet<string> visit, int prevHeight)
        {
            //starting from ocean so height > upward
            if (visit.Contains($"{row},{col}")
                || row < 0 || col < 0 || row == ROWS || col == COLS
                || heightsMatrix[row][col] < prevHeight)
                return;
            visit.Add($"{row},{col}");

            Dfs(row + 1, col, visit, heightsMatrix[row][col]);
            Dfs(row - 1, col, visit, heightsMatrix[row][col]);
            Dfs(row, col + 1, visit, heightsMatrix[row][col]);
            Dfs(row, col - 1, visit, heightsMatrix[row][col]);
        }
    }
}
