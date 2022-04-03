using System.Collections.Generic;
using FluentAssertions;
using Xunit;

namespace LeetCode
{
    /// <summary>
    /// Given a non-empty array of integers nums, every element appears twice except for one.
    /// Find that single one.
    /// 
    /// You must implement a solution with a linear runtime complexity
    /// and use only constant extra space.
    /// 
    /// Example 1:
    /// 
    /// Input: nums = [2,2,1]
    /// Output: 1
    /// 
    /// Example 2:
    /// 
    /// Input: nums = [4,1,2,1,2]
    /// Output: 4
    /// 
    /// Example 3:
    /// 
    /// Input: nums = [1]
    /// Output: 1
    /// 
    /// </summary>
    public class L136SingleNumber
    {
        [Fact]
        public void Test()
        {
            SingleNumber(new int[] { 2, 2, 1 }).Should().Be(1);
            SingleNumber(new int[] { 4, 2, 1, 1, 2 }).Should().Be(4);

            BitManipulation(new int[] { 2, 2, 1 }).Should().Be(1);
            BitManipulation(new int[] { 4, 2, 1, 1, 2 }).Should().Be(4);
        }

        /// <summary>
        /// Güzel fakat olmaz. Time Complexity & Space Complexity = O(N).
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int SingleNumber(int[] nums)
        {
            var hashSet = new HashSet<int>();

            foreach (int num in nums)
            {
                if(hashSet.Contains(num))
                    hashSet.Remove(num);
                else
                    hashSet.Add(num);
            }

            foreach (var n in nums)
            {
                if (hashSet.Contains(n))
                    return n;
            }

            return 0;
        }

        /// <summary>
        /// Bit Manipülasyonu
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int BitManipulation(int[] nums)
        {
            var result = 0; // n ^ 0 = n olduğundan.

            for (int i = 0; i < nums.Length; i++)
            {
                result = result ^ nums[i];
            }
            
            return result;
        }
    }
}
