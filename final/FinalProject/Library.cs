using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public class Library
{
    private List<LibraryItem> libraryItems = new List<LibraryItem>();
    private List<Patron> patrons = new List<Patron>();

    public void AddItem(LibraryItem item)
    {
        libraryItems.Add(item);
    }

    public void AddPatron(Patron patron)
    {
        patrons.Add(patron);
    }

    public void LoadLibraryInventoryFromCSV(string filePath)
    {
        // Load inventory from CSV file
        try
        {
            string[] lines = File.ReadAllLines(filePath);
            foreach (string line in lines)
            {
                string[] parts = line.Split(',');
                if (parts.Length == 4)
                {
                    string title = parts[0].Trim();
                    string author = parts[1].Trim();
                    string genre = parts[2].Trim();
                    int pages = int.Parse(parts[3].Trim());

                    Book book = new Book(title, author, genre, pages);
                    AddItem(book);
                }
            }

            Console.WriteLine("Library inventory loaded successfully!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error loading library inventory: {ex.Message}");
        }
    }

    public void DisplayLibraryInfo()
    {
        Console.WriteLine("Library Inventory:");
        foreach (var item in libraryItems)
        {
            Console.WriteLine(item.GetDisplayText());
        }
    }

    public void DisplayItemsByGenre(LibraryItem sampleItem, string genre)
    {
        var matchingItems = libraryItems
            .Where(item => item.MatchGenre(sampleItem, genre))
            .ToList();

        DisplayMatchingItems(matchingItems);
    }

    public void DisplayItemsByName(LibraryItem sampleItem, string name)
    {
        var matchingItems = libraryItems
            .Where(item => item.MatchName(sampleItem, name))
            .ToList();

        DisplayMatchingItems(matchingItems);
    }

    public void DisplayItemsByAuthor(LibraryItem sampleItem, string author)
    {
        var matchingItems = libraryItems
            .Where(item => item.MatchAuthor(sampleItem, author))
            .ToList();

        DisplayMatchingItems(matchingItems);
    }

    public void CheckOutBook(Patron patron, string bookName)
    {
        LibraryItem bookToCheckOut = libraryItems
            .FirstOrDefault(item => item.MatchName(new Book(bookName, "", "", 0), bookName) && !item.IsCheckedOut);

        if (bookToCheckOut != null)
        {
            bookToCheckOut.CheckOut(patron);
            patron.CheckOutItem(bookToCheckOut);
            AddPatron(patron);
            
            Console.WriteLine($"{patron.Name} checked out {bookToCheckOut.Title}.");
        }
        else
        {
            Console.WriteLine($"Error: Book '{bookName}' not available for checkout.");
        }
    }

    public void ReturnBook()
    {
        // Ask for user's name
        Console.Write("Enter your name: ");
        string patronName = Console.ReadLine();

        // Find the patron
             
        Patron _patron = patrons.FirstOrDefault(patron => patron.Name.Equals(patronName, StringComparison.OrdinalIgnoreCase));
        //Patron _patron = patrons.Where(_patron=>_patron.Name.Contains(patronName));
        if (_patron != null)
        {
            // Display the books checked out by the patron
            DisplayCheckedOutBooks(_patron);

            // Ask which book to return
            Console.Write("Enter the name of the book you want to return: ");
            string returningBookName = Console.ReadLine();

            // Return the selected book
            ReturnBook(_patron, returningBookName);
        }
        else
        {
            Console.WriteLine($"Error: Patron '{patronName}' not found.");
        }
    }

    private void DisplayCheckedOutBooks(Patron patron)
    {
        Console.WriteLine($"Books checked out by {patron.Name}:");
        foreach (var checkedOutBook in patron.CheckedOutItems)
        {
            Console.WriteLine($"{checkedOutBook.Title} ({checkedOutBook.GetType().Name})");
        }
    }

    private void ReturnBook(Patron patron, string bookName)
    {
        LibraryItem bookToReturn = patron.CheckedOutItems
            .FirstOrDefault(item => item.MatchName(new Book(bookName, "", "", 0), bookName));

        if (bookToReturn != null)
        {
            if (bookToReturn.IsCheckedOut && bookToReturn.CheckedOutBy == patron)
            {
                patron.ReturnItem(bookToReturn);
                bookToReturn.Return();  // Update: This line is added to update the book's status
                Console.WriteLine($"{patron.Name} returned {bookToReturn.Title}.");
            }
            else
            {
                Console.WriteLine($"Error: {patron.Name} did not check out the book '{bookName}'.");
            }
        }
        else
        {
            Console.WriteLine($"Error: Book '{bookName}' not found in the library inventory.");
        }
    }

    private Patron FindPatron(string patronName)
    {
        return patrons.FirstOrDefault(patron => patron.Name.Equals(patronName, StringComparison.OrdinalIgnoreCase));
    }

    private void DisplayMatchingItems(List<LibraryItem> matchingItems)
    {
        Console.WriteLine("Matching Items:");
        foreach (var item in matchingItems)
        {
            Console.WriteLine(item.GetDisplayText());
        }
    }
}
