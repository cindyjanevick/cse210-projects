using System;
using System.Collections.Generic;

class PromptGenerator
{
    private List<string> prompts = new List<string>
    {
        "Who was the most interesting person I interacted with today?",
        "How did I see the hand of the Lord in my life today?",
        "What was the strongest emotion I felt today?",
        "If I had one thing I could do over today, what would it be?",
        "What made you smile or laugh today?",
        "How did I take care of myself today?",
        "What is the most exciting thing you did today",
        "Who from my family did I talk to, today?",
        "How many hours did I study today",
        "What did I learn today that I didn't know before?",
        "Did I visit or call a friend today?",
        "Write about a challenge situation that I faced today",
        "Express gratitud for three things that happened during your day",

    };

    private Random random = new Random();

    public string GetRandomPrompt()
    {
        int index = random.Next(prompts.Count);
        return prompts[index];
    }
}
