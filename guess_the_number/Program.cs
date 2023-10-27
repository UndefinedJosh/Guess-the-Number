public class MasterMind
{
    public static void Main()
    {
        bool playAgain = true;

        while (playAgain)
        {
            Random random = new Random();
            int number = random.Next(0, 100);
            int tryCount = 5;
            List<int> guesses = new List<int>();

            Console.WriteLine("Welcome to GUESS THE NUMBER");
            Console.WriteLine("______________________________");
            while (tryCount > 0)
            {
                PrintSpacer();
                Console.WriteLine("You have " + tryCount + " attempts left.");
                Console.WriteLine("____________________");
                PrintSpacer();

                string input = Console.ReadLine();

                if (int.TryParse(input, out int inputNumber))
                {
                    tryCount--;

                    guesses.Add(inputNumber);

                    if (inputNumber == number)
                    {
                        PrintSpacer();
                        Console.WriteLine("Congrats, you got it!");
                        tryCount = 0;
                        continue;
                    }

                    PrintSpacer();
                    Console.WriteLine(CalculateGuess(inputNumber,number));
                    Console.WriteLine("____________________");
                }
                else
                {
                    Console.WriteLine(input + " is not a number, try again!");
                    PrintSpacer();
                }
            }

            Console.WriteLine("_____________________________");
            PrintSpacer();
            Console.WriteLine("Searched number: " + number);
            PrintSpacer();
            Console.WriteLine("Your guesses:");

            foreach (int guess in guesses)
            {
                Console.WriteLine(guess + " | " + CalculateGuess(guess, number));
            }

            PrintSpacer();
            Console.WriteLine("Do you want to play again? (yes/no)");
            string playAgainInput = Console.ReadLine().ToLower();
            playAgain = (playAgainInput == "yes" || playAgainInput == "y");
            PrintSpacer();
        }

        Console.WriteLine("Thanks for playing! Press any key to exit.");
        Console.ReadLine();
    }

    public static void PrintSpacer()
    {
        Console.WriteLine(" ");
    }

    public static string CalculateGuess(int guessNumber, int number)
    {
        string output = (guessNumber == number) ? "Match" : (guessNumber > number) ? "Larger" : "Smaller";

        return output;
    }
}
