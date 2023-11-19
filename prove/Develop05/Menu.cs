using System.Collections.Generic;
using System.Dynamic;
using System.Net;
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
                EternalGoal e = new EternalGoal();
                Console.WriteLine("What is the name of the Goal: ");
                name = Console.ReadLine();
                e.SetTitle(name);
                Console.WriteLine("Please Provide a brief description of the goal: ");
                d = Console.ReadLine();
                e.SetDescription(d);
                Console.WriteLine("Please provide the point value for the goal: ");
                worked = int.TryParse(Console.ReadLine(), out num);
                while (worked == false || answer < 0){
                    Console.WriteLine("Please provide the point value for the goal: ");                    
                    worked = int.TryParse(Console.ReadLine(), out num);
                }
                e.SetPoints(num);
                e.SaveGoal();
                break;
            case 3:
                // Make Checklist Goal
                ChecklistGoal c = new ChecklistGoal();
                Console.WriteLine("What is the name of the Goal: ");
                name = Console.ReadLine();
                c.SetTitle(name);
                Console.WriteLine("Please Provide a brief description of the goal: ");
                d = Console.ReadLine();
                c.SetDescription(d);
                Console.WriteLine("Please provide the point value for the goal: ");
                worked = int.TryParse(Console.ReadLine(), out num);
                while (worked == false || answer < 0){
                    Console.WriteLine("Please provide the point value for the goal: ");                    
                    worked = int.TryParse(Console.ReadLine(), out num);
                }
                c.SetPoints(num);
                
                Console.WriteLine("Please enter the amount of times this goal should be completed: ");
                int max;
                worked = int.TryParse(Console.ReadLine(), out max);
                while (worked == false || max < 0){
                    Console.WriteLine("Please enter the amount of times this goal should be completed: ");                    
                    worked = int.TryParse(Console.ReadLine(), out max);
                }
                c.SetMaxCompletions(max);
                
                Console.WriteLine("Please provide the bonus point value for fully completing this activity: ");
                int bonus;
                worked = int.TryParse(Console.ReadLine(), out bonus);
                while (worked == false || bonus < 0){
                    Console.WriteLine("Please provide the bonus point value for fully completing this activity: ");                    
                    worked = int.TryParse(Console.ReadLine(), out bonus);
                }
                c.SetBonusPoints(c.GetPoints() + bonus);
                c.SaveGoal();
                break;
            default:
                // Do something if answer is not 1, 2, or 3
                Console.WriteLine("An Error Has Occured");
                break;
        }


    }
    public List<string> GetGoals(string file){
        string fileName = file;
        List<string> goals = new List<string>();
        string result = "";
        string[] lines = File.ReadAllLines(fileName);
        for (int i = 0; i < lines.Length; i++){
            if (lines[i].Contains("Type: 1")){
                result += lines[i] + "\n";
                result += lines[i+1] + "\n";
                result += lines[i+2] + "\n";
                result += lines[i+3] + "\n";
                result += lines[i+4] + "\n";
                goals.Add(result);
                result = "";
            }else if (lines[i].Contains("Type: 2")){
                result += lines[i] + "\n";
                result += lines[i+1] + "\n";
                result += lines[i+2] + "\n";
                result += lines[i+3] + "\n";
                goals.Add(result);
                result = "";
            }else if (lines[i].Contains("Type: 3")){
                result += lines[i] + "\n";
                result += lines[i+1] + "\n";
                result += lines[i+2] + "\n";
                result += lines[i+3] + "\n";
                result += lines[i+4] + "\n";
                result += lines[i+5] + "\n";
                goals.Add(result);
                result = "";
            }
        }
        
        /*try
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
        }*/

        return goals;
    }

    public List<dynamic> MakeGoalList(List<string> goals){
        List<dynamic> mastergoals = new List<dynamic>();
        char type;
        string title;
        string description;
        string stringpoints;
        int points;
        int completions;
        int maxcompletions;
        int bonuspoints;
        foreach (string s in goals){
            type = s[6];
            if (type == '1'){
                SimpleGoal g = new SimpleGoal();
                int endoftitle = s.IndexOf("Description");
                title = s.Substring(14, endoftitle - 15);
                //Console.WriteLine(title);
                g.SetTitle(title);

                int endofdescription = s.IndexOf("Points");
                description = s.Substring(endoftitle + 13, endofdescription - (endoftitle + 14));
                //Console.WriteLine(description);
                g.SetDescription(description);

                int startofcompleted = s.IndexOf("Completed");
                stringpoints = s.Substring(endofdescription + 8, startofcompleted - (endofdescription + 9));
                bool success = int.TryParse(stringpoints, out points);
                //Console.WriteLine(points);
                g.SetPoints(points);

                
                string stringcom = s.Substring(startofcompleted + 11, s.Length - (startofcompleted + 12));
                //Console.WriteLine(stringcom);
                int complete;
                success = int.TryParse(stringcom, out complete);
                g.SetCompleted(complete);

                mastergoals.Add(g);

            }else if (type == '2'){
                //Add Eternal Goal to master list
                EternalGoal e = new EternalGoal();
                int endoftitle = s.IndexOf("Description");
                title = s.Substring(14, endoftitle - 15);
                //Console.WriteLine(title);
                e.SetTitle(title);

                int endofdescription = s.IndexOf("Points");
                description = s.Substring(endoftitle + 13, endofdescription - (endoftitle + 14));
                //Console.WriteLine(description);
                e.SetDescription(description);

                stringpoints = s.Substring(endofdescription + 8, s.Length - (endofdescription + 9));
                bool success = int.TryParse(stringpoints, out points);
                //Console.WriteLine(points);
                e.SetPoints(points);

                mastergoals.Add(e);
            }else if (type == '3'){
                //Add Checklist Goal to Master List
                ChecklistGoal c = new ChecklistGoal();
                int endoftitle = s.IndexOf("Description");
                title = s.Substring(14, endoftitle - 15);
                //Console.WriteLine(title);
                c.SetTitle(title);

                int endofdescription = s.IndexOf("Completions");
                description = s.Substring(endoftitle + 13, endofdescription - (endoftitle + 14));
                //Console.WriteLine(description);
                c.SetDescription(description);

                int endofcomplete = s.IndexOf("Points");
                string stringcompletions = s.Substring(endofdescription + 13, endofcomplete - (endofdescription + 16));
                bool success = int.TryParse(stringcompletions, out completions);
                //Console.WriteLine(completions);
                c.SetCompletions(completions);

                string stringmaxcompletions = s.Substring(endofdescription + 15, endofcomplete - (endofdescription + 16));
                success = int.TryParse(stringmaxcompletions, out maxcompletions);
                //Console.WriteLine(maxcompletions);
                c.SetMaxCompletions(maxcompletions);
                
                int endofpoints = s.IndexOf("Completion Bonus");
                stringpoints = s.Substring(endofcomplete + 8, endofpoints - (endofcomplete + 9));
                success = int.TryParse(stringpoints, out points);
                //Console.WriteLine(points);
                c.SetPoints(points);

                string stringbonus = s.Substring(endofpoints + 18, s.Length - (endofpoints + 19));
                success = int.TryParse(stringbonus, out bonuspoints);
                Console.WriteLine(bonuspoints);
                c.SetBonusPoints(bonuspoints);

                mastergoals.Add(c);
            }else{
                Console.WriteLine("An Error Has Occured");
            }
        }
        
        return mastergoals;
    }

    public void OverWriteGoal(Goal g, int times){
        if (g.GetTypeOfGoal() == 1){
            string fileName = "goals.txt";
            string[] lines = File.ReadAllLines(fileName);
            for (int i = 0; i < lines.Length; i++){
                if (lines[i].Contains(g.GetTitle())){
                    //Console.WriteLine("String found on line {0}: {1}", i + 1, lines[i]);
                    lines[i+2] = $"Completed: {times}";
                }
            }
            File.WriteAllLines("goals.txt", lines);
        }
    }

    public int SelectGoal(List<string> goals, List<dynamic> mastergoals, User currentuser){
        int num = 1;
        foreach (string s in goals){
            Console.WriteLine($"{num}.) {s}");
            num++;
        }

        Console.WriteLine("\nPlease Select the Goal you Completed with the Coresponding Number: ");
        int answer;
        bool success = int.TryParse(Console.ReadLine(), out answer);

        while (success == false | answer < 1 | answer > goals.Count()){
            num = 1;
            foreach (string s in goals){
                Console.WriteLine($"{num}.) {s}");
                num++;
            }
            Console.WriteLine("\nPlease Select the Goal you Completed with the Coresponding Number: ");
            success = int.TryParse(Console.ReadLine(), out answer);
        }

        mastergoals[answer - 1].Complete();
        SaveGoalToUser(currentuser, mastergoals[answer - 1]);

        if (mastergoals[answer - 1].GetTypeOfGoal() == 3){
            if (mastergoals[answer - 1].GetCompletions()/mastergoals[answer - 1].GetMaxCompletions() == 1){
                mastergoals[answer - 1].Complete();
                return mastergoals[answer - 1].GetBonusPoints();
            }
        }
        return mastergoals[answer -1].GetPoints();

    }

    public void CreateUser(){
        User u = new User();
        Console.WriteLine("Please Enter your username");
        string name = Console.ReadLine();
        u.SetUsername(name);
        Console.WriteLine("Please enter a 4 number pin");
        int num;
        bool success = int.TryParse(Console.ReadLine(), out num);
        while(success == false | num.ToString().Length > 4 | num.ToString().Length < 4){
            Console.WriteLine("Please enter a 4 number pin");
            success = int.TryParse(Console.ReadLine(), out num);
        }
        string line;
        string fileName = "users.txt";
        //bool exists = false;
        if (File.Exists(fileName)){
            StreamReader file = new StreamReader(fileName);
            while ((line = file.ReadLine()) != null){
                if (line.Contains(num.ToString())){
                    Console.WriteLine("Pin is in use");
                    CreateUser();
                    //exists = true;
                    //break;
                }
            }
            //broken pin checker
            /*while (exists == true){
                Console.WriteLine("Please enter a 4 number pin");
                success = int.TryParse(Console.ReadLine(), out num);
                while ((line = file.ReadLine()) != null){
                    if (line.Contains(num.ToString())){
                        Console.WriteLine("");
                        exists = true;
                        Console.WriteLine("Pin is in use");
                        break;
                    }else{
                        exists = false;
                    }
                }
            }*/

            file.Close();
        }

        u.SetPin(num);
        u.SaveUserToMasterFile();
    }

    public User GetUser(){
        if (File.Exists("users.txt") == false){
            CreateUser();
        }
        User u = new User();
        Console.WriteLine("Please enter your user pin");
        int answer;
        bool success = int.TryParse(Console.ReadLine(), out answer);
        while (success == false || answer.ToString().Length < 4 || answer.ToString().Length > 4){
            if (answer == 1){
                break;
            }
            Console.WriteLine("Please enter your user pin");
            success = int.TryParse(Console.ReadLine(), out answer);
        }
        //attempted condition to make new user if pin doesnt work
        /*if (answer == 1){
            
        }*/

        string fileName = "users.txt";
        string[] lines = File.ReadAllLines(fileName);
        for (int i = 0; i < lines.Length; i++){
            if (lines[i].Contains(answer.ToString())){
                //Console.WriteLine("String found on line {0}: {1}", i + 1, lines[i]);
                string username = lines[i-1].Substring(10, lines[i-1].Length - 10);
                u.SetUsername(username);
                int pin;
                success = int.TryParse(lines[i].Substring(4, lines[i].Length - 4), out pin);
                if (success == false){
                    Console.WriteLine("An Error has oucured please try agian");
                    GetUser();
                }else{
                    u.SetPin(pin);
                }

                int points;
                success = int.TryParse(lines[i+1].Substring(7, lines[i+1].Length - 7), out points);
                if (success == false){
                    Console.WriteLine("An Error has oucured please try agian");
                    GetUser();
                }else{
                    u.SetPoints(points);
                }
            }
        }

        return u;

    }

    public void OverWriteUser(User u){
        string fileName = "users.txt";
        string[] lines = File.ReadAllLines(fileName);
        for (int i = 0; i < lines.Length; i++){
            if (lines[i].Contains(u.GetUsername())){
                //Console.WriteLine("String found on line {0}: {1}", i + 1, lines[i]);
                lines[i+2] = $"Points: {u.GetPoints()}";
            }
        }
        File.WriteAllLines("users.txt", lines);
    }

    public void SaveGoalToUser(User u, Goal g){
        string fileName = $"{u.GetUsername()}goals.txt";
        StreamWriter sw = new StreamWriter(fileName, true);
        sw.WriteLine(g.Display());
        sw.Close();
    }

    public List<int> GetTimesGoalCompleted(User u){
        string fileName = $"{u.GetUsername()}goals.txt";
        if(File.Exists(fileName) == false){
            List<int> none = new List<int>();
            return none;
        }
        List<string> checkgoal = new List<string>();
        List<dynamic> goals = MakeGoalList(GetGoals(fileName));
        for (int x = 0; x < goals.Count(); x++){
            string title = goals[x].GetTitle();
            checkgoal.Add(title);
        }
        
        List<int> timespergoal = new List<int>();
        int count = 0;
        for(int x = 0; x < goals.Count(); x++){

            string title = checkgoal[x];
            for (int y = 0; y < checkgoal.Count(); y++){
                if (checkgoal[y].Contains(title)){
                    count += 1;
                }
            }
            timespergoal.Add(count);
            count = 0;
        }

        return timespergoal;

    }

    public void ShowUserCompletedGoals(List<string> goals){
        int num = 1;
        foreach (string s in goals){
            Console.WriteLine($"{num}.) {s}");
            num++;
        }
    }
}