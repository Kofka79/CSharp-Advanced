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

            string name = Console.ReadLine();
            Queue<string> names = new Queue<string>();

            while (name!="End")
            {
                if (name=="Paid")
                {
                    while (names.Any())
                    {
                        Console.WriteLine(names.Dequeue());
                    }
                    names.Clear();
                }
                else
                {

                names.Enqueue(name);
                }
                name = Console.ReadLine();
            }
            Console.WriteLine($"{names.Count} people remaining.");
        }
    }
}
