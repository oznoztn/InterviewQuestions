using FluentAssertions;
using System;
using Xunit;

namespace Gayle.StringsArrays;

/// <summary>
/// Verilen iki string birbirlerinin permütasyonu mu?
/// str1: ozan, str2: nzao = YES
/// </summary>
public class UnitTest2
{
    [Fact]
    public void Execute()
    {
        IsPermutation("ozan", "znoa").Should().Be(true);
        IsPermutation("ozan", "znoa ").Should().Be(false);

        IsPermutation("silwerhawk", "silwerhaw_").Should().Be(false);
        IsPermutation("silwerhawk", "silwerhawK").Should().Be(false);

        IsPermutation("silwer", "sil er").Should().Be(false);

        IsPermutation("  ", "  ").Should().Be(true);
    }

    [Fact]
    public void Execute2()
    {
        IsPermutationFramework("ozan", "znoa").Should().Be(true);
        IsPermutationFramework("ozan", "znoa ").Should().Be(false);

        IsPermutationFramework("silwerhawk", "silwerhaw_").Should().Be(false);
        IsPermutationFramework("silwerhawk", "silwerhawK").Should().Be(false);

        IsPermutationFramework("silwer", "sil er").Should().Be(false);
            
            
        IsPermutationFramework("  ", "  ").Should().Be(true);
    }

    public bool IsPermutation(string str1, string str2)
    {
        // Yine öncelikle þunlarý sormalý:
        //      1) Stringler için kullanýlan char space nedir? ASCII mi UNICODE mu?
        //      2) Case sentitive mi veya whitespace'ler göz önünde tutulacak mý?

        // Permütasyon sorduðundan iki stringin length'leri eþit olmalýdýr
        if (str1.Length != str2.Length)
            return false;

        // VARSAYIMLAR:
        // Stringler -> ASCII
        // Case sensitive ve whitespace'ler göz önünde tutulmalý

        int[] chars = new int[128];

        foreach (var c in str1)
        {
            chars[(int)c]++;
        }

        foreach (var c in str2)
        {
            if (chars[c] == 0) // Bir önceki iterasyonda c'ye karþýlýk gelen slotun deðerin 1 artýrýlmýþ olmalýydý
                return false;
        }

        return true;
    }

    public bool IsPermutationFramework(string str1, string str2)
    {
        if (str1.Length != str2.Length)
            return false;

        var str1Array = str1.ToCharArray();
        var str2Array = str2.ToCharArray();
            
        Array.Sort(str1Array);
        Array.Sort(str2Array);

        return string.Equals(new string(str1Array), new string(str2Array), StringComparison.InvariantCulture);
    }
}