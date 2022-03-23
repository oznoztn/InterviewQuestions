using FluentAssertions;
using Xunit;

namespace Gayle.StringsArrays
{
    /// <summary>
    /// Urlify: Verilen stringdeki boşlukları '%20' ile değiştir
    /// </summary>
    public class UnitTest3
    {
        [Fact]
        public void Test()
        {
            Urlify("Silwer Hawk").Should().Be("Silwer%20Hawk");
            Urlify("Silwer ").Should().Be("Silwer%20");
            Urlify(" Silwer").Should().Be("%20Silwer");
            Urlify("Silwer").Should().Be("Silwer");
            Urlify("  ").Should().Be("%20%20");
            Urlify("").Should().Be("");
        }

        public string Urlify(string input)
        {
            var spaceCount = 0;
            foreach (char c in input)
                if (c == ' ')
                    spaceCount++;

            var inputLength = input.Length;
            var outputLength = inputLength + spaceCount * 2;
            
            var urlified = new char[outputLength];
            
            var index = outputLength;
            for (int i = inputLength - 1; i >= 0; i--)
            {
                if (input[i] != ' ')
                {
                    urlified[index - 1] = input[i];
                    index--;
                }
                else
                {
                    urlified[index - 1] = '0';
                    urlified[index - 2] = '2';
                    urlified[index - 3] = '%';
                    index -= 3;
                }
            }

            return new string(urlified);
        }
    }
}
