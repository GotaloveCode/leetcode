using System;
using System.Collections.Generic;
using System.Linq;

namespace MyConsole
{
    public class PacificAtlantics
    {
        private int rowBound;
        private int colBound;
        private int rowIndex;
        private int colIndex;
        HashSet<String> pacificVerticex = new HashSet<string>();
        HashSet<String> atlanticsVerticex = new HashSet<string>();
        HashSet<String> oceans = new HashSet<string>();
        private IList<IList<int>> results = new List<IList<int>>();

        public IList<IList<int>> PacificAtlantic(int[][] heights)
        {
            //list of vertices atlantic
            // list of vertices on pacific
            //check you are in bounds of matrix
            // dfs 
            //return if val > current
            // Input: heights = [[1,2,2,3,5],[3,2,3,4,4],[2,4,5,3,1],[6,7,1,4,5],[5,1,1,2,4]]

            // pacific // 0,0 ... 0 ,Maxcol
            bool isPacific = false;
            bool isAtlantic = false;
            rowBound = heights.Length - 1;
            colBound = heights[0].Length - 1;


            //populate pacifics vertics 
            string key = "";
            for (int col = 0; col <= colBound; col++)
            {
                key = "0," + col; // '0,0' ,'0,1','0,2'
                pacificVerticex.Add(key);
            }

            for (int row = 0; row <= rowBound; row++)
            {
                key = row + ",0"; // 00,10,20,
                pacificVerticex.Add(key);
            }

            //populate atlantics vertics 
            for (int col = 0; col <= colBound; col++)
            {
                key = rowBound + "," + col; // '5,0','5,1','5,2'
                atlanticsVerticex.Add(key);
            }

            for (int row = 0; row <= rowBound; row++)
            {
                key = row + "," + colBound; // '05',10,20,
                atlanticsVerticex.Add(key);
            }
            
            Dfs(0, 0, heights[0][0], heights);
            // add to results
            List<int> tempList = new List<int>();
            if (oceans.Count() == 2)
            {
                tempList.Add(heights[rowIndex][colIndex]);
            }
            results.Add(tempList);
   
            return results;
        }

        void Dfs(int row, int col, int last_value, int[][] heights)
        {
            rowIndex = row;
            colIndex = col;
            if ((row > rowBound) || col > colBound)
                return;
            if (last_value > heights[row][col])
                return;
            string key = row + "," + col;
            if (pacificVerticex.Contains(key))
            {
                oceans.Add("p");
            }

            if (atlanticsVerticex.Contains(key))
            {
                oceans.Add("a");
            }

            Dfs(row + 1, col, heights[row][col], heights);
            Dfs(row - 1, col, heights[row][col], heights);
            Dfs(row, col + 1, heights[row][col], heights);
            Dfs(row, col - 1, heights[row][col], heights);
        }
    }
}