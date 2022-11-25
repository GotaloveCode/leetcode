using System;

namespace MyConsole
{
    public class DynamicRobber
    {
        public int Rob(int[] nums)
        {
            int N = nums.Length;
            if (N == 0)
                return 0;
            if (N == 1)
                return nums[0];
            if (N == 2)
                return Math.Max(nums[0], nums[1]);
            int[] dp = new int[N];
            dp[0] = nums[0];
            dp[1] = nums[1];
            dp[2] = dp[0] + nums[2];
            for (int i = 3; i < N; i++)
            { //either jump 1 house or 2
                dp[i] = Math.Max(dp[i - 2], dp[i - 3]) + nums[i];
            }
            //return the max of last or second last value
            return Math.Max(dp[N - 1], dp[N - 2]);
        }
    }
    
    // var rob = function(nums, i=0, memo={}) {
    //     if(i in memo) return memo[i];
    //     if(i>=nums.length)
    //         return memo[i] = 0;
    //     let robFirst = nums[i] + rob(nums, i+2, memo);
    //     let robSecond = rob(nums, i+1, memo);
    //     return  memo[i] = Math.max(robSecond, robFirst);
    //
    // };
    
    // int max=0;
    // public int rob(int[] nums) {
    //     /**
    //        1. base case
    //        2. recursive or boundaries
    //      */
    //     int dp[]= new int[nums.length];
    //     if(nums.length==0) return 0;//if there are no houses to steal from
    //     if(nums.length==1) return nums[0];//there is only one house to steal from
    //     if(nums.length==2) return Math.max(nums[0], nums[1]);
    //     //die had 6
    //     dp[0]=nums[0];
    //     dp[1]=Math.max(nums[0],nums[1]);
    //     for(int i=2;i<nums.length;i++){
    //         dp[i]=Math.max(dp[i-1], nums[i]+dp[i-2]);
    //     }
    //     return dp[nums.length-1];
    // }
}