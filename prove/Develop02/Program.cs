using System;
using System.Formats.Asn1;
using System.IO;

class Program
{
    
    static void Main(string[] args)
    {
        Prompt p = new Prompt();
        File f = new File();
        Header h = new Header();
        Console.WriteLine("1.)Write an entry\n2.)Add a Prompt\n3.)Remove a Prompt");
        Console.WriteLine("Please choose an action with the corresponding number:");
        int answer;
        while(!int.TryParse(Console.ReadLine(), out answer)){
            Console.WriteLine("That was invalid. Enter a valid option.");
        }
        if (answer==1){
            h.getheader();
            p.displayprompt();
            int answ = p.displaypromptchoice();
            string entry = p.entertext(answ);
            f.writefile($"Entry Number: {h.entrynum}");
            f.writefile($"Name: {h.name}");
            f.writefile($"Date: {h.date}");
            f.writefile(entry);
            Console.WriteLine("You entered:");
            f.readfile();
            h.entrynum+=1;
            Console.WriteLine("\nWould you like to continue (y/n)");
            string cont = Console.ReadLine().ToLower();
        }

    }
}