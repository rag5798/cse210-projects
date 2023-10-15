class Reference{
    private string reference;
    private List<string> references = new List<string>(){
        "Proverbs 3:5-6",
        "1 Nephi 3:7",
        "Moses 1:39"
    };

    public string displayheader(int index){
        return references[index];
    }
}