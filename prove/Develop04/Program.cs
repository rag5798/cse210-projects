
class Program
{
    static void Main(string[] args)
    {
        Breathing b = new Breathing();
        Reflection r = new Reflection();
        Listing l = new Listing();
        bool cont = true;
        while (cont != false){
            Console.WriteLine("Menu Options:\n1.) Start Breathing Activity\n2.) Start Reflection Activity\n3.) Start Listing Activity\n4.) Quit");
            string answer = Console.ReadLine();
            int choice;
            bool ans = int.TryParse(answer, out choice);
            while (ans != true){
                Console.WriteLine("\n\n***Please Enter an Integer 1, 2, or 3***\n\n");
                Console.WriteLine("Menu Options:\n1.) Start Breathing Activity\n2.) Start Reflection Activity\n3.) Start Listing Activity\n4.) Quit");
                answer = Console.ReadLine();
                ans = int.TryParse(answer, out choice);
            }

            if (choice < 1 || choice > 4){
                Console.WriteLine("\n\n***Please Enter an Integer 1, 2, or 3***\n\n");
                Console.WriteLine("Menu Options:\n1.) Start Breathing Activity\n2.) Start Reflection Activity\n3.) Start Listing Activity\n4.) Quit");
                answer = Console.ReadLine();
                ans = int.TryParse(answer, out choice);
            }

            if (choice == 1){
                //Breathing Activity
                Console.WriteLine(b.StartMessage(choice - 1));
                b.SetDuration();
                b.RunBreath();
                /*DateTime start = DateTime.Now;
                DateTime end = start.AddSeconds(b.GetDuration());
                int timer = b.GetDuration();
                int divisible = timer % 8;
                while (divisible != 0){
                    timer += 1;
                    divisible = timer%8;
                }
                b.Prepare();
                while(DateTime.Now < end){
                    b.BreathIn();
                    b.BreathOut();
                }
                b.EndMessage(0);*/
            }else if (choice == 2){
                //Reflection Activity
                Console.WriteLine(b.StartMessage(choice - 1));
                r.SetDuration();
                r.RunReflection();
            }else if (choice == 3){
                //Listing Activity
                l.RunListing();
            }else if(choice == 4){
                Environment.Exit(1);
            }else{
                Console.WriteLine("An error has occured");
                continue;
            }
        }
    }
}