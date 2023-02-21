using System.Collections.Generic;

namespace MyConsole
{
    // A string s is called happy if it satisfies the following conditions:
    // s only contains the letters 'a', 'b', and 'c'.
    // s does not contain any of "aaa", "bbb", or "ccc" as a substring.
    // s contains at most a occurrences of the letter 'a'.
    // s contains at most b occurrences of the letter 'b'.
    // s contains at most c occurrences of the letter 'c'. 
    //
    // Given three integers a, b, and c, return the longest possible happy string. If there are multiple longest happy strings, return any of them. 
    // If there is no such string, return the empty string "".
    // A substring is a contiguous sequence of characters within a string.
    //
    // Example 1: 
    //
    // Input: a = 1, b = 1, c = 7 
    // Output: "ccaccbcc" 
    // Explanation: "ccbccacc" would also be a correct answer. 
    //
    //
    // Example 2:
    // Input: a = 7, b = 1, c = 0 
    // Output: "aabaa" 
    // Explanation: It is the only correct answer in this case. 
    //a =7 b=4 c=3
   aabbaabbaaccac
    

    public class HappyStringSolution
    {

        public string HappyString(int a, int b, int c)
        {
            var dict = new Dictionary<string, int>();
            dict.Add("a", a);
            dict.Add("b", b);
            dict.Add("c", c);
            string largest = "";
            if (a > b && a > c)
            {
                largest = "a";
            }
            if (b > a && b > c)
            {
                largest = "b";
            }
            
            if (c > a && c > b)
            {
                largest = "c";
            }

            var result = "";
            for (int i = 0; i < a + b + c; i++)
            {
                var largestCharCount = dict[largest];
                if(largestCharCount > 1)
                dict[largest] = dict[largest] - 1;
                result+=
            }
            
            
            return "";
        }

    }
}