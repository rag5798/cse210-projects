class Book : Item
{
    private string genre{get; set;}

    public void SetGenre(string g){
        genre = g;
    }

    public string GetGenre(){
        return genre;
    }
    public override void AddToFile()
    {
        string filePath = "Books.txt";
        string line = $"{GetName()},{GetAuthor()},{GetGenre()},{GetType()},{GetQuantity()}";
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
        Console.WriteLine($"Title: {GetName()}\nAuthor: {GetAuthor()}\nGenre: {GetGenre()}\nType: {GetType()}\nQuantity: {GetQuantity()}");
    }

    public Book(string n, string a, string g, string t, int q):base(n, a, t, q)
    {
        SetName(n);
        SetAuthor(a);
        SetGenre(g);
        SetType(t);
        SetQuantity(q);
    }

    public Book(){
        SetName("");
        SetAuthor("");
        SetGenre("");
        SetType("Book");
        SetQuantity(1);
    }


}