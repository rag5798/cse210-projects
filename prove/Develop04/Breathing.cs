
using System.Net;

class Breathing  : Activity{

    public void BreathIn(){
        Console.Write("Breath In...");
        for (int x = 1; x < 5; x++){
            Console.Write(x);
            Thread.Sleep(1000);
            Console.Write("\b \b");
        }
        Console.WriteLine("\n");
    }

    public void BreathOut(){
        Console.Write("Breath Out...");
        for (int x = 1; x < 5; x++){
            Console.Write(x);
            Thread.Sleep(1000);
            Console.Write("\b \b");
        }
        Console.WriteLine("\n");
    }

    public void RunBreath(){
        int timer = GetDuration();
        int divisible = timer % 8;
        while (divisible != 0){
            timer += 1;
            divisible = timer%8;
        }
        Prepare();
        DateTime start = DateTime.Now;
        DateTime end = start.AddSeconds(timer);
        while(DateTime.Now < end){
            BreathIn();
            BreathOut();
        }

        EndMessage(0);

        /*int timer = GetDuration();
        int divisible = timer % 8;
        while (divisible != 0){
            timer += 1;
            divisible = timer%8;
        }
        Prepare();
        BreathIn();
        BreathOut();*/
    }
}