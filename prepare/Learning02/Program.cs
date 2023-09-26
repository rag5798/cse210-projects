using System;

class Program
{
    static void Main(string[] args)
    {
        Job job1 = new Job("Microsoft", "Software Engineer", 2019, 2022);
        job1.Display();
        Job job2 = new Job("Apple", "Manager", 2019, 2022);
        job2.Display();
        Resume myresume = new Resume();
        myresume.name = "Allison Rose";
        myresume.AddJob(job1);
        myresume.AddJob(job2);
        myresume.Display();
    }
}