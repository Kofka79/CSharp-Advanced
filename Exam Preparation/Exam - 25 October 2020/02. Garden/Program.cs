using System;

namespace _02._Garden
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] dimension = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);
            int rowsCount = int.Parse(dimension[0]);
            int colsCount = int.Parse(dimension[1]);
            int[,] matrix = new int[rowsCount, colsCount];

            for (int row = 0; row < rowsCount; row++)
            {
                for (int col = 0; col < colsCount; col++)
                {
                    matrix[row, col] =0;
                }
            }
            string command;
            while ((command=Console.ReadLine())!="Bloom Bloom Plow")
            {
                string[] flowers = command
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);
                int firstFlower = int.Parse(flowers[0]);
                int secondFlower = int.Parse(flowers[1]);
                if (firstFlower<rowsCount&&secondFlower<colsCount)
                {
                    for (int i = 0; i < rowsCount; i++)
                    {
                        matrix[i, secondFlower] ++;
                    }
                    for (int j = 0; j < colsCount; j++)
                    {
                        matrix[firstFlower, j]++;
                    }
                    matrix[firstFlower, secondFlower] -= 1;
                }
                else
                {
                    Console.WriteLine($"Invalid coordinates.");
                }
                
                
            }
            for (int m = 0; m < rowsCount; m++)
            {
                for (int l = 0; l < colsCount; l++)
                {
                    Console.Write(matrix[m,l]+" ");
                }
                Console.WriteLine();
            }
        }
    }
}
