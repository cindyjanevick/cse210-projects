using System;
public class CheckListGoal : Goal
{
    private string _goalType = "CheckList";
    private int _goalPoints;
    private int _goalTimes;
    private int _goalBonus;
    private int _timesCompleted = 0;
    private int _totalPoints = 0;
    private bool _goalComplete;

    public CheckListGoal()
    {
    }

    public CheckListGoal(string goalName, string goalDescription, int goalPoints, int goalTimes, int timesCompleted, int goalBonus, bool goalComplete) : base (goalName, goalDescription)
    {
        _goalPoints = goalPoints;
        _goalTimes = goalTimes;
        _timesCompleted = timesCompleted;
        _goalBonus = goalBonus;
        _goalComplete = goalComplete;
    }

    public override void DisplayGoalPoints()
    {
        Console.Write("What is the amount of points associated with this goal? ");
        _goalPoints = int.Parse(Console.ReadLine());
        
        Console.Write("How many times does this goal need to be accomplished for a bonus? ");
        _goalTimes = int.Parse(Console.ReadLine());
        
        Console.Write($"What is the bonus for accomplishing it that many times? ");
        _goalBonus = int.Parse(Console.ReadLine());
        return;
    }
    public int GetPoints()
    {
        return _goalPoints;
    }
    public override int GetGoalPoints()
    {
        if (_timesCompleted == _goalTimes)
        {
            _totalPoints = _goalPoints + _goalBonus;
        }
        else if (_timesCompleted < _goalTimes)
        {
            _totalPoints = _goalPoints;
        }
        return _totalPoints;
    }
    public int GetGoalTimes()
    {
        return _goalTimes;
    }
    public int GetGoalBonus()
    {
        return _goalBonus;
    }
    public int GetRunningTimes()
    {
        return _timesCompleted;
    }
    
    public override bool GetGoalStatus()
    {
        return _goalComplete;
    }

    public override string ToCSVRecord()
    {
        return $"{_goalType}:{GetGoalName()},{GetGoalDescription()},{GetPoints()},{GetGoalTimes()},{GetRunningTimes()},{GetGoalBonus()},{_goalComplete}";
    }

    public override string ToString()
    {
        return $"[{((_goalComplete == false) ? " " : "x")}] {GetGoalName()} ({GetGoalDescription()}) - Currently Completed: {GetRunningTimes()}/{GetGoalTimes()}";
    }

    public override void RecordEvent()
    {
        _timesCompleted += 1;
        Console.WriteLine($"Congratulations! You have earned {GetGoalPoints()} points!");
        if (_timesCompleted < _goalTimes)
        {
            _goalComplete = false;
        }
        else if (_timesCompleted >= _goalTimes)
        {
            _goalComplete = true;

             Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("C");
            Thread.Sleep(300);
            Console.Clear();
            Console.WriteLine("CO");
            Thread.Sleep(300);
            Console.Clear();
            Console.WriteLine("CON");
            Thread.Sleep(300);
            Console.Clear();
            Console.WriteLine("CONG");
            Thread.Sleep(300);
            Console.Clear();
            Console.WriteLine("CONGR");
            Thread.Sleep(300);
            Console.Clear();
            Console.WriteLine("CONGRA");
            Thread.Sleep(300);
            Console.Clear();
            Console.WriteLine("CONGRAT");
            Thread.Sleep(300);
            Console.Clear();
            Console.WriteLine("CONGRATU");
            Thread.Sleep(300);
            Console.Clear();
            Console.WriteLine("CONGRATUL");
            Thread.Sleep(300);
            Console.Clear();
            Console.WriteLine("CONGRATULA");
            Thread.Sleep(300);
            Console.Clear();
            Console.WriteLine("CONGRATULAT");
            Thread.Sleep(300);
            Console.Clear();
            Console.WriteLine("CONGRATULATI");
            Thread.Sleep(300);
            Console.Clear();
            Console.WriteLine("CONGRATULATIO");
            Thread.Sleep(300);
            Console.Clear();
            Console.WriteLine("CONGRATULATION");
            Thread.Sleep(300);
            Console.Clear();
            Console.WriteLine("CONGRATULATIONS");
            Thread.Sleep(300);

            Console.ResetColor();
            Console.Clear();
            Console.WriteLine("You completed this goal & earned the bonus points!");
        }
     
    }
}