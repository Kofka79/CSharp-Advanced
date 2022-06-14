using System;
using System.Linq;

namespace _3._Maximal_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine().Split(" ")
                                .Select(int.Parse).ToArray();
            int rowsCount = dimensions[0];
            int colsCount = dimensions[1];
            int[,] matrix = new int[rowsCount, colsCount];
            int rowMax = 0;
            int colMax = 0;

            for (int row = 0; row < rowsCount; row++)
            {
                string[] line = Console.ReadLine().Split();
                for (int col = 0; col < colsCount; col++)
                {
                    matrix[row, col] = int.Parse(line[col]);
                }
            }
            int sumMax = int.MinValue;
            for (int row = 0; row < rowsCount - 2; row++)
            {
                for (int col = 0; col < colsCount - 2; col++)
                {
                    int currSum = matrix[row, col] + matrix[row, col + 1] + matrix[row, col + 2]
                       + matrix[row + 1, col] + matrix[row + 1, col + 1] +
                       matrix[row + 1, col + 2] + matrix[row + 2, col] +
                       matrix[row + 2, col + 1] + matrix[row + 2, col + 2];
                    if (currSum>sumMax)
                    {
                        sumMax = currSum;
                        rowMax = row;
                        colMax = col;
                    }
                }
            }
            Console.WriteLine($"Sum = {sumMax}");
            Console.WriteLine(matrix[rowMax, colMax] + " " + matrix[rowMax, colMax + 1] + " " +matrix[rowMax,colMax+2]);
            Console.WriteLine(matrix[rowMax+1, colMax] + " " + matrix[rowMax+1, colMax + 1] + " " + matrix[rowMax+1, colMax + 2]);
            Console.WriteLine(matrix[rowMax+2, colMax] + " " + matrix[rowMax+2, colMax + 1] + " " + matrix[rowMax+2, colMax + 2]);
        }
    }
}
