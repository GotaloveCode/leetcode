using System;
namespace MyConsole
{
    // https://leetcode.com/problems/minimum-time-to-make-rope-colorful/submissions/899878623/
    public class MincostSolution
    {
        public int MinCost(string s, int[] cost)
        {
            if (s == null || s.Length == 0 || cost == null || cost.Length == 0)
                return 0;
            int res = 0, maxCost = cost[0];
            for (int i = 1; i < s.Length; i++)
            {
                if (s[i] == s[i - 1])
                {
                    // find repeating letters, remove the letter that cost less
                    res += Math.Min(maxCost, cost[i]);
                    // update the maxCost, the current letter could be duplicates with larger cost than its following letters
                    // e.g., s = "aaa", cost = [2,3,1]. We need to udpate the maxCost when checking the 2nd 'a'.
                    maxCost = Math.Max(maxCost, cost[i]);
                }
                else
                {
                    // current letter is different from the previous one, but it could be duplicated  with its following letters.
                    maxCost = cost[i];   
                }
            }
            return res;
        }
    }
}
