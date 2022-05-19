using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms.Implementations
{
    public static class HRFormingMagicSquare
    {
        /// <summary>
        /// We define a magic square to be an <b></b><i>n * n</i> matrix of distinct positive integers from <b>1</b> to <b>n^2</b> 
        /// where the sum of any row, column, or diagonal of length  is always equal to the same number: <b>the magic constant</b>.<br/><br/>
        /// 
        /// You will be given a <b>3 X 3</b> matrix s of integers in the inclusive range <b>[1, 9]</b>. 
        /// We can convert any digit <b>a</b> to any other digit <b>b</b> in the range <b>[1, 9]</b> at cost of <b>|a - b|</b>.
        /// <br/><br/>
        /// Given <b>s</b>, convert it into a magic square at <b><i>minimal cost</i></b>. Print this cost on a new line.<br/>
        /// <b>Note</b>: The resulting magic square must contain distinct integers in the inclusive range.<br/>
        /// <b><u>Example</u></b><br/>
        /// <code>$s = [[5, 3, 4], [1, 5, 8], [6, 4, 2]]</code>
        /// The matrix looks like this:
        /// <code>
        /// 5 3 4
        /// 1 5 8
        /// 6 4 2
        /// </code>
        /// We can convert it to the following magic square:
        /// <code>
        /// 8 3 4
        /// 1 5 9
        /// 6 7 2
        /// </code>
        /// This took three replacements at a cost of <b><i>|5 - 8| + |8 - 9| + |4 - 7| = 7</i></b>
        /// </summary>
        /// <param name="_"></param>
        /// <param name="square"></param>
        /// <returns><see cref="int"/>: Cost of Converting a Matrix to a Perfect Square</returns>
        public static int CalculateCostToMakeMagicSquare(this Algorithm _, List<List<int>> square)
        {
            int min_cost = -1;

            var possibleSquares = PossibleMagicSquares();
            foreach(var p in possibleSquares)
            {
                var cost = 0;
                for(var i = 0; i < 3; i++)
                {
                    for(var j = 0; j < 3; j++)
                    {
                        cost += Math.Abs(square[i][j] - p[i][j]);
                    }
                }

                if(min_cost == -1 || cost < min_cost)
                {
                    min_cost = cost;
                }
            }

            return min_cost;
        }

        private static List<List<List<int>>> PossibleMagicSquares()
        {
            return new List<List<List<int>>>
            {
                new List<List<int>>
                {
                    new List<int>{8, 1, 6},
                    new List<int>{3, 5, 7},
                    new List<int>{4, 9, 2}
                },
                new List<List<int>>
                {
                    new List<int>{6, 1, 8},
                    new List<int>{7, 5, 3},
                    new List<int>{2, 9, 4}
                },
                new List<List<int>>
                {
                    new List<int>{4, 9, 2},
                    new List<int>{3, 5, 7},
                    new List<int>{8, 1, 6}
                },
                new List<List<int>>
                {
                    new List<int>{2, 9, 4},
                    new List<int>{7, 5, 3},
                    new List<int>{6, 1, 8}
                },
                new List<List<int>>
                {
                    new List<int>{8, 3, 4},
                    new List<int>{1, 5, 9},
                    new List<int>{6, 7, 2}
                },
                new List<List<int>>
                {
                    new List<int>{4, 3, 8},
                    new List<int>{9, 5, 1},
                    new List<int>{2, 7, 6}
                },
                new List<List<int>>
                {
                    new List<int>{2, 7, 6},
                    new List<int>{9, 5, 1},
                    new List<int>{4, 3, 8}
                },
                new List<List<int>>
                {
                    new List<int>{6, 7, 2},
                    new List<int>{1, 5, 9},
                    new List<int>{8, 3, 4}
                }
            };
        }
    }
}
