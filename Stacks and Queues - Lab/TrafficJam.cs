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
            int n = int.Parse(Console.ReadLine());
            Queue<string> cars = new Queue<string>();
            string car = Console.ReadLine();
            int count = 0;

            while (car!="end")
            {
                if (car=="green")
                {
                    for (int i = 1; i <= n; i++)
                    {
                        if (cars.Any())
                        {
                        Console.WriteLine($"{cars.Dequeue()} passed!");
                        count++;

                        }
                    }
                }
                else
                {
                cars.Enqueue(car);

                }

                car = Console.ReadLine();
            }
            Console.WriteLine($"{count} cars passed the crossroads.");
        }
    }
}
