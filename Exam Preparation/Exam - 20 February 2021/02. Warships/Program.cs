using System;
using System.Linq;

namespace _02._Warships
{
    class Program
    {
        static void Main(string[] args)
        {

            int size = int.Parse(Console.ReadLine());
            char[,] field = new char[size, size];
            string[] input = Console.ReadLine().Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);
            int firstPlayerDestroyedShips = 0;
            int secondPlayerDestroyedShips = 0;
            int shipOne = 0;
            int shipTwo = 0;

            int currAttackRow = 0;
            int currAttackCol = 0;



            for (int row = 0; row < field.GetLength(0); row++)
            {
                char[] fillMatrix = Console.ReadLine().Split()
                    .Select(char.Parse).ToArray();
                for (int col = 0; col < field.GetLength(1); col++)
                {
                    field[row, col] = fillMatrix[col];
                    if (field[row, col] == '<')
                    {
                        shipOne++;
                    }
                    if (field[row, col] == '>')
                    {
                        shipTwo++;
                    }
                }
            }

            //"0 0", "-1 -1", "2 2", "4 4", "4 2", "3 3", "3 6"
            for (int i = 0; i < input.Length; i += 2)
            {
                currAttackRow = int.Parse(input[i]);
                currAttackCol = int.Parse(input[i + 1]);

                if (IsInrange(field, currAttackRow, currAttackCol) &&
                field[currAttackRow, currAttackCol] == '<')
                {
                    field[currAttackRow, currAttackCol] = 'X';
                    firstPlayerDestroyedShips++;
                    shipOne--;
                }
                else if (IsInrange(field, currAttackRow, currAttackCol) &&
                field[currAttackRow, currAttackCol] == '>')
                {
                    field[currAttackRow, currAttackCol] = 'X';
                    secondPlayerDestroyedShips++;
                    shipTwo--;
                    
                }

                else if (IsInrange(field, currAttackRow, currAttackCol) &&
                        field[currAttackRow, currAttackCol] == '#')
                {
                    field[currAttackRow, currAttackCol] = 'X';
                    //up
                    if (IsInrange(field, currAttackRow-1,currAttackCol))
                    {
                        if (field[currAttackRow - 1, currAttackCol] =='<')
                        {
                            firstPlayerDestroyedShips++;
                            shipOne--;
                        }
                        else if (field[currAttackRow - 1, currAttackCol] == '>')
                        {
                            secondPlayerDestroyedShips++;
                            shipTwo--;
                        }
                        field[currAttackRow - 1, currAttackCol] = 'X';
                    }
                    //down
                    if (IsInrange(field, currAttackRow + 1, currAttackCol))
                    {
                        if (field[currAttackRow + 1, currAttackCol] == '<')
                        {
                            firstPlayerDestroyedShips++;
                            shipOne--;
                        }
                        if (field[currAttackRow + 1, currAttackCol] == '>')
                        {
                            secondPlayerDestroyedShips++;
                            shipTwo--;
                        }
                        field[currAttackRow + 1, currAttackCol] = 'X';
                    }
                    //left
                    if (IsInrange(field, currAttackRow, currAttackCol-1))
                    {
                        if (field[currAttackRow, currAttackCol - 1] == '<')
                        {
                            firstPlayerDestroyedShips++;
                            shipOne--;
                        }
                        if (field[currAttackRow, currAttackCol - 1] == '>')
                        {
                            secondPlayerDestroyedShips++;
                            shipTwo--;
                        }
                        field[currAttackRow, currAttackCol - 1] = 'X';
                    }
                    //right
                    if (IsInrange(field, currAttackRow , currAttackCol+1))
                    {
                        if (field[currAttackRow, currAttackCol + 1] == '<')
                        {
                            firstPlayerDestroyedShips++;
                            shipOne--;
                        }
                        if (field[currAttackRow, currAttackCol + 1] == '>')
                        {
                            secondPlayerDestroyedShips++;
                            shipTwo--;
                        }
                        field[currAttackRow, currAttackCol + 1] = 'X';
                    }
                    //upleft
                    if (IsInrange(field, currAttackRow - 1, currAttackCol-1))
                    {
                        if (field[currAttackRow - 1, currAttackCol - 1] == '<')
                        {
                            firstPlayerDestroyedShips++;
                            shipOne--;
                        }
                        if (field[currAttackRow - 1, currAttackCol - 1] == '>')
                        {
                            secondPlayerDestroyedShips++;
                            shipTwo--;
                        }
                        field[currAttackRow - 1, currAttackCol - 1] = 'X';
                    }
                    //upright
                    if (IsInrange(field, currAttackRow - 1, currAttackCol+1))
                    {
                        if (field[currAttackRow - 1, currAttackCol + 1] == '<')
                        {
                            firstPlayerDestroyedShips++;
                            shipOne--;
                        }
                        if (field[currAttackRow - 1, currAttackCol + 1] == '>')
                        {
                            secondPlayerDestroyedShips++;
                            shipTwo--;
                        }
                        field[currAttackRow - 1, currAttackCol + 1] = 'X';
                    }
                    //downleft
                    if (IsInrange(field, currAttackRow + 1, currAttackCol-1))
                    {
                        if (field[currAttackRow + 1, currAttackCol - 1] == '<')
                        {
                            firstPlayerDestroyedShips++;
                            shipOne--;
                        }
                        if (field[currAttackRow + 1, currAttackCol - 1] == '>')
                        {
                            secondPlayerDestroyedShips++;
                            shipTwo--;
                        }
                        field[currAttackRow + 1, currAttackCol - 1] = 'X';
                    }
                    //downright
                    if (IsInrange(field, currAttackRow + 1, currAttackCol+1))
                    {
                        if (field[currAttackRow + 1, currAttackCol + 1] == '<')
                        {
                            firstPlayerDestroyedShips++;
                            shipOne--;
                        }
                        if (field[currAttackRow + 1, currAttackCol + 1] == '>')
                        {
                            secondPlayerDestroyedShips++;
                            shipTwo--;
                        }
                        field[currAttackRow + 1, currAttackCol + 1] = 'X';
                    }
                }
                
                
                if (shipOne==0)
                {
                    Console.WriteLine($"Player Two has won the game!" +
                        $" {firstPlayerDestroyedShips+secondPlayerDestroyedShips} ships have been sunk in the battle.");
                    break;
                }
                if (shipTwo==0)
                {
                    Console.WriteLine($"Player One has won the game!" +
                        $" {firstPlayerDestroyedShips+secondPlayerDestroyedShips} ships have been sunk in the battle.");
                    break;
                }


            }

            if ( shipOne> 0 && shipTwo > 0)
            {
                Console.WriteLine($"It's a draw! Player One has {shipOne} ships left." +
                    $" Player Two has {shipTwo} ships left.");
            }

        }

        private static bool IsInrange(char[,] field, int row, int col)
        {

            return row >= 0 && row < field.GetLength(0) && col >= 0 && col < field.GetLength(1);
        }
    }
}
