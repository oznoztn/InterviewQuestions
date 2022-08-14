using System;
using System.Collections.Generic;
using FluentAssertions;
using Xunit;

namespace LeetCode
{
    // LOWERCASE HARFLERDEN OLU�TU�UNU S�YL�YOR
    // 'a' => 97
    // 'z' => 122

    // 128 TANE ASCII KARAKTER VARDIR.
    // 128'L�K B�R ARRAY OLU�TURMAK YER�NE 26 KARAKTERL�K B�R ARRAY OLU�TURDUM...

    // '\0' -> SET ED�LMEM��, DEFAULT, BO� CHAR DE�ER�.

    /// <summary>
    /// 20. Valid Parentheses
    /// </summary>
    public class L0389FindTheDifference
    {
        [Fact]
        public void Test()
        {
            FindTheDifference("abcd", "abcde").Should().Be('e');
            FindTheDifference("", "y").Should().Be('y');
            FindTheDifference("y", "").Should().Be('y');
            FindTheDifference("ab", "a").Should().Be('a');
            FindTheDifference("aa", "a").Should().Be('a');
            FindTheDifference(
                "ymbgaraibkfmvocpizdydugvalagaivdbfsfbepeyccqfepzvtpyxtbadkhmwmoswrcxnargtlswqemafandgkmydtimuzvjwxvlfwlhvkrgcsithaqlcvrihrwqkpjdhgfgreqoxzfvhjzojhghfwbvpfzectwwhexthbsndovxejsntmjihchaotbgcysfdaojkjldprwyrnischrgmtvjcorypvopfmegizfkvudubnejzfqffvgdoxohuinkyygbdzmshvyqyhsozwvlhevfepdvafgkqpkmcsikfyxczcovrmwqxxbnhfzcjjcpgzjjfateajnnvlbwhyppdleahgaypxidkpwmfqwqyofwdqgxhjaxvyrzupfwesmxbjszolgwqvfiozofncbohduqgiswuiyddmwlwubetyaummenkdfptjczxemryuotrrymrfdxtrebpbjtpnuhsbnovhectpjhfhahbqrfbyxggobsweefcwxpqsspyssrmdhuelkkvyjxswjwofngpwfxvknkjviiavorwyfzlnktmfwxkvwkrwdcxjfzikdyswsuxegmhtnxjraqrdchaauazfhtklxsksbhwgjphgbasfnlwqwukprgvihntsyymdrfovaszjywuqygpvjtvlsvvqbvzsmgweiayhlubnbsitvfxawhfmfiatxvqrcwjshvovxknnxnyyfexqycrlyksderlqarqhkxyaqwlwoqcribumrqjtelhwdvaiysgjlvksrfvjlcaiwrirtkkxbwgicyhvakxgdjwnwmubkiazdjkfmotglclqndqjxethoutvjchjbkoasnnfbgrnycucfpeovruguzumgmgddqwjgdvaujhyqsqtoexmnfuluaqbxoofvotvfoiexbnprrxptchmlctzgqtkivsilwgwgvpidpvasurraqfkcmxhdapjrlrnkbklwkrvoaziznlpor",
                "qhxepbshlrhoecdaodgpousbzfcqjxulatciapuftffahhlmxbufgjuxstfjvljybfxnenlacmjqoymvamphpxnolwijwcecgwbcjhgdybfffwoygikvoecdggplfohemfypxfsvdrseyhmvkoovxhdvoavsqqbrsqrkqhbtmgwaurgisloqjixfwfvwtszcxwktkwesaxsmhsvlitegrlzkvfqoiiwxbzskzoewbkxtphapavbyvhzvgrrfriddnsrftfowhdanvhjvurhljmpxvpddxmzfgwwpkjrfgqptrmumoemhfpojnxzwlrxkcafvbhlwrapubhveattfifsmiounhqusvhywnxhwrgamgnesxmzliyzisqrwvkiyderyotxhwspqrrkeczjysfujvovsfcfouykcqyjoobfdgnlswfzjmyucaxuaslzwfnetekymrwbvponiaojdqnbmboldvvitamntwnyaeppjaohwkrisrlrgwcjqqgxeqerjrbapfzurcwxhcwzugcgnirkkrxdthtbmdqgvqxilllrsbwjhwqszrjtzyetwubdrlyakzxcveufvhqugyawvkivwonvmrgnchkzdysngqdibhkyboyftxcvvjoggecjsajbuqkjjxfvynrjsnvtfvgpgveycxidhhfauvjovmnbqgoxsafknluyimkczykwdgvqwlvvgdmufxdypwnajkncoynqticfetcdafvtqszuwfmrdggifokwmkgzuxnhncmnsstffqpqbplypapctctfhqpihavligbrutxmmygiyaklqtakdidvnvrjfteazeqmbgklrgrorudayokxptswwkcircwuhcavhdparjfkjypkyxhbgwxbkvpvrtzjaetahmxevmkhdfyidhrdeejapfbafwmdqjqszwnwzgclitdhlnkaiyldwkwwzvhyorgbysyjbxsspnjdewjxbhpsvj")
                .Should().Be('t');


            FindTheDifference2("abcd", "abcde").Should().Be('e');
            FindTheDifference2("", "y").Should().Be('y');
            FindTheDifference2("y", "").Should().Be('y');
            FindTheDifference2("ab", "a").Should().Be('a');
            FindTheDifference2("aa", "a").Should().Be('a');
            FindTheDifference2(
                "ymbgaraibkfmvocpizdydugvalagaivdbfsfbepeyccqfepzvtpyxtbadkhmwmoswrcxnargtlswqemafandgkmydtimuzvjwxvlfwlhvkrgcsithaqlcvrihrwqkpjdhgfgreqoxzfvhjzojhghfwbvpfzectwwhexthbsndovxejsntmjihchaotbgcysfdaojkjldprwyrnischrgmtvjcorypvopfmegizfkvudubnejzfqffvgdoxohuinkyygbdzmshvyqyhsozwvlhevfepdvafgkqpkmcsikfyxczcovrmwqxxbnhfzcjjcpgzjjfateajnnvlbwhyppdleahgaypxidkpwmfqwqyofwdqgxhjaxvyrzupfwesmxbjszolgwqvfiozofncbohduqgiswuiyddmwlwubetyaummenkdfptjczxemryuotrrymrfdxtrebpbjtpnuhsbnovhectpjhfhahbqrfbyxggobsweefcwxpqsspyssrmdhuelkkvyjxswjwofngpwfxvknkjviiavorwyfzlnktmfwxkvwkrwdcxjfzikdyswsuxegmhtnxjraqrdchaauazfhtklxsksbhwgjphgbasfnlwqwukprgvihntsyymdrfovaszjywuqygpvjtvlsvvqbvzsmgweiayhlubnbsitvfxawhfmfiatxvqrcwjshvovxknnxnyyfexqycrlyksderlqarqhkxyaqwlwoqcribumrqjtelhwdvaiysgjlvksrfvjlcaiwrirtkkxbwgicyhvakxgdjwnwmubkiazdjkfmotglclqndqjxethoutvjchjbkoasnnfbgrnycucfpeovruguzumgmgddqwjgdvaujhyqsqtoexmnfuluaqbxoofvotvfoiexbnprrxptchmlctzgqtkivsilwgwgvpidpvasurraqfkcmxhdapjrlrnkbklwkrvoaziznlpor",
                "qhxepbshlrhoecdaodgpousbzfcqjxulatciapuftffahhlmxbufgjuxstfjvljybfxnenlacmjqoymvamphpxnolwijwcecgwbcjhgdybfffwoygikvoecdggplfohemfypxfsvdrseyhmvkoovxhdvoavsqqbrsqrkqhbtmgwaurgisloqjixfwfvwtszcxwktkwesaxsmhsvlitegrlzkvfqoiiwxbzskzoewbkxtphapavbyvhzvgrrfriddnsrftfowhdanvhjvurhljmpxvpddxmzfgwwpkjrfgqptrmumoemhfpojnxzwlrxkcafvbhlwrapubhveattfifsmiounhqusvhywnxhwrgamgnesxmzliyzisqrwvkiyderyotxhwspqrrkeczjysfujvovsfcfouykcqyjoobfdgnlswfzjmyucaxuaslzwfnetekymrwbvponiaojdqnbmboldvvitamntwnyaeppjaohwkrisrlrgwcjqqgxeqerjrbapfzurcwxhcwzugcgnirkkrxdthtbmdqgvqxilllrsbwjhwqszrjtzyetwubdrlyakzxcveufvhqugyawvkivwonvmrgnchkzdysngqdibhkyboyftxcvvjoggecjsajbuqkjjxfvynrjsnvtfvgpgveycxidhhfauvjovmnbqgoxsafknluyimkczykwdgvqwlvvgdmufxdypwnajkncoynqticfetcdafvtqszuwfmrdggifokwmkgzuxnhncmnsstffqpqbplypapctctfhqpihavligbrutxmmygiyaklqtakdidvnvrjfteazeqmbgklrgrorudayokxptswwkcircwuhcavhdparjfkjypkyxhbgwxbkvpvrtzjaetahmxevmkhdfyidhrdeejapfbafwmdqjqszwnwzgclitdhlnkaiyldwkwwzvhyorgbysyjbxsspnjdewjxbhpsvj")
                .Should().Be('t');
        }

