using System;
using System.Collections.Generic;
using System.Linq;

namespace Bombs
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] bombEffect = Console.ReadLine()
                            .Split(", ")
                            .Select(int.Parse)
                            .ToArray();
            int[] bombCasing = Console.ReadLine()
                            .Split(", ")
                            .Select(int.Parse)
                            .ToArray();
            Stack<int> casingStack = new Stack<int>(bombCasing);
            Queue<int> effectQueue = new Queue<int>(bombEffect);
            
                //{40, "Datura Bombs"},
                //{60, "Cherry Bombs"},
                //{120, "Smoke Decoy Bombs"},
            
           
            int sum = 0;
            int daturaBomb = 0;
            int cherryBomb = 0;
            int smokeBomb = 0;

            while (casingStack.Count > 0 && effectQueue.Count > 0)
            {
                int currCasing = casingStack.Peek();
                int currEffect = effectQueue.Peek();

                sum = currCasing + currEffect;

                if (sum == 40)
                {
                    daturaBomb++;
                    casingStack.Pop();
                    effectQueue.Dequeue();
                    if (cherryBomb >= 3 && daturaBomb >= 3 && smokeBomb >= 3)
                    {
                        break;
                    }
                }
                else if (sum == 60)
                {
                    cherryBomb++;
                    casingStack.Pop();
                    effectQueue.Dequeue();
                    if (cherryBomb >= 3 && daturaBomb >= 3 && smokeBomb >= 3)
                    {
                        break;
                    }
                }
                else if (sum == 120)
                {
                    smokeBomb++;
                    casingStack.Pop();
                    effectQueue.Dequeue();
                    if (cherryBomb >= 3 && daturaBomb >= 3 && smokeBomb >= 3)
                    {
                        break;
                    }
                }
                
                else
                {
                    currCasing -= 5;
                    casingStack.Pop();
                    casingStack.Push(currCasing);
                }
                
            }
            if (smokeBomb>=3&&cherryBomb>=3&&daturaBomb>=3)
                    {
                        Console.WriteLine($"Bene! You have successfully filled the bomb pouch!");
                    }
                else
                {
                   Console.WriteLine($"You don't have enough materials to fill the bomb pouch.");
                }
            
            
            if (effectQueue.Any())
            {
                Console.WriteLine($"Bomb Effects: {string.Join(", ", effectQueue)}");
            }
            else
            {
                Console.WriteLine($"Bomb Effects: empty");
            }
            if (casingStack.Any())
            {
                Console.WriteLine($"Bomb Casings: {string.Join(" ", casingStack)}");
            }
            else
            {
                Console.WriteLine($"Bomb Casings: empty");
            }

            //foreach (var bomb in bombsCreated.OrderBy(x => x.Key))
            //{
            //    Console.WriteLine($"{bomb.Key}: {bomb.Value}");
            //}
            Console.WriteLine($"Cherry Bombs: {cherryBomb}");
            Console.WriteLine($"Datura Bombs: {daturaBomb}");
            Console.WriteLine($"Smoke Decoy Bombs: {smokeBomb}");

        }

        
    }
}
