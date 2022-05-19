using System;

namespace Algorithms.Implementations
{
    public static class HRCountSolutions
    {
        public static int CountSolutions(this Algorithm _, int a, int b, int c, int d)
		{
			int res = 0;
			for (int x = 1; x <= c; x++)
			{
				var l = x * (x - a);
				var det2 = b * b - 4 * l;
				if (det2 == 0 && b % 2 == 0 && b / 2 >= 1 && b / 2 <= d)
				{
					res++;
					continue;
				}

				if (det2 > 0)
				{
					var det = Math.Ceiling((double)det2 / 2);
					if (det * det == det2 && (b + det) % 2 == 0)
					{
						if ((b + det) / 2 >= 1 && (b + det) / 2 <= d)
						{
							res++;
						}
						if ((b - det) / 2 >= 1 && (b - det) / 2 <= d)
						{
							res++;
						}
					}
				}
			}
			return res;
		}
	}
}
