using System;
using System.Collections.Generic;

class HangmanGame
{
    static string chosenWord;
    static HashSet<char> guessedLetters = new HashSet<char>();
    static int remainingLives = 7; 
    static string[] hangmanFrames = {
        @"      ╔═══╗   " + '\n' +
    @"      |   ║   " + '\n' +
    @"      O   ║   " + '\n' +
    @"     /|\  ║   " + '\n' +
    @"     / \  ║   " + '\n' +
    @"     ███  ║   " + '\n' +
    @"    ══════╩═══",

        @"      ╔═══╗   " + '\n' +
    @"      |   ║   " + '\n' +
    @"      O   ║   " + '\n' +
    @"     /|\  ║   " + '\n' +
    @"     / \  ║   " + '\n' +
    @"          ║   " + '\n' +
    @"    ══════╩═══",

        @"      ╔═══╗   " + '\n' +
    @"      |   ║   " + '\n' +
    @"      o>  ║   " + '\n' +
    @"     /|   ║   " + '\n' +
    @"      >\  ║   " + '\n' +
    @"          ║   " + '\n' +
    @"    ══════╩═══",

        @"      ╔═══╗   " + '\n' +
    @"      |   ║   " + '\n' +
    @"      O   ║   " + '\n' +
    @"     /|\  ║   " + '\n' +
    @"     / \  ║   " + '\n' +
    @"          ║   " + '\n' +
    @"    ══════╩═══",

        @"      ╔═══╗   " + '\n' +
    @"      |   ║   " + '\n' +
    @"     <o   ║   " + '\n' +
    @"      |\  ║   " + '\n' +
    @"     /<   ║   " + '\n' +
    @"          ║   " + '\n' +
    @"    ══════╩═══",

        @"      ╔═══╗   " + '\n' +
    @"      |   ║   " + '\n' +
    @"      O   ║   " + '\n' +
    @"     /|\  ║   " + '\n' +
    @"     / \  ║   " + '\n' +
    @"          ║   " + '\n' +
    @"    ══════╩═══",

        @"      ╔═══╗   " + '\n' +
    @"      |   ║   " + '\n' +
    @"      o>  ║   " + '\n' +
    @"     /|   ║   " + '\n' +
    @"      >\  ║   " + '\n' +
    @"          ║   " + '\n' +
    @"    ══════╩═══",

        @"      ╔═══╗   " + '\n' +
    @"      |   ║   " + '\n' +
    @"      o>  ║   " + '\n' +
    @"     /|   ║   " + '\n' +
    @"      >\  ║   " + '\n' +
    @"          ║   " + '\n' +
    @"    ══════╩═══",

        @"      ╔═══╗   " + '\n' +
    @"      |   ║   " + '\n' +
    @"      O   ║   " + '\n' +
    @"     /|\  ║   " + '\n' +
    @"     / \  ║   " + '\n' +
    @"          ║   " + '\n' +
    @"    ══════╩═══",

        @"      ╔═══╗   " + '\n' +
    @"      |   ║   " + '\n' +
    @"     <o   ║   " + '\n' +
    @"      |\  ║   " + '\n' +
    @"     /<   ║   " + '\n' +
    @"          ║   " + '\n' +
    @"    ══════╩═══",

        @"      ╔═══╗   " + '\n' +
    @"      |   ║   " + '\n' +
    @"     <o   ║   " + '\n' +
    @"      |\  ║   " + '\n' +
    @"     /<   ║   " + '\n' +
    @"          ║   " + '\n' +
    @"    ══════╩═══",

        @"      ╔═══╗   " + '\n' +
    @"      |   ║   " + '\n' +
    @"     <o   ║   " + '\n' +
    @"      |\  ║   " + '\n' +
    @"     /<   ║   " + '\n' +
    @"          ║   " + '\n' +
    @"    ══════╩═══",

        @"      ╔═══╗   " + '\n' +
    @"      |   ║   " + '\n' +
    @"      O   ║   " + '\n' +
    @"     /|\  ║   " + '\n' +
    @"     / \  ║   " + '\n' +
    @"          ║   " + '\n' +
    @"    ══════╩═══",

        @"      ╔═══╗   " + '\n' +
    @"      |   ║   " + '\n' +
    @"      o   ║   " + '\n' +
    @"      |   ║   " + '\n' +
    @"      |   ║   " + '\n' +
    @"          ║   " + '\n' +
    @"    ══════╩═══",

        @"      ╔═══╗   " + '\n' +
    @"      |   ║   " + '\n' +
    @"      o   ║   " + '\n' +
    @"      |   ║   " + '\n' +
    @"      |   ║   " + '\n' +
    @"          ║   " + '\n' +
    @"    ══════╩═══",

        @"      ╔═══╗   " + '\n' +
    @"      |   ║   " + '\n' +
    @"      o   ║   " + '\n' +
    @"      |   ║   " + '\n' +
    @"      |   ║   " + '\n' +
    @"          ║   " + '\n' +
    @"    ══════╩═══",

        @"      ╔═══╗   " + '\n' +
    @"      |   ║   " + '\n' +
    @"      o   ║   " + '\n' +
    @"      |   ║   " + '\n' +
    @"      |   ║   " + '\n' +
    @"          ║   " + '\n' +
    @"    ══════╩═══",

        @"      ╔═══╗   " + '\n' +
    @"      |   ║   " + '\n' +
    @"      o   ║   " + '\n' +
    @"      |   ║   " + '\n' +
    @"      |   ║   " + '\n' +
    @"          ║   " + '\n' +
    @"    ══════╩═══",

        @"      ╔═══╗   " + '\n' +
    @"      |   ║   " + '\n' +
    @"      o   ║   " + '\n' +
    @"      |   ║   " + '\n' +
    @"      |   ║   " + '\n' +
    @"          ║   " + '\n' +
    @"    ══════╩═══",

        @"      ╔═══╗   " + '\n' +
    @"      |   ║   " + '\n' +
    @"      O   ║   " + '\n' +
    @"          ║   " + '\n' +
    @"      |   ║   " + '\n' +
    @"      |   ║   " + '\n' +
    @"    ══════╩═══",

        @"      ╔═══╗   " + '\n' +
    @"      |   ║   " + '\n' +
    @"      O   ║   " + '\n' +
    @"          ║   " + '\n' +
    @"      /   ║   " + '\n' +
    @"      \   ║   " + '\n' +
    @"    ══════╩═══",

        @"      ╔═══╗   " + '\n' +
    @"      |   ║   " + '\n' +
    @"      O   ║   " + '\n' +
    @"      '   ║   " + '\n' +
    @"          ║   " + '\n' +
    @"    |__   ║   " + '\n' +
    @"    ══════╩═══",

        @"      ╔═══╗   " + '\n' +
    @"      |   ║   " + '\n' +
    @"      O   ║   " + '\n' +
    @"      .   ║   " + '\n' +
    @"          ║   " + '\n' +
    @"    \__   ║   " + '\n' +
    @"    ══════╩═══",

        @"      ╔═══╗   " + '\n' +
    @"      |   ║   " + '\n' +
    @"      O   ║   " + '\n' +
    @"          ║   " + '\n' +
    @"      '   ║   " + '\n' +
    @"   ____   ║   " + '\n' +
    @"    ══════╩═══",

        @"      ╔═══╗   " + '\n' +
    @"      |   ║   " + '\n' +
    @"      O   ║   " + '\n' +
    @"      '   ║   " + '\n' +
    @"      .   ║   " + '\n' +
    @"    __    ║   " + '\n' +
    @"   /══════╩═══",

        @"      ╔═══╗   " + '\n' +
    @"      |   ║   " + '\n' +
    @"      O   ║   " + '\n' +
    @"      .   ║   " + '\n' +
    @"          ║   " + '\n' +
    @"    _ '   ║   " + '\n' +
    @"  _/══════╩═══",

        @"      ╔═══╗   " + '\n' +
    @"      |   ║   " + '\n' +
    @"      O   ║   " + '\n' +
    @"          ║   " + '\n' +
    @"      '   ║   " + '\n' +
    @"      _   ║   " + '\n' +
    @" __/══════╩═══",

        @"      ╔═══╗   " + '\n' +
    @"      |   ║   " + '\n' +
    @"      O   ║   " + '\n' +
    @"      '   ║   " + '\n' +
    @"      .   ║   " + '\n' +
    @"          ║   " + '\n' +
    @" __/══════╩═══",

        @"      ╔═══╗   " + '\n' +
    @"      |   ║   " + '\n' +
    @"      O   ║   " + '\n' +
    @"      .   ║   " + '\n' +
    @"          ║   " + '\n' +
    @"      '   ║   " + '\n' +
    @" __/══════╩═══",

        @"      ╔═══╗   " + '\n' +
    @"      |   ║   " + '\n' +
    @"      O   ║   " + '\n' +
    @"          ║   " + '\n' +
    @"      '   ║   " + '\n' +
    @"      _   ║   " + '\n' +
    @" __/══════╩═══",

        @"      ╔═══╗   " + '\n' +
    @"      |   ║   " + '\n' +
    @"      O   ║   " + '\n' +
    @"      '   ║   " + '\n' +
    @"      .   ║   " + '\n' +
    @"          ║   " + '\n' +
    @" __/══════╩═══",

    @"      ╔═══╗   " + '\n' +
    @"      |   ║   " + '\n' +
    @"      O   ║   " + '\n' +
    @"      .   ║   " + '\n' +
    @"          ║   " + '\n' +
    @"      '   ║   " + '\n' +
    @" __/══════╩═══",

    @"      ╔═══╗   " + '\n' +
    @"      |   ║   " + '\n' +
    @"      O   ║   " + '\n' +
    @"          ║   " + '\n' +
    @"      '   ║   " + '\n' +
    @"      _   ║   " + '\n' +
    @" __/══════╩═══",

    @"      ╔═══╗   " + '\n' +
    @"      |   ║   " + '\n' +
    @"      O   ║   " + '\n' +
    @"          ║   " + '\n' +
    @"      .   ║   " + '\n' +
    @"          ║   " + '\n' +
    @" __/══════╩═══",

    @"      ╔═══╗   " + '\n' +
    @"      |   ║   " + '\n' +
    @"      O   ║   " + '\n' +
    @"          ║   " + '\n' +
    @"          ║   " + '\n' +
    @"      '   ║   " + '\n' +
    @" __/══════╩═══",

    @"      ╔═══╗   " + '\n' +
    @"      |   ║   " + '\n' +
    @"      O   ║   " + '\n' +
    @"          ║   " + '\n' +
    @"          ║   " + '\n' +
    @"      _   ║   " + '\n' +
    @" __/══════╩═══"
    };

