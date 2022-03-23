using System;
using FluentAssertions;
using Xunit;

namespace Experiments;

public class FindMissingOddNumber
{
    [Fact]
    public void Test()
    {
        Exec(new[] { 1, 3, 5, 7, 9, 13, 15 }).Should().Be(11);
        Exec(new[] { 15, 13, 9, 7, 5, 3, 1 }).Should().Be(11);
    }

    public int Exec(int[] numbers)
    {
        // Asc-desc olabilir.
        // Mutlaka bir tane ve yalnýzca bir tane eskik tek sayý var.

        // Örnek inputlar:
        // [1, 3, 5, 7, 9, _, 13, 15]
        // [15, 13, _, 9, 7, 5, 3, 1]

        Array.Sort(numbers);
        for (int i = 0; i < numbers.Length; i++)
        {
            if (numbers[i + 1] != numbers[i] + 2)
                return numbers[i] + 2;
        }

        return -1;
    }
}