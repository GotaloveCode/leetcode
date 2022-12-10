using System;

namespace MyConsole
{
    // https://leetcode.com/problems/longest-palindromic-substring/submissions/857516308/
    public class LongestPalindromicString
    {
        public string LongestPalindrome(string s)
        {
            var dp = new bool[s.Length][];
            //create dp bool array
            for (int i = 0; i < s.Length; i++)
            {
                dp[i] = new bool[s.Length];
                //every single letter by itself is a palindrome
                dp[i][i] = true;
            }

            //longest Palindrome
            int lp = 1;
            int start = 0;
            // loop for length of 2 //aa,bb etc
            for (int i = 0; i < s.Length - 1; i++)
            {
                if (s[i] == s[i + 1])
                {
                    dp[i][i + 1] = true;
                    start = i;
                    lp = 2;
                }
            }

            //use i as our length
            for (int i = 3; i <= s.Length; i++)
            {
                for (int j = 0; j < s.Length; j++)
                {
                    // stick within bound
                    if (j + i <= s.Length)
                    {
                        var lastIndex = j + i - 1;
                        //if first == last && mid is palindrome
                        if (s[j] == s[lastIndex] && dp[j + 1][lastIndex - 1])
                        {
                            dp[j][lastIndex] = true;
                            //update lp
                            if (lp < i)
                            {
                                lp = i;
                                start = j;
                            }
                        }
                    }
                }
            }
            
            return s.Substring(start, lp);
        }
    }
}