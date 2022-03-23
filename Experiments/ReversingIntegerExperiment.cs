using FluentAssertions;
using Xunit;

namespace Experiments
{
    public class ReversingIntegerExperiment
    {
        [Fact]
        public void Test1()
        {
            ReversePositiveInteger(789).Should().Be(987);
            ReversePositiveInteger(780).Should().Be(87);
        }

        public int ReversePositiveInteger(int num)
        {
            int result = 0;
            while (num > 0)
            {
                result = result * 10 + num % 10;
                num /= 10;
            }
            return result;
        }
    }
}