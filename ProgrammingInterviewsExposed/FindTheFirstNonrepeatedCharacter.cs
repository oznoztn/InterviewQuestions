using FluentAssertions;
using System.Collections.Generic;
using Xunit;

namespace ProgrammingInterviewsExposed
{
    /// <summary>
    /// Write an efficient function to find the first nonrepeated character
    /// in a string. For instance, the first nonrepeated character in “total” is ‘o’ and
    /// the first nonrepeated character in “teeter” is ‘r’. Discuss the efficiency of your
    /// algorithm.
    /// </summary>
    public class FindTheFirstNonRepeatedCharacter
    {
        [Fact]
        public void Test1()
        {
            ExecuteBrute("total").Should().Be("o");
            ExecuteBrute("teeter").Should().Be("r");
            ExecuteBrute("aabbcc").Should().Be(null);

            Execute("total").Should().Be("o");
            Execute("teeter").Should().Be("r");
            Execute("aabbcc").Should().Be(null);

            ExecuteFinal("total").Should().Be("o");
            ExecuteFinal("teeter").Should().Be("r");
            ExecuteFinal("aabbcc").Should().Be(null);
        }

        /// <summary>
        /// O(N^2)
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public string ExecuteBrute(string str)
        {
            for (int i = 0; i < str.Length; i++)
            {
                char pos = str[i];
                bool hasDuplication = false;

                for (int j = 0; j < str.Length; j++)
                {
                    if (i == j)
                        continue;

                    if (str[j] == pos)
                    {
                        hasDuplication = true;
                        break;
                    }
                }

                if (hasDuplication == false)
                    return pos.ToString();
            }

            return null;
        }

        /// <summary>
        /// O(N) - Ýki tane dictionary kullanýyor.
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public string Execute(string str)
        {
            // POST-EDIT:
            // Burada pozisyonlarý tutuyorum ama gerek yok. Pozisyonlarla (index) iþim yok benim, benim iþim deðerler ile.

            // total
            // teeter
            var counter = new Dictionary<char, int>();
            var positions = new Dictionary<char, int>();

            for (var index = 0; index < str.Length; index++)
            {
                char c = str[index];
                if (counter.ContainsKey(c)) 
                {
                    positions.Remove(c);
                }
                else
                {
                    counter[c] = 1;

                    if (positions.ContainsKey(c))
                    {
                        if(positions[c] < index)
                            positions[c] = index;
                    }
                    else
                    {
                        positions[c] = index;
                    }
                }
            }

            var lowestPos = int.MaxValue;
            string firstLetter = null;

            foreach (var positionKeyValue in positions)
            {
                if (positionKeyValue.Value < lowestPos)
                {
                    lowestPos = positionKeyValue.Value;
                    firstLetter = positionKeyValue.Key.ToString();
                }
            }

            return firstLetter;
        }

        /// <summary>
        /// O(N) - Bu bir öncekine kýyasla tek bir dictionary kullanýyor. Ayrýca sondaki check iþlemi çok daha mantýklý ve güzel.
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public string ExecuteFinal(string str)
        {
            // Pozisyonlarla iþim yok. Deðerlerlerle ve onlarýn adetleriyle iþim var.

            // total
            // teeter
            var characterCountDict = new Dictionary<char, int>();

            foreach (var c in str)
            {
                if (characterCountDict.ContainsKey(c))
                    characterCountDict[c]++;
                else
                    characterCountDict[c] = 1;
            }

            foreach (var c in str)
            {
                if (characterCountDict.ContainsKey(c) && characterCountDict[c] == 1)
                    return c.ToString();
            }

            return null;
        }
    }
}