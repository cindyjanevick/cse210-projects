using System;
using System.Threading;

public class Activity
{
    protected string _name;
    protected string _description;
    protected int _duration;

    public Activity(string name, string description, int duration)
    {
        _name = name;
        _description = description;
        _duration = duration;
    }

    public void DisplayStartingMessage()
    {
        Console.WriteLine($"Welcome to the {_name} Activity.");
        Console.WriteLine(_description);
        Console.Write("How long, in seconds, would you like for your session? ");
        int.TryParse(Console.ReadLine(), out _duration);
    }

    public void DisplayEndingMessage()
    {
        Console.WriteLine("Well done!");
        Console.WriteLine($"You have completed another {_duration} seconds of the {_name} Activity.");
        ShowSpinner(3);
        Console.WriteLine("Press Enter to return to the main menu.");
        Console.ReadLine();
    }

    public void ShowSpinner(int seconds)
    {
        string[] spin= {"|","/","-","\\","|","/","-","\\"};
        for (int i = 0; i < seconds; i++)
        {
            Console.Write(spin[i]);
            Thread.Sleep(500);
            Console.Write("\b \b");
            Thread.Sleep(500);
        }
        Console.WriteLine();
    }

    public void ShowCountDown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write(i + " ");
            Thread.Sleep(1000);
            Console.Write("\b\b \b\b"); 
        }
        Console.WriteLine();
    }

    public virtual void Run()
    {
        
    }
}
