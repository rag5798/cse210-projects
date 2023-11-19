using System.Net.Mime;
using System;
using System.Runtime.InteropServices;

class Program
{
    static void Main(string[] args)
    {
        //Test Runs
        SimpleGoal g = new SimpleGoal();
        EternalGoal e = new EternalGoal();
        ChecklistGoal c = new ChecklistGoal();
        Menu m = new Menu();
        User u = new User();
        //Console.WriteLine(c.Display());
        //m.CreateGoal();
        //m.CreateUser();
        //List<dynamic> goal = m.MakeGoalList(m.GetGoals());
        //Console.WriteLine(m.SelectGoal(m.GetGoals(), goal).GetType());
        //u = m.GetUser();
        //u.SetPoints(1000);
        //m.OverWriteUser(u);
        //g.SaveGoal();
        /*List<string> goals = m.GetGoals();
        foreach (string x in goals){
            Console.WriteLine(x);
        }*/
        //m.MakeGoalList(m.GetGoals("goals.txt"));
        //End of Testing
        



        Console.WriteLine("Please enter the numebr associated with each option: ");
        Console.WriteLine("1.) Create User\n2.) Login");
        int answer;
        bool success = int.TryParse(Console.ReadLine(), out answer);
        while (success == false | answer < 1 | answer > 2){
            Console.WriteLine("Please enter the numebr associated with each option: ");
            Console.WriteLine("1.) Create User\n2.) Login");
            success = int.TryParse(Console.ReadLine(), out answer);
        }
        User currentuser = new User();
        if (answer == 1){
            m.CreateUser();
            currentuser = m.GetUser();
        }else if (answer == 2){
            currentuser = m.GetUser();
        }else{
            Console.WriteLine("An error has occured in user creation/login");
        }
        bool exit = false;
        while(exit == false){

            Console.WriteLine("Please enter the numebr associated with each option: ");
            Console.WriteLine("1.) Create Goal\n2.) Complete Goal\n3.) User Points\n4.) Goals Completed\n5.)Quit");
            success = int.TryParse(Console.ReadLine(), out answer);
            while (success == false | answer < 1 | answer > 5){
                Console.WriteLine("Please enter the numebr associated with each option: ");
                Console.WriteLine("1.) Create Goal\n2.) Complete Goal\n3.) User Points\n4.) Goals Completed\n5.)Quit");
                success = int.TryParse(Console.ReadLine(), out answer);
            }
            if (answer == 1){
                m.CreateGoal();
            }else if(answer == 2 & File.Exists("goals.txt") == true){
                int p = m.SelectGoal(m.GetGoals("goals.txt"), m.MakeGoalList(m.GetGoals("goals.txt")), currentuser);
                //Console.WriteLine(p);
                currentuser.SetPoints(p);
                m.OverWriteUser(currentuser);
            }else if (answer == 3){
                Console.WriteLine($"Congrats! {currentuser.GetUsername()} you have {currentuser.GetPoints()} points");
            }else if (answer == 4 & File.Exists($"{currentuser.GetUsername()}goals.txt") == true){
                m.ShowUserCompletedGoals(m.GetGoals($"{currentuser.GetUsername()}goals.txt"));
            }else if (answer == 5){
                exit = true;
            }
        }
    }
}