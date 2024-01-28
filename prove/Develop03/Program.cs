//I added a menu where the user will choose what does he want to do, display the references we have, 
//add a new reference , enter a specific reference to practice or randomly use a reference to practice


using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        

        List<Scripture> verses = InitializeScriptures();

        do
        {
            Console.Clear();
            Console.WriteLine("Welcome to Scripture Memorizer!");
            Console.WriteLine("What do you want to do today?");
            Console.WriteLine("1. Display the references in the database");
            Console.WriteLine("2. Add a new reference");
            Console.WriteLine("3. Randomly use a reference to practice");
            Console.WriteLine("4. Enter the reference you want to practice today");
            Console.WriteLine("5. Quit");

            Console.Write("Enter your choice (1-5): ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    DisplayReferences(verses);
                    break;

                case "2":
                    AddNewReference(verses);
                    break;

                case "3":
                    PracticeRandomReference(verses);
                    break;

                 case "4":
                    PracticeSpecificReference(verses);
                    break;

                case "5":
                    Console.WriteLine("Goodbye!");
                    return;

                default:
                    Console.WriteLine("Invalid choice. Please enter a number between 1 and 4.");
                    break;
            }

        } while (true);
    }
static void PracticeSpecificReference(List<Scripture> verses)
    {
        Console.Clear();
        Console.WriteLine("Enter the reference you want to practice (e.g., 'John 3:16' or 'D&C 76:40-41'):");

        string input = Console.ReadLine();
        Reference selectedReference = FindReference(verses, input);

        if (selectedReference != null)
        {
            Scripture selectedVerse = verses.Find(verse => verse.GetReference() == selectedReference);

            do
            {
                Console.Clear();
                Console.WriteLine(selectedVerse.GetDisplayText());

                Console.Write("Press Enter to continue or type 'quit' to exit: ");
                input = Console.ReadLine();

                if (input.ToLower() == "quit")
                {
                    return;
                }

                selectedVerse.HideRandomWords(2);

            } while (!selectedVerse.IsCompletelyHidden());
        }
        else
        {
            Console.WriteLine("Reference not found in the database.");
            Console.WriteLine("Press Enter to continue...");
            Console.ReadLine();
        }
    }

    static Reference FindReference(List<Scripture> verses, string input)
    {
        foreach (var verse in verses)
        {
            Reference reference = verse.GetReference();
            if (reference.GetDisplayText().Equals(input, StringComparison.OrdinalIgnoreCase))
            {
                return reference;
            }
        }
        return null;
    }
    static List<Scripture> InitializeScriptures()
    {
        List<Scripture> verses = new List<Scripture>();

        Reference reference1 = new Reference("1 Nephi", 3, 7);
        string text1 = "And it came to pass that I, Nephi, said unto my father: I will go and do the things which the Lord hath commanded, for I know that the Lord giveth no commandments unto the children of men, save he shall prepare a way for them that they may accomplish the thing which he commandeth them.";
        Scripture verse1 = new Scripture(reference1, text1);
        verses.Add(verse1);

        Reference reference2 = new Reference("Moroni", 7, 41);
        string text2 = "And what is it that ye shall hope for? Behold I say unto you that ye shall have hope through the atonement of Christ and the power of his resurrection, to be raised unto life eternal, and this because of your faith in him according to the promise.";
        Scripture verse2 = new Scripture(reference2, text2);
        verses.Add(verse2);

        Reference reference3 = new Reference("Alma", 39, 9);
        string text3 = "Now my son, I would that ye should repent and forsake your sins, and go no more after the lusts of your eyes, but cross yourself in all these things; for except ye do this ye can in nowise inherit the kingdom of God. Oh, remember, and take it upon you, and cross yourself in these things.";
        Scripture verse3 = new Scripture(reference3, text3);
        verses.Add(verse3);

        Reference reference4 = new Reference("D&C", 76, 40, 41);
        string text4 = "And this is the gospel, the glad tidings, which the voice out of the heavens bore record unto us—\n\nThat he came into the world, even Jesus, to be crucified for the world, and to bear the sins of the world, and to sanctify the world, and to cleanse it from all unrighteousness;";
        Scripture verse4 = new Scripture(reference4, text4);
        verses.Add(verse4);

        Reference reference5 = new Reference("D&C", 84, 46);
        string text5 = "And the Spirit giveth light to every man that cometh into the world; and the Spirit enlighteneth every man through the world, that hearkeneth to the voice of the Spirit.";
        Scripture verse5 = new Scripture(reference5, text5);
        verses.Add(verse5);

        return verses;
    }

    static void DisplayReferences(List<Scripture> verses)
    {
        Console.Clear();
        Console.WriteLine("References in the database:");

        foreach (var verse in verses)
        {
            Console.WriteLine(verse.GetReference().GetDisplayText());
        }

        Console.WriteLine("Press Enter to continue...");
        Console.ReadLine();
    }

    static void AddNewReference(List<Scripture> verses)
    {
        Console.Clear();
        Console.Write("Enter the book: ");
        string book = Console.ReadLine();

        Console.Write("Enter the chapter: ");
        int chapter = int.Parse(Console.ReadLine());

        Console.Write("Enter the verse: ");
        int verse = int.Parse(Console.ReadLine());

        Console.Write("Enter the text: ");
        string text = Console.ReadLine();

        Reference newReference = new Reference(book, chapter, verse);
        Scripture newVerse = new Scripture(newReference, text);
        verses.Add(newVerse);

        Console.WriteLine("Reference added successfully!");
        Console.WriteLine("Press Enter to continue...");
        Console.ReadLine();
    }

    static void PracticeRandomReference(List<Scripture> verses)
    {
        if (verses.Count == 0)
        {
            Console.WriteLine("No references available to practice. Add references first.");
            Console.WriteLine("Press Enter to continue...");
            Console.ReadLine();
            return;
        }

        Random random = new Random();
        int randomIndex = random.Next(verses.Count);
        Scripture randomVerse = verses[randomIndex];

        do
        {
            Console.Clear();
           Console.WriteLine(randomVerse.GetDisplayText());

            Console.Write("Press Enter to continue or type 'quit' to exit: ");
            string input = Console.ReadLine();

            if (input.ToLower() == "quit")
            {
                return;
            }

            randomVerse.HideRandomWords(2);

        } while (!randomVerse.IsCompletelyHidden());
    }
}
