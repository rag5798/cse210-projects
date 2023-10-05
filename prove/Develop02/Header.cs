using Microsoft.VisualBasic;

class Header{
    public string name;
    public int entrynum;
    public string date;

    public void getheader(){
        Console.WriteLine("What is your name: ");
        name = Console.ReadLine();
        date = DateTime.Now.ToShortDateString();
        Boolean check = File.Exists("prompt.txt");
        Console.WriteLine(check);
        if (check == true){
            List<string> num = new List<string>();
            foreach (var line in File.ReadAllLines("prompt.txt")){
                if (line.Contains("Entry Number")==true){
                    num.Add(line);
                }
            }
            Console.WriteLine(num[0]);
        }else{
            entrynum = 1;
        }
    }
}