    static string[] wordList = { "hangman", "programming", "csharp", "developer", "openai", "game" , "SoftUni" , "computer"};

    static void Main()
    {
        Console.WriteLine("Welcome to Hangman!");
        ChooseRandomWord();

        do
        {
            DisplayGameState();
            char guessedLetter = GetGuessedLetter();
            CheckGuess(guessedLetter);
        } while (!GameIsOver());

        DisplayEndGame();
        Console.ReadLine();
    }

    static void ChooseRandomWord()
    {
        Random random = new Random();
        int randomIndex = random.Next(0, wordList.Length);
        chosenWord = wordList[randomIndex];
    }

    static void DisplayGameState()
    {
        Console.Clear();
        Console.WriteLine($"Word: {GetVisibleWord()}");
        Console.WriteLine($"Guessed Letters: {string.Join(", ", guessedLetters)}");
        Console.WriteLine($"Remaining Lives: {remainingLives}");
        Console.WriteLine("Hangman:");
        DisplayHangman();
    }

    static string GetVisibleWord()
    {
        string visibleWord = "";
        foreach (char letter in chosenWord)
        {
            if (guessedLetters.Contains(letter))
                visibleWord += letter;
            else
                visibleWord += "_";
        }
        return visibleWord;
    }

    static void DisplayHangman()
    {
        int frameIndex = hangmanFrames.Length - remainingLives;
        if (frameIndex >= 0 && frameIndex < hangmanFrames.Length)
        {
            Console.WriteLine(hangmanFrames[frameIndex]);
        }
        else if (remainingLives == 0)
        {
            // Display the last frame in the array when lives run out
            Console.WriteLine(hangmanFrames[hangmanFrames.Length - 1]);
        }
    }


