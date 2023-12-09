class Movie : Item
{
    private string genre;
    private string rating;

    public string GetGenre()
    {
        return genre;
    }

    public void SetGenre(string g)
    {
        genre = g;
    }

    public string GetRating()
    {
        return rating;
    }

    public void SetRating(string r)
    {
        rating = r;
    }
    public override void AddToFile()
    {
        string filePath = "Books.txt";
        string line = $"{GetName()},{GetAuthor()},{GetGenre()},{GetRating()},{GetType()},{GetQuantity()}";
        File.AppendAllText(filePath, line + Environment.NewLine);
    }

    public override void Check()
    {
        throw new NotImplementedException();
    }

    public override void Display()
    {
        Console.WriteLine($"Title: {GetName()}\nDirector: {GetAuthor()}\nGenre: {GetGenre()}\nRating: {GetRating()}\nType: {GetType()}\nQuantity: {GetQuantity()}\n");
    }

    public override void Remove()
    {
        throw new NotImplementedException();
    }

    public Movie(string n, string a, string g, string r, string t, int q):base(n,a,t,q)
    {
        SetName(n);
        SetAuthor(a);
        SetGenre(g);
        SetRating(r);
        SetType(t);
        SetQuantity(q);
    }

    public Movie()
    {
        SetName("");
        SetAuthor("");
        SetGenre("");
        SetRating("");
        SetType("Movie");
        SetQuantity(1);
    }
}