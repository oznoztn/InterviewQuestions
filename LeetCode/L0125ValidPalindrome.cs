using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Xunit;

namespace LeetCode
{
    /// <summary>
    /// A phrase is a palindrome if, after converting all uppercase letters into lowercase letters and removing all non-alphanumeric characters, it reads the same forward and backward. Alphanumeric characters include letters and numbers.
    /// 
    /// Given a string s, return true if it is a palindrome, or false otherwise.
    /// 
    /// 
    /// 
    /// Example 1:
    /// 
    /// Input: s = "A man, a plan, a canal: Panama"
    /// Output: true
    /// Explanation: "amanaplanacanalpanama" is a palindrome.
    /// Example 2:
    /// 
    /// Input: s = "race a car"
    /// Output: false
    /// Explanation: "raceacar" is not a palindrome.
    /// Example 3:
    /// 
    /// Input: s = " "
    /// Output: true
    /// Explanation: s is an empty string "" after removing non-alphanumeric characters.
    /// Since an empty string reads the same forward and backward, it is a palindrome.
    /// 
    /// 
    /// Constraints:
    /// 
    /// 1 &lt;= s.length &lt;= 2 * 105
    /// s consists only of printable ASCII characters.
    /// 
    /// </summary>
    public class L0125ValidPalindrome
    {
        [Fact]
        public void Test()
        {
            IsPalindrome(" ").Should().Be(true);

            IsPalindrome("a.").Should().Be(true);

            IsPalindrome("ab").Should().Be(false);
            IsPalindrome("aa").Should().Be(true);

            IsPalindrome("0P").Should().Be(false);
            IsPalindrome("aba").Should().BeTrue();
            IsPalindrome("abba").Should().BeTrue();
            IsPalindrome("abcba").Should().BeTrue();
            IsPalindrome("A man, a plan, a canal: Panama").Should().BeTrue();
        }

        public bool IsPalindrome(string input)
        {
            // A man, a plan, a canal: Panama > amanaplanacanalpanama

            StringBuilder builder = new StringBuilder();
            
            foreach (var ch in input)
            {
                if (char.IsLetterOrDigit(ch))
                {
                    if (char.IsUpper(ch))
                        builder.Append((char)(ch + 32));
                    else
                        builder.Append(ch);
                }
            }
            
            var sanitized = builder.ToString();
            if (sanitized.Length == 0 || sanitized.Length == 1)
                return true;
            if (sanitized.Length == 2)
            {
                return sanitized[0] == sanitized[1];
            }


            //for (int i = 0; i < sanitized.Length; i++)
            //{
            //    if (sanitized[i] != sanitized[sanitized.Length - 1 - i])
            //    {
            //        return false;
            //    }
            //}

            // Bu üsttekinin yarısı kadar iş yapıyor
            for (int i = 0; i < sanitized.Length / 2; i++)
            {
                if (sanitized[i] != sanitized[sanitized.Length - 1 - i])
                {
                    return false;
                }
            }

            return true;
        }
    }
}
