using System;
using System.Collections;
using System.Collections.Generic;

namespace Algorithms.Implementations
{
    public class PerfectSquares : IEnumerable<long>
    {
        private readonly long _start;
        private readonly long _end;

        public PerfectSquares(): this(0, 1000) { }

        public PerfectSquares(long end): this(0, end) { }

        public PerfectSquares(long start, long end)
        {
            if((start < 0 && end < 0) || start < 0 || end < 0) 
            {
                throw new ArgumentException("Valid range is 0 to positive infinity");
            }
            else if(start >= end)
            {
                throw new ArgumentException("Upper limit must be higher than lower limit");
            }

            _start = start;
            _end = end;
        }

        public IEnumerator<long> GetEnumerator()
        {
            for(var i = _start; i <= _end; i++)
            {
                if(IsSquare(i)) yield return i;
            }
        }

        private bool IsSquare(long num)
        {
            var sqrt = Math.Sqrt(num);
            var floor = (double) Math.Floor(sqrt);

            return sqrt == floor;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
