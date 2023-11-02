
using System.Dynamic;

class Activity{
    private List<string> title = new List<string>{
        "Breathing Activity",
        "Reflection Activity",
        "Listing Activity"
    };

    private List<string> description = new List<string>{
        "This activity will help you relax by walking your through breathing in and out slowly. Clear your mind and focus on your breathing.",
        "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.",
        "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area."
    };

    private List<string> propmpts = new List<string>();

    private int duration = 10;

    private string endmessage;

    public void Prepare(){
        Console.WriteLine("Get Ready...");
        LoadingScreen();
    }

    public void SetDuration(){
        Console.Write("How long, in seconds, would you like for your session: ");
        string time = Console.ReadLine();
        bool num = int.TryParse(time, out duration);
        while(num != true){
            Console.Write("How long,in seconds, would you like for your session");
            time = Console.ReadLine();
            num = int.TryParse(time, out duration);
        }
    }

    public int GetDuration(){
        return duration;
    }

    public string StartMessage(int index){
        string message = $"Welcome the {title[index]}\n\n{description[index]}\n";
        return message;
    }

    public void EndMessage(int index){
        Console.WriteLine($"Well Done!\n\n");
        LoadingScreen();
        Console.WriteLine($"You have completed {duration} seconds of {title[index]}.");
    }

    public void LoadingScreen(){
        List<string> bar = new List<string>{"{","}"};
        List<string> insidebar = new List<string>();
        int x = 0;
        while (x != 100){
            insidebar.Add("-");
            x += 1;
        }
        
        int index = 1;
        foreach (string newString in insidebar){
            bar.Insert(index, newString);
            index++;
        }

        for(int i = 1; i < bar.Count()-1; i++){
            bar.RemoveAt(i);
            bar.Insert(i, "*");
            foreach(string text in bar){
                Console.Write(text);
            }
            Thread.Sleep(10);
            for (int z = 0; z<bar.Count(); z++){
                Console.Write("\b \b");
            }
        }
    }
}