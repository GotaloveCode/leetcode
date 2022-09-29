using System;
using System.ComponentModel.Design;

namespace MyConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            // Console.WriteLine(solution(new int[]{-5, -3, -1, 0, 3, 6}));
            Console.WriteLine(Caterpillar.Solution(new int[]{-5, -5, -1, 0, 3, 6}));
            Console.WriteLine(Caterpillar.Solution(new int[]{ Int32.MinValue,1}));
        }
        
        
    }
}