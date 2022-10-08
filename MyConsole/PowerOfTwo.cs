namespace MyConsole
{
    
    // https://leetcode.com/problems/powx-n/
    public class PowerOfTwo
    {
        public bool IsPowerOfTwo(int n) {
            if(n == 1) return true;
            if(n % 2 != 0 || n == 0) return false;
            return IsPowerOfTwo(n/2);
        }
    }
}
public class Solution {
    public double result = 1;
    public double MyPow(double x, int n) {
        if(n == 0) return result;
        // if(n != 0)
        // {
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
        // } 
        return result; 
    }
}