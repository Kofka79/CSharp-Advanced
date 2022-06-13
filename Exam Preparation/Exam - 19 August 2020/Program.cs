using System;

namespace _02._Bee
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            //int row = size;
            //int col = size;
            int flowers = 0;
            char[,] field = new char[size,size];
            int beeRow = 0;
            int beeCol = 0;
            for (int row = 0; row < size; row++)
            {
                char[] input = Console.ReadLine().ToCharArray();
                for (int col = 0; col < size; col++)
                {
                    field[row, col] = input[col];
                    if (field[row,col]=='B')
                    {
                        beeRow = row;
                        beeCol = col;
                    }
                }
            }
            
            
            string command;
            while ((command=Console.ReadLine())!="End")
            {
                field[beeRow, beeCol] = '.';
                if (command=="up"&&beeRow-1>=0)
                {
                    beeRow--;
                }
                else if (command == "down" && beeRow + 1 < size)
                {
                    beeRow++;
                }
                else if (command == "left" && beeCol - 1 >= 0)
                {
                    beeCol--;
                }
                else if (command == "right" && beeRow + 1 <size)
                {
                    beeCol++;
                }
                else
                {
                    Console.WriteLine("The bee got lost!");
                    break;
                }
                if (field[beeRow, beeCol]=='f')
                {
                    flowers++;
                }
                
                if (field[beeRow, beeCol]=='O')
                {
                    field[beeRow, beeCol] = '.';
                    if (command=="up")
                    {
                        beeRow --;
                        if (beeRow<0)
                        {
                            Console.WriteLine("The bee got lost!");
                            break;
                        }
                        if (field[beeRow, beeCol] == 'f')
                        {
                            flowers++;
                        }
                    }
                    
                    if (command == "down")
                    {
                        beeRow ++;
                        if (beeRow > size)
                        {
                            Console.WriteLine("The bee got lost!");
                            break;
                        }
                        if (field[beeRow, beeCol] == 'f')
                        {
                            flowers++;
                        }
                    }
                    
                    if (command == "left")
                    {
                        beeCol --;
                        if (beeCol < 0)
                        {
                            Console.WriteLine("The bee got lost!");
                            break;
                        }
                        if (field[beeRow, beeCol] == 'f')
                        {
                            flowers++;
                        }
                    }
                    
                    if (command == "right")
                    {
                        beeCol ++;
                        if (beeCol > size)
                        {
                            Console.WriteLine("The bee got lost!");
                            break;
                        }
                        if (field[beeRow, beeCol] == 'f')
                        {
                            flowers++;
                        }
                    }
                    
                }
                field[beeRow, beeCol] = 'B';
            }
            if (flowers>=5)
            {
                Console.WriteLine($"Great job, the bee managed to pollinate" +
                    $" {flowers} flowers!");
            }
            else
            {
                Console.WriteLine($"The bee couldn't pollinate the flowers," +
                    $" she needed {5-flowers} flowers more");
            }
            for (int m = 0; m < size; m++)
            {
                for (int l = 0; l < size; l++)
                {
                    Console.Write(field[m, l]);
                }
                Console.WriteLine();
            }
        }
    }
}
