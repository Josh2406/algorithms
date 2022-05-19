namespace Algorithms.Implementations
{
    public static class HRDivisibleSumPairs
    {
        public static int DivisibleSumPairs(Algorithm _, int n, int k, int[] ar)
        {
            var result = 0;
            for (var i = 0; i < (n - 1); i++)
            {
                var iVal = ar[i];
                for (var j = i + 1; j < n; j++)
                {
                    var jVal = ar[j];
                    if ((iVal + jVal) % k == 0)
                    {
                        result++;
                    }
                }
            }
            return result;
        }
    }
}
