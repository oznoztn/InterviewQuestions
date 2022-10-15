using FluentAssertions;

namespace HackerRank;

public class GetMinimumDifference
{
    [Fact]
    public void Test()
    {
        //GetMinimumDifference(
        //    new List<string>() { "tea, act" },
        //    new List<string>() { "", "act" }).Should().BeEquivalentTo(new List<int>() { -1, 0 });

        Execute(
                new List<string>() { "zzz", "xxx" },
                new List<string>() { "zzz", "xxx" })
            .Should().BeEquivalentTo(new List<int>() { 0, 0 });

        Execute(
                new List<string>() { "zzz", "xxx" },
                new List<string>() { "zzzzzzzzzzz", "xxxxxxxx" })
            .Should().BeEquivalentTo(new List<int>() { -1, -1 });

        Execute(
                new List<string>() {"tea", "tea", "act"},
                new List<string>() {"ate", "toe", "acts"})
            .Should().BeEquivalentTo(new List<int>() { 0, 1, -1});
    }

    public List<int> Execute(List<string> a, List<string> b)
    {
        var result = new List<int>();

        for (int i = 0; i < a.Count; i++)
        {
            if (a[i].Length != b[i].Length)
            {
                result.Add(-1);
                continue;
            }

            var identifier = 0;

            // tea - tea - act
            // ate - toe - acts

            var charSpace = new int[128];

            for (int j = 0; j < a[i].Length; j++)
            {
                char ch = a[i][j];
                charSpace[ch]++;
            }
            
            for (int j = 0; j < b[i].Length; j++)
            {
                char ch = b[i][j];
                charSpace[ch]--;
            }

            for (int k = 0; k < 128; k++)
            {
                if (charSpace[k] != 0)
                {
                    identifier += Math.Abs(charSpace[k]);
                }
            }

            result.Add(identifier / 2);
        }

        return result;
    }
}