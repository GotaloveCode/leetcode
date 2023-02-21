using System.Collections.Generic;

namespace MyConsole
{
    public class LongestSubStringSolution
    {
        // https://leetcode.com/problems/longest-substring-without-repeating-characters/submissions/894190274/
        public int LengthOfLongestSubstring(string s) {
            int lSubstr = 0;
            var set = new HashSet<char>();
       
            for(int i = 0; i <  s.Length; i++){
                set.Clear();
                set.Add(s[i]);
                // Console.WriteLine("s[i]" + s[i]);
                for(int j = i + 1; j <  s.Length; j++){
                    if(set.Contains(s[j])){
                        if(set.Count > lSubstr){
                            lSubstr = set.Count;
                            set.Clear();
                        }

                        // if(s[j] == s[j-1]){
                        //     i = i + 1;
                        // }
                        break;
                    }else{
                        set.Add(s[j]);
                        // Console.WriteLine("s[j]" + s[j]);
                        if(set.Count > lSubstr){
                            lSubstr = set.Count;
                        }
                    }
                } 
                //  Console.WriteLine("_________________");
            }
            if(set.Count > lSubstr){
                lSubstr = set.Count;
            }

            return lSubstr;
        }
        
        //     public int LengthOfLongestSubstring(string s)
// {
//     int n = s.Length;
//     int ans = 0;
//     Dictionary<char, int> map = new Dictionary<char, int>();
//     for (int j = 0, i = 0; j < n; j++)
//     {
//         if (map.ContainsKey(s[j]))
//         {
//             i = Math.Max(map[s[j]], i);
//         }
//         ans = Math.Max(ans, j - i + 1);
//         map[s[j]] = j + 1;
//     }
//     return ans;
// }
// This solution uses a sliding window approach and a dictionary to keep track of the last index of each character in the current substring. The variable i keeps track of the start index of the current substring, and j is the end index. The ans variable stores the length of the longest substring without repeating characters seen so far.
    }
}