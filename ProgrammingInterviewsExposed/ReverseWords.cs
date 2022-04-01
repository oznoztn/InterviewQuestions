using FluentAssertions;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Xunit.Abstractions;

namespace ProgrammingInterviewsExposed
{
    /// <summary>
    /// Write a function that reverses the order of the words in a string. For
    /// example, your function should transform the string “Do or do not, there is no
    /// try.” to “try. no is there not, do or Do”. Assume that all words are space delimited
    /// and treat punctuation the same as letters.
    /// </summary>
    public class ReverseWords
    {
        private readonly ITestOutputHelper _output;

        public ReverseWords(ITestOutputHelper output)
        {
            _output = output;
        }

        [Fact]
        public void Test1()
        {
            Execute("ozan oz www").Should().Be("www oz ozan");
            Execute("Do or do not, there is no try.").Should().Be("try. no is there not, do or Do");

            Execute_SimplifiedVersion("ozan oz www").Should().Be("www oz ozan");
            Execute_SimplifiedVersion("Do or do not, there is no try.").Should().Be("try. no is there not, do or Do");

            ExecuteFinal("ozan oz www").Should().Be("www oz ozan");
            ExecuteFinal("Do or do not, there is no try.").Should().Be("try. no is there not, do or Do");
        }

        /// <summary>
        /// Uses a STACK
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public string Execute(string str)
        {
            // o z a n   o z   w w w
            // 0 1 2 3 4 5 6 7 8 9 10
            var stack = new Stack<string>();

            int pos = 0;
            for (int i = 0; i < str.Length; i++)
            {
                char ch = str[i];

                if (char.IsWhiteSpace(ch))
                {
                    var substring = str.Substring(pos, i - pos);
                    
                    stack.Push(substring);

                    pos = i;
                }
            }

            stack.Push(str.Substring(pos, str.Length - pos));

            var reversed = new char[str.Length];
            int ri = 0;
            while (stack.Count != 0)
            {
                var word = stack.Pop();

                foreach (char ch in word)
                {
                    if (char.IsWhiteSpace(ch))
                        continue;

                    reversed[ri] = ch;
                    ri++;
                }

                if (ri + 1 < str.Length)
                {
                    reversed[ri] = ' ';
                    ri++;
                }
            }

            return new string(reversed);
        }

        /// <summary>
        /// Uses a STACK and StringBuilder -- Simplified, a little bit.
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public string Execute_SimplifiedVersion(string str)
        {
            // o z a n   o z   w w w
            // 0 1 2 3 4 5 6 7 8 9 10
            var stack = new Stack<string>();

            int pos = 0;
            for (int i = 0; i < str.Length; i++)
            {
                char ch = str[i];

                if (char.IsWhiteSpace(ch))
                {
                    var substring = str.Substring(pos, i - pos);
                    stack.Push(substring);
                    pos = i;
                }
            }

            stack.Push(str.Substring(pos, str.Length - pos));

            StringBuilder stringBuilder = new StringBuilder();
            while (stack.Count != 0)
            {
                var word = stack.Pop();
                stringBuilder.Append(word.Trim());

                if (stack.Count != 0)
                    stringBuilder.Append(" ");
            }

            return stringBuilder.ToString();
        }

        /// <summary>
        /// This does not use STACK.
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public string ExecuteFinal(string str)
        {
            var reversed = new char[str.Length];
            int index = 0;
            for (int i = str.Length - 1; i >= 0; i--)
            {
                if (char.IsWhiteSpace(str[i]))
                {
                    for (int j = i + 1; j < str.Length; j++)
                    {
                        if (char.IsWhiteSpace(str[j]))
                            break;

                        reversed[index] = str[j];
                        index++;
                    }

                    reversed[index] = ' ';
                    index++;
                }
            }

            // ilk boþluða kadar olan karakterler için...
            for (int i = 0; i < str.Length; i++)
            {
                if (char.IsWhiteSpace(str[i]))
                {
                    for (int j = 0; j < i; j++)
                    {
                        reversed[index] = str[j];
                        index++;
                    }

                    break;
                }
            }

            return new string(reversed);
        }
    }
}