class File{
    public void writefile(string text){
        string path = "propmt.txt";
        StreamWriter writer = new StreamWriter(path, true);
        writer.WriteLine(text);
        writer.Close();
    }

    public void readfile(){
        string path = "propmt.txt";
        StreamReader reader = new StreamReader(path);
        string line;
        while ((line = reader.ReadLine()) != null)
        {
            Console.WriteLine(line);
        }

    }
}