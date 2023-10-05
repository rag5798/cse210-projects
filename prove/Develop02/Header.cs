using Microsoft.VisualBasic;

class Header{
    public string name;
    public int entrynum=1;
    public string date;

    public void getheader(){
        Console.WriteLine("What is your name: ");
        name = Console.ReadLine();
        date = DateTime.Now.ToShortDateString();
        Boolean check = File.Exists("prompt.txt");
        Console.WriteLine(check);
        if (check == true){
            List<char> num = new List<char>();
            List<string> txt = new List<string>();
            foreach (var line in File.ReadAllLines("prompt.txt")){
                if (line.Contains("Entry Number")==true){
                    txt.Add(line);
                }
            }
            for(int x=0; x<txt.Count(); x++){
                string word = txt[x];
                for(int y=0;y<word.Length;y++){
                    char part = word[y];
                    num.Add(part);
                }

            }
            for(int z=0;z<num.Count();z++){
                _ = int.TryParse(num[z].ToString(), out entrynum);
            }
            entrynum+=1;
        }
    }
}