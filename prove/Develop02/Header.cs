using Microsoft.VisualBasic;

class Header{
    public string name;
    public int entrynum=1;
    public string date;

    public void getheader(){
        File.Create("prompt.txt");
        Console.WriteLine("What is your name: ");
        name = Console.ReadLine();
        Console.WriteLine("What is the date in month/day/year format: ");
        date = Console.ReadLine();
        StreamWriter writer = new StreamWriter("prompt.txt");
        writer.Close();
        int index=0;
        var lines = File.ReadAllLines("prompt.txt");
        while(index<lines.Count()){
            
        }
    }
}