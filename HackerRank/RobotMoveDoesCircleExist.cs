using System.Collections.Generic;
using FluentAssertions;
using Xunit;

namespace HackerRank;

public class RobotMoveDoesCircleExist
{
    [Fact]
    public void Test()
    {
        DoesCircleExist(new List<string>() {"R"}).Should().BeEquivalentTo(new List<string>() {"YES"});
        DoesCircleExist(new List<string>() {"L"}).Should().BeEquivalentTo(new List<string>() {"YES"});
        DoesCircleExist(new List<string>() {"G"}).Should().BeEquivalentTo(new List<string>() {"NO"});
        DoesCircleExist(new List<string>() {"RGRG"}).Should().BeEquivalentTo(new List<string>() {"YES"});

        DoesCircleExist(new List<string>() {"R", "L", "G", "RGRG"}).Should().BeEquivalentTo(new List<string>() {"YES", "YES", "NO", "YES"});
    }

    public List<string> DoesCircleExist(List<string> commands)
    {
        var result = new List<string>();
        
        for (int i = 0; i < commands.Count; i++)
        {
            var command = commands[i];

            if (command.Length == 1 && command[0] == 'G')
            {
                result.Add("NO");
                continue;
            }
            
            if (command.Length == 1 && command[0] == 'L' ||
                command.Length == 1 && command[0] == 'R')
            {
                result.Add("YES");
                continue;
            }

            if (command.Length % 2 != 0)
            {
                result.Add("NO");
                continue;
            }

            var dict = new Dictionary<char, int>();
            for (int j = 0; j < command.Length; j++)
            {
                if (dict.ContainsKey(command[j]))
                {
                    dict[command[j]]--;
                }
                else
                {
                    dict[command[j]] = 1;
                }
            }


            var counter = 0;
            foreach (var kv in dict)
            {
                if(kv.Value != 0)
                    counter++;
            }

            if (counter == 0)
                result.Add("YES");
            else
                result.Add("NO");
        }
        

        return result;
    }
}