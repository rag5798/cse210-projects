class Files{
    public void WriteFile(string text){
        string path = "prompt.txt";
        StreamWriter writer = new StreamWriter(path, true);
        writer.WriteLine(text);
        writer.Close();
    }

    public void ReadFile(){
        string path = "prompt.txt";
        StreamReader reader = new StreamReader(path);
        string line;
        while ((line = reader.ReadLine()) != null)
        {
            Console.WriteLine(line);
        }
        reader.Close();
    }
}