using FluentAssertions;
using System.Text;

namespace HackerRank
{
    public class SuperReducedString
    {
        [Fact]
        public void Test()
        {
        }

        public static string superReducedString(string s)
        {
            var chars = new char[s.Length];
            for (int i = 0; i < chars.Length; i++)
            {
                chars[i] = s[i];
            }

            bool hasOneAdjacent = true;
            while (hasOneAdjacent)
            {
                hasOneAdjacent = false;

                for (int i = 1; i < s.Length; i++)
                {
                    if (s[i] == s[i - 1])
                    {
                        if (chars[i - 1] == default && s[i] != default)
                        {
                            continue;
                        }

                        chars[i] = default;
                        chars[i - 1] = default;

                        hasOneAdjacent = true;
                    }
                }
            }

            var sb = new StringBuilder();
            foreach (var c in chars)
            {
                if (c != default)
                    sb.Append(c);
            }

            if (sb.Length == 0)
                return "Empty String";

            return sb.ToString();
        }
        public static string superReducedString2(string s)
        {
            if (s.Length == 1)
                return s;

            int i = 1;
            while (true)
            {
                if (s == "")
                    return "Empty String";

                var prev = s[i - 1];
                var curr = s[i];

                if (prev == curr)
                {
                    s = s.Remove(i - 1, 2);
                    i = 1;
                }
                else
                {
                    i++;
                }

                if (s.Length == i)
                    break;
            }

            if (s == "")
                return "Empty String";

            return s;
        }
    }
}