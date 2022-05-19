using System;
using System.Collections;
using System.Collections.Generic;

namespace Algorithms.Implementations.SN1
{
    /// <summary>
    /// Prime Number Generator
    /// </summary>
    public class PrimeNumberGenerator : IEnumerable<long>
    {
        private readonly long _start;
        private readonly long _end;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="start">Inclusive lower boundary of prime number sequence</param>
        /// <param name="end">Inclusive upper boundary of prime number sequence</param>
        /// <exception cref="ArgumentException"></exception>
        public PrimeNumberGenerator(long start, long end)
        {
            if(start < 0 && end < 2)
            {
                throw new ArgumentOutOfRangeException("\"start\" > 0 and \"end\" >= 2");
            }
            if(start > end)
            {
                throw new ArgumentException("Parameter \"start\" cannot be greater than parameter \"end\"");
            }
            _start = start;
            _end = end;
        }

        public IEnumerator<long> GetEnumerator()
        {
            if (_start <= 2 && _end >= 2)
            {
                yield return 2;
            }

            for(long i = _start; i <= _end; i += 1)
            {
                if (IsPrime(i)) yield return i;
            }
        }

        private bool IsPrime(long value)
        {
            if(value > 2 && value % 2 == 0)
            {
                return false;
            }

            long sqrt = (long)Math.Sqrt(value);
            for (long i = 3; i <= sqrt; i += 2)
                if (value % i == 0) return false;

            return true;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
