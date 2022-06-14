using System;
using System.Linq;

namespace _4._Matrix_Shuffling
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
            string cmd = Console.ReadLine();
            while (cmd!="END")
	        {

                if (!CheckIsValid(cmd, rowsCount, colsCount))
                {
                    Console.WriteLine($"Invalid input!");
                    cmd = Console.ReadLine();
                    continue;
                }
                else
                {
                    string[] command = cmd.Split();
                    int row1 = int.Parse(command[1]);
                    int col1 = int.Parse(command[2]);
                    int row2 = int.Parse(command[3]);
                    int col2 = int.Parse(command[4]);
                    string firstElement = matrix[row1, col1];
                    string secondElement = matrix[row2, col2];
                    matrix[row2, col2] = firstElement;
                    matrix[row1, col1] = secondElement;


                    for (int row = 0; row < rowsCount; row++)
                    {
                        for (int col = 0; col < colsCount; col++)
                        {
                            Console.Write(matrix[row, col] + " ");
                        }
                        Console.WriteLine();
                    }
                }
                    
                cmd = Console.ReadLine();
	        }

            
        }
        

        private static bool CheckIsValid(string cmd, int rowsCount, int colsCount)
        {
            string[] command = cmd.Split();
            string action = command[0];
            
            if (action == "swap" && command.Length == 5)
            {
                int row1 =int.Parse(command[1]);
                int col1 =int.Parse(command[2]);
                int row2 =int.Parse(command[3]);
                int col2 =int.Parse(command[4]);
                if (row1 >= 0 && row1 < rowsCount && row2 >= 0 && row2 < rowsCount &&
                    col1 >= 0 && col1 < colsCount && col2 >= 0 && col2 < colsCount)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
                
            
        }
    }
}
