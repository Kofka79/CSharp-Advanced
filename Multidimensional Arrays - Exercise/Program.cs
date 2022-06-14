using System;
using System.Linq;

namespace _1._Diagonal_Difference
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int[,] matrix = new int[n, n];

            for (int row = 0; row < n; row++)
            {
                int[] line = Console.ReadLine().Split(" ")
                              .Select(int.Parse).ToArray();
                for (int col = 0; col < n; col++)
                {
                    matrix[row, col] = line[col];
                }
            }
            int sum1 = 0;
            int sum2 = 0;
            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    if (row == col)
                    {
                        sum1 += matrix[row, col];
                    }
                    if (row+col==n-1)
                    {
                        sum2 += matrix[row, col];
                    }
                }
            }
            Console.WriteLine(Math.Abs(sum1-sum2));
        }
    }
}
