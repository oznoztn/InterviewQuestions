using System;
using System.Collections.Generic;
using FluentAssertions;
using Xunit;

namespace LeetCode
{
    public class L0013RomanToInteger
    {
        [Fact]
        public void Test()
        {
            Execute("I").Should().Be(1);
            Execute("X").Should().Be(10);
            Execute("XIIV").Should().Be(13);
            Execute("LVIII").Should().Be(58);
            Execute("MCMXCIV").Should().Be(1994);
            Execute("MDCCCLXXXIV").Should().Be(1884);
        }

        /// <summary>
        /// Runtime: 110 ms, faster than 41.14% of C# online submissions for Roman to Integer.
        /// Memory Usage: 36.7 MB, less than 91.13% of C# online submissions for Roman to Integer.
        /// </summary>
        /// <param name="roman"></param>
        /// <returns></returns>
        public int Execute(string roman)
        {
            Dictionary<char, int> numerals = new Dictionary<char, int>
            {
                ['I'] = 1,
                ['V'] = 5,
                ['X'] = 10,
                ['L'] = 50,
                ['C'] = 100,
                ['D'] = 500,
                ['M'] = 1000
            };

            if (roman.Length == 1)
                return numerals[roman[0]];

            // XIIV

            int sum = 0;
            int pos = 0;

            // X I I V
            while (pos < roman.Length)
            {
                if (pos + 1 == roman.Length)
                {
                    // pos -> son index'e karþýlýk geliyor demektir
                    sum += numerals[roman[pos]];
                    break;
                }

                char ch = roman[pos];
                char chPost = roman[pos + 1];
                
                if (numerals[ch] < numerals[chPost])
                {
                    sum += numerals[ch] * -1;
                    pos++;
                }
                else if (numerals[ch] == numerals[chPost])
                {
                    var innerSum = 0;
                    for (int i = pos; i < roman.Length; i++)
                    {
                        if (ch == roman[i])
                        {
                            innerSum += numerals[ch];
                            pos++;

                            if (pos == roman.Length)
                            {
                                // pos -> son index'e karþýlýk geliyor demektir
                                sum += innerSum;
                                break;
                            }
                        }
                        else
                        {
                            if (numerals[ch] < numerals[roman[i]]) // isRightNumeralBigger
                            {
                                sum += innerSum * (-1);
                                break;
                            }
                            else
                            {
                                sum += innerSum;
                                break;
                            }
                        }
                    }
                }
                else
                {
                    sum += numerals[ch];
                    pos++;
                }
            }

            return sum;
        }
    }
}