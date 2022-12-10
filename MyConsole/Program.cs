using System;

namespace MyConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var p = new SkillTree();
            var q = p.Solution2(new int[] {0, 0, 0, 0, 2, 3, 3}, new int[] {2, 5, 6});
            Console.WriteLine($"{q}");
            // Console.WriteLine(solution(new int[]{-5, -3, -1, 0, 3, 6}));
            // Console.WriteLine(Caterpillar.Solution(new int[]{-5, -5, -1, 0, 3, 6}));
            // Console.WriteLine(Caterpillar.Solution(new int[]{ Int32.MinValue,1}));
            // Console.WriteLine(reversingWithSpecial());
            // runGraphPathExists();
            // Graph.DfsRun();
            // var s = new LongestPalindromicString();
            // var p = s.LongestPalindrome("babad");
            // var q = s.LongestPalindrome("cbbd");
            // Console.WriteLine("string: babad");
            // Console.WriteLine($"substring: {p}");   
            // Console.WriteLine("string: cbbd");
            // Console.WriteLine($"substring: {q}");

            // var ws = new WordSearch();
            // ws.Execute();
        }

        static void runGraphPathExists()
        {
            var edges = new int[3][] {new[] {0, 1}, new[] {1, 2}, new[] {2, 0}};
            GraphPathExists g = new GraphPathExists();
            bool isValid = g.ValidPath(3, edges, 0, 2);
            if (isValid)
            {
                Console.WriteLine("GraphPathExists has a ValidPath for source 0 and destination 2");
            }
        }

        public static string reversingWithSpecial()
        {
            // Custom input string
            String str = "Ab,c,de!$";
            // output = "ed,c,bA!$"
            char[] ch = str.ToCharArray();
            char[] newch = new char[str.Length];
            int front = 0;
            int index = 0;
            String newstr = "";
            for (int i = str.Length - 1; i >= 0; i--)
            {
                front = str.Length - 1 - i;
                Console.WriteLine(front + " " + newch[front]);
                // newch[front] = ch[i];
                // //back is letter
                if (ch[i] >= 'A' && ch[i] <= 'z')
                {
                    // Console.WriteLine("char at " + i + " is "+ ch[i]);
                    // letter
                    if (ch[front] >= 'A' && ch[front] <= 'z')
                    {
                        newch[front] = ch[i];
                        newch[i] = ch[front];
                    }
                    else // special char
                    {
                        newch[front] = ch[front];
                    }
                }
                else
                {
                    newch[i] = ch[i];
                }
            }

            return new string(newch);
        }
    }
}