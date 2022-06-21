using System;
using System.Collections.Generic;
using System.Linq;

namespace Flower_Wreaths
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] lilies = Console.ReadLine()
                            .Split(", ")
                            .Select(int.Parse)
                            .ToArray();
            int[] roses = Console.ReadLine()
                            .Split(", ")
                            .Select(int.Parse)
                            .ToArray();
            Stack<int> liliesStack = new Stack<int>(lilies);
            Queue<int> rosesQueue = new Queue<int>(roses);
            int wreathCount = 0;
            int leftFlowers = 0;

            while (liliesStack.Count>0&&rosesQueue.Count>0)
            {
                int currLily = liliesStack.Pop();
                int currRose = rosesQueue.Dequeue();
                int sum = currLily + currRose;
                if (sum==15)
                {
                    wreathCount++;
                }
                else if (sum<15)
                {
                    leftFlowers += sum;
                }
                else 
                {
                    while (sum>15)
                        sum -= 2;
                    if (sum == 15)
                    {
                        wreathCount++;
                    }
                    else if (sum < 15)
                    {
                        leftFlowers += sum;
                    }
                }
            }
            wreathCount += leftFlowers / 15;
            if (wreathCount>=5)
            {
                Console.WriteLine($"You made it, " +
                    $"you are going to the competition with {wreathCount} wreaths!");
            }
            else
            {
                Console.WriteLine($"You didn't make it," +
                    $" you need {5-wreathCount} wreaths more!");
            }
        }
    }
}
