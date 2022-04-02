using System.Collections.Generic;
using System.Text;
using FluentAssertions;
using Xunit;

namespace LeetCode
{
    /// <summary>
    /// 20. Valid Parentheses
    /// </summary>
    public class L345ReverseVowelsOfAString
    {
        [Fact]
        public void Test()
        {
            Execute("aA").Should().Be("Aa");
            Execute("hello").Should().Be("holle");
            Execute("leetcode").Should().Be("leotcede");
        }

        public string Execute(string s)
        {
            StringBuilder strb = new StringBuilder();

            // IT SAYS "PRINTABLE ASCII CHARACTERS ONLY"
            foreach (char ch in s)
                if(ch >= 32 && ch <= 127)
                    strb.Append(ch);

            int start = 0;
            int end = s.Length - 1;

            while (start < end)
            {
                if (strb[start] == 'a' || 
                    strb[start] == 'e' ||
                    strb[start] == 'i' || 
                    strb[start] == 'o' ||
                    strb[start] == 'u' || 
                    strb[start] == 'A' ||
                    strb[start] == 'E' || 
                    strb[start] == 'I' || 
                    strb[start] == 'O' || 
                    strb[start] == 'U')
                {
                    while (true)
                    {
                        if (strb[end] == 'a' || 
                            strb[end] == 'e' || 
                            strb[end] == 'i' || 
                            strb[end] == 'o' || 
                            strb[end] == 'u' || 
                            strb[end] == 'A' || 
                            strb[end] == 'E' || 
                            strb[end] == 'I' || 
                            strb[end] == 'O' || 
                            strb[end] == 'U')
                        {
                            (strb[start], strb[end]) =  (strb[end], strb[start]);

                            end--;
                            break;
                        }
                        else
                        {
                            end--;
                        }
                    }
                }

                start++;
            }

            return strb.ToString();
        }
    }
}