using System.Collections.Generic;

namespace Algorithms.Implementations
{
    public static class HRGradingStudents
    {
        public static List<int> GradingStudents(Algorithm _, List<int> grades)
		{
			var result = new List<int>();
			var len = grades.Count;
			for (var i = 0; i < len; i++)
			{
				var grd = grades[i];
				if (grd < 40)
				{
					result.Add(grd);
				}
				else
				{
					var lBound = grd / 5 * 5;
					var uBound = lBound + 5;

					if ((uBound - grd) < 3)
					{
						result.Add(uBound);
					}
					else
					{
						result.Add(grd);
					}
				}
			}

			return result;
		}
	}
}
