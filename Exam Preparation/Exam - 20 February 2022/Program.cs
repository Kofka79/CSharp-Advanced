using System;
using System.Collections.Generic;
using System.Linq;

namespace Bakery
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] water = Console.ReadLine()
                            .Split()
                            .Select(double.Parse)
                            .ToArray();
            double[] flour = Console.ReadLine()
                            .Split()
                            .Select(double.Parse)
                            .ToArray();
            Stack<double> flourStack = new Stack<double>(flour);
            Queue<double> waterQueue = new Queue<double>(water);

                int muffinCount = 0;
                int croissantCount = 0;
                int baguetteCount = 0;
                int bagelCount = 0;
            
            Dictionary<string, int> bakery = new Dictionary<string, int>();
            bakery.Add("Muffin", 0);
            bakery.Add("Croissant", 0);
            bakery.Add("Bagel", 0);
            bakery.Add("Baguette", 0);
            
            while (flourStack.Count>0&&waterQueue.Count>0)
            {
                double currFlour = flourStack.Pop();
                double currWater = waterQueue.Dequeue();
                double ratio = currWater * 100 / (currWater + currFlour);
                
                if (ratio==40)
                {
                    bakery["Muffin"]++;
                }
                else if (ratio==30)
                {
                    //baguetteCount++;
                    bakery["Baguette"]++;
                }
                else if (ratio==20)
                {
                    //bagelCount++;
                    bakery["Bagel"]++;
                }
                else if (ratio==50)
                {
                    //croissantCount++;
                    bakery["Croissant"]++;
                }
                else
                {
                    double flourLeft = currFlour - currWater;
                    //croissantCount++;
                    bakery["Croissant"]++;
                    flourStack.Push(flourLeft);
                }

            }
            //Console.WriteLine(muffinCount);
            //Console.WriteLine(bagelCount);
            //Console.WriteLine(baguetteCount);
            //Console.WriteLine(croissantCount);
            foreach (var product in bakery.OrderByDescending(x=>x.Value).ThenBy(x=>x.Key))
            {
                if (product.Value>0)
                {
                    Console.WriteLine($"{product.Key}: {product.Value}");
                }
                
            }
            if (waterQueue.Any())
            {
                Console.WriteLine($"Water left: {string.Join(", ", waterQueue)}");
            }
            else
            {
                Console.WriteLine("Water left: None");
            }
            if (flourStack.Any())
            {
                Console.WriteLine($"Flour left: {string.Join(", ", flourStack)}");
            }
            else
            {
                Console.WriteLine("Flour left: None");
            }
        }
    }
}
