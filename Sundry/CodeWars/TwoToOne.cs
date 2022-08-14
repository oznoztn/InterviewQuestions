using System.Text;
using Xunit;

namespace Sundry.CodeWars
{
    /// <summary>
    /// Take 2 strings s1 and s2 including only letters from ato z.
    /// Return a new sorted string, the longest possible, containing distinct letters - each taken only once - coming from s1 or s2.
    ///
    /// a = "xyaabbbccccdefww"
    /// b = "xxxxyyyyabklmopq"
    /// longest(a, b) -&gt; "abcdefklmopqwxy"
    /// 
    /// a = "abcdefghijklmnopqrstuvwxyz"
    /// longest(a, a) -&gt; "abcdefghijklmnopqrstuvwxyz"
    /// 
    /// </summary>
    public class TwoToOne
    {
        [Fact]
        public void Test()
        {
            Assert.Equal("aehrsty", Execute("aretheyhere", "yestheyarehere"));
            Assert.Equal("abcdefghilnoprstu", Execute("loopingisfunbutdangerous", "lessdangerousthancoding"));
            Assert.Equal("acefghilmnoprstuy", Execute("inmanylanguages", "theresapairoffunctions"));
        }

        private string Execute(string str1, string str2)
        {
            var chars = new char[128];

            for (int i = 0; i < str1.Length; i++)
                chars[str1[i]] = str1[i];

            for (int i = 0; i < str2.Length; i++)
                chars[str2[i]] = str2[i];

            var stringBuilder = new StringBuilder();
            
            // a b c d e _ f g h j k l m n
            for (int i = 0; i < chars.Length - 1; i++)
            {
                if (!char.IsLetter(chars[i]))
                    continue;
                else
                    stringBuilder.Append(chars[i]);
            }

            return stringBuilder.ToString();
        }
    }
}
