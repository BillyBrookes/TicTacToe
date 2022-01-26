using System;
using System.Collections.Generic;

namespace TicTacToe
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
                turn--; //avoid wasting turn if theres a cell taken
            }
            else
            {
                taken = false;
            }

            return taken;
        }
        static void DetectWin()
        {
            //stale by turn
            if (turn >= 9)
            {
                gameRunning = false;
                Console.WriteLine("No one wins!");
            }
            //win by horizontal
            for (int column = 0; column < 3; column++)
            {
                if (grid[column, 0] != ' ' && grid[column, 1] != ' ' && grid[column, 2] != ' ' && grid[column, 0] == grid[column, 1] && grid[column, 0] == grid[column, 2])
                {
                    gameRunning = false;
                    Console.WriteLine(grid[column, 0] + " Wins!");
                    break;
                }
            }
            //win by vertical
            for (int row = 0; row < 3; row++)
            {
                if (grid[0, row] != ' ' && grid[1, row] != ' ' && grid[2, row] != ' ' && grid[0, row] == grid[1, row] && grid[0, row] == grid[2, row])
                {
                    gameRunning = false;
                    Console.WriteLine(grid[0, row] + " Wins!");
                    break;
                }
            }
            //win by LR diagonal
            if(grid[0,0] != ' ' && grid[1,1] != ' ' && grid[2, 2] != ' ' && grid[0,0] == grid[1,1] && grid[0, 0] == grid[2, 2])
            {
                gameRunning = false;
                Console.WriteLine(grid[0, 0] + " Wins!");
            }
            //win by RL diagonal
            if (grid[0, 2] != ' ' && grid[1, 1] != ' ' && grid[2, 0] != ' ' && grid[0, 2] == grid[1, 1] && grid[0, 2] == grid[2, 0])
            {
                gameRunning = false;
                Console.WriteLine(grid[0, 2] + " Wins!");
            }
        }
        static void Main(string[] args)
        {
            if(!gameRunning) //initial printing of the game board in empty state
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
                Console.WriteLine("Input column value");
                int row = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Input row value");
                int column = Convert.ToInt32(Console.ReadLine());
                if(!isTaken(column, row)) //check if inputted coordinates are taken
                {
                    Board(column, row);
                }
                else
                {
                    Console.WriteLine("INVALID POSITION: CELL ALREADY TAKEN, PICK AGAIN");
                }
                DetectWin();
                turn++;
            }
        }
    }
}
