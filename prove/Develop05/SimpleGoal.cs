using System;
using System.IO;

class SimpleGoal : Goal
{
    private bool completed {get; set;}
    public SimpleGoal(string name, string d, int p){
        SetTitle(name);
        SetDescription(d);
        SetPoints(p);
    }

    public SimpleGoal(){
        SetTitle("No Name Provided");
        SetDescription("No Description Provided");
        SetPoints(0);
    }

    public override void Display(){
        Console.WriteLine($"Type: 1\nGoal: {GetTitle()}\nDescription: {GetDescription()}\nPoints: {GetPoints()}\n");
    }
    public override void Complete()
    {
        throw new NotImplementedException();
    }

    public override void SaveGoal()
    {
        string fileName = "goals.txt";
        try
        {
            using (StreamWriter sr = new StreamWriter(fileName, true))
            {
                sr.WriteLine($"Type: \nGoal: {GetTitle()}\nDescription: {GetDescription()}\nPoints: {GetPoints()}\n");
            }
        }
        catch (Exception e)
        {
            Console.WriteLine($"The file {fileName} could not be read:");
            Console.WriteLine(e.Message);
        }
    }
}