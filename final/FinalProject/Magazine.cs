
class Magazine : Item
{

    private string publishdate {get; set;}

    public void SetPublishDate(string d)
    {
        publishdate = d;
    }

    public string GetPublishDate()
    {
        return publishdate;
    }
    public override void AddToFile()
    {
        string filePath = "Books.txt";
        string line = $"{GetName()},{GetAuthor()},{GetPublishDate()},{GetType()},{GetQuantity()}";
        File.AppendAllText(filePath, line + Environment.NewLine);
    }

    public override string Check()
    {
        string type = "Magazine";
        return type;
    }

    public override void Remove()
    {
        throw new NotImplementedException();
    }

    public override void Display()
    {
        Console.WriteLine($"Title: {GetName()}\nAuthor: {GetAuthor()}\nPublished: {GetPublishDate()}\nType: {GetType()}\nQuantity: {GetQuantity()}\n");
    }

    public Magazine(string n, string a, string d, string t, int q):base(n, a, t, q)
    {
        SetName(n);
        SetAuthor(a);
        SetPublishDate(d);
        SetType(t);
        SetQuantity(q);
    }

    public Magazine(){
        SetName("");
        SetAuthor("");
        SetPublishDate("");
        SetType("Magazine");
        SetQuantity(1);
    }
}