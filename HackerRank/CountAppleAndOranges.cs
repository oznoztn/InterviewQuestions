using FluentAssertions;

namespace HackerRank
{
    public class CountAppleAndOranges
    {
        [Fact]
        public void Test()
        {
        }

        public void Execute(int s, int t, int a, int b, List<int> apples, List<int> oranges)
        {
            var ac = 0;
            foreach (var apple in apples)
            {
                if (apple + a >= s && apple + a <= t)
                    ac++;
            }

            var oc = 0;
            foreach (var orange in oranges)
            {
                if (orange + b >= s && orange + b <= t)
                    oc++;
            }
        }
    }
}