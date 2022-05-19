using System.Collections.Generic;

namespace Algorithms.Implementations
{
    public static class HRDrawingBook
    {
        public static int PageCount(Algorithm _ ,int n, int p)
        {
            var flipDico = new Dictionary<int, int>();

            var pageFlips = 0;
            for (int i = 1; i <= (n + 1); i += 2)
            {
                if (i > 1)
                {
                    pageFlips++;
                    flipDico[i - 1] = pageFlips;
                    flipDico[i] = pageFlips;
                }
            }

            var result = 0;
            if (flipDico.ContainsKey(p))
            {
                var frontFlips = flipDico[p];
                var backFlips = pageFlips - frontFlips;
                result = frontFlips < backFlips ? frontFlips : backFlips;
            }

            return result;
        }
    }
}
