using FluentAssertions;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace ProgrammingInterviewsExposed
{
    /// <summary>
    /// Write an efficient function that deletes characters from a mutable
    /// ASCII string. Your function should take two arguments, str and remove. Any
    /// character existing in remove must be deleted from str. For example, given
    /// a str of "Battle of the Vowels: Hawaii vs. Grozny" and a remove of
    /// "aeiou", the function should transform str to "Bttl f th Vwls: Hw vs.
    /// Grzny".
    /// </summary>
    public class RemoveSpecifiedCharacters
    {
        [Fact] 
        /// 
        public void Test1()
        {
            Execute("Ozan Ozten", "ae").Should().Be("Ozn Oztn");
            Execute("Battle of the Vowels: Hawaii vs. Grozny", "aeiou").Should().Be("Bttl f th Vwls: Hw vs. Grzny");

            Execute2("Ozan Ozten", "ae").Should().Be("Ozn Oztn");
            Execute2("Battle of the Vowels: Hawaii vs. Grozny", "aeiou").Should().Be("Bttl f th Vwls: Hw vs. Grzny");

            Execute3("Ozan Ozten", "ae").Should().Be("Ozn Oztn");
            Execute3("Battle of the Vowels: Hawaii vs. Grozny", "aeiou").Should().Be("Bttl f th Vwls: Hw vs. Grzny");
        }


        /// <summary>
        /// Brute Force - O(N^2)
        /// </summary>
        /// <param name="str"></param>
        /// <param name="repl"></param>
        /// <returns></returns>
        public string Execute(string str, string repl)
        {
            // ASCII -> 128 Chars
            StringBuilder stringBuilder = new StringBuilder();

            for (int i = 0; i < str.Length; i++)
            {
                bool add = true;

                for (int j = 0; j < repl.Length; j++)
                {
                    if (repl[j] == str[i])
                        add = false;
                }

                if(add)
                    stringBuilder.Append(str[i]);
            }

            return stringBuilder.ToString();
        }


        /// <summary>
        /// Uses a HashSet. O(N)
        /// </summary>
        /// <param name="str"></param>
        /// <param name="repl"></param>
        /// <returns></returns>
        public string Execute2(string str, string repl)
        {
            StringBuilder stringBuilder = new StringBuilder();

            var uniqueLetters = new HashSet<char>();

            foreach (var ch in str)
                uniqueLetters.Add(ch);

            foreach (var ch in repl)
                uniqueLetters.Remove(ch);

            foreach (var ch in str)
                if (uniqueLetters.Contains(ch))
                    stringBuilder.Append(ch);

            return stringBuilder.ToString();
        }

        /// <summary>
        /// Uses the boolean mapping array of 128 elements for the ASCII chars. O(N).
        /// </summary>
        /// <param name="str"></param>
        /// <param name="repl"></param>
        /// <returns></returns>
        public string Execute3(string str, string repl)
        {
            StringBuilder stringBuilder = new StringBuilder();

            bool[] chars = new bool[128];
            
            foreach (var ch in str)
                chars[ch] = true;

            foreach (var ch in repl)
                chars[ch] = false;
            
            for (int i = 0; i < str.Length; i++)
            {
                if(chars[str[i]])
                    stringBuilder.Append(str[i]);
            }

            return stringBuilder.ToString();
        }
    }
}