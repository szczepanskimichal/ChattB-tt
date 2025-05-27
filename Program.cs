
using System;

class Program
{
    static void Main(String[] args)
    {
        bool play = true;
        while (play)
        {
            ShowMenu();
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
       
    }

    private static void ShowMenu()
    {
        //Console.WriteLine("Hello, World!");
        Console.Clear(); // Clear the console screen
        Console.WriteLine("welcome to my chattbått");
        Console.WriteLine("1.Create a new chattbått");
        Console.WriteLine("2.Load a chattbått");
        Console.WriteLine("3.Exit");
        Console.Write("Please select an option (1-3): ");
        string choice = Console.ReadLine();

        switch (choice)
        {
            case "1":
                Console.WriteLine("You chose to create a new chattbått.");
                // Add logic for creating a new chattbått here
                break;
            case "2":
                Console.WriteLine("You chose to load a chattbått.");
                // Add logic for loading an existing chattbått here
                break;
            case "3":
                Console.WriteLine("Exiting the program. Goodbye!");
                Environment.Exit(0);
                break;
            default:
                Console.WriteLine("Invalid choice. Please select a valid option (1-3).");
                Console.ReadLine();
                break;
        }
    }
}