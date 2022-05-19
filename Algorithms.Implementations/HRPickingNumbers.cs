using System.Collections.Generic;
using System.Linq;

namespace Algorithms.Implementations
{
    public static class HRPickingNumbers
    {
        public static int PickingNumbers(Algorithm _ ,List<int> a)
        {
            var longest = 0;
            var dist = a.Distinct().ToList();

            for (var i = 0; i < dist.Count; i++)
            {
                var val = dist[i];
                var subArray1 = a.Where(x => (x == val) || (x - 1) == val).ToList();
                var subArray2 = a.Where(x => (x == val) || (x + 1) == val).ToList();
                var count = subArray1.Count > subArray2.Count ?
                subArray1.Count : subArray2.Count;
                if (count > longest)
                {
                    longest = count;
                }
            }

            return longest;
        }
    }
}
