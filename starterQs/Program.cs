using System;

namespace starterQs
{
    class Program
    {
        static char[,] grid = new char[3, 3];

        static int turn;

        static bool Xturn;
        static bool gameRunning;

        static void Board(int column, int row) //set coordinate to X or O
        {
            if (Xturn)
            {
                grid[column, row] = 'X';
                Xturn = false;
            }
            else
            {
                grid[column, row] = 'O';
                Xturn = true;
            }
            Console.WriteLine("---------");
            for (int y = 0; y < 3; y++)
            {
                for (int x = 0; x < 3; x++)
                {
                    Console.Write("|" + grid[y, x] + "|"); //output current game state
                }
                Console.WriteLine("\n---------");
            }
        }
        static bool isTaken(int column, int row) //check if cell is taken already
        {
            bool taken = false;

            if(grid[column, row] == 'X' || grid[column, row] == 'O')
            {
                taken = true;
            }
            else
            {
                taken = false;
            }

            return taken;
        }
        static void Main(string[] args)
        {
            if(!gameRunning)
            {
                Console.WriteLine("Game State:");
                Console.WriteLine("---------");
                for (int y = 0; y < 3; y++)
                {
                    for (int x = 0; x < 3; x++)
                    {
                        grid[y, x] = ' ';
                        Console.Write("|" + grid[y, x] + "|"); //initial output of the game board
                    }
                    Console.WriteLine("\n---------");
                }
                gameRunning = true;
            }
            while(gameRunning)
            {
                Console.WriteLine("Input row value");
                int row = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Input column value");
                int column = Convert.ToInt32(Console.ReadLine());
                if(!isTaken(column, row)) //check if inputted coordinates are taken
                {
                    Board(column, row);
                }
                else
                {
                    Console.WriteLine("INVALID POSITION: CELL ALREADY TAKEN, PICK AGAIN");
                }
            }
        }
    }
}
