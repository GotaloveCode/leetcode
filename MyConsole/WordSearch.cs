using System;

namespace MyConsole
{
    public class WordSearch
    {
        private string _word;

        public bool Exist(char[][] board, string word)
        {
            _word = word;
            var rows = board.Length;
            var cols = board[0].Length;
            var visited = new bool[rows][];
            for (int i = 0; i < rows; i++)
            {
                visited[i] = new bool[cols];
            }
            for(var r = 0; r < rows; r++){
                for(var c = 0; c < cols; c++){
                    if(board[r][c] == word[0]){ // find first char in word
                        var isFound = Dfs(board, r, c, 0, visited);    // call DFS or recursion
                        if(isFound){ return true; }
                    }
                }
            }

            return false;
        }

        private bool Dfs(char[][] board, int row, int col, int wordIndex, bool[][] visited)
        {
            if (row >= board.Length || row < 0 || col >= board[0].Length || col < 0
                || board[row][col] != _word[wordIndex] || visited[row][col])
                return false;

            if (wordIndex == _word.Length - 1)
                return true;

            //mark traversed
            visited[row][col] = true;
 
            if (Dfs(board, row + 1, col, wordIndex + 1, visited))
                return true;
            if (Dfs(board, row - 1, col, wordIndex + 1,visited))
                return true;
            if (Dfs(board, row, col + 1, wordIndex + 1,visited))
                return true;
            if (Dfs(board, row, col - 1, wordIndex + 1,visited))
                return true;
            
            //if we get here set not traversed no char found
            visited[row][col] = false;
            
            return false;
        }

        public void Execute()
        {
            char[][] board = new[]
            {
                new[] {'A', 'B', 'C', 'E'},
                new[] {'S', 'F', 'C', 'S'},
                new[] {'A', 'D', 'E', 'E'}
            };

            var word = "ABCCED";

            Console.WriteLine(Exist(board, word));
        }
    }
}