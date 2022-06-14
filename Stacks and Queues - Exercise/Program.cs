using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _05.FashionBoutique
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> inputClothes =Console.ReadLine().Split().Select(int
                .Parse).ToList();
            Stack<int> clothes = new Stack<int>(inputClothes);
            int rackCapacity = int.Parse(Console.ReadLine());
            int counter = 1;
            int sum = 0;
            
            while (clothes.Any())
            {
                if (sum+clothes.Peek()<=rackCapacity)
                {
                sum += clothes.Pop();

                }
                else
                {
                    sum = 0;
                    counter++;

                }
            }

            
            Console.WriteLine(counter);
        }
    }
}