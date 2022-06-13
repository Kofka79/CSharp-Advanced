using System;
using System.Collections.Generic;
using System.Linq;

namespace Masterchef
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] ingredients = Console.ReadLine()
                            .Split(" ")
                            .Select(int.Parse)
                            .ToArray();
            int[] freshnessLevel = Console.ReadLine()
                            .Split(" ")
                            .Select(int.Parse)
                            .ToArray();
            Stack<int> freshnessStack = new Stack<int>(freshnessLevel);
            Queue<int> ingredientsQueue = new Queue<int>(ingredients);
            Dictionary<int, string> dishToCook = new Dictionary<int, string>
            {
                {150, "Dipping sauce"},
                {250, "Green salad"},
                {300, "Chocolate cake"},
                {400, "Lobster"}
            };
            Dictionary<string, int> cookedDish = new Dictionary<string, int>();
            int totalFreshness = 0;

            while (freshnessStack.Count > 0 && ingredientsQueue.Count > 0)
            {
                int currFreshness = freshnessStack.Peek();
                int currIngredient = ingredientsQueue.Peek();
                if (currIngredient==0)
                {
                    ingredientsQueue.Dequeue();
                    continue;
                }
                totalFreshness = currFreshness * currIngredient;
                
                if (dishToCook.ContainsKey(totalFreshness))
                {
                    string currDish = dishToCook[totalFreshness];
                    if (cookedDish.ContainsKey(currDish))
                    {
                        cookedDish[currDish]++;
                    }
                    else
                    cookedDish.Add(currDish, 1);
                    freshnessStack.Pop();
                    ingredientsQueue.Dequeue();
                }
                else
                {
                    freshnessStack.Pop();
                    ingredientsQueue.Dequeue();
                    currIngredient += 5;
                    ingredientsQueue.Enqueue(currIngredient);
                }
            }
            if (cookedDish.Count<4)
            {
                Console.WriteLine($"You were voted off. Better luck next year.");
            }
            else
            {
                Console.WriteLine($"Applause! The judges are fascinated by your dishes!");
            }
            if (ingredientsQueue.Any())
            {
                Console.WriteLine($"Ingredients left: {ingredientsQueue.Sum()}");
            }
            foreach (var dish in cookedDish.OrderBy(x=>x.Key))
            {
                Console.WriteLine($" # {dish.Key} --> {dish.Value}");
            }
            
        }
    }
}

