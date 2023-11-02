
class Listing : Activity{
    List<string> prompts = new List<string>{
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"
    };

    List<string> answers = new List<string>();

    public void CountDown(){
        Console.Write("Here's 10 seconds to think.....");
        for (int x = 1; x < 11; x++){
            Console.Write(x);
            Thread.Sleep(1000);
            Console.Write("\b \b");
        }
        Console.WriteLine("\nStart");
    }

    public void RunListing(){
        Random rand = new Random();
        int index = rand.Next(0,prompts.Count());
        Console.WriteLine(StartMessage(2));
        SetDuration();
        Console.WriteLine(prompts[index]);
        CountDown();
        DateTime start = DateTime.Now;
        DateTime end = start.AddSeconds(GetDuration());
        while (DateTime.Now < end){
            Console.Write("\n");
            string answer = Console.ReadLine();
            answers.Add(answer);
        }
        EndMessage(2);
        Console.WriteLine("\nYour Answers were:");
        foreach (string a in answers){
            Console.WriteLine(a);
        }
        Console.WriteLine("\n");
    }
}