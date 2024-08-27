// Homework 1
// Battleship game
// By: Jennifer Vicentes

using System;
using System.Collections.Generic;

class BattleshipGame
{

    static int gridSize = 8;
    static char[,] grid = new char[gridSize, gridSize];
    static bool[,] shipGrid = new bool[gridSize, gridSize];
    static int[] shipSizes = { 5, 4, 3, 3, 2 };
    static int shipsRemaining = shipSizes.Length;

    static void Main()
    {
        InitializeGrid();
        PlaceShips();
        PlayGame();
    }

    // Initialize the grid with dots
    static void InitializeGrid()
    {
        for (int i = 0; i < gridSize; i++)
        {
            for (int j = 0; j < gridSize; j++)
            {
                grid[i, j] = '.';
            }
        }
    }

    // Place the ships on the grid, randomly and without overlapping each other
    static void PlaceShips()
    {
        Random rand = new Random();

        foreach (int size in shipSizes)
        {
            bool placed = false;
            while (!placed)
            {
                // Randomly choose a row, column, and orientation
                int row = rand.Next(gridSize);
                int col = rand.Next(gridSize);
                bool horizontal = rand.Next(2) == 0;

                // Check if the ship can be placed in the chosen position
                if (CanPlaceShip(row, col, size, horizontal))
                {   
                    // Place the ship, and mark it as placed
                    PlaceShip(row, col, size, horizontal);
                    placed = true;
                }
            }
        }
    }

    // Check if a ship can be placed in the given position, without overlapping other ships
    static bool CanPlaceShip(int row, int col, int size, bool horizontal)
    {
        // Check if the ship goes out of bounds or overlaps another ship
        if (horizontal)
        {
            if (col + size > gridSize || col - 1 < 0 || col + size < gridSize && grid[row, col + size] != '.') return false;
            for (int i = 0; i < size; i++)
            {
                if (shipGrid[row, col + i] || (row - 1 >= 0 && shipGrid[row - 1, col + i]) || (row + 1 < gridSize && shipGrid[row + 1, col + i])) return false;
            }
        }
        else
        {
            if (row + size > gridSize || row - 1 < 0 || row + size < gridSize && grid[row + size, col] != '.') return false;
            for (int i = 0; i < size; i++)
            {
                if (shipGrid[row + i, col] || (col - 1 >= 0 && shipGrid[row + i, col - 1]) || (col + 1 < gridSize && shipGrid[row + i, col + 1])) return false;
            }
        }
        return true;
    }

    // Place the ship on the grid
    static void PlaceShip(int row, int col, int size, bool horizontal)
    {
        if (horizontal)
        {
            for (int i = 0; i < size; i++)
            {
                shipGrid[row, col + i] = true;
            }
        }
        else
        {
            for (int i = 0; i < size; i++)
            {
                shipGrid[row + i, col] = true;
            }
        }
    }

    static void PlayGame()
    {
        while (shipsRemaining > 0)
        {
            PrintGrid();
            Console.WriteLine("Write your coordinates (Ex. A 1): ");
            string input = Console.ReadLine().ToUpper();

            if (input.Length < 3 || !char.IsLetter(input[0]) || !char.IsDigit(input[2]))
            {
                Console.WriteLine("Invalid input. Try again.");
                continue;
            }

            int col = input[0] - 'A';
            int row = int.Parse(input[2].ToString()) - 1;

            if (row < 0 || row >= gridSize || col < 0 || col >= gridSize)
            {
                Console.WriteLine("Out of bounds. Try again.");
                continue;
            }

            if (grid[row, col] != '.')
            {
                Console.WriteLine("You already tried those coordinates. Try again.");
                continue;
            }

            if (shipGrid[row, col])
            {
                grid[row, col] = 'X';
                Console.WriteLine("Hit!");
                if (IsShipSunk(row, col))
                {
                    shipsRemaining--;
                    Console.WriteLine("You have sunk a ship!");
                }
            }
            else
            {
                grid[row, col] = 'O';
                Console.WriteLine("Miss!");
            }
        }

        Console.WriteLine("Congratulations! You have sunk all the ships");
    }

    static bool IsShipSunk(int row, int col)
    {
        // Check horizontally for the entire ship
        int left = col;
        while (left >= 0 && shipGrid[row, left]) left--;
        left++;  // Adjust to the first part of the ship

        int right = col;
        while (right < gridSize && shipGrid[row, right]) right++;
        right--;  // Adjust to the last part of the ship

        // Check if the entire horizontal ship is hit
        for (int c = left; c <= right; c++)
        {
            if (grid[row, c] != 'X')
            {
                return false;
            }
        }

        // Check vertically for the entire ship
        int top = row;
        while (top >= 0 && shipGrid[top, col]) top--;
        top++;  // Adjust to the first part of the ship

        int bottom = row;
        while (bottom < gridSize && shipGrid[bottom, col]) bottom++;
        bottom--;  // Adjust to the last part of the ship

        // Check if the entire vertical ship is hit
        for (int r = top; r <= bottom; r++)
        {
            if (grid[r, col] != 'X')
            {
                return false;
            }
        }

        return true;
    }

    static void PrintGrid()
    {
        Console.WriteLine("  A B C D E F G H ");
        for (int i = 0; i < gridSize; i++)
        {
            Console.Write((i + 1) + " ");
            for (int j = 0; j < gridSize; j++)
            {
                Console.Write(grid[i, j] + " ");
            }
            Console.WriteLine();
        }
    }
}