    static char GetGuessedLetter()
    {
        char guessedLetter;
        do
        {
            Console.Write("Guess a letter: ");
        } while (!char.TryParse(Console.ReadLine().ToLower(), out guessedLetter) || !char.IsLetter(guessedLetter));

        return guessedLetter;
    }

    static void CheckGuess(char guessedLetter)
    {
        if (guessedLetters.Contains(guessedLetter))
        {
            Console.WriteLine("You already guessed that letter. Try again.");
        }
        else
        {
            guessedLetters.Add(guessedLetter);

            if (!chosenWord.Contains(guessedLetter.ToString()))
            {
                remainingLives--;
                DisplayWrongGuessAnimation();
            }
        }
    }

    static bool GameIsOver()
    {
        return remainingLives == 0 || GetVisibleWord() == chosenWord;
    }

    static void DisplayWinAnimation()
    {
        Console.WriteLine(@"
┌───────────────────────────┐
│                           │
│ WW       WW  **  NN   N   │
│ WW       WW  ii  NNN  N   │
│  WW  WW WW   ii  N NN N   │
│   WWWWWWW    ii  N  NNN   │
│    WW  W     ii  N   NN   │
│                           │
│         Good job!         │
│   You guessed the word!   │
└───────────────────────────┘
"
);
    }

