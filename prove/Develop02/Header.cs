class Header{
    public string name;
    public int entrynum=1;
    public string date;

    public void getheader(){
        Console.WriteLine("What is your name: ");
        name = Console.ReadLine();
        Console.WriteLine("What is the date in month/day/year format: ");
        date = Console.ReadLine();
    }
}