using System;
using System.Collections.Generic;

namespace MyConsole
{
    // https://app.codility.com/public-link/Microsoft-Kenya-SSWE-III-In-Class---Trees-2/   
    public class LongestPathTree
    {
        int maxDepth = 1;
        
        public int Solution(Tree T) {
            // write your code in C# 6.0 with .NET 4.7 (Mono 6.12)
            var mySet = new HashSet<int>();
            return Dfs(T,1,mySet);
        }

        int Dfs(Tree T,int depth, HashSet<int> mySet)
        {
            if(mySet.Contains(T.x)){
                return maxDepth;
            }
            mySet.Add(T.x);
            maxDepth = depth;
            if(T.l != null){
                maxDepth = Math.Max(Dfs(T.l,depth++,mySet),maxDepth);
            }
            if(T.r != null){
                maxDepth = Math.Max(Dfs(T.r,depth++,mySet),maxDepth);
            }
            mySet.Remove(T.x);
            return depth;
        }
    }

    public class Tree
    {
        public Tree r;
        public int x { get; set; }
        public Tree l { get; set; }
    }
}