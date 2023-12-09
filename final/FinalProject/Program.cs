using System;
using System.Reflection;

class Program
{
    static void Main(string[] args)
    {
        bool cont = true;
        while (cont == true)
        {
            Menu m = new Menu();
            User u = m.UserMenu();
            m.BookMenu(u);
            Console.WriteLine("Would you like to Continue?");
            Console.WriteLine("1.) Continue\n2.) Exit");
            int choice;
            bool testchoice = int.TryParse(Console.ReadLine(), out choice);
            while (testchoice == false || choice < 1 || choice > 2)
            {
                Console.WriteLine("Would you like to Continue?");
                Console.WriteLine("1.) Continue\n2.) Exit");
                testchoice = int.TryParse(Console.ReadLine(), out choice);
            }

            if (choice == 1)
            {
                
            }else if (choice == 2){
                cont = false;
            }else{
                Console.WriteLine("An Error has occured in exit menu");
            }
        }
    }
}