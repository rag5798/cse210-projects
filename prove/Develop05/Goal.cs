abstract class Goal{
    private int points {get; set;}
    private string description {get; set;}
    private string title {get; set;}

    protected Goal(){
        points = 0;
        description = "No Description provided";
        title = "No Title Provided";
    }

    protected Goal(string name, string d, int p){
        title = name;
        description = d;
        points = p;
    }

    public abstract void Complete();
    public abstract void SaveGoal();

    public abstract void Display();
    public void SetPoints(int num){
        points = num;
    }

    public int GetPoints(){
        return points;
    }

    public void SetDescription(string d){
        description = d;
    }

    public string GetDescription(){
        return description;
    }

    public void SetTitle(string name){
        title = name;
    }

    public string GetTitle(){
        return title;
    }

}