using System;
namespace MyConsole
{
    // https://leetcode.com/problems/median-of-two-sorted-arrays/submissions/888215637/
    public class FindMedianSortedArraysSolution
    {
        public double FindMedianSortedArrays(int[] nums1, int[] nums2)
        {
            int l1 = nums1.Length;
            int l2 = nums2.Length;
            //combining 2 arrays
            // length of both arrays so as to create new array
            //sort function
            // from the array get the median by taking l1+l2/2 as the index which will give us median value
            // if even index is the half value and the value before it
            // if odd round off and subtract 1

            var newArr = new int[l1 + l2];
            int index = 0;
            for (int i = 0; i < l1; i++)
            {
                newArr[index++] = nums1[i];
            }

            for (int j = 0; j < l2; j++)
            {
                newArr[index++] = nums2[j];
            }

            Array.Sort(newArr);

            if (l1 + l2 == 1)
            {
                return newArr[0];
            }

            if ((l1 + l2) % 2 == 0)
            {
                int lastmedIndex = (l1 + l2) / 2;
                int firstmedIndex = lastmedIndex - 1;
                double median = ((double)newArr[firstmedIndex] + newArr[lastmedIndex]) / 2;
                return median;
            }
            else
            {
                return newArr[(l1 + l2) / 2];
            }
        }
    }
}
