using Xunit.Abstractions;

namespace Common.Extensions
{
    public static class TestOutputHelperExtensions
    {
        public static void WriteLine(this ITestOutputHelper helper, char c)
        {
            helper.WriteLine(c.ToString());
        }
    }
}
