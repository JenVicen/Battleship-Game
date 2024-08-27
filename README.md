# Battleship Game

Battleship game developed in C# as a first homework for the Object-Oriented Programming class.

By Jennifer Vicentes

## Table of Contents

- [Introduction](#introduction)
- [Gameplay](#gameplay)
- [Features](#features)
- [Installation](#installation)
- [Usage](#usage)
- [Code Structure](#code-structure)
- [License](#license)
- [Acknowledgments](#acknowledgments)

## Introduction

Battleship is a classic two-player strategy game where players take turns guessing the locations of each other's ships on a grid. This implementation allows a single player to play against a computer-generated opponent, providing a fun way to practice coding skills in C#.

## Gameplay

- The game consists of an 8x8 grid.
- Players take turns inputting coordinates to attack the opponent's ships.
- The objective is to sink all enemy ships by correctly guessing their locations.
- The game ends when all ships have been sunk.

## Features

- Random placement of ships on the grid.
- Validation of player input to ensure correct coordinates.
- Tracking of hits and misses.
- Display of the game grid after each turn.
- Notification when a ship is sunk.
- Simple console-based interface for easy interaction.

## Installation

To run the Battleship game, follow these steps:

1. **Clone the Repository**:
   ```bash
   git clone https://github.com/yourusername/battleship-game.git
   ```

2. **Navigate to the Project Directory**:
   ```bash
   cd battleship-game
   ```

3. **Open the Project in Visual Studio or your preferred C# IDE**.

4. **Build the Project** to restore any dependencies.

## Usage

1. **Run the Application** from your IDE.
2. Follow the prompts in the console to enter your attack coordinates (e.g., "A 1").
3. Continue attacking until all ships are sunk or you choose to exit.

### Input Format

- The coordinates must be in the format:
  - Column: A-H
  - Row: 1-8
- Example: "A 1" represents the top-left corner of the grid.

## Code Structure

- **BattleshipGame.cs**: Contains the main logic of the game.
  - **Main()**: Entry point of the game.
  - **InitializeGrid()**: Sets up the game grid.
  - **PlaceShips()**: Randomly places ships on the grid.
  - **CanPlaceShip()**: Validates if a ship can be placed in a specified location.
  - **IsShipSunk()**: Checks if a ship has been completely sunk.
  - **PlayGame()**: Main game loop for player interaction.
  - **PrintGrid()**: Displays the current state of the grid.

## License

N/A

## Acknowledgments

- Inspired by the classic game Battleship and a previous tic tac toe game developed in C for the Programming Principles class.
