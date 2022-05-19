using System.Collections.Generic;

namespace Algorithms.Implementations
{
    public static class HRAppleAndOrange
    {

        public static List<int> CountApplesAndOranges( Algorithm _, int s, int t, int a, int b, int[] apples, int[] oranges)
        {
            var appleCount = 0;
            var orangeCount = 0;

            for (var i = 0; i < apples.Length; i++)
            {
                var aPoint = a + apples[i];
                if (aPoint >= s && aPoint <= t)
                {
                    appleCount++;
                }
            }

            for (var i = 0; i < oranges.Length; i++)
            {
                var oPoint = b + oranges[i];
                if (oPoint >= s && oPoint <= t)
                {
                    orangeCount++;
                }
            }

            return new List<int> { appleCount, orangeCount };
        }
    }
}
