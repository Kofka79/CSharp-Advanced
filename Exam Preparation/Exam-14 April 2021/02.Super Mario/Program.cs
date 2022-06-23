using System;

namespace _02._SuperMario
{
    class Program
    {
        static void Main(string[] args)
        {
            int lives = int.Parse(Console.ReadLine());
            int rows = int.Parse(Console.ReadLine());
            char[][] field = new char[rows][];
            for (int i = 0; i < rows; i++)
            {
                char[] chars = Console.ReadLine().ToCharArray();
                    field[i]= chars;
            }
            int marioRow = 0;
            int marioCol = 0;
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < field[i].Length; j++)
                {
                    if (field[i][j]=='M')
                    {
                        marioRow = i;
                        marioCol = j;
                    }
                }
            }

            while (true)
            {
                string commandLine = Console.ReadLine();
                string[] commandParts = commandLine.Split(' ');
                string command = commandParts[0];
                int enemyRow =int.Parse(commandParts[1]);
                int enemyCol =int.Parse(commandParts[2]);
                
                lives--;
                field[marioRow][marioCol] = '-';
                field[enemyRow][ enemyCol] = 'B';
                //up
                if (command=="W"&&marioRow-1>=0)
                {
                    marioRow--;
                }
                //down
                else if (command=="S"&& marioRow+1<rows)
                {
                    marioRow++;
                }
                //left
                else if (command=="A"&&marioCol-1>=0)
                {
                    marioCol--;
                }
                //right
                else if (command=="D"&&marioCol+1<field[marioRow].Length)
                {
                    marioCol++;
                }

                if (field[marioRow][ marioCol]=='B')
                {
                    lives -= 2;
                }
                if (field[marioRow][marioCol]=='P')
                {
                    Console.WriteLine($"Mario has successfully saved the princess! Lives left: {lives}");
                    field[marioRow][marioCol] = '-';
                    break;
                }

                if (lives<=0)
                {
                    field[marioRow][marioCol] = 'X';
                    Console.WriteLine($"Mario died at {marioRow};{marioCol}.");
                    break;
                }

                field[marioRow][marioCol] = 'M';
            }
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < field[i].Length; j++)
                {
                    Console.Write(field[i][j]);
                }
                Console.WriteLine();
            }
        }
    }
}
