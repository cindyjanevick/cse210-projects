using System;

public abstract class LibraryItem
{
    public string Title { get; protected set; }
    public string Author { get; protected set; }
    public string Genre { get; protected set; }
    public bool IsCheckedOut { get; protected set; }
    public Patron CheckedOutBy { get; protected set; }

    public LibraryItem(string title, string author, string genre)
    {
        Title = title;
        Author = author;
        Genre = genre;
    }

    public void CheckOut(Patron patron)
    {
        if (!IsCheckedOut)
        {
            IsCheckedOut = true;
            CheckedOutBy = patron;
        }
    }

    public void Return()
    {
        if (IsCheckedOut)
        {
            IsCheckedOut = false;
            CheckedOutBy = null;
        }
    }

    public abstract bool MatchName(LibraryItem sampleItem, string name);
    public abstract bool MatchAuthor(LibraryItem sampleItem, string author);
    public abstract bool MatchGenre(LibraryItem sampleItem, string genre);

    public abstract string GetDisplayText();
}
