using System.Diagnostics;
class Listening : Activity{
     
     public void RunListen(){
        ProcessStartInfo info = new ProcessStartInfo{
            UseShellExecute = true,
            FileName = "C:\\Program Files (x86)\\Windows Media Player\\wmplayer.exe",
            WindowStyle = ProcessWindowStyle.Minimized,
            Arguments = "C:\\cse210\\projects\\cse210-projects\\prove\\Develop04\\jazz.mp3",
            
        };
        Process p = new Process();
        p.StartInfo = info;
        Console.WriteLine(StartMessage(3));
        SetDuration();
        p.Start();
        DateTime start = DateTime.Now;
        DateTime end = start.AddSeconds(GetDuration());
        Console.Write("Time Left:");
        while(DateTime.Now < end){
            for (int x = GetDuration(); x !=0; x--){
                Console.Write(x);
                Thread.Sleep(1000);
                if (x >= 10){
                    Console.Write("\b\b");
                }else{
                    Console.Write("\b");
                }
            }
        }
        p.Kill();
        EndMessage(3);
    }
}