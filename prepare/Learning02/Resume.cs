using System.Runtime.InteropServices.JavaScript;

public class Resume{
    public string name;
    public List<Job> job = new List<Job>();
    public Resume(){
    }
    public void AddJob(Job jobs){
        job.Add(jobs);
    }
    public void Display(){
        Console.Write($"Name: {name}\nJobs:\n");
        for(int i = 0; i < job.Count; i++){
            job[i].Display();
        }
    }
}