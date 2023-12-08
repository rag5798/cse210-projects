class Magazine : Item
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

    public Magazine(string n, string a, string t, int q):base(n, a, t, q)
    {
        SetName(n);
        SetAuthor(a);
        SetType(t);
        SetQuantity(q);
    }

    public Magazine(){
        SetName("");
        SetAuthor("");
        SetType("Magazine");
        SetQuantity(1);
    }
}