using System;
using System.Formats.Asn1;
using System.IO;

class Program
{
    
    static void Main(string[] args)
    {
        Boolean done = false;
        while(done==false){
            Prompt p = new Prompt();
            Files f = new Files();
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
                f.writefile(entry + "\n");
                Console.WriteLine("You entered:");
                f.readfile();
                h.entrynum+=1;
                string cont="0";
                while(cont!="y" && cont!="n"){
                    Console.WriteLine("\nWould you like to continue (y/n)");
                    cont = Console.ReadLine().ToLower();
                }
                if (cont=="y"){
                    continue;
                }else if (cont=="n"){
                    done=true;
                }
            }else if(answer==2){
                p.addprompt();
                string cont="0";
                while(cont!="y" && cont!="n"){
                    Console.WriteLine("\nWould you like to continue (y/n)");
                    cont = Console.ReadLine().ToLower();
                }
                if (cont=="y"){
                    continue;
                }else if (cont=="n"){
                    done=true;
                }
            }else if(answer==3){
                p.removeprompt();
                string cont="0";
                while(cont!="y" && cont!="n"){
                    Console.WriteLine("\nWould you like to continue (y/n)");
                    cont = Console.ReadLine().ToLower();
                }
                if (cont=="y"){
                    continue;
                }else if (cont=="n"){
                    done=true;
                }
            }

        }
    }
}