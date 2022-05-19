using System.Collections.Generic;
using System.Text;

namespace Algorithms.Implementations
{
    public static class StringManipulations
    {
        /// <summary>
        /// Reverse the arrangement of characters in a string
        /// </summary>
        /// <param name="original">Original string</param>
        /// <returns>Reversed <see cref="string"/></returns>
        public static string Reversed(this string original)
        {
            var chars = new char[original.Length];
            for(int i = 0, j = original.Length - 1; i <= j; i++, --j)
            {
                chars[i] = original[j];
                chars[j] = original[i];
            }
            return new string(chars);
        }

        public static string RemoveDuplicateWithoutLinq(this string original)
        {
            var dico = new Dictionary<char, char>();
            foreach(char c in original)
            {
                if (!dico.ContainsKey(c))
                {
                    dico.Add(c, c);
                }
            }

            var sb = new StringBuilder();
            foreach(char c in dico.Values)
            {
                sb.Append(c);
            }

            return sb.ToString();
        }
    }
}
