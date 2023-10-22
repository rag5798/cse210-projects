class Reference{
    private string reference;
    private List<string> references = new List<string>(){
        "Proverbs 3:5-6",
        "1 Nephi 3:7",
        "Moses 1:39"
    };

    private List<string> test = new List<string>();

    public string DisplayHeader(int index){
        return references[index];
    }

    public string GetHeaderFromFile(int index){
        
        string path = "scripturetext\\csv\\lds-scriptures.csv";
        StreamReader reader = new StreamReader(path);
        string line;
        while ((line = reader.ReadLine()) != null)
        {
            foreach(var a in line.Split("$")){
                test.Add(a);
            }
        }
        reader.Close();
        
        for(int x =0; x<test.Count();x++){
            test.RemoveAt(x);
        }

        return test[index];
    }
}