using System;
using System.Collections.Generic;

public class Patron
{
    public string Name { get; private set; }
    public List<LibraryItem> CheckedOutItems { get; private set; }

    public Patron(string name)
    {
        Name = name;
        CheckedOutItems = new List<LibraryItem>();
    }

    public void CheckOutItem(LibraryItem item)
    {
        CheckedOutItems.Add(item);
    }

    public void ReturnItem(LibraryItem item)
    {
        CheckedOutItems.Remove(item);
    }

    public bool HasCheckedOutItem(LibraryItem item)
    {
        return CheckedOutItems.Contains(item);
    }
}
