using System;
using System.Collections.Generic;
using System.Linq;

namespace Algorithms.Implementations
{
    public static class HRClimbingLeaderBoard
    {
        /// <summary>
        /// <b>Joshua</b> is an arcade game player who wants to climb to the top of a leaderboard and track ranking. <br/>
        /// The game uses <b><i>Dense Ranking</i></b>, so its leaderboard works like this:
        /// <list type="bullet">
        ///     <item>The player with the highest score is ranked number 1 on the leaderboard.</item>
        ///     <item>Players who have equal scores receive the same ranking number, and the next player(s) receive the immediately following ranking number.</item>
        /// </list>
		/// <br/>
        /// <example>
        /// <u>Example</u>:
        /// <code>
        /// ranked = [100, 90, 90, 80]
        /// player = [70, 80, 105]
        /// </code>
        /// </example>
        /// 
        ///The ranked players will have ranks 1, 2, 2, and 3, respectively. <br/>
        ///If the player's scores are 70, 80 and 105, their rankings after each game are 4th, 3rd and 1st. Return <b>[4, 3, 1]</b>.
        /// </summary>
        /// <param name="ranked">the leaderboard scores</param>
        /// <param name="player">the player's scores</param>
        /// <returns><see cref="int"/>[m]: the player's rank after each new score</returns>
        public static List<int> ClimbLeaderboard(this Algorithm _, List<int> ranked, List<int> player)
        {
            var result = new List<int>();
            var defaultComparer = Comparer<int>.Default;
            var reverseComparer = Comparer<int>.Create((x, y) => -defaultComparer.Compare(x, y));
            var distinctOrderedScores = ranked.Distinct().OrderBy(i => i, reverseComparer).ToList();

            foreach (var p in player)
            {
                var pos = distinctOrderedScores.BinarySearch(p, reverseComparer);
                var actualPosition = (pos >= 0 ? pos : ~pos) + 1;
                if (pos < 0)
                {
                    distinctOrderedScores.Insert(actualPosition - 1, p);
                }
                result.Add(actualPosition);
            }
            return result;
        }
    }
}
