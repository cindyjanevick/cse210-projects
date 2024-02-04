using System;
using System.Threading;

public class BreathingActivity : Activity
{
    public BreathingActivity() : base("Breathing", "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.", 0)
    {
    }

    public override void Run()
    {
        DisplayStartingMessage();

        for (int i = 0; i < _duration; i += 6)
        {
            Console.WriteLine("Breathe in...");

            
            BreathingAnimation(true, 3);

            Console.WriteLine("Now breathe out...");

            
            BreathingAnimation(false, 3);
        }

        DisplayEndingMessage();
    }

    private void BreathingAnimation(bool breathingIn, int seconds)
    {
        int growthRate = breathingIn ? 2 : 1; 
        int initialSize = 5;

        for (int i = 1; i <= seconds; i++)
        {
            int newSize = initialSize * i * growthRate;

            Console.WriteLine(new string(' ', newSize) + "Breathe...");

            Thread.Sleep(1000);
            Console.Clear(); 
        }
    }
}
