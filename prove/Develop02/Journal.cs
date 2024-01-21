using System;
using System.Collections.Generic;
using System.IO;

class Journal
{
    private List<Entry> entries = new List<Entry>();
    private PromptGenerator promptGenerator = new PromptGenerator();

    public void WriteEntry()
    {
        string prompt = promptGenerator.GetRandomPrompt();
        Console.WriteLine($"Prompt: {prompt}");
        Console.Write("Your response: ");
        string response = Console.ReadLine();

        Entry entry = new Entry(prompt, DateTime.Now, response);
        entries.Add(entry);

        Console.WriteLine("Entry added successfully!\n");
    }

    public void Display()
    {
        if (entries.Count == 0)
        {
            Console.WriteLine("Journal is empty.");
        }
        else
        {
            foreach (var entry in entries)
            {
                Console.WriteLine($"Date: {entry.Date}, Prompt: {entry.Prompt}, Response: {entry.Response}");
            }
        }
        Console.WriteLine();
    }

    public void SaveToFile(string fileName)
    {
        try
        {
            using (StreamWriter writer = new StreamWriter(fileName))
            {
                foreach (var entry in entries)
                {
                    writer.WriteLine($"{entry.Date},{entry.Prompt},{entry.Response}");
                }
            }
            Console.WriteLine("Journal saved successfully!\n");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error saving journal: {ex.Message}\n");
        }
    }

    public void LoadFromFile(string fileName)
    {
        try
        {
            entries.Clear();
            using (StreamReader reader = new StreamReader(fileName))
            {
                while (!reader.EndOfStream)
                {
                    string[] entryData = reader.ReadLine().Split(',');
                    if (entryData.Length == 3)
                    {
                        DateTime date = DateTime.Now; // You can replace this with actual date parsing logic
                        Entry entry = new Entry(entryData[1], date, entryData[2]);
                        entries.Add(entry);
                    }
                }
            }
            Console.WriteLine("Journal loaded successfully!\n");
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("File not found. Unable to load the journal.\n");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error loading journal: {ex.Message}\n");
        }
    }
}
