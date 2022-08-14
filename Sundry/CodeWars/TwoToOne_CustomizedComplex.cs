using System.Text;
using Xunit;

namespace Sundry.CodeWars
{
    /// <summary>
    /// Ben işi biraz daha zorlaştırdım.
    /// Bu diğerine nazaran sadece "alfabetik yönden geçerli mümkün olan en uzun stringi bulur.
    ///
    /// Alfabetik yönden geçerli olması demek en uzun stringi oluşturan harflerin arasında boşluk olmaması demektir.
    /// 
    /// </summary>
    public class TwoToOne_CustomizedComplex
    {
        [Fact]
        public void Test()
        {
            Assert.Equal("abcdefg", Execute("abc", "aabbccddeeffgggg"));
            Assert.Equal("pqrstuvwxyz", Execute("abc", "aabbccddeeffggggmnpqrstuvwxyz"));
        }

        private string Execute(string str1, string str2)
        {
            var chars = new char[128];

            for (int i = 0; i < str1.Length; i++)
                chars[str1[i]] = str1[i];

            for (int i = 0; i < str2.Length; i++)
                chars[str2[i]] = str2[i];

            int longestStart = 0;
            int longestLength = 0;

            int start = 0;
            int length = 0;

            // a b c d e _ f g h j k l m n
            for (int i = 0; i < chars.Length - 1; i++)
            {
                if (chars[i] < chars[i + 1] && !char.IsWhiteSpace(chars[i + 1]))
                {
                    if (start == 0)
                        start = i + 1;

                    length += 1;
                }
                else
                {
                    if (length > longestLength)
                    {
                        longestStart = start;
                        longestLength = length;
                    }

                    start = 0;
                    length = 0;

                }
            }


            var counter = 0;
            var stringBuilder = new StringBuilder();
            while (counter != longestLength)
            {
                var ch = chars[longestStart + counter];
                stringBuilder.Append(ch);

                counter++;
            }

            var result = stringBuilder.ToString();
            return result;
        }
    }
}
