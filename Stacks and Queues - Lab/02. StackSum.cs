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
            int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Stack<int> stack = new Stack<int>(input);
            string command = Console.ReadLine().ToLower();
            while (command!="end")
            {
                var commandArg = command.Split();
                string action = commandArg[0].ToLower();
                if (action=="add")
                {
                    int first = int.Parse(commandArg[1]);
                    int second = int.Parse(commandArg[2]);
                    stack.Push(first);
                    stack.Push(second);
                }
                else if (action=="remove")
                {
                    int toRemove = int.Parse(commandArg[1]);
                    if (toRemove<stack.Count)
                    {
                        for (int i = 0; i < toRemove; i++)
                        {
                            stack.Pop();
                        }
                    }
                    
                }
                command = Console.ReadLine().ToLower();
            }
            Console.WriteLine($"Sum: {stack.Sum()}");
        }
    }
}
