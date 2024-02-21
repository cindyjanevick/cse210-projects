using System;

public class Book : LibraryItem
{
    public int Pages { get; private set; }

    public Book(string title, string author, string genre, int pages) : base(title, author, genre)
    {
        Pages = pages;
    }

    public new bool IsCheckedOut => CheckedOutBy != null;

    public override bool MatchName(LibraryItem sampleItem, string name)
    {
        if (sampleItem is Book sampleBook)
        {
            return string.Equals(Title, sampleBook.Title, StringComparison.OrdinalIgnoreCase);
        }
        return false;
    }

    public override bool MatchAuthor(LibraryItem sampleItem, string author)
    {
        return Author.Contains(author, StringComparison.OrdinalIgnoreCase);
    }

    public override bool MatchGenre(LibraryItem sampleItem, string genre)
    {
        return Genre.Contains(genre, StringComparison.OrdinalIgnoreCase);
    }

    public override string GetDisplayText()
    {
        return $"{Title} by {Author} ({Genre}) - {Pages} pages";
    }
}