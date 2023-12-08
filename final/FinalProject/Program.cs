using System;
using System.Reflection;

class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            //User Creation/Login menu
            Console.WriteLine("WELCOME TO THE LIBRARY");
            Console.WriteLine("Please Select an option from the menu using the associated number:");
            Console.WriteLine("1.) Login\n2.) Create User");
            int num;
            bool test = int.TryParse(Console.ReadLine(), out num);
            while (test == false || num > 2 || num < 0)
            {
                Console.WriteLine("Please Select an option from the menu using the associated number:");
                Console.WriteLine("1.) Login\n2.) Create User");
                test = int.TryParse(Console.ReadLine(), out num);
            }
            User u = new User();
            if (num == 1)
            {
                string filepath = "Users.txt";
                bool exists = File.Exists(filepath);
                if (exists == false)
                {
                    Console.WriteLine("Please Create a User Before Login");
                    continue;
                }
                bool isempty = new FileInfo(filepath).Length == 0;
                if (isempty == true)
                {
                    Console.WriteLine("Please Create a User Before Login");
                    continue;
                }

                
                Console.Write("Please input a username:");
                string user = Console.ReadLine();
                u.SetUserName(user);

                int pin;
                test = int.TryParse(Console.ReadLine(), out pin);
                while (test == false || pin > 9999 || pin < 1000)
                {
                    Console.Write("Please input a 4 digit pin:");
                    test = int.TryParse(Console.ReadLine(), out pin);
                }
                u.SetPin(pin);
                bool checkuser = u.CheckUserName();
                bool checkpin = u.CheckPin();
                while (checkuser == false || checkpin == false)
                {
                    Console.Write("Please input a username:");
                    user = Console.ReadLine();
                    u.SetUserName(user);

                    test = int.TryParse(Console.ReadLine(), out pin);
                    while (test == false || pin > 9999 || pin < 1000)
                    {
                        Console.Write("Please input a 4 digit pin:");
                        test = int.TryParse(Console.ReadLine(), out pin);
                    }
                    u.SetPin(pin);
                    checkuser = u.CheckUserName();
                    checkpin = u.CheckPin();
                }
                

            }else if (num == 2)
            {
                string filepath = "Users.txt";
                bool fileexists = File.Exists(filepath);
                Console.Write("Please input a username:");
                string user = Console.ReadLine();
                u.SetUserName(user);
                if (fileexists == true)
                {
                    bool exists = u.CheckUserName();
                    while (exists == true)
                    {
                        Console.WriteLine("*Username is in use*");
                        Console.Write("Please input a username:");
                        user = Console.ReadLine();
                        u.SetUserName(user);
                        exists = u.CheckUserName();
                    }
                }
                


                Console.Write("Please input a 4 digit pin:");
                int pin;
                test = int.TryParse(Console.ReadLine(), out pin);
                while (test == false || pin > 9999 || pin < 1000)
                {
                    Console.Write("Please input a 4 digit pin:");
                    test = int.TryParse(Console.ReadLine(), out pin);
                }

                u.SetPin(pin);
                u.SaveUserToFile();
                Console.WriteLine("***User Created***");

            }else
            {
                Console.WriteLine("An Error Has Occured");
            }
            //End of User Menu
            //Start of Library Menu
            Console.WriteLine("Please Select an option from the menu using the associated number:");
            Console.WriteLine("1.) Check Out A Book\n2.) Return Book\n3.) Donate Book");
            int choice;
            bool valid = int.TryParse(Console.ReadLine(), out choice);
            while (valid == false || num > 3 || num < 0)
            {
                Console.WriteLine("Please Select an option from the menu using the associated number:");
                Console.WriteLine("1.) Check Out A Book\n2.) Return Book\n3.) Donate Book");
                valid = int.TryParse(Console.ReadLine(), out num);
            }

            if (choice == 1)
            {
                string filePath = "Books.txt";
                string[] lines = File.ReadAllLines(filePath);
                string[] fields;
                foreach (string line in lines)
                {
                    fields = line.Split(',');
                }

            }else if (choice == 2)
            {
                
            }else if (choice == 3)
            {
                Console.WriteLine("What type of Book are you Donating?");
                Console.WriteLine("1.) Book\n2.) Magazine\n3.) Comic Book");
                int booktype;
                bool testchoice = int.TryParse(Console.ReadLine(), out booktype);
                while (testchoice == false || num > 3 || num < 0)
                {
                    Console.WriteLine("What type of Book are you Donating?");
                    Console.WriteLine("1.) Book\n2.) Magazine\n3.) Comic Book");
                    testchoice = int.TryParse(Console.ReadLine(), out booktype);
                }

                if (booktype == 1)
                {   
                    Book b = new Book();
                    Console.Write("What is the title of the Book: ");
                    string title = Console.ReadLine();
                    b.SetName(title);

                    Console.Write("Who is the author of the Book: ");
                    string author = Console.ReadLine();
                    b.SetAuthor(author);

                    Console.Write("What is the genre of the Book: ");
                    string genre = Console.ReadLine();
                    b.SetGenre(genre);

                    Console.Write("How many Books are you Donating: ");
                    int quantity;
                    bool testquant = int.TryParse(Console.ReadLine(), out quantity);
                    while (testquant == false)
                    {
                        Console.Write("How many Books are you Donating: ");
                        testquant = int.TryParse(Console.ReadLine(), out quantity);
                    }
                    b.SetQuantity(quantity);

                    Console.WriteLine("You Donated the Book:");
                    b.Display();
                    b.AddToFile();
                }else if (booktype == 2)
                {
                    Magazine m = new Magazine();
                    Console.Write("What is the title of the Magazine: ");
                    string title = Console.ReadLine();
                    m.SetName(title);

                    Console.Write("Who is the author of the Magazine: ");
                    string author = Console.ReadLine();
                    m.SetAuthor(author);

                    Console.Write("What Year was the Magazine made: ");
                    int year;
                    bool testyear = int.TryParse(Console.ReadLine(), out year);
                    while (testyear == false || year < 1800 || year > 2024)
                    {
                        Console.Write("What Year was the Magazine: ");
                        testyear = int.TryParse(Console.ReadLine(), out year);
                    }

                    Console.Write("What month was the Magazine made:");
                    int month;
                    bool testmonth = int.TryParse(Console.ReadLine(), out month);
                    while (testmonth == false || month < 1 || month > 12)
                    {
                        Console.Write("What month was the Magazine made:");
                        testmonth = int.TryParse(Console.ReadLine(), out month);
                    }

                    Console.Write("What day was the Magazine made:");
                    int day;
                    bool testday = int.TryParse(Console.ReadLine(), out day);
                    while (testmonth == false || day < 1 || day > 31)
                    {
                        Console.Write("What day was the Magazine made:");
                        testmonth = int.TryParse(Console.ReadLine(), out day);
                    }

                    string date = $"{day}/{month}/{year}";
                    m.SetPublishDate(date);

                    Console.Write("How many Books are you Donating: ");
                    int quantity;
                    bool testquant = int.TryParse(Console.ReadLine(), out quantity);
                    while (testquant == false)
                    {
                        Console.Write("How many Books are you Donating: ");
                        testquant = int.TryParse(Console.ReadLine(), out quantity);
                    }
                    m.SetQuantity(quantity);

                    Console.WriteLine("You Donated the Magazine:");
                    m.Display();
                    m.AddToFile();
                }else if (booktype == 3)
                {
                    ComicBook cb = new ComicBook();
                    Console.Write("What is the title of the Book: ");
                    string title = Console.ReadLine();
                    cb.SetName(title);

                    Console.Write("Who is the author of the Book: ");
                    string author = Console.ReadLine();
                    cb.SetAuthor(author);

                    Console.Write("What is the volume number: ");
                    int volume;
                    bool testvolume = int.TryParse(Console.ReadLine(), out volume);
                    while (testvolume == false || volume < 1)
                    {
                        Console.Write("What is the volume number: ");
                        testvolume = int.TryParse(Console.ReadLine(), out volume);
                    }
                    cb.SetVolume(volume.ToString());

                    Console.Write("What is the issue number: ");
                    int issue;
                    bool testissue = int.TryParse(Console.ReadLine(), out issue);
                    while (testissue == false || volume < 1)
                    {
                        Console.Write("What is the issue number: ");
                        testissue = int.TryParse(Console.ReadLine(), out issue);
                    }
                    cb.SetBookNumber(issue);

                    Console.Write("How many Books are you Donating: ");
                    int quantity;
                    bool testquant = int.TryParse(Console.ReadLine(), out quantity);
                    while (testquant == false)
                    {
                        Console.Write("How many Books are you Donating: ");
                        testquant = int.TryParse(Console.ReadLine(), out quantity);
                    }
                    cb.SetQuantity(quantity);

                    Console.WriteLine("You Donated the Comic Book:");
                    cb.Display();
                    cb.AddToFile();
                }
            }
        }
    }
}