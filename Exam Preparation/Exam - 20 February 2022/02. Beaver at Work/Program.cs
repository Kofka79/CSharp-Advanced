using System;
using System.Collections.Generic;

namespace _02._Beaver_at_Work
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char[,] matrix = new char[n, n];
            int beaverRow = 0;
            int beaverCol = 0;
            int woodSum = 0;
            int collectedBranches = 0;

            List<char> branches = new List<char>();

            for (int row = 0; row < n; row++)
            {
                char[] input = Console.ReadLine()
                    .Replace(" ", string.Empty).ToCharArray();
                for (int col = 0; col < n; col++)
                {
                    matrix[row, col] = input[col];
                    if (matrix[row, col]=='B')
                    {
                        beaverRow = row;
                        beaverCol = col;
                    }
                    if (char.IsLower(matrix[row, col]))
                    {
                        woodSum++;
                    }
                }
            }

            string command;
            while ((command=Console.ReadLine())!="end")
            {
                matrix[beaverRow, beaverCol] = '-';
                if (command=="up")
                {
                    if (beaverRow-1>=0 )
                    {
                        beaverRow--;
                        if (char.IsLower(matrix[beaverRow, beaverCol]))
                        {
                            collectedBranches++;
                            branches.Add(matrix[beaverRow, beaverCol]);
                            woodSum--;
                        }
                        else if (matrix[beaverRow, beaverCol] == 'F')
                        {
                            matrix[beaverRow, beaverCol] = '-';
                            if (beaverRow == 0)
                            {
                                beaverRow = n - 1;
                            }
                            else if (beaverRow == n - 1)
                            {
                                beaverRow = 0;
                            }
                        }
                        matrix[beaverRow, beaverCol] = 'B';
                        if (woodSum == 0)
                        {
                            break;
                        }

                    }
                    else
                    {
                        collectedBranches--;
                        branches.RemoveAt(branches.Count - 1);
                    }
                    
                    
                }
                else if (command=="down")
                {
                    if (beaverRow+1<n)
                    {
                        beaverRow++;
                        if (char.IsLower(matrix[beaverRow, beaverCol]))
                        {
                            collectedBranches++;
                            branches.Add(matrix[beaverRow, beaverCol]);
                            woodSum--;
                        }
                        else if (matrix[beaverRow, beaverCol] == 'F')
                        {
                            matrix[beaverRow, beaverCol] = '-';
                            if (beaverRow == 0)
                            {
                                beaverRow = n - 1;
                            }
                            else if (beaverRow == n - 1)
                            {
                                beaverRow = 0;
                            }
                        }
                        matrix[beaverRow, beaverCol] = 'B';
                        if (woodSum == 0)
                        {
                            break;
                        }
                    }
                    
                    else
                    {
                        collectedBranches--;
                        branches.RemoveAt(branches.Count - 1);
                    }
                }
                else if (command=="left")
                {
                    if (beaverCol-1>=0)
                    {
                        beaverCol--;
                        if (char.IsLower(matrix[beaverRow, beaverCol]))
                        {
                            collectedBranches++;
                            branches.Add(matrix[beaverRow, beaverCol]);
                            woodSum--;
                        }
                        else if (matrix[beaverRow, beaverCol] == 'F')
                        {
                            matrix[beaverRow, beaverCol] = '-';
                            if (beaverRow == 0)
                            {
                                beaverRow = n - 1;
                            }
                            else if (beaverRow == n - 1)
                            {
                                beaverRow = 0;
                            }
                        }
                        matrix[beaverRow, beaverCol] = 'B';
                        if (woodSum == 0)
                        {
                            break;
                        }
                    }
                    
                    
                    else
                    {
                        collectedBranches--;
                        branches.RemoveAt(branches.Count-1);
                    }
                }
                else if (command=="right")
                {
                    if (beaverCol+1< n)
                    {
                        beaverCol++;
                        if (char.IsLower(matrix[beaverRow, beaverCol]))
                        {
                            collectedBranches++;
                            branches.Add(matrix[beaverRow, beaverCol]);
                            woodSum--;
                        }
                        else if (matrix[beaverRow, beaverCol] == 'F')
                        {
                            matrix[beaverRow, beaverCol] = '-';
                            if (beaverRow == 0)
                            {
                                beaverRow = n - 1;
                            }
                            else if (beaverRow == n - 1)
                            {
                                beaverRow = 0;
                            }
                        }
                        matrix[beaverRow, beaverCol] = 'B';
                        if (woodSum == 0)
                        {
                            break;
                        }
                    }
                    else
                    {
                        collectedBranches--;
                        branches.RemoveAt(branches.Count-1);
                    }
                }
                
            }
            
            if (woodSum==0)
            {
                Console.WriteLine($"The Beaver successfully collect" +
                    $" {collectedBranches} wood branches:" +
                    $" {string.Join(", ", branches)}.");
            }
            else
            {
                Console.WriteLine($"The Beaver failed to collect" +
                    $" every wood branch. There are {woodSum} branches left.");
            }
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write(matrix[i, j] + " ");
                }
                Console.WriteLine();
            }
        }

        private static bool IsRowValid(int beaverRow, int n)
        {
            return beaverRow>=0 && beaverRow<n;
        }

        private static bool IsColValid(int beaverCol, int n)
        {
            return beaverCol >= 0 && beaverCol < n;
        }
    }
}
