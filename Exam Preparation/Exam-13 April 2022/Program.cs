using System;

namespace _02._Truffel_Hunter
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char[,] matrix = new char[n, n];
            for (int row = 0; row < n; row++)
            {
                char[] input = Console.ReadLine()
                    .Replace(" ", string.Empty).ToCharArray();
                for (int col = 0; col < n; col++)
                {
                    matrix[row, col] = input[col];
                }    
            }
            int blackTruffleCounter = 0;
            int summerTruffleCounter = 0;
            int whiteTruffleCounter = 0;
            int wildTruffleCounter = 0;

            string commandLine;
            while ((commandLine=Console.ReadLine())!= "Stop the hunt")
            {
                string[] commandParts = commandLine.Split();
                string command = commandParts[0];
                int row = int.Parse(commandParts[1]);
                int col = int.Parse(commandParts[2]);
                if (command== "Collect")
                {
                    if (matrix[row,col]=='B')
                    {
                        blackTruffleCounter++;
                        matrix[row, col] = '-';
                    }
                    else if (matrix[row, col] == 'W')
                    {
                        whiteTruffleCounter++;
                        matrix[row, col] = '-';
                    }
                    else if (matrix[row, col] == 'S')
                    {
                        summerTruffleCounter++;
                        matrix[row, col] = '-';
                    }
                }
                else if (command== "Wild_Boar")
                {
                    string direction = commandParts[3];
                    if (direction=="up")
                    {
                        while (IsRowValid(row, n))
                        {
                            if (HasEaten(row, col, matrix))
                            {
                                wildTruffleCounter++;
                            }
                            row -= 2;
                        }
                        
                    }
                    else if (direction=="down")
                    {
                        while (IsRowValid(row,n))
                        {
                            if (HasEaten(row, col, matrix))
                            {
                                wildTruffleCounter++;
                            }
                            row += 2;
                        }

                    }
                    else if (direction=="left")
                    {
                        while (IsColValid(col,n))
                        {
                            if (HasEaten(row, col, matrix))
                            {
                                wildTruffleCounter++;
                            }
                            col -= 2;
                        }
                    }
                    else if (direction=="right")
                    {
                        while (IsColValid(col,n))
                        {
                            if (HasEaten(row, col, matrix))
                            {
                                wildTruffleCounter++;
                            }
                            col += 2;
                        }
                    }
                }
            }
            Console.WriteLine($"Peter manages to harvest" +
                $" {blackTruffleCounter} black, {summerTruffleCounter} summer," +
                $" and {whiteTruffleCounter} white truffles.");
            Console.WriteLine($"The wild boar has eaten {wildTruffleCounter} truffles.");
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write(matrix[i, j] + " ");
                }
                Console.WriteLine();
            }
        }

        private static bool HasEaten(int row, int col, char[,] matrix)
        {
            char currSymbol = matrix[row, col];
            if (currSymbol=='S' || currSymbol=='B' || currSymbol=='W')
            {
                matrix[row, col] = '-';
                return true;
            }
            return false;
        }

        private static bool IsColValid(int col, int n)
        {
            if (col >= 0 && col < n)
            {
                return true;
            }
            return false;
        }

        private static bool IsRowValid(int row, int n)
        {
            if (row>=0 && row<n)
            {
                return true;
            }
            return false;
        }
    }
}
