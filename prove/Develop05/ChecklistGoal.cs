using System.Dynamic;

class ChecklistGoal : Goal
{

    private int fullycompletedpoints {get; set;}
    private int timescompleted {get; set;}
    private int maxcompletions {get; set;}

    public ChecklistGoal(string name, string d, int p, int competion, int maxcompletions, int bonus){
        SetTitle(name);
        SetDescription(d);
        SetPoints(p);
        SetCompletions(competion);
        SetMaxCompletions(maxcompletions);
        SetBonusPoints(bonus);
    }

    public ChecklistGoal(){
        SetTitle("No Name Provided");
        SetDescription("No Description Provided");
        SetPoints(0);
        SetCompletions(0);
        SetMaxCompletions(1);
    }
    public override void Complete()
    {
        Console.WriteLine($"You Completed {GetTitle()}");
        timescompleted += 1;
    }

    public override string Display()
    {
        return $"Type: 3\nGoal: {GetTitle()}\nDescription: {GetDescription()}\nCompletions: {timescompleted}/{maxcompletions}\nPoints: {GetPoints()}\nCompletion Bonus: {fullycompletedpoints}\n";
    }

    public override void SaveGoal()
    {
        string fileName = "goals.txt";
        try{
            using (StreamWriter sr = new StreamWriter(fileName, true)){
                sr.WriteLine($"Type: 3\nGoal: {GetTitle()}\nDescription: {GetDescription()}\nCompletions: {timescompleted}/{maxcompletions}\nPoints: {GetPoints()}\nCompletion Bonus: {fullycompletedpoints}\n");
            }
        }
        catch (Exception e){
            Console.WriteLine($"The file {fileName} could not be read:");
            Console.WriteLine(e.Message);
        }
    }

    public void SetCompletions(int c){
        timescompleted = c;
    }

    public int GetCompletions(){
        return timescompleted;
    }

    public void SetMaxCompletions(int c){
        maxcompletions = c;
    }

    public int GetMaxCompletions(){
        return maxcompletions;
    }

    public void SetBonusPoints(int b){
        fullycompletedpoints = b;
    }

    public int GetBonusPoints(){
        return fullycompletedpoints;
    }

    public override int GetTypeOfGoal()
    {
        return 3;
    }
}