    static void DisplayLossAnimation()
    {
        Console.WriteLine(@"
┌────────────────────────────────────┐
│  LLL          OOOO    SSSS   SSSS  │
│  LLL         OO  OO  SS  SS SS  SS │
│  LLL        OO    OO SS     SS     │
│  LLL        OO    OO  SSSS   SSSS  │
│  LLL        OO    OO     SS     SS │
│  LLLLLLLLLL  OO  OO  SS  SS SS  SS │
│   LLLLLLLLL   OOOO    SSSS   SSSS  │
│                                    |
│        You were so close.          │
│ Next time you will guess the word! │
└────────────────────────────────────┘
"
);
    }

    static void DisplayWrongGuessAnimation()
    {
        Console.Clear();
        int frameIndex = hangmanFrames.Length - remainingLives;

        if (frameIndex >= 0 && frameIndex < hangmanFrames.Length)
        {
            Console.WriteLine(hangmanFrames[frameIndex]);
        }
        else
        {
            // If remainingLives is zero or negative, display the last frame
            Console.WriteLine(hangmanFrames[hangmanFrames.Length - 1]);
        }

        Console.WriteLine("Wrong guess! Try again.");
        Console.ReadLine();
    }


    static void DeathAnimation()
    {
        foreach (var frame in hangmanFrames)
        {
            Console.Clear(); // Clears the console to create an animation effect
            Console.WriteLine(frame);
            System.Threading.Thread.Sleep(500); // Adjust the delay based on your preference
        }
    }

    static void DisplayEndGame()
    {
        Console.Clear();
        if (remainingLives == 0)
        {
            Console.WriteLine("Game over! You ran out of lives!");
            DeathAnimation();
            DisplayLossAnimation();
        }
        else
        {
            Console.WriteLine("Congratulations! You guessed the word!");
            DisplayWinAnimation();
        }
    }
}
