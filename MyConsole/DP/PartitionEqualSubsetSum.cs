using System.Collections.Generic;
using System.Linq;

namespace MyConsole
{
    // https://leetcode.com/problems/partition-equal-subset-sum/submissions/849777622/
    // https://leetcode.com/problems/partition-equal-subset-sum/submissions/857541648/
    // https://www.youtube.com/watch?v=IsvocB5BJhw&ab_channel=NeetCode
    public class PartitionEqualSubsetSum
    {
        public bool CanPartition(int[] nums) {
            if(nums.Length == 1) return false;
            var sumdp = nums.Sum();
            //cant be odd
            if(sumdp % 2 != 0) return false;

            var set = new HashSet<int>();
            set.Add(0);
            var target = sumdp /2;

            for(var i = 0; i < nums.Length; i++){
                var nextSet = new HashSet<int>();
                foreach (var n in set)
                {
                    if(target == n) return true;
                    if(target == (nums[i] + n)) return true;
                    nextSet.Add(nums[i] + n);
                    nextSet.Add(n);
                }
                set = nextSet;
            }
       
            return set.Contains(target); 
        }
        
        // https://leetcode.com/problems/partition-equal-subset-sum/submissions/857541648/
        //DP Solution
        public bool CanPartition2(int[] nums)
        {
            int n = nums.Length;
            if (n == 1) return false;
            var sumdp = nums.Sum();
            //cant be odd
            if (sumdp % 2 != 0) return false;
        
            var midsum = sumdp / 2;
            var dp = new bool[midsum + 1][];
            for (var i = 0; i < midsum + 1; i++)
            {
                dp[i] = new bool[n + 1];
            }

            for (int i = 0; i <= n; i++) // with no item, we could get "0" 
                dp[0][i] = true;

            for (int i = 1; i <= midsum; i++) // w/o item, we could not get "i"
                dp[i][0] = false;
            
    
            for (int i = 0; i <= midsum; i++)
            {
                for (int j = 1; j <= n; j++)
                {
                    if (i >= nums[j - 1])
                        dp[i][j] = dp[i][j - 1] || dp[i - nums[j - 1]][j - 1]; // with or w/o item j - 1
                    else
                        dp[i][j] = dp[i][j - 1];
                }
            }
    
            return dp[midsum][n];
        }
    }
}