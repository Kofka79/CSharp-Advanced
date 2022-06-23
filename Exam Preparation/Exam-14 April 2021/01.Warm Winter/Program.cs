using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.WarmWinter
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] hats = Console.ReadLine().Split()
                        .Select(int.Parse).ToArray();
            int[] scarfs = Console.ReadLine().Split()
                        .Select(int.Parse).ToArray();
            Stack<int> hatStack = new Stack<int>(hats);
            Queue<int> scarfQueue = new Queue<int>(scarfs);
            Queue<int> sets = new Queue<int>();
            int maxSet = 0;
            while (hatStack.Count > 0 && scarfQueue.Count > 0)
            {
                int currHat = hatStack.Peek();
                int currScarf = scarfQueue.Peek();
                if (currHat>currScarf)
                {
                    int currSet = currScarf + currHat;
                    if (currSet>maxSet)
                    {
                        maxSet = currSet;
                    }
                    hatStack.Pop();
                    scarfQueue.Dequeue();
                    sets.Enqueue(currSet);
                            
                }
                else if (currHat<currScarf)
                {
                    hatStack.Pop();
                }
                else if (currHat==currScarf)
                {
                    scarfQueue.Dequeue();
                    currHat++;
                    hatStack.Pop();
                    hatStack.Push(currHat);
                }
            }
            Console.WriteLine($"The most expensive set is: {maxSet}");
            Console.WriteLine(string.Join(" ", sets));
        }
    }
}
