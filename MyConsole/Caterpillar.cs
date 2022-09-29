using System;

namespace MyConsole
{
    public static class Caterpillar
    {
        public static int Solution(int[] A)
        {
            int distCt = 0;
            int front = 0;
            int back = A.Length - 1;

            while (front <= back)
            {
                var currentFront = Math.Abs((long) A[front]);
                var currentBack = Math.Abs((long) A[back]);
                //check for consecutive and move up left  index
                if (front > 0 && currentFront == Math.Abs((long) A[front - 1]))
                {
                    front++;
                    continue;
                }

                //check consecutive at tail end
                if (back < A.Length - 1 && currentBack == Math.Abs((long) A[back + 1]))
                {
                    back--;
                    continue;
                }

                if (currentBack == currentFront)
                {
                    front++;
                    back--;
                }
                else if (currentFront > currentBack)
                {
                    front++;
                }
                else
                {
                    back--;
                }

                distCt++;
            }

            return distCt;
        }
        
       
        
    }
}