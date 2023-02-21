using System.Collections.Generic;

namespace MyConsole
{
    // https://leetcode.com/problems/find-n-unique-integers-sum-up-to-zero/submissions/886717413/
    // Given an integer n, return any array containing n unique integers such that they add up to 0.
    public class NUniqueIntSum
    {
        public int[] SumZero(int n) {
            var result = new List<int>();
            if(n % 2 != 0){
                result.Add(0);
            }
            for(int i = 1; i <= n/2; i++){
                result.Add(i);
                result.Add(-1 *i);
            }
       
            return result.ToArray();
        }
    }
}