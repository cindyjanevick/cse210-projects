// I added animation of CONGRATULATIONS when you complete your goals in the ChecklistGoal//

using System;

class Program
{
    static void Main(string[] args)
    {
        GoalManager goalmanager = new GoalManager();
        int userMainMenuSelection = 0;

        Console.Clear();

        Console.WriteLine();

        while (userMainMenuSelection != 6)
        {
            DisplayMainMenu(goalmanager);
            userMainMenuSelection = int.Parse(Console.ReadLine());
            Console.Clear();

            switch (userMainMenuSelection)
            {
                case 1:
                    CreateNewGoal(goalmanager);
                    break;

                case 2:
                    goalmanager.DisplayGoals();
                    break;

                case 3:
                    goalmanager.SaveGoals();
                    break;

                case 4:
                    goalmanager.LoadGoals();
                    break;

                case 5:
                    goalmanager.DisplayGoalRecordEvent();
                    break;

                case 6:
                    Console.WriteLine();
                    Console.WriteLine("Goodbye. Hope to see you again.");
                    break;

                default:
                    Console.WriteLine("Please select a valid option.");
                    break;
            }
        }
    }

    static void DisplayMainMenu(GoalManager goalManager)
    {
        Console.WriteLine();
        goalManager.DisplayPoints(goalManager.GetTotalPoints());

        Console.WriteLine();
        Console.WriteLine("Main Menu:");
        Console.WriteLine("1. Create New Goal");
        Console.WriteLine("2. List Goals");
        Console.WriteLine("3. Save Goals");
        Console.WriteLine("4. Load Goals");
        Console.WriteLine("5. Record Event");
        Console.WriteLine("6. Quit");
        Console.Write("Select a choice from the menu: ");
    }

    static void CreateNewGoal(GoalManager goalManager)
    {
        Console.WriteLine();
        Console.WriteLine("New Goal Menu:");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");
        Console.Write("Which type of goal would you like to create? ");

        int userNewGoalSelection = int.Parse(Console.ReadLine());
        Console.Clear();
        Goal goal = null;

        switch (userNewGoalSelection)
        {
            case 1:
                goal = new SimpleGoal();
                break;
            case 2:
                goal = new EternalGoal();
                break;
            case 3:
                goal = new CheckListGoal();
                break;
            default:
                Console.WriteLine("Invalid goal type selected.");
                break;
        }

        if (goal != null)
        {
            goal.DisplayGoalName();
            goal.DisplayGoalDescription();
            goal.DisplayGoalPoints();
            goalManager.AddGoal(goal);
        }
    }
}
