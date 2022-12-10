namespace MyConsole
{
    // https://leetcode.com/problems/unique-paths/
    // https://leetcode.com/problems/climbing-stairs/description/
    // https://app.codility.com/programmers/lessons/17-dynamic_programming/number_solitaire/
    public class DynamicProgramGame
    {
        public int solution(int[] A)
        {
            var dp = new int[A.Length];
            dp[0] = A[0];
            int maxVal = A[0];
            for (int i = 1; i < A.Length; i++)
            {
                int x = i - 1;
                while (x >= 0 && x >= i - 6)
                {
                    maxVal = maxVal > dp[x] ? maxVal : dp[x];
                    x--;
                }

                dp[i] = maxVal + A[i];
                maxVal = dp[i];
            }

            return dp[A.Length - 1];
        }
    }
}