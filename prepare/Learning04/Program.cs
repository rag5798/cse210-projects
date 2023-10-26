using System;

class Program
{
    static void Main(string[] args)
    {
        Assignment a = new Assignment("Bobby", "Math");
        MathAssignment m = new MathAssignment("Robert","Math","Section 7.7", "Problems 4-9");
        WritingAssignment w = new WritingAssignment("Robert", "Writing", "The History of the World by Unknown");

        Console.WriteLine(a.GetSummary());

       Console.WriteLine(m.GetHomeworkList());
       Console.WriteLine(m.GetSummary());

       Console.WriteLine(w.GetWritingInformation());
       Console.WriteLine(w.GetSummary());
    }
}