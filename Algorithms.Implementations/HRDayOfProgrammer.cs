using System;

namespace Algorithms.Implementations
{
    public static class HRDayOfProgrammer
    {
        public static string DayOfProgrammer(Algorithm _, int year)
        {
            var daysToAdd = 255;

            if (year == 1918)
            {
                daysToAdd += 13;
            }
            else if (year < 1918)
            {
                if (year % 4 == 0 && year % 100 == 0)
                {
                    daysToAdd -= 1;
                }
            }

            var jan1 = new DateTime(year, 1, 1);
            var date = jan1.AddDays(daysToAdd);

            return date.ToString("dd.MM.yyyy");
        }
    }
}
