using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Algorithms.Implementations
{
    public class Palindrome
    {
        public static bool IsPalindrome(string str)
        {
            int len = str.Length;
            for (int i = 0; i < len/2; i++)
            {
                if(str[i] != str[len - i - 1])
                    return false;
            }
            return true;
        }

        public static bool IsPalindrome(int number)
        {
            int reverse = 0;
            var copy = number;

            while(copy > 0)
            {
                reverse = reverse * 10 + copy % 10;
                copy /= 10;
            }

            return reverse == number;
        }

        /// <summary>
        /// Given a string of lowercase letters in the range ascii[a-z], 
        /// determine the index of a character that can be removed to make the string a palindrome. 
        /// There may be more than one solution, but any will do. If the word is already a palindrome or there is no solution, 
        /// return -1. Otherwise, return the index of a character to remove.
        /// </summary>
        /// <param name="str">Input</param>
        /// <returns></returns>
        public static int PalindromeIndex(string str)
        {
            if (IsPalindrome(str))
            {
                return -1;
            }

            int len = str.Length;
            StringBuilder sb = new StringBuilder(str);
            for(int i = 0, j = len - 1; i <= j; i++, j--)
            {
                sb = sb.Remove(i, 1);
                if(IsPalindrome(sb.ToString()))
                    return i;
                sb = sb.Insert(i, str[i]);

                sb = sb.Remove(j, 1);
                if (IsPalindrome(sb.ToString()))
                    return j;
                sb = sb.Insert(j, str[j]);
            }

            return -1;
        }

        /// <summary>
        /// Given string <b>str</b>, find the minimum number of characters to be replaced to make a given string palindrome. 
        /// Replacing a character means replacing it with any single character in the same position.<br/><br/>
        /// Return 0 if <b>str</b> is already a palindrome and -1 if no number of replacements make it a palindrome 
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static int MinAdjustmentToMakePalindrome(string str)
        {
            int n = str.Length;
            int result = 0;

            for(int i = 0; i < n/2; i++)
            {
                if (str[i] == str[n - i - 1])
                    continue;

                result++;

                if(str[i] < str[n - i - 1])
                {
                    str.Replace(str[n - i - 1], str[i]);
                }
                else
                {
                    str.Replace(str[i], str[n - i - 1]);
                }
            }

            if(result == 0)
            {
                return 0;
            }

            return IsPalindrome(str) ? result : -1;
        }

        /// <summary>
        /// You are given a string s and array queries where <b><i>queries[i] = [lefti, righti, ki]</i></b>. 
        /// We may rearrange the substring s[lefti...righti] for each query and then choose up to ki of them to replace with any 
        /// lowercase English letter. <br/><br/>
        /// If the substring is possible to be a palindrome string after the operations above, the result of the query is true. 
        /// Otherwise, the result is false. <br/><br/>
        /// Return a boolean array answer where <b>answer[i]</b> is the result of the ith query <b>queries[i]</b>.<br/><br/>
        /// Note that each letter is counted individually for replacement, so if, for example s[lefti...righti] = "aaa", and ki = 2, 
        /// we can only replace two of the letters.Also, note that no query modifies the initial string s.<br/><br/><br/>
        /// <b><u>Example</u></b> :<br/>
        /// <code>
        /// Input: s = "abcda", queries = [[3, 3, 0], [1,2,0], [0,3,1], [0,3,2], [0,4,1]]
        /// Output: [true,false,false,true,true]
        /// </code>
        /// <b><u>Explanation</u></b>:<br/>
        /// queries[0]: substring = "d", is palidrome.<br/>
        /// queries[1]: substring = "bc", is not palidrome.<br/>
        /// queries[2]: substring = "abcd", is not palidrome after replacing only 1 character. <br/>
        /// queries[3]: substring = "abcd", could be changed to "abba" which is palidrome. 
        /// Also this can be changed to "baab" first rearrange it "bacd" then replace "cd" with "ab". <br/>
        /// queries[4]: substring = "abcda", could be changed to "abcba" which is palidrome.
        /// </summary>
        /// <param name="str"></param>
        /// <param name="queries"></param>
        /// <returns></returns>
        public static IList<bool> CanMakePalindromeFromSubstring(string str, int[][] queries)
        {
            int rowLength = queries.GetLength(0);
            var result = new bool[rowLength];
            Array.Fill(result, false);

            for(int i = 0;i < rowLength; i++)
            {
                int left = queries[i][0];
                int right = queries[i][1];
                int cnt = right - left + 1;
                var substring = str.Substring(left, cnt);
                int k = queries[i][2];

                if (k == 0)
                {
                    result[i] = IsPalindrome(substring);
                }
                else
                {
                    int n = MinAdjustmentToMakePalindrome(substring);
                    if (n == 0 || (n != -1 && n == k))
                    {
                        result[i] = true;
                    }
                }
            }

            return result.ToList();
        }
    }
}
