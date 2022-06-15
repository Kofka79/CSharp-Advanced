using System;

namespace _02._Armory
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char[,] field = new char[n, n];
            int officerRow = 0;
            int officerCol = 0;
            int firstMirrorRow = 0;
            int firstMirrorCol = 0;
            int secondMirrorRow = 0;
            int secondMirrorCol = 0;
            int count = 0;

            int price = 0;

            for (int row = 0; row < n; row++)
            {
                char[] inputData = Console.ReadLine().ToCharArray();
                for (int col = 0; col < n; col++)
                {
                    field[row, col] = inputData[col];
                    if (field[row,col]=='A')
                    {
                        officerRow = row;
                        officerCol = col;
                    }
                    if (field[row,col]=='M' && count==0)
                    {
                        firstMirrorRow = row;
                        firstMirrorCol = col;
                        count++;
                    }
                    else if (field[row, col] == 'M' && count == 1)
                    {
                        secondMirrorRow = row;
                        secondMirrorCol = col;
                    }
                }
            }

            //Move
            while (true)
            {
                string command = Console.ReadLine();

                field[officerRow, officerCol] = '-';
                if (command=="up" && officerRow-1>=0)
                {
                    officerRow--;
                }
                else if (command=="down" && officerRow+1<n)
                {
                    officerRow++;
                }
                else if (command=="left" && officerCol-1>=0)
                {
                    officerCol--;
                }
                else if (command=="right" && officerCol+1<n)
                {
                    officerCol++;
                }
                else
                {
                    Console.WriteLine("I do not need more swords!");
                    break;
                }
                

                if (Char.IsDigit(field[officerRow,officerCol]))
                {
                    price += field[officerRow, officerCol]- '0';
                    if (price>=65)
                    {
                        field[officerRow, officerCol] = 'A';
                        Console.WriteLine("Very nice swords, I will come back for more!");
                        break;
                    }
                }
                if (field[officerRow,officerCol]=='M')
                {
                    field[officerRow, officerCol] = '-';
                    if (officerRow==firstMirrorRow)
                    {
                        officerRow = secondMirrorRow;
                        officerCol = secondMirrorCol;
                    }
                    else
                    {
                        officerRow = firstMirrorRow;
                        officerCol = secondMirrorCol;
                    }
                    field[officerRow, officerCol] = '-';
                }
                field[officerRow, officerCol] = 'A';
            }
            Console.WriteLine($"The king paid {price} gold coins.");
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
