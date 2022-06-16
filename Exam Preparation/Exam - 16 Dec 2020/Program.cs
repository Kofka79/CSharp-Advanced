using System;

namespace _02._Selling
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char[,] field = new char[n, n];
            int sellRow = 0;
            int sellCol = 0;
            int pilarRow1 = 0;
            int pilarCol1 = 0;
            int pilarRow2 = 0;
            int pilarCol2 = 0;
            int count = 0;
            int collectedMoney = 0;
                

            for (int row = 0; row < n; row++)
            {
                char[] input = Console.ReadLine().ToCharArray();
                for (int col = 0; col < n; col++)
                {
                    field[row, col] = input[col];
                    if (field[row,col]=='S')
                    {
                        sellRow = row;
                        sellCol = col;
                    }
                    if (field[row,col]=='O'&&count==0)
                    {
                        pilarRow1 = row;
                        pilarCol1 = col;
                    }
                    else if (field[row, col] == 'O' && count == 1)
                    {
                        pilarRow2 = row;
                        pilarCol2 = col;
                    }
                }
            }
            while (true)
            {
                string command=Console.ReadLine();
                field[sellRow, sellCol] = '-';
                if (command=="up"&&sellRow-1>=0)
                {
                    sellRow--;
                }
                else if (command=="down"&&sellRow+1<n)
                {
                    sellRow++;
                }
                else if (command=="left"&&sellCol-1>=0)
                {
                    sellCol--;
                }
                else if (command=="right"&&sellCol+1<n)
                {
                    sellCol++;
                }
                else
                {
                    Console.WriteLine("Bad news, you are out of the bakery.");
                    break;
                }

                if (field[sellRow,sellCol]=='O')
                {
                    if (sellRow == pilarRow1)
                    {
                        field[sellRow, sellCol] = '-';
                        sellRow = pilarRow2;
                        sellCol = pilarCol2;
                        field[sellRow, sellCol] = '-';
                    }
                    else if (sellRow == pilarRow2)
                    {
                        field[sellRow, sellCol] = '-';
                        sellRow = pilarRow1;
                        sellCol = pilarCol1;
                        field[sellRow, sellCol] = '-';
                    }

                }
                if (Char.IsDigit(field[sellRow,sellCol]))
                {
                    collectedMoney += field[sellRow, sellCol]-'0';
                    if (collectedMoney>=50)
                    {
                        field[sellRow, sellCol] = 'S';
                        break;
                    }
                }
                field[sellRow, sellCol] = 'S';
            }
            if (collectedMoney>=50)
            {
                Console.WriteLine("Good news! You succeeded in collecting enough money!");
            }
            Console.WriteLine($"Money: {collectedMoney}");
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write(field[i,j]);
                }
                Console.WriteLine();
            }
        }
    }
}
