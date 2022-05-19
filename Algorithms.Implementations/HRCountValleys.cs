namespace Algorithms.Implementations
{
    public static class HRCountValleys
	{
		/// <summary>
		/// <b>Joshua Ajibade</b> is a volunteered hill walker. <br/>
		/// He takes <b><i>s</i></b> number of steps up and down mountains. <br/>
		/// The number os steps corresponds with path, <b><i>p</i></b>, having letters <b>U</b> and <b>D</b>, 
		/// indicating up and down steps respectively. <br/><br/>
		/// 
		/// Count the number of valleys encountered by <b>Joshua Ajibade</b> <br/><br/>
		/// 
		/// <example>
		/// <u>Example</u>:
		/// <code>
		/// s = 14
		/// p = "UDDDDUUUDDDUUU"
		/// </code>
		/// </example>
		/// 
		/// The example above can be represented diagrammatically as: <br/><br/>
		/// <br/>
		///	<code>
		///	____
		///	|  |  ____
		///	...|..|  |..|
		///	...|..|  |..|
		///	...|..|  |..|
		///	</code>
		///	From the above diagram, it is clear <b>Joshua</b> passed across 2 valleys.
		/// </summary>
		/// <param name="s">number of steps</param>
		/// <param name="p">path walked</param>
		/// <returns><see cref="int"/>: Number of Valleys</returns>
		public static int CountValleys(this Algorithm _, int s, string p)
		{
			int level = 0;
			int valleys = 0;

			for (int i = 0; i < s; i++)
			{
				if (p[i] == 'U')
				{
					level++;
					if (level == 0) { valleys++; }
				}
				else
				{
					level--;
				}
			}

			return valleys;
		}
	}
}
