# Mastermind Game (C# Console Application)

## Overview

This is a simple implementation of the **Mastermind** game in C#. The program generates a random 4-digit secret code with each digit ranging from 1 to 6. The player has up to 10 attempts to guess the secret code. After each guess, the program provides feedback in the form of a hint:
- `+` for correct digits in the correct position.
- `-` for correct digits but in the wrong position.
- No symbol for incorrect digits.

The game ends when the player guesses the code correctly or exhausts all attempts.

---

## Game Flow

- Secret Code Generation: A random 4-digit code is generated with digits between 1 and 6.
- Player's Guess: The player is prompted to enter their guess (4 digits, each between 1 and 6).
- Feedback: After each guess, the program provides feedback in the form of + and - characters.
- Attempts: The player has up to 10 attempts to guess the code.
- Win Condition: If the player guesses the code correctly, they win, and the game ends.
- Loss Condition: If the player runs out of attempts, the game ends, and the secret code is revealed.

## Features

- **Random Code Generation**: The secret code consists of 4 digits, each ranging from 1 to 6.
- **Player Input**: The player guesses the code by entering a 4-digit number.
- **Hint System**: The program provides a hint after each guess:
  - `+` indicates a correct digit in the correct position.
  - `-` indicates a correct digit in the wrong position.
  - No symbol for incorrect digits.
- **Input Validation**: Only valid 4-digit guesses with digits between 1 and 6 are allowed. Invalid guesses result in an error message.
- **Exception Handling**: Proper exception handling ensures the program is resilient to errors like invalid input.

---

## Requirements

- .NET Core or .NET Framework (C# compiler)
- Visual Studio or any other C# IDE for running the code

---

## How to Run

### Clone the Repository

To start playing the Mastermind game, you first need to clone the repository to your local machine. Open a terminal and run:


git clone https://github.com/yourusername/mastermind-csharp.git
cd mastermind-csharp

## Build and Run the Application

- Open the project in your preferred C# IDE (e.g., Visual Studio, Visual Studio Code).
- Compile and run the program file.
- Follow the on-screen instructions to guess the secret code.


## Contributions
Contributions to improve the game or add features are welcome. Feel free to fork the repository, create a new branch, and submit a pull request with your improvements.

## How to Contribute:
- Fork the repository.
- Create a new branch for your feature or fix.
- Make your changes.
- Commit and push your changes to your fork.
- Create a pull request to the main branch of the original repository.
