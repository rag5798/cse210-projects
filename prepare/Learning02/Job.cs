using System;
using System.ComponentModel.DataAnnotations;

public class Job{
    public string company;
    public string jobtitle;
    public int startyear;
    public int endyear;
    public Job(){
    }
    public Job(string comp, string title, int syear, int eyear){
        company = comp;
        jobtitle = title;
        startyear = syear;
        endyear = eyear;
    }
    public void GiveName(string name1){
        company = name1;
    }
    public void GiveJobTitle(string job){
        jobtitle = job;
    }
    public void GiveStartYear(int year){
        startyear = year;
    }
    public void GiveEndYear(int year){
        endyear = year;
    }

    public void Display(){
        Console.WriteLine($"{jobtitle} ({company}) {startyear}-{endyear}");
    }
}