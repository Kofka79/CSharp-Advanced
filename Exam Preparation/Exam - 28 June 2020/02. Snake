using System;

namespace _02._Snake
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int snakeRow = 0;
            int snakeCol = 0;
            int food = 0;
            int burrowRow1 = 0;
            int burrowCol1 = 0;
            int burrowRow2 = 0;
            int burrowCol2 = 0;
            int count = 0;
            char[,] field = new char[n, n];
            for (int row = 0; row < n; row++)
            {
                char[] input = Console.ReadLine().ToCharArray();
                for (int col = 0; col < n; col++)
                {
                    field[row, col] = input[col];
                    if (field[row,col]=='S')
                    {
                        snakeRow = row;
                        snakeCol = col;
                    }
                    if (field[row,col]=='B'&&count==0)
                    {
                        burrowRow1 = row;
                        burrowCol1 = col;
                        count++;
                    }
                    else if (field[row, col] == 'B' && count == 1)
                    {
                        burrowRow2 = row;
                        burrowCol2 = col;
                    }
                    
                }
            }

            while (true)
            {
                string command = Console.ReadLine();
                field[snakeRow, snakeCol] = '.';
                if (command=="up"&&snakeRow-1>=0)
                {
                    snakeRow--;
                }
                else if (command=="down"&&snakeRow+1<n)
                {
                    snakeRow++;
                }
                else if (command=="left"&&snakeCol-1>=0)
                {
                    snakeCol--;
                }
                else if (command=="right"&&snakeCol+1<n)
                {
                    snakeCol++;
                }
                else
                {
                    Console.WriteLine("Game over!");
                    break;
                }
                if (field[snakeRow,snakeCol]=='*')
                {
                    food++;
                    if (food>=10)
                    {
                        field[snakeRow, snakeCol] = 'S';
                        break;
                    }
                }
                if (field[snakeRow,snakeCol]=='B')
                {
                    if (snakeRow==burrowRow1)
                    {
                        field[snakeRow, snakeCol] = '.';
                        snakeRow = burrowRow2;
                        snakeCol = burrowCol2;
                        field[snakeRow, snakeCol] = '.';
                    }
                    else if (snakeRow==burrowRow2)
                    {
                        snakeRow = burrowRow1;
                        field[snakeRow, snakeCol] = '.'; 
                        snakeCol = burrowCol1;
                        field[snakeRow, snakeCol] = '.';
                    }
                    
                }
                field[snakeRow, snakeCol] = 'S';
            }
            if (food>=10)
            {
                Console.WriteLine("You won! You fed the snake.");
                Console.WriteLine($"Food eaten: {food}");
            }
            else
            {
                Console.WriteLine($"Food eaten: {food}");
            }
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
