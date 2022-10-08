using System;
using System.ComponentModel.Design;

namespace MyConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            // Console.WriteLine(solution(new int[]{-5, -3, -1, 0, 3, 6}));
            // Console.WriteLine(Caterpillar.Solution(new int[]{-5, -5, -1, 0, 3, 6}));
            // Console.WriteLine(Caterpillar.Solution(new int[]{ Int32.MinValue,1}));
            // Console.WriteLine(reversingWithSpecial());
            GraphPathExists g = new GraphPathExists();
            var n = 3;
            int [ , ] edges = { {0, 1}, {1, 2}, {2, 0} };
            var source = 0;
            var destination = 2;
            Console.WriteLine(g.ValidPath(n,edges,source,destination));
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