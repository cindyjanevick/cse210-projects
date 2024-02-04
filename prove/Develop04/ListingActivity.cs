using System;
using System.Collections.Generic;
using System.Threading;

public class ListingActivity : Activity
{
    public ListingActivity() : base("Listing", "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.", 0)
    {
    }

    public override void Run()
    {
        DisplayStartingMessage();

        Console.WriteLine("List as many responses as you can to the following prompt:");
        Console.WriteLine("--- When have you felt the Holy Ghost this month? ---");
        ShowCountDown(3);

        Console.WriteLine("You may begin in:");

        for (int i = 3; i > 0; i--)
        {
            Console.Write(i + " ");
            Thread.Sleep(1000);
            Console.Write("\b\b \b\b"); 
        }
        Console.WriteLine();

        GetListFromUser();
        DisplayEndingMessage();
    }

    public void GetListFromUser()
    {
        Console.WriteLine("Now, type as many responses as you want. Press Enter after each response. Type 'done' when finished:");

        int count = 0;
        string response;
        do
        {
            response = Console.ReadLine();
            if (response.ToLower() != "done")
            {
                count++;
            }
        } while (response.ToLower() != "done");

        Console.WriteLine($"You listed {count} items!!");

        ShowSpinner(3);
    }
}
