
class MathAssignment : Assignment{
    private string textbooksection {get; set;}
    private string problems {get; set;}

    public MathAssignment(string name, string subject, string section, string problem){
        SetName(name);
        SetTopic(subject);
        textbooksection = section;
        problems = problem;
    }
    public string GetHomeworkList(){
        string summary = $"{GetSummary()}\n{textbooksection} {problems}";
        return summary;
    }
}