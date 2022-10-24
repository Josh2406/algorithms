using System;
using System.Linq;

namespace Algorithms.Implementations.AlgoExpert.Easy
{
    public static class SqauresOfSortedArray
    {
        /// <summary>
        /// Given an integer array nums sorted in non-decreasing order, return an array of the squares of each number 
        /// sorted in non-decreasing order. <br/><br/>
        /// <b>Example</b>: <br/>
        /// <code>
        /// Input: nums = [-4,-1,0,3,10]
        /// Output: [0,1,9,16,100]
        /// </code>
        /// Explanation: After squaring, the array becomes[16, 1, 0, 9, 100].<br></br>
        /// After sorting, it becomes[0, 1, 9, 16, 100].
        /// </summary>
        /// <param name="_"></param>
        /// <param name="nums"></param>
        /// <returns></returns>
        public static int[] SortedSquares(this Algorithm _, int[] nums)
        {
            var length = nums.Length;
            var result = Enumerable.Repeat(0, length).ToArray();
            int smallestElementIdx = 0;
            int largestElementIdx = length - 1;

            for(int i = length - 1; i >= 0; i--)
            {
                var smallestElement = nums[smallestElementIdx];
                var largestElement = nums[largestElementIdx];

                if(Math.Abs(smallestElement) >= Math.Abs(largestElement))
                {
                    result[i] = smallestElement * smallestElement;
                    smallestElementIdx++;
                }
                else
                {
                    result[i] = largestElement * largestElement;
                    largestElementIdx--;
                }
            }

            return result;
        }
    }
}
