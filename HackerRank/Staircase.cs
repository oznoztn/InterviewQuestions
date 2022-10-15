using FluentAssertions;

namespace HackerRank
{
    public class Staircase
    {
        [Fact]
        public void Test()
        {

        }

        public static void Exec(int n)
        {
            var numberOf = n;
            var emptySpace = n - 1;
            while (true)
            {
                if (emptySpace == 0)
                {
                    for (int i = 0; i < n - numberOf + 1; i++)
                        Console.Write("#");

                    Console.WriteLine();
                    numberOf--;

                    emptySpace = numberOf - 1;

                    if (numberOf == 0)
                        break;
                }
                else
                {
                    Console.Write(" ");
                    emptySpace--;
                }
            }
        }
    }
}