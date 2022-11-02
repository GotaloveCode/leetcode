namespace MyConsole
{
    public class Battleship
    {
        public char[][] makeBoard (string[] B){

            char[][] board = new char[B.Length][];
            for (int i = 0; i < B.Length; i++)
                board[i] = B[i].ToCharArray(); 

            return board; 
        }

        public int[] solution(string[] B) {
            // write your code in C# 6.0 with .NET 4.7 (Mono 6.12)
            int [] ships = new int [3];
            char[][] board = makeBoard(B);
        
            for (int i = 0; i < B[0].Length; i++) {
                for (int j = 0; j < B.Length; j++) {
                    if (board[j][i] == '#')
                        ships[countShip(board,i,j)-1]++;
                }
            }

            return ships; 
        }

        public int countShip(char[][] board, int i, int j) {

            if (i >= board[0].Length || i < 0 || j >= board.Length || j  < 0 || board[j][i] == '.')
                return 0; 

            board[j][i] = '.';

            int count = 0; 
            count += countShip (board, i+1, j);
            count += countShip (board, i-1, j);
            count += countShip (board, i, j+1);
            count += countShip (board, i, j-1);

            return count+1; 
        }
    }
}