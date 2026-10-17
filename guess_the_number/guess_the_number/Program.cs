using System;
using System.Collections.Generic;
using System.Linq;

class Program
{

    static void Main(string[] args)
    {

        Dictionary<string, Dictionary<string, int>> Stats = new Dictionary<string, Dictionary<string, int>>
        {
            {"easy", new Dictionary<string, int>

            {
                {"games", 0},
                {"win", 0},
                {"loose", 0},
            }

            },
            
            {"medium", new Dictionary<string, int>

            {
                {"games", 0},
                {"win", 0},
                {"loose", 0},
            }

            },

            {"hard", new Dictionary<string, int>

            {
                {"games", 0},
                {"win", 0},
                {"loose", 0},
            }

            }

        };

        while (true)
        {

            Console.WriteLine("""
                ===== GUESS THE NUMBER =====
                1. Play
                2. Stats
                3. Exit
                """);

            string choice = Console.ReadLine().ToLower();

            if (choice == "1")
            {
                string difficulty_choice = ChooseDifficulty();

                switch (difficulty_choice) {

                    case "1":

                        Game(50, 51, ref Stats, "easy");

                        break;

                    case "2":

                        Game(100, 15, ref Stats, "medium");

                        break;

                    case "3":

                        Game(100, 10, ref Stats, "hard");

                        break;

                    case "":

                        return;

                    default:

                        Console.WriteLine("Error, retry");

                        break;

                }
            }
            else if (choice == "2")
            {
                Statistics(ref Stats);
            }
            else if (choice == "3")
            {
                break;
            }
            else
            {
                Console.WriteLine("Error, retry");
            }

        }


    }

    static void Game(int n2, int max, ref Dictionary<string, Dictionary<string, int>> stats, string difficulty)
    {
        Random random = new Random();

        int bot = random.Next(1, n2 + 1);

        int attempts = 0;

        int max_attempts = max;

        while (true)
        {
            if (max_attempts > 0)
            {
                attempts++;

                max_attempts--;


                int player = AskNumber(n2);

                if (player > bot)
                {
                    Console.WriteLine($"\nThe number you chose is greater than the one I had in mind. You have now {max_attempts} attempts");

                    continue;

                }
                else if (player < bot)
                {

                    Console.WriteLine($"\nThe number you chose is smaller than the one I had in mind. You have now {max_attempts} attempts");

                    continue;

                }
                else
                {
                    Console.WriteLine($"\nThe number you chose is the same as the one I had in mind! ({bot})\n" +
                $"It took you {attempts} tries to guess it!");

                    stats[difficulty]["win"]++;
                    stats[difficulty]["games"]++;

                    break;

                }

            }
            else
            {
                Console.WriteLine("\nYou loose :(");

                stats[difficulty]["loose"]++;
                stats[difficulty]["games"]++;

                break;
            }
        }


    }
    static int AskNumber(int n2)
    {

        while (true)
        {
            try
            {

                Console.WriteLine($"\nWrite a number between 1 and {n2}: ");

                int n = Convert.ToInt32(Console.ReadLine());

                if (n > 0 && n <= n2)
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

    static string ChooseDifficulty()
    {
        while (true)
        {
            Console.WriteLine("""
                Choose between:

                1. Easy (1-50 max attempts)
                2. Medium (1-100 with 15 attempts)
                3. Hard (1-100 with 10 attempts)
                4. Exit
                
                """);

            string choice = Console.ReadLine();

            switch (choice) {

                case "1":

                    return "1";


                case "2":

                    return "2";

                case "3":

                    return "3";

                case "4":

                    return "";

                default:

                    Console.WriteLine("\nError, retry!");

                    continue;

            }
        }
    }

    static void Statistics(ref Dictionary<string, Dictionary<string, int>> stats)
    {

        foreach (var mode in stats)
        {
            Console.WriteLine($"--- {mode.Key} ---");

            foreach (var stat in mode.Value)
            {
                Console.WriteLine($"{stat.Key}: {stat.Value}");
            }
        }
    }
}