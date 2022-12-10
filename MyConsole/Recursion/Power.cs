namespace MyConsole
{
    // Implement pow(x, n), which calculates x raised to the power n (i.e., xn).
    // Example 1:
    // Input: x = 2.00000, n = 10
    // Output: 1024.00000
    // Constraints:
    // -100.0 < x < 100.0
    // -231 <= n <= 231-1
    // n is an integer.
    // -104 <= x^n <= 104
    // https://leetcode.com/problems/powx-n/submissions/812229605/
    public class Power
    {
        public double result = 1;
        public double MyPow(double x, int n) {
            if(x == 1) return 1;
            if(x == -1 && n < 0) return 1;
            if(x == -1 && n > 0) return -1;
            if(n > int.MaxValue -1 || n <= int.MinValue) return 0;
            if(n == 0) return result;
    
            if (n > 0)
            {
                result *= x; //result = result * x
                MyPow(x,n-1);
            }
            else
            {
                result /= x; // result = result/x
                MyPow(x,n+1);
            }
            return result; 
        }
    }
}