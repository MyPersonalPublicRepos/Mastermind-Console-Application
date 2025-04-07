using System;

class Mastermind
{
    static void Main()
    {
        try
        {
            // Generate a random 4-digit secret code between 1 and 6
            int[] secretCode = GenerateSecretCode();

            // Maximum number of attempts
            const int maxAttempts = 10;
            int attempts = 0;

            Console.WriteLine("Welcome to Mastermind!");
            Console.WriteLine("Try to guess the 4-digit number.");
            Console.WriteLine("Each digit is between 1 and 6.");
            Console.WriteLine("For every correct digit in the correct position, you'll get a '+'.");
            Console.WriteLine("For every correct digit in the wrong position, you'll get a '-'.");
            Console.WriteLine("You have 10 attempts to guess the secret code.");

            // Game loop
            while (attempts < maxAttempts)
            {
                attempts++;

                // Prompt the player for their guess
                Console.Write($"Attempt {attempts}/{maxAttempts}: Enter your guess (4 digits, each between 1 and 6): ");
                string guessInput = Console.ReadLine();

                // Validate the input and throw exception for invalid guesses
                if (string.IsNullOrEmpty(guessInput) || !IsValidGuess(guessInput))
                {
                    throw new ArgumentException("Invalid guess. Make sure your guess is 4 digits long and each digit is between 1 and 6.");
                }

                // Convert the guess string into an integer array
                int[] guess = new int[4];
                for (int i = 0; i < 4; i++)
                {
                    guess[i] = int.Parse(guessInput[i].ToString());
                }

                // Generate the hint
                string hint = GenerateHint(secretCode, guess);

                // Output the hint
                Console.WriteLine($"Hint: {hint}");

                // Check if the guess is correct
                if (hint == "++++")
                {
                    Console.WriteLine($"Congratulations! You guessed the secret code {string.Join("", secretCode)} correctly!");
                    break;
                }

                // If maximum attempts reached, the player loses
                if (attempts == maxAttempts)
                {
                    Console.WriteLine($"Sorry, you've used all {maxAttempts} attempts. The secret code was {string.Join("", secretCode)}.");
                }
            }
        }
        catch (ArgumentException ex)
        {
            // Handle invalid input gracefully
            Console.WriteLine(ex.Message);
        }
        catch (Exception ex)
        {
            // Catch any other unforeseen errors
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }

    /// <summary>
    /// Generates a random 4-digit secret code where each digit is between 1 and 6.
    /// </summary>
    /// <returns>An array of integers representing the secret code.</returns>
    static int[] GenerateSecretCode()
    {
        Random rand = new Random();
        int[] secretCode = new int[4];
        for (int i = 0; i < 4; i++)
        {
            secretCode[i] = rand.Next(1, 7); // Random number between 1 and 6
        }
        return secretCode;
    }

    /// <summary>
    /// Checks whether the player's guess is valid (4 digits between 1 and 6).
    /// </summary>
    /// <param name="guess">The player's guess as a string.</param>
    /// <returns>True if the guess is valid, otherwise false.</returns>
    static bool IsValidGuess(string guess)
    {
        if (guess.Length != 4)
        {
            return false;
        }

        foreach (char c in guess)
        {
            if (c < '1' || c > '6')
            {
                return false;
            }
        }
        return true;
    }

    /// <summary>
    /// Generates a hint based on the player's guess.
    /// The hint consists of '+' for correct digits in the correct position,
    /// and '-' for correct digits in the wrong position.
    /// </summary>
    /// <param name="secretCode">The secret code array.</param>
    /// <param name="guess">The player's guess array.</param>
    /// <returns>A string representing the hint with '+' and '-' characters.</returns>
    static string GenerateHint(int[] secretCode, int[] guess)
    {
        char[] hint = new char[4];
        bool[] secretUsed = new bool[4]; // To keep track of which digits of the secret have been used
        bool[] guessUsed = new bool[4];  // To keep track of which digits of the guess have been used

        // First pass: Check for correct digits in the correct position ('+')
        for (int i = 0; i < 4; i++)
        {
            if (secretCode[i] == guess[i])
            {
                hint[i] = '+';
                secretUsed[i] = true;
                guessUsed[i] = true;
            }
        }

        // Second pass: Check for correct digits in the wrong position ('-')
        for (int i = 0; i < 4; i++)
        {
            if (!guessUsed[i]) // Only consider digits that haven't been correctly matched yet
            {
                for (int j = 0; j < 4; j++)
                {
                    if (!secretUsed[j] && secretCode[j] == guess[i])
                    {
                        hint[i] = '-';
                        secretUsed[j] = true;
                        guessUsed[i] = true;
                        break;
                    }
                }
            }
        }

        // Build the hint string by removing unused positions (i.e. no '+' or '-')
        return new string(hint).Replace('\0', ' ');
    }
}
