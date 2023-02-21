using System;
namespace MyConsole
{
    //https://leetcode.com/problems/find-missing-observations/submissions/899896662/
    public class MissingRollsSolution
    {
        public int[] MissingRolls(int[] rolls, int mean, int n)
        {
            int observations = rolls.Length + n;
            int sumRolls = rolls.Sum();
            int missingSumObservations = (observations * mean) - sumRolls;
            int m = missingSumObservations / n;

            // dice can only have 1 - 6
            if (m > 6 || m < 1) return new int[0];

            int mod = missingSumObservations % n;

            // dice cannot exceed 6 
            if (m == 6 && mod > 0)
            {
                return new int[0];
            }
            var result = new int[n];

            //assign variables
            for (int i = 0; i < result.Length; i++)
            {
                result[i] = m;
            }

            // for mod times add 1 to result to distribute mod in result
            for (int i = 0; i < mod; i++)
            {
                result[i] = result[i] + 1;
            }

            return result;
        }
    }
}
