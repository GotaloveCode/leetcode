namespace MyConsole
{
    // a battleship alternative
    // https://leetcode.com/problems/battleships-in-a-board/submissions/853838584/
    public class Battleship
    {
        public char[][] makeBoard(string[] B)
        {
            char[][] board = new char[B.Length][];
            for (int i = 0; i < B.Length; i++)
                board[i] = B[i].ToCharArray();

            return board;
        }

        public int[] solution(string[] B)
        {
            // write your code in C# 6.0 with .NET 4.7 (Mono 6.12)
            int[] ships = new int [3];
            var board = makeBoard(B);
            for (var i = 0; i < board.Length; i++)
            {
                for (var j = 0; j < board[0].Length; j++)
                {
                    if (board[i][j] == '#')
                        ships[countShips(i, j, board)]++;
                }
            }

            return ships;
        }

        int countShips(int i, int j, char[][] board)
        {
            if (i < 0 || i == board.Length || j < 0 || j == board[0].Length || board[i][j] == '.')
                return 0;

            board[i][i] = '.';
            int count = 0;

            count += countShips(i + 1, j, board);
            count += countShips(i - 1, j, board);
            count += countShips(i, j + 1, board);
            count += countShips(i , j - 1, board);

            return count + 1;
        }
    }
}

