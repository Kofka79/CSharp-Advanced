using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.BirthdayCelebration
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] guests = Console.ReadLine().Split()
                        .Select(int.Parse).ToArray();
            int[] plates = Console.ReadLine().Split()
                        .Select(int.Parse).ToArray();
            Stack<int> platesStack = new Stack<int>(plates);
            Queue<int> guestsQueue = new Queue<int>(guests);
            
            int waste = 0;
            while (platesStack.Count > 0 && guestsQueue.Count > 0)
            {
                int currGuest = guestsQueue.Dequeue();
                int currPlate = platesStack.Peek();
                
                if (currPlate >= currGuest)
                {
                    waste += currPlate - currGuest;
                    platesStack.Pop();
                    
                }
                else if (currPlate<currGuest)
                {
                    while (currGuest>=0)
                    {
                        currGuest -= currPlate;
                        platesStack.Pop();
                        currPlate = platesStack.Peek();
                        if (currPlate>=currGuest)
                        {
                            waste += currPlate - currGuest;
                            platesStack.Pop();
                            
                            break;
                        }

                    }
                    
                }
            }
            if (platesStack.Count>0)
            {
                Console.WriteLine($"Plates: {string.Join(" ", platesStack)}");
            }
            else if (guestsQueue.Count>0)
            {
                Console.WriteLine($"Guests: {string.Join(" ", guestsQueue)}");
            }
            Console.WriteLine($"Wasted grams of food: {waste}");
            
        }
    }
}
