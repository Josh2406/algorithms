namespace Algorithms.Implementations
{
    public static class HRNumberLineJumps
    {
        public static string Kangaroo(Algorithm _, int x1, int v1, int x2, int v2)
        {
            string result;
            if (x1 <= x2 && v1 < v2)
            {
                result = "NO";
            }
            else if (x1 >= x2 && v1 > v2)
            {
                result = "NO";
            }
            else
            {
                var jump = 1;
                while (true)
                {
                    var k1Location = x1 + v1 * jump;
                    var k2Location = x2 + v2 * jump;

                    if (k1Location == k2Location)
                    {
                        result = "YES";
                        break;
                    }
                    if (v1 >= v2 && k1Location > k2Location)
                    {
                        result = "NO";
                        break;
                    }

                    if (v1 <= v2 && k1Location < k2Location)
                    {
                        result = "NO";
                        break;
                    }

                    jump++;
                }
            }

            return result;
        }
    }
}
