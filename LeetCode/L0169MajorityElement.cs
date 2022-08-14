using System;
using System.Collections.Generic;
using FluentAssertions;
using Xunit;

namespace LeetCode
{
    /// <summary>
    /// 1374. Generate a String With Characters That Have Odd Counts
    /// </summary>
    public class L0169MajorityElement
    {
        [Fact]
        public void Test()
        {
            Exec(new[] { 2, 2, 1, 1, 1, 2, 2 }).Should().Be(2);
            Exec(new[] { 3, 2, 3 }).Should().Be(3);

            Exec(new[] { 3 }).Should().Be(3);

            ExecBinarySort(new[] { 2, 2, 1, 1, 1, 2, 2 }).Should().Be(2);
            ExecBinarySort(new[] { 3, 2, 3 }).Should().Be(3);

            ExecBinarySort(new[] { 3 }).Should().Be(3);
        }

        public int Exec(int[] nums)
        {
            if (nums.Length == 1 || nums.Length == 2)
                return nums[0];

            var dict = new Dictionary<int, int>();

            foreach (var n in nums)
            {
                if (dict.ContainsKey(n))
                    dict[n] += 1;
                else
                    dict.Add(n, 1);
            }

            int m = 0;
            int mVal = 0;
            foreach (var keyValPair in dict)
            {
                if (keyValPair.Value > mVal)
                {
                    m = keyValPair.Key;
                    mVal = keyValPair.Value;
                }
            }

            return m;
        }

        public int ExecBinarySort(int[] nums)
        {
            Array.Sort(nums);

            return nums[nums.Length / 2];
        }
    }
}