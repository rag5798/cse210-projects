class ComicBook : Item
{

    private string volume {get; set;}
    private int booknumber {get; set;}

    public void SetVolume(string v)
    {
        volume = v;
    }

    public string GetVolume()
    {
        return volume;
    }

    public void SetBookNumber(int b)
    {
        booknumber = b;
    }

    public int GetBookNumber()
    {
        return booknumber;
    }

    public override void AddToFile()
    {
        string filePath = "Books.txt";
        string line = $"{GetName()},{GetAuthor()},{GetVolume()},{GetBookNumber()},{GetType()},{GetQuantity()}";
        File.AppendAllText(filePath, line + Environment.NewLine);
    }

    public override void Check()
    {
        throw new NotImplementedException();
    }

    public override void Remove()
    {
        throw new NotImplementedException();
    }

    public override void Display()
    {
        Console.WriteLine($"Title: {GetName()}\nAuthor: {GetAuthor()}\nVolume: {GetVolume()}\nIssue: #{GetBookNumber()}\nType: {GetType()}\nQuantity: {GetQuantity()}\n");
    }

    public ComicBook(string n, string a, string v,  int b, string t, int q):base(n, a, t, q)
    {
        SetName(n);
        SetAuthor(a);
        SetVolume(v);
        SetBookNumber(b);
        SetType(t);
        SetQuantity(q);
    }

    public ComicBook(){
        SetName("");
        SetAuthor("");
        SetVolume("");
        SetBookNumber(1);
        SetType("ComicBook");
        SetQuantity(1);
    }
}