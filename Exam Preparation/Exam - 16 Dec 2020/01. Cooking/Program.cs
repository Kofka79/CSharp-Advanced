using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Cooking
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<int> liquids = new Queue<int>(Console.ReadLine().Split(" ").
                Select(int.Parse));
            Stack<int>ingredients=new Stack<int>(Console.ReadLine().Split(" ").
                Select(int.Parse));
            int sum = 0;
            int breadCount = 0;
            int cakeCount = 0;
            int pastryCount = 0;
            int fruitPieCount = 0;
            //Bread   25
            //Cake    50
            //Pastry  75
            //Fruit Pie   100

            while (liquids.Count>0&&ingredients.Count>0)
            {
                int currLiquid = liquids.Peek();
                int currIngredient = ingredients.Peek();
                sum = currLiquid + currIngredient;
                if (sum==25)
                {
                    breadCount++;
                    liquids.Dequeue();
                    ingredients.Pop();
                }
                else if (sum==50)
                {
                    cakeCount++;
                    liquids.Dequeue();
                    ingredients.Pop();
                }
                else if (sum==75)
                {
                    pastryCount++;
                    liquids.Dequeue();
                    ingredients.Pop();
                }
                else if (sum==100)
                {
                    fruitPieCount++;
                    liquids.Dequeue();
                    ingredients.Pop();
                }
                else
                {
                    liquids.Dequeue();
                    currIngredient += 3;
                    ingredients.Pop();
                    ingredients.Push(currIngredient);

                }
            }
            if (breadCount>=1&&pastryCount>=1&&fruitPieCount>=1&&cakeCount>=1)
            {
                Console.WriteLine("Wohoo! You succeeded in cooking all the food!");
            }
            else
            {
                Console.WriteLine("Ugh, what a pity! You didn't have enough materials to cook everything.");
            }
            if (liquids.Count<=0)
            {
                Console.WriteLine("Liquids left: none");
            }
            else
            {
                Console.WriteLine($"Liquids left: {string.Join(", ", liquids)}");
            }
            if (ingredients.Count<=0)
            {
                Console.WriteLine("Ingredients left: none");
            }
            else
            {
                Console.WriteLine($"Ingredients left: {string.Join(", ", ingredients)}");
            }
            //o   "Bread: {amount}"
            //o   "Cake: {amount}"
            //o   "Fruit Pie: {amount}"
            //o   "Pastry: {amount}"
            Console.WriteLine($"Bread: {breadCount}");
            Console.WriteLine($"Cake: {cakeCount}");
            Console.WriteLine($"Fruit Pie: {fruitPieCount}");
            Console.WriteLine($"Pastry: {pastryCount}");
        }
    }
}
