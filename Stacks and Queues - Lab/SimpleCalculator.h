using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _01.StackAndQueue
{
    class Program
    {
        static void Main(string[] args)
        {
            
            string [] input = Console.ReadLine().Split(" ").ToArray();
            Stack<string> stack = new Stack<string>(input);
            int sum = 0;
            string sign = string.Empty;
            Stack<string> reversed = new Stack<string>();
            while (stack.Count != 0)
            {
                reversed.Push(stack.Pop());
            }

            for (int i = 0; i < input.Length; i++)

            {
                if (input[i] != "+" && input[i] != "-")
                {
                    if (sign == "minus")
                    {
                        sum -= int.Parse(reversed.Pop());

                    }
                    else
                    {
                        sum += int.Parse(reversed.Pop());
                    }
                }
                else
                {
                    if (input[i] == "+")
                    {
                        sign = "plus";
                    }
                    else
                    {
                        sign = "minus";
                    }
                    reversed.Pop();
                }
            }
            Console.WriteLine(sum);
        }
    }
}
