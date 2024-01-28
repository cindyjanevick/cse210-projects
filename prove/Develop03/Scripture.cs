using System;
using System.Collections.Generic;
using System.Linq;

public class Scripture
{
    private Reference _reference;
    private List<Word> _words;

    // Constructors
    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = text.Split(' ').Select(word => new Word(word)).ToList();
    }
public Reference GetReference()
    {
        return _reference;
    }
    // Methods
    public void HideRandomWords(int numberToHide)
    {
        Random random = new Random();

        List<Word> wordsToHide = _words.Where(word => !word.IsHidden()).ToList();

        for (int i = 0; i < Math.Min(numberToHide, wordsToHide.Count); i++)
        {
            int randomIndex = random.Next(wordsToHide.Count);
            wordsToHide[randomIndex].Hide();
        }

        Console.Clear();
        Console.WriteLine(GetDisplayText());
    }

    public string GetDisplayText()
    {
        string displayText = $"{_reference.GetDisplayText()}\n";

        foreach (var word in _words)
        {
            displayText += word.GetDisplayText() + " ";
        }

        return displayText;
    }

    public bool IsCompletelyHidden()
    {
        return _words.All(word => word.IsHidden());
    }
}
