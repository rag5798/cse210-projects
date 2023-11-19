class EternalGoal : Goal{
    private int completed = 0;

    public EternalGoal(string name, string d, int p){
        SetTitle(name);
        SetDescription(d);
        SetPoints(p);
    }

    public EternalGoal(){
        SetTitle("No Name Provided");
        SetDescription("No Description Provided");
        SetPoints(0);
    }

    public override void Complete()
    {
        Console.WriteLine($"{GetTitle()} will Never be Complete, but keep in mind with every completion we learn something new.\nGood Job!\nKeep Up The Great Work");
    }

    public override string Display()
    {
        return $"Type: 2\nGoal: {GetTitle()}\nDescription: {GetDescription()}\nPoints: {GetPoints()}\nCompleted: {GetCompleted()}\n";
    }

    public override void SaveGoal()
    {
        string fileName = "goals.txt";
        try{
            using (StreamWriter sr = new StreamWriter(fileName, true)){
                sr.WriteLine($"Type: 2\nGoal: {GetTitle()}\nDescription: {GetDescription()}\nPoints: {GetPoints()}\n");
            }
        }
        catch (Exception e){
            Console.WriteLine($"The file {fileName} could not be read:");
            Console.WriteLine(e.Message);
        }
    }

    public override int GetTypeOfGoal(){
        return 2;
    }

    public int GetCompleted(){
        return completed;
    }


}  