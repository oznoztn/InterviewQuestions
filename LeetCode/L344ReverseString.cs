using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Xunit;

namespace LeetCode
{
    /// <summary>
    /// Write a function that reverses a string. The input string is given as an array of characters s.
    /// 
    /// You must do this by modifying the input array in-place with O(1) extra memory.
    /// 
    /// 
    /// 
    /// Example 1:
    /// 
    /// Input: s = ["h","e","l","l","o"]
    /// Output: ["o","l","l","e","h"]
    /// Example 2:
    /// 
    /// Input: s = ["H","a","n","n","a","h"]
    /// Output: ["h","a","n","n","a","H"]
    /// 
    /// 
    /// Constraints:
    /// 
    /// 1 &lt;= s.length &lt;= 105
    /// s[i] is a printable ascii character.
    /// </summary>
    public class L344ReverseString
    {
        [Fact]
        public void Test()
        {
            var i1 = "hello".ToCharArray();
            Execute(i1);
            i1.Should().BeEquivalentTo("olleh".ToCharArray());

            i1 = "Hannah".ToCharArray();
            Execute(i1);
            i1.Should().BeEquivalentTo("hannaH".ToCharArray());
        }

        public void Execute(char[] chars)
        {
            int start = 0;
            int end = chars.Length - 1;

            while (start < end)
            {
                (chars[start], chars[end]) = (chars[end], chars[start]);

                start++;
                end--;
            }
        }
    }
}
