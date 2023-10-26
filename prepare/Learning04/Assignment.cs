
class Assignment{
    private string studentname {get; set;}
    private string topic {get; set;}

    public Assignment(){
        studentname = "";
        topic = "";
    }

    public Assignment(string name, string subject){
        studentname = name;
        topic = subject;
    }

    public void SetName(string name){
        studentname = name;
    }

    public void SetTopic(string subject){
        topic = subject;
    }
    public string GetSummary(){
        string summary = $"{studentname} - {topic}";
        return summary;
    }


}