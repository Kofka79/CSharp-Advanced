using System;
using System.Linq;

namespace _2._Squares_in_Matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine().Split(" ")
                                .Select(int.Parse).ToArray();
            int rowsCount = dimensions[0];
            int colsCount = dimensions[1];
            string[,] matrix = new string[rowsCount, colsCount];

            for (int row = 0; row < rowsCount; row++)
            {
                string[] line = Console.ReadLine().Split();
                for (int col = 0; col < colsCount; col++)
                {
                    matrix[row, col] = line[col];
                }
            }
            int count = 0;
            for (int row = 0; row < rowsCount-1; row++)
            {
                for (int col = 0; col < colsCount-1; col++)
                {
                    if (matrix[row,col]==matrix[row,col+1]&& matrix[row, col] == matrix[row+1, col]
                       && matrix[row, col]==matrix[row+1,col+1] )
                    {
                        count++;
                    }
                }
            }
            Console.WriteLine(count);
        }
    }
}
