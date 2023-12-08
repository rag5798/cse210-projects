using System;

class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
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

                User u = new User();
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
                User u = new User();
                Console.Write("Please input a username:");
                string user = Console.ReadLine();
                u.SetUserName(user);
                if (fileexists == true)
                {
                    bool exists = u.CheckUserName();
                    while (exists == true)
                    {
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

            }else
            {
                Console.WriteLine("An Error Has Occured");
            }
            
        }
    }
}