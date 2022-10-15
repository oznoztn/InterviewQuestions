using FluentAssertions;

namespace HackerRank
{
    public class CaesarCipher
    {
        [Fact]
        public void Test()
        {
        }

        public string caesarCipher(string s, int k)
        {
            var result = new char[s.Length];

            for (var i = 0; i < s.Length; i++)
            {
                char ch = s[i];
                if (!char.IsLetter(ch))
                {
                    result[i] = ch;
                }

                int rotated = ch + k % 26;

                if (ch >= 'a' && ch <= 'z') // is LOWER case char? 
                {
                    if (rotated > 'z')
                    {
                        var cc = (char)(rotated - 'z' + 'a' - 1);
                        result[i] = cc;
                        continue;
                    }

                    char c2 = (char)rotated;
                    result[i] = c2;
                }
                else if (ch >= 'A' && ch <= 'Z') // is UPPER case char?
                {
                    if (rotated > 'Z')
                    {
                        var cc = (char)(rotated - 'Z' + 'A' - 1);
                        result[i] = cc;
                        continue;
                    }

                    char c2 = (char)rotated;
                    result[i] = c2;
                }
            }
            return new string(result);
        }
    }
}