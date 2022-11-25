using System;

namespace MyConsole
{
    // https://www.geeksforgeeks.org/fractional-knapsack-problem/
    // Given the weights and values of N items, in the form of {value, weight}
    // put these items in a knapsack of capacity W to get the maximum total value in the knapsack.
    // In Fractional Knapsack, we can break items for maximizing the total value of the knapsack
    
    public class KnapsackSolution
    {
        public int MaxValue(int[] value, int[] weights, int capacity)
        {
            var dp = new int[weights.Length + 1][];

            for (var i = 0; i < weights.Length + 1; i++)
            {
                dp[i] = new int[capacity + 1];
            }

            for (var i = 1; i <= weights.Length; i++)
            {
                for (var j = 1; j <= capacity; j++)
                {
                    if (weights[i - 1] <= j || dp[i][j - 1] == 0)
                    {
                        dp[i][j] = value[i - 1];
                    }
                    else
                    {
                        dp[i][j] = Math.Max(dp[i][j - weights[i - 1]] + value[i - 1], dp[i - 1][j]);
                    }
                }
            }

            return dp[weights.Length][capacity];
        }
    }
}