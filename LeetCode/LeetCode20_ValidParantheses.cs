using System.Collections.Generic;
using FluentAssertions;
using Xunit;

namespace LeetCode
{
    /// <summary>
    /// 20. Valid Parentheses
    /// </summary>
    public class LeetCode20_ValidParantheses
    {
        [Fact]
        public void Test()
        {
            this.IsValid("").Should().Be(true);

            this.IsValid("(){}[]").Should().Be(true);
            
            this.IsValid("[{()}]").Should().Be(true);
            this.IsValid("[{(())}]").Should().Be(true);
            this.IsValid("({[]})").Should().Be(true);
            this.IsValid("()").Should().Be(true);
            
            this.IsValid("(]").Should().Be(false);
            this.IsValid("[{(]}]").Should().Be(false);

            this.IsValid("(").Should().Be(false);
        }

        public bool IsValid(string input)
        {
            if (input == "")
                return true;

            if (input.Length % 2 != 0)
                return false;

            Stack<char> stack = new();

            foreach (char c in input)
            {
                if (c == '(' || c == '{' || c == '[')
                {
                    stack.Push(c);
                }
                else if (c == ')')
                {
                    if (stack.Peek() == '(')
                    {
                        stack.Pop();
                    }
                }
                else if (c == '}')
                {
                    if (stack.Peek() == '{')
                    {
                        stack.Pop();
                    }
                }
                else if (c == ']')
                {
                    if (stack.Peek() == '[')
                    {
                        stack.Pop();
                    }
                }
            }

            if (stack.Count == 0)
                return true;


            return false;

            //for (var i = 0; i < input.Length; i++)
            //{
            //    if (i == input.Length / 2)
            //        break;

            //    char c = input[i];
            //    if (c == '[')
            //    {
            //        if (stack.Pop() != ']')
            //            return false;
            //    }
            //    else if (c == '{')
            //    {
            //        if (stack.Pop() != '}')
            //            return false;
            //    }
            //    else if (c == '(')
            //    {
            //        if (stack.Pop() != ')')
            //            return false;
            //    }
            //    else
            //    {
            //        return false;
            //    }
            //}

            //return true;
        }
    }
}