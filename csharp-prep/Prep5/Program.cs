using System;
using System.ComponentModel;

class Program
{
    public string DisplayWelcome(){
        string welcome = "Welcome to the program!";
        return welcome;
    }

    public string PromptUserName(){
        Console.Write("Please enter your name: ");
        string name = Console.ReadLine();
        return name;
    }

    public int PromptUserNumber(){
        Console.Write("Please enter your favorite number: ");
        int num = int.Parse(Console.ReadLine());
        return num;
    }

    public int SquareNumber(int num){
        int SquareNumber = 0;
        return SquareNumber;
    }


    static void Main(string[] args)
    {
        Console.WriteLine("Hello Prep5 World!");
    }
}