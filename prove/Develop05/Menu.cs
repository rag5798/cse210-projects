using System.Collections.Generic;
using System.Dynamic;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;

class Menu{


    public void CreateGoal(){
        Console.WriteLine("What type of Goal would you like to add?\n1.)Simple Goal\n2.)Eternal Goal\n3.)Checklist Goal");
        int answer;
        bool success = int.TryParse(Console.ReadLine(), out answer);

        while (success == false || answer > 3){
            Console.WriteLine("What type of Goal would you like to add?\n1.)Simple Goal\n2.)Eternal Goal\n3.)Checklist Goal");
            success = int.TryParse(Console.ReadLine(), out answer);
        }

        switch (answer)
        {
            case 1:
                // Make simple goal
                SimpleGoal g = new SimpleGoal();
                Console.WriteLine("What is the name of the Goal: ");
                string name = Console.ReadLine();
                g.SetTitle(name);
                Console.WriteLine("Please Provide a brief description of the goal: ");
                string d = Console.ReadLine();
                g.SetDescription(d);
                Console.WriteLine("Please provide the point value for the goal: ");
                int num;
                bool worked = int.TryParse(Console.ReadLine(), out num);
                while (worked == false || answer < 0){
                    Console.WriteLine("Please provide the point value for the goal: ");                    
                    worked = int.TryParse(Console.ReadLine(), out num);
                }
                g.SetPoints(num);
                g.SaveGoal();
                break;
            case 2:
                // Make eternal goal
                break;
            case 3:
                // Make Checklist Goal
                break;
            default:
                // Do something if answer is not 1, 2, or 3
                break;
        }


    }
    public List<string> GetGoals(){
        string fileName = "goals.txt";
        List<string> lines = new List<string>();
        List<string> goals = new List<string>();
        try
        {
            using (StreamReader sr = new StreamReader(fileName))
            {
                string result = "";
                for (int i = 1; !sr.EndOfStream; i++)
                {
                    result += sr.ReadLine();
                    lines.Add(result);
                    result = "";
                }

                int mod = 3;
                for (int x = 0; x<lines.Count(); x++){
                    if (lines[x] == ""){
                        continue;
                    }
        
                    result += lines[x];
                    result += "\n";
                    if (x!=0 & x%mod == 0){
                        goals.Add(result);
                        result = "";
                        mod += 5;
                    }
                }

            }
        }
        catch (Exception e)
        {
            Console.WriteLine($"The file {fileName} could not be read:");
            Console.WriteLine(e.Message);
            Console.WriteLine("Please Enter A Goal");
        }

        return goals;
    }

    public List<dynamic> MakeGoalList(List<string> goals){
        List<dynamic> mastergoals = new List<dynamic>();
        char type;
        string title;
        string description;
        string stringpoints;
        int points;
        foreach (string s in goals){
            type = s[6];
            if (type == '1'){
                SimpleGoal g = new SimpleGoal();
                int endoftitle = s.IndexOf("Description");
                title = s.Substring(14, endoftitle - 15);
                g.SetTitle(title);
                int endofdescription = s.IndexOf("Points");
                description = s.Substring(endoftitle + 13, endofdescription - (endoftitle + 14));
                g.SetDescription(description);
                stringpoints = s.Substring(endofdescription + 8, s.Length - (endofdescription + 9));
                bool success = int.TryParse(stringpoints, out points);
                g.SetPoints(points);
                mastergoals.Add(g);

            }else if (type == '2'){
                //Add Eternal Goal to master list
            }else if (type == '3'){
                //Add Checklist Goal to Master List
            }else{
                Console.WriteLine("An Error Has Occured");
            }
        }
        foreach (Goal g in mastergoals){
            Console.WriteLine(g.GetPoints());
        }
        return mastergoals;
    }

    public void CreateUser(){
        User u = new User();
        Console.WriteLine("Please Enter your name");
        string name = Console.ReadLine();
        u.SetUsername(name);
        Console.WriteLine("Please enter a 4 number pin");
        int num;
        bool success = int.TryParse(Console.ReadLine(), out num);
        while(success == false || num.ToString().Length > 4){
            Console.WriteLine("Please enter a 4 number pin");
            success = int.TryParse(Console.ReadLine(), out num);
        }
        u.SetPin(num);
        u.SaveUserToMasterFile();
    }

    public void GetUser(){
        Console.WriteLine("Please enter your user pin (type 1 for forgot password)");
        int answer;
        bool success = int.TryParse(Console.ReadLine(), out answer);
        while (success == false || answer.ToString().Length < 4 || answer.ToString().Length > 4){
            if (answer == 1){
                break;
            }
            Console.WriteLine("Please enter your user pin (type 1 for forgot password)");
            success = int.TryParse(Console.ReadLine(), out answer);
        }
        //Add condition to change password
        /*if (answer == 1){
            Console.WriteLine("What is your username:");
            string name = Console.ReadLine();

        }*/

    }
}