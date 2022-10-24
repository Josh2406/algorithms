using System;
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
            //"John Seun"

            var chars = new char[original.Length];
            for(int i = 0, j = original.Length - 1; i <= j; i++, j--)
            {
                chars[i] = original[j];
                chars[j] = original[i];
            }

            return new string(chars);
        }

        public static string ReversedStatementWords(this string statement)
        {
            var delims = new char[] { ' ', ',', '.', ';', '(', ')', ':', '?' , '\\', '/' };
            var words = statement.Split(delims, StringSplitOptions.RemoveEmptyEntries);
            for(int i = 0, j = words.Length - 1; i <= j; ++i, j--)
            {
                var word = words[i];
                words[i] = words[j];
                words[j] = word;
            }

            return string.Join(" ", words);
        }

        public static string EachWordInAStatementReversed(this string statement)
        {
            var delims = new char[] { ' ', ',', '.', ';', '(', ')', ':', '?', '\\', '/' };
            var words = statement.Split(delims, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < words.Length; i++)
            {
                var word = words[i];
                char[] chars = new char[word.Length];
                for(int j = 0, k = word.Length - 1; j <= k; ++j, k--)
                {
                    chars[j] = word[k];
                    chars[k] = word[j];
                }
                var nword = new string(chars);
                words[i] = nword;
            }

            return string.Join(" ", words);
        }

        public static string RemoveDuplicateWithoutLinq(this string original)
        {
            var dico = new Dictionary<char, char>();
            var sb = new StringBuilder();
            foreach (char c in original)
            {
                if (!dico.ContainsKey(c))
                {
                    dico.Add(c, c);
                    sb.Append(c);
                }
            }

            return sb.ToString();
        }
    }
}
