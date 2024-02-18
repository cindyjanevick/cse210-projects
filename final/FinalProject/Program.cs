using System;

class Program
{
    static void Main()
    {
       
        Library library = new Library();
        library.LoadLibraryInventoryFromCSV("library_inventory.csv");

        Console.WriteLine("Welcome to the \"Vick Library\"");
        int choice;
        do
        {
            Console.WriteLine("What do you want to do today?");
            Console.WriteLine("1. Display Library Inventory");
            Console.WriteLine("2. Search a book");
            Console.WriteLine("3. Check out a book");
            Console.WriteLine("4. Return a book");
            Console.WriteLine("5. Quit");
            Console.Write("Enter your choice (1-5): ");

            if (int.TryParse(Console.ReadLine(), out choice))
            {
                switch (choice)
                {
                    case 1:
                        library.DisplayLibraryInfo();
                        break;
                    case 2:
                        // Search a book
                        Console.WriteLine("Choose a search option:");
                        Console.WriteLine("1. Display items by genre");
                        Console.WriteLine("2. Display items by name");
                        Console.WriteLine("3. Display items by author");
                        Console.Write("Enter your choice (1-3): ");
                        int searchOption;
                        if (int.TryParse(Console.ReadLine(), out searchOption))
                        {
                            switch (searchOption)
                            {
                                case 1:
                                    Console.Write("Enter the genre: ");
                                    string genre = Console.ReadLine();
                                    library.DisplayItemsByGenre(new Book("", "", genre, 0), genre);
                                    break;
                                case 2:
                                    Console.Write("Enter the name: ");
                                    string name = Console.ReadLine();
                                    library.DisplayItemsByName(new Book(name, "", "", 0), name);
                                    break;
                                case 3:
                                    Console.Write("Enter the author: ");
                                    string author = Console.ReadLine();
                                    library.DisplayItemsByAuthor(new Book("", author, "", 0), author);
                                    break;
                                default:
                                    Console.WriteLine("Invalid search option.");
                                    break;
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid input. Please enter a number.");
                        }
                        break;
                    case 3:
                        // Check out a book
                        Console.Write("Enter your name: ");
                        string patronName = Console.ReadLine();
                        Patron patron = new Patron(patronName);

                        Console.Write("Enter the name of the book you want to check out: ");
                        string bookName = Console.ReadLine();

                        library.CheckOutBook(patron, bookName);
                        break;
                    case 4:
                        // Return a book
                        library.ReturnBook();
                        break;
                    case 5:
                        Console.WriteLine("Goodbye!");
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please enter a number between 1 and 5.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a number.");
            }
        } while (choice != 5);
    }
}
