using System.Text;
using FluentAssertions;
using Xunit;

namespace LeetCode
{
    /// <summary>
    /// 1374. Generate a String With Characters That Have Odd Counts
    /// </summary>
    public class LeetCode1374
    {
        [Fact]
        public void Test()
        {
            this.ExecuteArray(1).Should().Be("W");
            this.ExecuteArray(2).Should().Be("WQ");
            this.ExecuteArray(3).Should().Be("WWW");
            this.ExecuteArray(4).Should().Be("WWWQ");

            this.ExecuteStringBuilder(1).Should().Be("W");
            this.ExecuteStringBuilder(2).Should().Be("WQ");
            this.ExecuteStringBuilder(3).Should().Be("WWW");
            this.ExecuteStringBuilder(4).Should().Be("WWWQ");
        }

        public string ExecuteArray(int n)
        {
            char[] output = new char[n];

            for (int i = 0; i < n; i++)
                output[i] = 'W';

            if (n % 2 == 0)
                output[n - 1] = 'Q';

            return new string(output);
        }

        public string ExecuteStringBuilder(int n)
        {
            StringBuilder stringBuilder = new StringBuilder();
            char[] output = new char[n];

            for (int i = 0; i < n; i++)
                stringBuilder.Append('W');

            if (n % 2 == 0)
                stringBuilder.Replace('W','Q', stringBuilder.Length-1, 1 );

            return stringBuilder.ToString();
        }
    }
}