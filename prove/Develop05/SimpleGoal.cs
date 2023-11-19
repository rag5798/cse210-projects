using System;
using System.IO;

class SimpleGoal : Goal
{
    private int completed = 0;
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

    public override string Display(){
        return $"Type: 1\nGoal: {GetTitle()}\nDescription: {GetDescription()}\nPoints: {GetPoints()}\nCompleted: {GetCompleted()}\n";
    }
    public override void Complete(){
        completed += 1;
        Console.WriteLine($"You Completed {GetTitle()} {completed} times");

    }

    public override void SaveGoal(){
        string fileName = "goals.txt";
        try{
            using (StreamWriter sr = new StreamWriter(fileName, true)){
                sr.WriteLine($"Type: 1\nGoal: {GetTitle()}\nDescription: {GetDescription()}\nPoints: {GetPoints()}\nCompleted: {GetCompleted()}\n");
            }
        }
        catch (Exception e){
            Console.WriteLine($"The file {fileName} could not be read:");
            Console.WriteLine(e.Message);
        }
    }

    public int GetCompleted(){
        return completed;
    }

    public void SetCompleted(int c){
        completed = c;
    }

    public override int GetTypeOfGoal()
    {
        return 1;
    }
}