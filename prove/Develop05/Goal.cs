using System;

public abstract class Goal
{
    private string _goalName;
    private string _goalDescription;

    public Goal() {}

    public Goal(string goalName, string goalDescription)
    {
        _goalName = goalName;
        _goalDescription = goalDescription;
    }

    public string GetGoalName()
    {
        return _goalName;
    }

    public void SetGoalName(string goalName)
    {
        _goalName = goalName;
    }

    public string GetGoalDescription()
    {
        return _goalDescription;
    }

    public void SetGoalDescription(string goalDescription)
    {
        _goalDescription = goalDescription;
    }

    public abstract void DisplayGoalPoints();

    public abstract int GetGoalPoints();

    public abstract bool GetGoalStatus();

    public abstract string ToCSVRecord();

    public abstract void RecordEvent();

    public string DisplayGoalName()
    {
        Console.Write("What is the name of your goal? ");
        _goalName = Console.ReadLine();
        return _goalName;
    }

    public string DisplayGoalDescription()
    {
        Console.Write("What is a short description of your goal? ");
        _goalDescription = Console.ReadLine();
        return _goalDescription;
    }
}
