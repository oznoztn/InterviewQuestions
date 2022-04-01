using System;
using System.Collections.Generic;
using FluentAssertions;
using Xunit;

namespace LeetCode
{
    /// <summary>
    /// 1374. Generate a String With Characters That Have Odd Counts
    /// </summary>
    public class LeetCode26
    {
        [Fact]
        public void Test()
        {
            Execute(new int[] { 1, 1 }).Should().Be(1);
            Execute(new int[] { 1, 1, 1, 2 }).Should().Be(2);
            Execute(new int[] { 1, 1, 1, 2, 3 }).Should().Be(3);
            Execute(new int[] { 0, 0, 1, 1, 1, 2, 2, 3, 3, 4 }).Should().Be(5);
        }

        public int Execute(int[] nums)
        {
            return 1;
        }
    }

    public class Leet13_RomanToInteger
    {
        [Fact]
        public void Test()
        {
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
                    sum += numerals[ch] * (-1);
                    pos++;
                }
                else if (numerals[ch] == numerals[chPost])
                {
                    var inner_sum = 0;
                    for (int i = pos; i < roman.Length; i++)
                    {
                        if (ch == roman[i])
                        {
                            inner_sum += numerals[ch];
                            pos++;

                            if (pos == roman.Length)
                            {
                                // pos -> son index'e karþýlýk geliyor demektir
                                sum += inner_sum;
                                break;
                            }
                        }
                        else
                        {
                            if (numerals[ch] < numerals[roman[i]]) // isRightNumeralBigger
                            {
                                sum += inner_sum * (-1);
                                break;
                            }
                            else
                            {
                                sum += inner_sum;
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