using System.Collections.Generic;

namespace Algorithms.Implementations.AlgoExpert.Easy
{
    
    public static class TwoNumberSum
    {
        /// <summary>
        /// Given an array of integers <b><i>nums</i></b> and an integer <b><i>target</i></b>, return indices of the two numbers such 
        /// that they add up to <b><i>target</i></b>.<br/>
        /// You may assume that each input would have exactly one solution, and you may not use the same element twice.<br/>
        /// You can return the answer in any order.<br/><br/>
        /// <b>Example</b>: <br/>
        /// <code>
        /// Input: nums = [2,7,11,15], target = 9
        /// Output: [0,1]
        /// </code>
        /// Explanation: Because nums[0] + nums[1] == 9, we return [0, 1].
        /// </summary>
        /// <param name="_"></param>
        /// <param name="nums">Array of integers</param>
        /// <param name="target">Target</param>
        /// <returns></returns>
        public static int[] TwoSum(this Algorithm _, int[] nums, int target)
        {
            int[] result = new int[2];
            var dico = new Dictionary<int, int>();

            for(int i = 0; i < nums.Length; i++)
            {
                int sumMinusElement = target - nums[i];
                if (dico.TryGetValue(sumMinusElement, out int index2))
                {
                    result = new int[] {i, index2};
                    break;
                }
                else
                {
                    dico[nums[i]] = i;
                }
            }

            return result;
        }
    }
}
