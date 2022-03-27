using System.Collections.Generic;
using FluentAssertions;
using Xunit;

namespace CoderByte
{
    public class CaesarCipher
    {
        [Fact]
        public void Test()
        {
            Execute("xyz", 0).Should().Be("xyz");
            Execute("Hello", 4).Should().Be("Lipps");
            Execute("Caesar Cipher", 2).Should().Be("Ecguct Ekrjgt");
        }

        public string Execute(string str, int num)
        {
            if (num == 0)
                return str;

            var charsDict = new Dictionary<int, char>();

            foreach (var c in "ABCDEFGHIJKLMNOPQRSTUVWXYZ" + "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToLowerInvariant())
                charsDict.Add((int)c, c);

            var cipher = new char[str.Length];

            for (var i = 0; i < str.Length; i++)
            {
                if (char.IsLetter(str[i]))
                {
                    cipher[i] = charsDict[str[i] + num];
                }
                else if (char.IsWhiteSpace(str[i]))
                {
                    cipher[i] = ' ';
                }
            }

            return new string(cipher);
        }
    }
}