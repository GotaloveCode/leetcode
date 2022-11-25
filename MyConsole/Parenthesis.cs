using System.Collections.Generic;

namespace MyConsole
{
    // Input: n = 3
    // Output: ["((()))","(()())","(())()","()(())","()()()"]
    // https://leetcode.com/problems/generate-parentheses/submissions/847542485/
    
    public class Parenthesis
    {
        public IList<string> GenerateParenthesis(int n)
        {
            IList<string> allStrings = new List<string>();
            dfs(0, 0, "", n, allStrings);

            return allStrings;
        }

        void dfs(int l, int r, string brackets, int n, IList<string> allStrings)
        {
            if (brackets.Length == n * 2)
            {
                allStrings.Add(brackets);
                return;
            }

            if (l < n)
            {
                dfs(l + 1, r, brackets + "(", n, allStrings);
            }

            if (r < l)
            {
                dfs(l, r + 1, brackets + ")", n, allStrings);
            }
        }
    }
}