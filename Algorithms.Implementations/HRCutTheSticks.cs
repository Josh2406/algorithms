using System.Collections.Generic;
using System.Linq;

namespace Algorithms.Implementations
{
    public static class HRCutTheSticks
    {
        /// <summary>
        /// You are given a number of sticks of varying lengths. You will iteratively cut the sticks into smaller sticks, 
        /// discarding the shortest pieces until there are none left. At each iteration you will determine the length of the 
        /// shortest stick remaining, cut that length from each of the longer sticks and then discard all the pieces of that 
        /// shortest length. When all the remaining sticks are the same length, they cannot be shortened so discard them.
        /// <br/><br/>
        /// Given the lengths of <b><i>n</i></b> sticks, print the number of sticks that are left before each iteration until 
        /// there are none left. <br/><br/>
        /// <b><u>Example</u></b><br/>
        /// <c>arr = [1, 2, 3]</c>
        /// The shortest stick length is <b>1</b>, so cut that length from the longer two and discard the pieces of 
        /// length <b>1</b>. Now the lengths are <b>arr = [1, 2]</b>. Again, the shortest stick is of length <b>1</b>, 
        /// so cut that amount from the longer stick and discard those pieces. There is only one stick left, <b>arr = [1]</b>, 
        /// so discard that stick. The number of sticks at each iteration are <b>answer = [3, 2, 1]</b>. <br/><br/>
        /// <b><u>Function Description</u></b><br/>
        /// Complete the cutTheSticks function in the editor below. It should return an array of integers representing 
        /// the number of sticks before each cut operation is performed.<br/>
        /// <b><i>CutTheSticks</i></b> has the following parameter(s) :<br/>
        /// <list type="bullet">
        /// <item><b>int arr[n]</b>: the lengths of each stick</item>
        /// </list>
        /// </summary>
        /// <param name="_"></param>
        /// <param name="arr">List of sticks</param>
        /// <returns>List<int>: The number of sticks after each iteration</int></returns>
        public static List<int> CutTheSticks(Algorithm _, List<int> arr)
        {
            var len = arr.Count;
            var result = new List<int> { len };
            var sticksLeft = arr.OrderBy(a => a).ToList();

            for (; ; )
            {
                if (sticksLeft.All(a => a == sticksLeft[0]))
                {
                    break;
                }

                var shortestStick = sticksLeft[0];
                sticksLeft.RemoveAll(a => a == shortestStick);
                result.Add(sticksLeft.Count);
                sticksLeft = sticksLeft.Select(a => a - shortestStick).ToList();
            }

            return result;
        }
    }
}
