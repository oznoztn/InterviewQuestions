using FluentAssertions;
using Xunit;

namespace LeetCode
{
    /// <summary>
    /// Given a string s, return true if the s can be palindrome after deleting at most one character from it.
    /// 
    /// Example 1:
    /// 
    /// Input: s = "aba"
    /// Output: true
    /// Example 2:
    /// 
    /// Input: s = "abca"
    /// Output: true
    /// Explanation: You could delete the character 'c'.
    /// Example 3:
    /// 
    /// Input: s = "abc"
    /// Output: false
    /// 
    /// 
    /// Constraints:
    /// 
    /// 1 &lt;= s.length &lt;= 105
    /// s consists of lowercase English letters.
    /// 
    /// </summary>
    public class L680ValidPalindrome2
    {
        [Fact]
        public void Test()
        {
            IsPalindrome("aba").Should().Be(true);
            IsPalindrome("abba").Should().Be(true);
            IsPalindrome("abcba").Should().Be(true);

            IsPalindrome("deeee").Should().BeTrue();
            
            IsPalindrome("").Should().BeTrue();
            IsPalindrome("x").Should().BeTrue();

            IsPalindrome("abccba").Should().Be(true);
            IsPalindrome("abcXcba").Should().Be(true);
            IsPalindrome("abXa").Should().Be(true);

            IsPalindrome("abXXa").Should().Be(true);

            IsPalindrome("abca").Should().Be(true);

            IsPalindrome("abc").Should().Be(false);
        }

        public bool IsPalindrome(string input)
        {
            int start = 0;
            int end = input.Length - 1;

            while (start < end)
            {
                if (input[start] != input[end])
                {
                    return checkPalindrome(input, start + 1, end) || checkPalindrome(input, start, end - 1);
                }

                start++;
                end--;
            }

            return true;
        }

        private bool checkPalindrome(string input, int start, int end)
        {
            while (start < end)
            {
                if (input[start] != input[end])
                    return false;

                start++;
                end--;
            }

            return true;
        }
    }
}
