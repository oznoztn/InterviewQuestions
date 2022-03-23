using FluentAssertions;
using Xunit;

namespace Gayle
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
}