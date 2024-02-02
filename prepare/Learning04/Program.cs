using System;
using System.Linq.Expressions;

class Program
{
    static void Main(string[] args)
    {
        Assignment assignment1 = new Assignment ("Shey Vick","Multiplication");
        Console.WriteLine(assignment1.GetSummary());
        Console.WriteLine();

        MathAssignment assignment2 = new MathAssignment ("Georgie Vick", "Fractions", "8.3", "7-18");
        Console.WriteLine(assignment2.GetSummary());
        Console.WriteLine(assignment2.GetHomeworkList());
        Console.WriteLine();

        WritingAssignment assignment3 = new WritingAssignment("Rory Vick","European History","The causes of World War II");
        Console.WriteLine(assignment3.GetSummary());
        Console.WriteLine(assignment3.GetWritingInformation());

    }
}