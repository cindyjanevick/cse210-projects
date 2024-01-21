using System;

class Program
{
    static void Main()
    {
        Journal journal = new Journal();
        int option;

        Console.WriteLine("Welcome to the Journal Program!");

        do
        {
            PrintMenu();

            Console.Write("What would you like to do today? ");
            string choice = Console.ReadLine();

            if (int.TryParse(choice, out option))
            {
                switch (option)
                {
                    case 1:
                        journal.WriteEntry();
                        break;

                    case 2:
                        journal.Display();
                        break;

                    case 3:
                        Console.Write("Enter the filename to load: ");
                        string loadFileName = Console.ReadLine();
                        journal.LoadFromFile(loadFileName);
                        break;

                    case 4:
                        Console.Write("Enter the filename to save: ");
                        string saveFileName = Console.ReadLine();
                        journal.SaveToFile(saveFileName);
                        break;

                    case 5:
                        Console.WriteLine("Exiting the program. See you next time!");
                        break;

                    default:
                        Console.WriteLine("Invalid choice. Please choose a valid option (1-5).\n");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a number (1-5).\n");
            }

        } while (option != 5);
    }

    static void PrintMenu()
    {
        Console.WriteLine("Please select one of the following choices:");
        Console.WriteLine("1. Write a new entry");
        Console.WriteLine("2. Display");
        Console.WriteLine("3. Load journal file");
        Console.WriteLine("4. Save file");
        Console.WriteLine("5. Quit");
    }
}
