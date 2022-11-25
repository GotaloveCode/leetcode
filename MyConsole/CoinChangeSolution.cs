using System;

namespace MyConsole
{
    // https://leetcode.com/problems/last-stone-weight-ii/description/
    // https://leetcode.com/problems/coin-change/submissions/843409394/
    public class CoinChangeSolution
    {
        public int CoinChange(int[] coins, int amount)
        {
            if (amount == 0) return 0;
            int[][] matrix = new int[coins.Length][];
            //intialize the matrix 
            for (int i = 0; i < coins.Length; i++)
            {
                matrix[i] = new int[amount + 1];
            }

            //building the logic 
            for (int i = 0; i < coins.Length; i++)
            {
                int curCoin = coins[i];
                int previousRowValue = int.MaxValue; // Infinity
                int curComputedValue = int.MaxValue;
                for (int j = 0; j <= amount; j++)
                {
                    if (j == 0)
                    {
                        matrix[i][j] = 0;
                    }
                    else
                    {
                        if ((i - 1) < 0)
                        {
                            previousRowValue = int.MaxValue;
                        }
                        else
                        {
                            previousRowValue = matrix[i - 1][j];
                        }

                        if ((j - curCoin) < 0)
                        {
                            curComputedValue = previousRowValue;
                            matrix[i][j] = curComputedValue;
                        }
                        else
                        {
                            curComputedValue = matrix[i][j - curCoin];
                            if (curComputedValue != int.MaxValue)
                            {
                                curComputedValue = curComputedValue + 1;
                            }

                            matrix[i][j] = Math.Min(curComputedValue, previousRowValue);
                        }
                    }

                    Console.Write(matrix[i][j]);
                    Console.Write(",");
                }

                Console.WriteLine("---------------------");
            }

            if (matrix[coins.Length - 1][amount] == int.MaxValue) return -1;
            return matrix[coins.Length - 1][amount];
        }
    }
}
