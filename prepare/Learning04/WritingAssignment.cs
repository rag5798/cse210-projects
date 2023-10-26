
class WritingAssignment : Assignment{
    private string title;

    public WritingAssignment(string name, string subject, string book){
        SetName(name);
        SetTopic(subject);
        title = book;
    }

    public string GetWritingInformation(){
        string summary = $"{GetSummary()}\n{title}";
        return summary;
    }
}