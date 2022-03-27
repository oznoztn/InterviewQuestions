using FluentAssertions;
using Xunit;

namespace LeetCode;

public class TwoSums
{
    [Fact]
    public void Test()
    {
        var input = new int[] { 2, 7, 11, 15 };

        var output = new TwoSums().ExecBrute(input, 9);

        var expected = new int[] { 0, 1 };

        output.Should().BeEquivalentTo(expected);
    }

    public int[] ExecBrute(int[] nums, int target)
    {
        for (int i = 0; i < nums.Length; i++)
        {
            for (int j = i + 1; j < nums.Length; j++)
            {

                if (nums[i] + nums[j] == target)
                {
                    return new int[] { i, j };
                }
            }
        }

        return null;
    }
}