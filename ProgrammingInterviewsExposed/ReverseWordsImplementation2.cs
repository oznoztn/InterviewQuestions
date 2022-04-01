using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using FluentAssertions;
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
    public class ReverseWordsImplementation2
    {
        private readonly ITestOutputHelper _output;

        public ReverseWordsImplementation2(ITestOutputHelper output)
        {
            _output = output;
        }

        [Fact]
        public void Test1()
        {
            Execute("123 ABC XYZ").Should().Be("XYZ ABC 123");
            Execute("Do or do not, there is no try.").Should().Be("try. no is there not, do or Do");
        }

        /// <summary>
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public string Execute(string str)
        {
            var chars = str.ToCharArray();
            
            ReverseString(chars, 0, chars.Length - 1);
            int whPos = 0;
            for (var i = whPos; i < chars.Length; i++)
            {
                var ch = chars[i];
                if (char.IsWhiteSpace(ch))
                {
                    ReverseString(chars, whPos, i - 1);

                    whPos = i;
                }
            }

            return null;
        }

        private void ReverseString(char[] chars, int start, int end)
        {
            while (true)
            {
                char end_temp = chars[end];

                chars[end] = chars[start];
                chars[start] = end_temp;

                start++;
                end--;

                if (start > end)
                    break;
            }
        }
    }
}
