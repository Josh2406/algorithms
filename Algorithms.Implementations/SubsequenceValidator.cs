using System.Collections.Generic;

namespace Algorithms.Implementations
{
    public static class SubsequenceValidator
    {
        /// <summary>
        /// <u><b>Problem</b></u><br/>
        /// Given two non-empty arrays of integers, write a function that determines whether the second array is a 
        /// subsequence of the first one. <br/>
        /// A subsequence of an array is a set of numbers that aren’t necessarily adjacent in the array but that are in the 
        /// same order as they appear in the array. <br/><br/>
        /// For instance, the numbers <b>[1, 3, 4]</b> form a subsequence of the array <b>[1, 2, 3, 4]</b>, 
        /// and so do the numbers <b>[2, 4]</b>. Note that a single number in an array and the array itself are both valid subsequences 
        /// of the array. (<b>[1], [2], [3], [4]</b> and <b>[1, 2, 3, 4]</b> are all valid subsequences of <b>[1, 2, 3, 4]</b>) <br/><br/>
        /// <u><b>Sample Output</b></u> <br/>
        /// <code>
        /// array = [5,1,22,25,6,-1,8,10]
        /// subsequence = [1,6,-1,10]
        /// </code>
        /// <u><b>Answer</b></u>: True
        /// </summary>
        /// <param name="_"></param>
        /// <param name="array">Parent array</param>
        /// <param name="subsequence">Possible subsequence of parent</param>
        /// <returns><see cref="bool"/>: True or False</returns>
        public static bool ValidateSubsequence(this Algorithm _, List<int> array, List<int> subsequence)
        {
            var result = false;
            int counter = 0;
            for(int i = 0; i < array.Count; i++)
            {
                int curNum = array[i];
                if(subsequence[counter] == curNum)
                {
                    counter++;
                }

                if(counter == subsequence.Count)
                {
                    result = true;
                    break;
                }
            }

            return result;
        }
    }
}
