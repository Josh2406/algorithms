using System;

namespace Algorithms.Implementations
{
    public static class HRBeautifulDays
    {
        /// <summary>
        /// <b>Lily</b> likes to play games with integers. <br/>
        /// She has created a new game where she determines the difference between a number and its reverse.<br/><br/>
        /// For instance, given the number <b>12</b>, its reverse is <b>21</b>. Their difference is <b>9</b>.<br/>
        /// The number <b>120</b> reversed is <b>21</b>, and their difference is <b>99</b>.<br/><br/>
        /// 
        /// She decides to apply her game to decision making.<br/>
        /// She will look at a numbered range of days and will only go to a <b>movie</b> on a beautiful day.<br/><br/>
        /// 
        /// Given a range of numbered days, <b><i>[i...j]</i></b> and a number <b>k</b>, determine the number of days in the range that are beautiful.<br/>
        /// Beautiful numbers are defined as numbers where <b><i>|i - reverse(i)|</i></b> is evenly divisible by <b>k</b>. <br/>
        /// If a day's value is a beautiful number, it is a beautiful day. Return the number of beautiful days in the range.
        /// </summary>
        /// <param name="i">starting day number</param>
        /// <param name="j">ending day number</param>
        /// <param name="k">divisor</param>
        /// <returns><see cref="int"/>: Number of Beautiful Days</returns>
        public static int BeautifulDays(this Algorithm _, int i, int j, int k)
        {
            int result = 0;
            for(int a = i; a <= j; a++)
            {
                int num = a;
                int reverse = 0;

                while(num > 0)
                {
                    reverse = reverse * 10 + num % 10;
                    num /= 10;
                }

                int diff = Math.Abs(reverse - a);
                if(diff % k == 0)
                    result++;
            }

            return result;
        }
    }
}
