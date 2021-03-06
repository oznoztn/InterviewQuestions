using FluentAssertions;
using Xunit;

namespace CoderByte
{
    /// <summary>
    /// A string is considered beautiful if it satisfies the following conditions:
    /// 
    /// Consisting of English vowels only, and each of the 5 English vowels ('a', 'e', 'i', 'o', 'u') must appear at least once in it.
    /// 
    /// The letters must be sorted in alphabetical order (i.e. all 'a's before 'e's, all 'e's before 'i's, etc.).
    /// 
    /// For example, strings "aeiou" and "aaaaaaeiiiioou" are considered beautiful, but "uaeio", "aeoiu", "aaaeeeooo" and ?aeixyzou? are not beautiful.
    /// 
    /// Given a string consisting of English Characters and numbers , return the length of the longest beautiful substring in the given string. 
    /// If no such substring exists, return 0.
    /// 
    /// A substring is a contiguous sequence of characters in a string.
    /// 
    /// Examples
    /// Input: "abcdeaeiaaioaaaaeiiiiouuuooaauuaeiu"
    /// Output: 13
    /// 
    /// Input: "abceiou"
    /// Output: 0
    /// 
    /// </summary>
    public class LongestBeautifulString
    {
        [Fact]
        public void Test()
        {
            // Whenever the first char in the pair comes before the second char in the pair, i increase the counter
            //      example: in the case of "ae", "a" comes before "e", so we increase the counter.

            // It will increase the counter for incorrect pair for example "ou", just because "o" comes before "u"
            // BUT the if the pair is incorrect, the counter will be reset to 1 eventually.
            //      example: for first iteration "oux" is valid, but for the second it is NOT, so the counter will be RESET to 1.

            
            Execute("a").Should().Be("0");
            Execute("aeio").Should().Be("0");
            Execute("aeiou").Should().Be("5");
            Execute("ououououou").Should().Be("0");
            Execute("aeiouaaeeiioouu").Should().Be("10");
            Execute("aaaaeiiiiouuuaaaaeiiiiouuuuuuuuuooaauuaeiua").Should().Be("19");
            Execute("abcdeaeiaaioaaaaeiiiiouuuooaauuaeiu").Should().Be("13");

            
            Execute("abceiou").Should().Be("0");
        }

        public string Execute(string str)
        {
            // a b c d e a e i a a i  o  a   a   a   a   e   i   i   i   i   o   u   u   u   o   o   a   a   u
            // 0 1 2 3 4 5 6 7 8 9 10 11 12  13  14  15  16  17  18  19  20  21  22  23  24  25  26
            if (str.Length < 5)
                return "0";

            if (str.Length == 5 && str == "aeiou")
                return "5";

            var counter = 1;
            var length = 1;
            var maxLength = 0;

            for (var i = 1; i != str.Length; ++i)
            {
                var n = str[i - 1];
                var npost = str[i];

                if (str[i - 1] == str[i])
                {
                    ++length;
                }
                else if ((int)str[i - 1] < (int)str[i])
                {
                    if (str[i - 1] != 'a' &&
                        str[i - 1] != 'e' &&
                        str[i - 1] != 'i' &&
                        str[i - 1] != 'o' &&
                        str[i - 1] != 'u')
                    {
                        counter = 1;
                        length = 1;
                    }
                    else
                    {
                        ++length;
                        ++counter;
                    }
                }
                else
                {
                    counter = 1;
                    length = 1;
                }

                if (counter == 5)
                {
                    if (maxLength < length)
                        maxLength = length;
                }
            }

            return maxLength.ToString();
        }
    }
}