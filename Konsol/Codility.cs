using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Konsol
{
    class Solution
    {
        public int Exec(int[] A, int K)
        {
            if (K > A.Length)
                return -1;

            var result = 0;
            var oddNumbers = new List<int>();
            var evenNumbers = new List<int>();
            
            foreach (var n in A)
            {
                if (n % 2 == 1)
                    oddNumbers.Add(n);
                else
                    evenNumbers.Add(n);
            }

            oddNumbers.Sort();
            evenNumbers.Sort();

            var e = evenNumbers.Count - 1;
            var o = oddNumbers.Count - 1;
            while (K > 0)
            {
                if (K % 2 == 1)
                {
                    if (e >= 0)
                    {
                        result += evenNumbers[e];
                        e--;
                    }
                    else
                    {
                        return -1;
                    }
                    K--;
                }
                else if (e >= 1 && o >= 1)
                {
                    if (evenNumbers[e] + evenNumbers[e - 1] <= oddNumbers[o] + oddNumbers[o - 1])
                    {
                        result += oddNumbers[o] + oddNumbers[o - 1];
                        o -= 2;
                    }
                    else
                    {
                        result += evenNumbers[e] + evenNumbers[e - 1];
                        e -= 2;
                    }
                    K -= 2;
                }
                else if (e >= 1)
                {
                    result += evenNumbers[e] + evenNumbers[e - 1];
                    e -= 2;
                    K -= 2;
                }
                else if (o >= 1)
                {
                    result += oddNumbers[o] + oddNumbers[o - 1];
                    o -= 2;
                    K -= 2;
                }
            }

            return result;
        }
    }
}