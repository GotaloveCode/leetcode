using System;

namespace MyConsole
{
    public class WordSearch
    {
        private string _word;

        public bool Exist(char[][] board, string word)
        {
            _word = word;
            var index = CountWords(board, 0, 0, 0);
            Console.WriteLine("last word char:" + (_word.Length - 1));
            Console.WriteLine("our index:" + index);
            return (index == (word.Length - 1));
        }

        private int CountWords(char[][] board, int i, int j, int index)
        {
            if (i >= board.Length || i < 0 || j >= board[0].Length || j < 0
                || board[i][j] == '.' || index == _word.Length - 1)
            {
                //mark as traversed
                // board[i][j] = '.';
                Console.WriteLine(_word[index] + " index:" + index);
                return index;
            }

            //check if matches current character
            if (board[i][j] == _word[index])
            {
                // if (index == _word.Length - 1)
                // {
                //     //mark as traversed
                //     // board[i][j] = '.';
                //     Console.WriteLine(_word[index] + " index:" + index);
                //     return index;
                // }

                index++;
            }

            var temp = board[i][j];
            //mark as traversed
            board[i][j] = '.';

            index = CountWords(board, i + 1, j, index);
            index = CountWords(board, i - 1, j, index);
            index = CountWords(board, i, j + 1, index);
            index = CountWords(board, i, j - 1, index);

            Console.WriteLine("end:" + _word[index] + " index:" + index + " board:" + temp + " i: " + i + " j: " + j);
            return index;
        }

        public void Execute()
        {
            char[][] board = new[]
            {
                new[] {'A', 'B', 'C', 'E'},
                new[] {'S', 'F', 'C', 'S'},
                new[] {'A', 'D', 'E', 'E'}
            };

            var word = "ABCB";

            Console.WriteLine(Exist(board, word));
        }
    }
}