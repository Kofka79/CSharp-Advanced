using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Meal_Plan
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] meals = Console.ReadLine().Split();
            int[] dailyIntake = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Queue<string> mealsQueue = new Queue<string>(meals);
            Stack<int> dailyCaloriesStack = new Stack<int>(dailyIntake);

            
            int leftMealCal = 0;

            int numberOfMeals = 0;
            int currentCalories = 0;
            while (mealsQueue.Count > 0 && dailyCaloriesStack.Count > 0)
            {

                currentCalories = dailyCaloriesStack.Pop();


                while (currentCalories > 0 && mealsQueue.Any())
                {
                    string currentMeal = mealsQueue.Dequeue();
                    numberOfMeals++;
                    currentCalories -= EatMeal(currentMeal);
                   
                }
                        if (currentCalories < 0 )
                        {
                            leftMealCal = currentCalories;
                                if (dailyCaloriesStack.Any())
                                {
                                    int nextDay = dailyCaloriesStack.Pop();
                                    dailyCaloriesStack.Push(nextDay + currentCalories);
                                }
                            
                        }

                        if (!mealsQueue.Any() && currentCalories>0)
                        {
                            dailyCaloriesStack.Push(currentCalories);
                        }
                    }
                



            
            if (mealsQueue.Count == 0)
            {
                Console.WriteLine($"John had {numberOfMeals} meals.");
                Console.WriteLine($"For the next few days, he can eat" +
                    $" {string.Join(", ", dailyCaloriesStack)} calories.");
            }
            else if (dailyCaloriesStack.Count== 0)
            {
                Console.WriteLine($"John ate enough, he had {numberOfMeals} meals.");
                Console.WriteLine($"Meals left: {string.Join(", ", mealsQueue)}.");
            }
        }

        private static int EatMeal(string meal)
        {
            int calories = 0;
            if (meal == "salad")
            {
                calories = 350;
            }
            if (meal == "soup")
            {
                calories = 490;
            }
            if (meal == "pasta")
            {
                calories = 680;
            }
            if (meal == "steak")
            {
                calories = 790;
            }
            return calories;
        }
    }
}
