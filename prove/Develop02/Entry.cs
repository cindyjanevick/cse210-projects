using System;

class Entry
{
    public string Prompt { get; }
    public DateTime Date { get; }
    public string Response { get; }

    public Entry(string prompt, DateTime date, string response)
    {
        Prompt = prompt;
        Date = date;
        Response = response;
    }
}
