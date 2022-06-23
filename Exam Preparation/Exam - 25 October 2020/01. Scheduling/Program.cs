using System;
using System.Collections.Generic;
using System.Linq;

namespace Scheduling
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] tasks = Console.ReadLine()
                            .Split(", ")
                            .Select(int.Parse)
                            .ToArray();
            int[] threads = Console.ReadLine()
                            .Split(" ")
                            .Select(int.Parse)
                            .ToArray();
            Stack<int> taskStack = new Stack<int>(tasks);
            Queue<int> threadQueue = new Queue<int>(threads);
            
            int taskToKill = int.Parse(Console.ReadLine());

            while (true)
            {
                int currTask = taskStack.Peek();
                int currThread = threadQueue.Peek();

                if (currTask != taskToKill)
                {
                    if (currThread >= currTask)
                    {
                        taskStack.Pop();
                        threadQueue.Dequeue();
                    }
                    else
                    {
                        threadQueue.Dequeue();
                    }
                }
                else
                {
                    Console.WriteLine($"Thread with value {currThread} killed task {taskToKill}");
                    Console.Write(string.Join(' ', threadQueue));
                    return;
                    
                }
                
            }
            
        }
    }
}

