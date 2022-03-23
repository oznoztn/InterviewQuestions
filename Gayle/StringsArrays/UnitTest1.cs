using System.Collections.Generic;
using FluentAssertions;
using Xunit;
using Xunit.Abstractions;

namespace Gayle.StringsArrays
{
    /// <summary>
    /// Verilen stringi oluþturan bütün karakterler özgün mü? (Unique)
    /// onur - true, ozan - true, eren - false
    /// </summary>
    public class UnitTest1
    {
        private readonly ITestOutputHelper _helper;

        public UnitTest1(ITestOutputHelper helper)
        {
            _helper = helper;
        }

        [Fact]
        public void Test()
        {
            this.IsAllCharactersUniqueNoob("silwer").Should().Be(true);
            this.IsAllCharactersUniqueNoob("silwwer").Should().Be(false);

            this.IsAllCharactersUnique("silwer").Should().Be(true);
            this.IsAllCharactersUnique("silwwer").Should().Be(false);
        }

        
        public bool IsAllCharactersUniqueNoob(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return false;

            Dictionary<int, char> chars = new Dictionary<int, char>();

            foreach (var c in input)
            {
                if (chars.ContainsKey((int) c))
                    return false;
                else
                    chars[(int) c] = c;
            }
            
            return true;
        }

        public bool IsAllCharactersUnique(string input)
        {
            // Ýlk sorman gereken soru string ASCII mi UNICODE mu?

            // ASCII            -> 128 karakterden oluþuyor
            // Extencded ASCII  -> 256 karakter
            // Unicode          -> 144.697

            // VARSAYIMLAR
            // String -> ASCII.

            if (input.Length > 128) // ASCII olduðundan direkt bu þekilde bir validasyon yapabilirm.
                return false;

            bool[] chars = new bool[128]; // Her bir slot ASCII char space'indeki bir karaktere denk geliyor.
            foreach (var c in input)
            {
                if (chars[(int)c])
                    return false;
                else
                    chars[(int) c] = true;
            }
            
            return true;

            
        }
    }
}