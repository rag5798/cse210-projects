class ComicBook : Item
{
    public override void AddToFile()
    {
        throw new NotImplementedException();
    }

    public override void Check()
    {
        throw new NotImplementedException();
    }

    public override void Remove()
    {
        throw new NotImplementedException();
    }

    public ComicBook(string n, string a, string t, int q):base(n, a, t, q)
    {
        SetName(n);
        SetAuthor(a);
        SetType(t);
        SetQuantity(q);
    }

    public ComicBook(){
        SetName("");
        SetAuthor("");
        SetType("ComicBook");
        SetQuantity(1);
    }
}