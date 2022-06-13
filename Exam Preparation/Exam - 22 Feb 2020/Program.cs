using System;
using System.Collections.Generic;
using System.Linq;

namespace Masterchef
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] firstBox = Console.ReadLine()
                            .Split(" ")
                            .Select(int.Parse)
                            .ToArray();
            int[] secondBox = Console.ReadLine()
                            .Split(" ")
                            .Select(int.Parse)
                            .ToArray();
            Stack<int> secondBoxStack = new Stack<int>(secondBox);
            Queue<int> firstBoxQueue = new Queue<int>(firstBox);
            List<int> claimedItems = new List<int>();
            int totalSum = 0;

            while (firstBoxQueue.Count > 0 && secondBoxStack.Count > 0)
            {
                int currFirst = firstBoxQueue.Peek();
                int currSecond = secondBoxStack.Peek();
                
                totalSum = currFirst+currSecond;

                if (totalSum%2==0)
                {
                    int currTotal = totalSum;
                    claimedItems.Add(currTotal);
                    firstBoxQueue.Dequeue();
                    secondBoxStack.Pop();
                }
                else
                {
                    secondBoxStack.Pop();
                    firstBoxQueue.Enqueue(currSecond);
                }
            }
            if (firstBoxQueue.Count==0)
            {
                Console.WriteLine($"First lootbox is empty");
            }
            if (secondBoxStack.Count==0)
            {
                Console.WriteLine($"Second lootbox is empty");
            }
            int claimedSum = claimedItems.Sum();
            if (claimedSum >= 100)
            {
                Console.WriteLine($"Your loot was epic! Value: {claimedSum}");
            }
            else
            {
                Console.WriteLine($"Your loot was poor... Value: {claimedSum}");
            }
        }
    }
}


