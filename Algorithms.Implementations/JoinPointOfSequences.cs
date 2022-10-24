using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms.Implementations
{
    public static class JoinPointOfSequences
    {
        public static int FindJoinPoint(this Algorithm _, int s1, int s2)
        {
            while(s1 != s2)
            {
                if(s1 < s2)
                {
                    if(s1 == 0)
                        return -1;

                    s1 += SumOfDigits(s1);
                }
                else if(s2 < s1)
                {
                    if (s2 == 0)
                        return -2;

                    s2 += SumOfDigits(s2);
                }
            }

            return s1;
        }

        private static int SumOfDigits(int n)
        {
            int sum = 0;
            while (n != 0)
            {
                sum += n % 10;
                n /= 10;
            }
            return sum;
        }
    }
}
