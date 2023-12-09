class VideoGame : Item
{
    private string system;

    public string GetSystem(){
        return system;
    }

    public void SetSystem(string s){
        system = s;
    }
    public override void AddToFile()
    {
        string filePath = "Books.txt";
        string line = $"{GetName()},{GetAuthor()},{GetSystem()},{GetType()},{GetQuantity()}";
        File.AppendAllText(filePath, line + Environment.NewLine);
    }

    public override void Check()
    {
        throw new NotImplementedException();
    }

    public override void Display()
    {
        Console.WriteLine($"Title: {GetName()},Publisher: {GetAuthor()},System: {GetSystem()},Type: {GetType()},Quantity: {GetQuantity()}\n");
    }

    public override void Remove()
    {
        throw new NotImplementedException();
    }

    public VideoGame(string n, string a, string s, string t, int q):base(n,a,t,q)
    {
        SetName(n);
        SetAuthor(a);
        SetSystem(s);
        SetType(t);
        SetQuantity(q);
    }

    public VideoGame()
    {
        SetName("");
        SetAuthor("");
        SetSystem("");
        SetType("VideoGame");
        SetQuantity(1);
    }
}