        public char FindTheDifference(string str1, string str2)
        {
            if (str1.Length == 0)
                return str2[0];
            if (str2.Length == 0)
                return str1[0];
            if (str2.Length == 1)
                return str2[0];
            if (str1.Length == 1)
                return str1[0];

            var dictionary = new Dictionary<char, int>();
            
            for (int i = 0; i < str1.Length; i++)
            {
                if (dictionary.ContainsKey(str1[i]))
                {
                    dictionary[str1[i]]++;
                }
                else
                {
                    dictionary[str1[i]] = 1;
                }
            }

            for (int i = 0; i < str2.Length; i++)
            {
                if (dictionary.ContainsKey(str2[i]))
                {
                    dictionary[str2[i]]--;
                }
                else
                {
                    return str2[i];
                }
            }

            foreach (KeyValuePair<char, int> keyValuePair in dictionary)
            {
                if (keyValuePair.Value != 0)
                    return keyValuePair.Key;
            }

            throw new InvalidOperationException();
        }

        /// <summary>
        /// Bu Dictionary kullanm�yor. Di�erine g�re �ok daha h�zl� ve az memory t�ketiyor.
        /// </summary>
        /// <param name="str1"></param>
        /// <param name="str2"></param>
        /// <returns></returns>
        public char FindTheDifference2(string str1, string str2)
        {
            if (str1.Length == 0)
                return str2[0];
            if (str2.Length == 0)
                return str1[0];

            // LOWERCASE HARFLERDEN OLU�TU�UNU S�YL�YOR
            // 'a' => 97
            // 'z' => 122

            // 128 TANE ASCII KARAKTER VARDIR.
            // 128'L�K B�R ARRAY OLU�TURMAK YER�NE 26 KARAKTERL�K B�R ARRAY OLU�TURDUM...

            // '\0' -> SET ED�LMEM��, DEFAULT, BO� CHAR DE�ER�.

            var chars = new int[122 - 97 + 1];

            for (int i = 0; i < str1.Length; i++)
            {
                chars[str1[i] - 97]++;
            }

            var x = 0;
            for (int i = 0; i < str2.Length; i++)
            {
                // 1. string okunurken str2[i] karakterinin mapping array i�ine at�lm�� olmas� gerekir.
                // At�lmam�� ise sonradan eklenmi� demektir. Bu da arad���m�z harf olur.
                if (chars[str2[i] - 97] == 0)
                    return str2[i];
                else
                {
                    x++;
                    chars[str2[i] - 97]--;
                }
            }

            return str2[0];
        }
    }


}