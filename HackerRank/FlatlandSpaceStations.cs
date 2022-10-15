using FluentAssertions;

namespace HackerRank
{
    public class FlatlandSpaceStations
    {
        [Fact]
        public void Test()
        {
            //Console.WriteLine(flatlandSpaceStations2( == 2);
            //Console.WriteLine(flatlandSpaceStations2();

            Exec(3, new[] { 0, 1, 2 }).Should().Be(0);

            Exec(6, new[] { 3 }).Should().Be(3);
            Exec(6, new[] { 1 }).Should().Be(4);
            Exec(6, new[] { 0 }).Should().Be(5);
            Exec(6, new[] { 5 }).Should().Be(5);

            Exec(6, new[] { 1,2,3,4,5 }).Should().Be(1);

            Exec(6, new[] { 3, 4 }).Should().Be(3);

            Exec(16, new[] { 6, 10,16 }).Should().Be(6);
            
            Exec(99998, new[] { 28000, 58701, 43043, 24909, 28572 }).Should().Be(41296);
        }

        public int Exec(int n, int[] c)
        {
            if (n == c.Length)
                return 0;

            var max = int.MinValue;

            if (c.Length == 1)
            {
                var left = c[0];
                var right = n - c[^1] - 1;
                return Math.Max(left, right);
            }

            Array.Sort(c);
            
            int newMax = 0;
            for (int i = 0; i < c.Length - 1; i++)
            {
                var curr = c[i];
                var next = c[i + 1];

                if ((next - curr + 1) % 2 == 0)
                {
                    newMax = (next - curr + 1) / 2 - 1;
                }
                else
                {
                    newMax = (next - curr + 1) / 2;
                }

                if (newMax > max)
                    max = newMax;
            }


            if (c[0] != 0)
            {
                newMax = c[0];

                if (newMax > max)
                    max = newMax;
            }

            if (c[^1] != n)
            {
                newMax = n - 1 - c[^1];

                if (newMax > max)
                    max = newMax;
            }

            return max;
        }
    }
}