
class Listening : Activity{
    string file = "medetation.mp3";

    public void RunListening(){
        
        Console.WriteLine(StartMessage(3));
        SetDuration();
        Prepare();
        DateTime start = DateTime.Now;
        DateTime end = start.AddSeconds(GetDuration());
        while(DateTime.Now < end){
            
        }
    }
}