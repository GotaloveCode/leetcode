namespace MyConsole
{
    //https://leetcode.com/problems/interleaving-string/submissions/857029158/
    public class InterleavingString
    {
        public bool IsInterleave(string s1, string s2, string s3)
        {
            if (s1.Length + s2.Length != s3.Length)
            {
                return false;
            }

            var memo = initializeMemo(s1, s2);

            return IsInterleaving(s1, 0, s2, 0,  s3, 0, memo);
        }

        int[][] initializeMemo(string s1, string s2)
        {
            var memo = new int[s1.Length][];
            for (int i = 0; i < s1.Length; i++)
            {
                memo[i] = new int[s2.Length];
            }
            
            for (int i = 0; i < s1.Length; i++)
            {
                for (int j = 0; j < s2.Length; j++)
                {
                    memo[i][j] = -1;
                }
            }

            return memo;
        }

        private bool IsInterleaving(string s1, int i, string s2, int j, string s3, int k, int[][] memo)
        {
            if (i == s1.Length)
            {
                return s2.Substring(j).Equals(s3.Substring(k));
            }

            if (j == s2.Length)
            {
                return s1.Substring(i).Equals(s3.Substring(k));
            }

            // string combo already evaluated
            if (memo[i][j] > -1)
            {
                return memo[i][j] == 1;
            }

            bool ans = (s1[i] == s3[k] && IsInterleaving(s1, i + 1, s2, j,  s3, k + 1, memo)) ||
                        (s2[j] == s3[k] && IsInterleaving(s1, i, s2 , j + 1,  s3, k + 1, memo));

            if (ans)
            {
                memo[i][j] = 1;
            }
            else
            {
                memo[i][j] = 0;
            }

            return ans;
        }
    }
}