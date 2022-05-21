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

            string[] name = Console.ReadLine().Split(" ").ToArray();
            int n = int.Parse(Console.ReadLine());
            Queue<string> names = new Queue<string>(name);
            while (names.Count()>1)
            {
            for (int i = 1; i < n; i++)
            {

                    names.Enqueue(names.Dequeue());
               
            }
                    Console.WriteLine($"Removed {names.Dequeue()}");

            }
            Console.WriteLine($"Last is {names.Dequeue()}");
        }
    }
}
