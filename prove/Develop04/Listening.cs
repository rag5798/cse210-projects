using System.Diagnostics;
using System.IO;

class Listening : Activity{
     
     public void RunListen(){
        string fileName = "jazz.mp3";
        string filePath = Path.GetFullPath(fileName).ToString();
        Process p = new Process();
        p.StartInfo.FileName = "C:\\Program Files (x86)\\Windows Media Player\\wmplayer.exe";
        p.StartInfo.Arguments = filePath;
        p.StartInfo.UseShellExecute = true;
        p.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
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
        Console.WriteLine("\n");
        EndMessage(3);
    }
}