using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms.Implementations
{
    public static class Ranking
    {
        public static IList<RankedResult> FilterByCountryWithRank(
            IList<Person> people,
            IList<CountryRanking> rankingData,
            IList<string> countryFilter,
            int minRank, int maxRank,
            int maxCount)
        {
            //Filter rankingData by countryFilter
            rankingData = rankingData.Where(x => countryFilter.Contains(x.Country, StringComparer.OrdinalIgnoreCase)).ToList();

            //Get people full details from filtered rankingData
            var filteredPeopleDetails = (from rank in rankingData
                                         join person in people
                                            on rank.PersonId equals person.Id
                                         select new { person.Id, person.Name, rank.Rank, rank.Country })
                                         .ToList();

            //Group people details by rank
            var groupedPeopleDetails = filteredPeopleDetails.GroupBy(x => x.Rank)
                .Select(grp => grp.ToList())
                .ToList();

            people = new List<Person>();
            int count = 0;
            var upperCaseCountryFilter = countryFilter.Select(x => x.ToUpper()).ToList();
            foreach (var group in groupedPeopleDetails)
            {
                //Order rankGroup first by countryFilter sequence, then by name
                var filteredGroup = group.OrderBy(x => upperCaseCountryFilter.IndexOf(x.Country.ToUpper()))
                    .ThenBy(x => x.Name, StringComparer.OrdinalIgnoreCase).ToList();

                if (count < maxCount)
                {
                    foreach (var personDetail in filteredGroup)
                    {
                        var person = new Person(personDetail.Id, personDetail.Name);
                        count++;
                    }
                }
                else
                {
                    break;
                }
            }

            return people
                .Select(p => new RankedResult(p.Id, rankingData.First(r => r.PersonId == p.Id).Rank))
                .ToList();
        }
    }
}
