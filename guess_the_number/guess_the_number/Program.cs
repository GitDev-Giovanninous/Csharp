using System;

class Program
{
    static void Main(string[] args)
    {

        while (true)
        {

            Console.WriteLine("""
            === GUESS THE NUMBER ===
            
            Press P to Play, Q to quit.
            
            """);

            string choice = Console.ReadLine().ToLower();

            if (choice == "p")
            {

                Game();

            }
            else if (choice == "q")
            {

                break;

            }

        }

    }
    static int AskNumber()
    {

        while (true)
        {
            try
            {

                Console.WriteLine("\nWrite a number: ");

                int n = Convert.ToInt32(Console.ReadLine());

                if (n > 0 && n <= 100)
                {
                    return n;
                }
                else
                {
                    Console.WriteLine("\nError, retry!");

                    continue;
                }

            }
            catch (FormatException)
            {
                Console.WriteLine("\nError, retry!");

                continue;

            }
            catch (OverflowException)
            {
                Console.WriteLine("\nError, retry!");

                continue;
            }
        }

    }

    static void Game()
    {

        Random random = new Random();

        int bot = random.Next(1, 101);

        int attempts = 0;

        while (true)
        {
            attempts++;

            int attempt = AskNumber();

            if (attempt > bot)
            {
                Console.WriteLine("\nThe number you chose is greater than the one I had in mind. Try again!");

                continue;
            }
            else if (attempt < bot)
            {
                Console.WriteLine("\nThe number you chose is smaller than the one I had in mind. Try again!");

                continue;
            }
            else if (attempt == bot)
            {
                Console.WriteLine($"\nThe number you chose is the same as the one I had in mind! ({bot})\n" +
                $"It took you {attempts} tries to guess it!");

                break;
            }


        }

    }
}
