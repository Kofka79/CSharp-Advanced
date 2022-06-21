using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Blacksmith
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] steel = Console.ReadLine()
                            .Split(" ")
                            .Select(int.Parse)
                            .ToArray();
            int[] carbon = Console.ReadLine()
                            .Split(" ")
                            .Select(int.Parse)
                            .ToArray();
            Stack<int> carbonStack = new Stack<int>(carbon);
            Queue<int> steelQueue = new Queue<int>(steel);
            Dictionary<int, string> swords = new Dictionary<int, string>
            {
                {70, "Gladius"},
                {80, "Shamshir"},
                {90, "Katana"},
                {110, "Sabre" },
                {150, "Broadsword" }
            };
            Dictionary<string, int> made = new Dictionary<string, int>();
            int sum = 0;

            while (carbonStack.Count > 0 && steelQueue.Count > 0)
            {
                int currCarbon = carbonStack.Peek();
                int currSteel = steelQueue.Peek();
                sum = currCarbon + currSteel;
                if (swords.ContainsKey(sum))
                {
                    if (!made.ContainsKey(swords[sum]))
                    {
                        made.Add(swords[sum], 1);
                    }
                    else
                    {
                        made[swords[sum]]++;
                    }
                    steelQueue.Dequeue();
                    carbonStack.Pop();
                }
                else
                {
                    steelQueue.Dequeue();
                    currCarbon += 5;
                    carbonStack.Pop();
                    carbonStack.Push(currCarbon);
                }
            }
            int count = made.Values.Sum();
            if (made.Count>0)
            {
                Console.WriteLine($"You have forged {count} swords.");
            }
            else
            {
                Console.WriteLine($"You did not have enough resources to forge a sword.");
            }
            if (steelQueue.Count>0)
            {
                Console.WriteLine($"Steel left: {string.Join(", ", steelQueue)}");
            }
            else
            {
                Console.WriteLine($"Steel left: none");
            }
            if (carbonStack.Count>0)
            {
                Console.WriteLine($"Carbon left: {string.Join(", ", carbonStack)}");
            }
            else
            {
                Console.WriteLine($"Carbon left: none");
            }
            if (made.Count>0)
            {
                foreach (var sword in made.OrderBy(x=>x.Key))
                {
                    Console.WriteLine($"{sword.Key}: {sword.Value}");
                }
            }
        }
    }
}
