using System.Collections.Generic;
using System.Linq;

namespace MyConsole
{
    // https://leetcode.com/problems/partition-equal-subset-sum/submissions/849777622/
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
        // public bool CanPartition(int[] nums)
        // {
        //     if (nums.Length == 1) return false;
        //     var sumdp = nums.Sum();
        //     //cant be odd
        //     if (sumdp % 2 != 0) return false;
        //
        //     var midsum = sumdp / 2;
        //     var dp = new bool[midsum + 1];
        //     dp[0] = true;
        //
        //     for (int i = 0; i < nums.Length; i++)
        //     {
        //         for (int j = midsum; j >= 0; j--)
        //         {
        //             //    Console.WriteLine($"i,j {i},{j} nums {nums[i]} sum {j + nums[i]}");
        //             if (dp[j] && ((j + nums[i]) < midsum))
        //             {
        //                 dp[j + nums[i]] = true;
        //             }
        //         }
        //     }
        //
        //     return dp[midsum - 1];
        // }
    }
}