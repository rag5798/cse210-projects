using System;
using System.ComponentModel;

class Program
{
    string DisplayWelcome(){
        string welcome = "Welcome to the program!";
        return welcome;
    }

    string PromptUserName(){
        Console.Write("Please enter your name: ");
        string name = Console.ReadLine();
        return name;
    }

    int PromptUserNumber(){
        Console.Write("Please enter your favorite number: ");
        int num = int.Parse(Console.ReadLine());
        return num;
    }

    int SquareNumber(int num){
        int square = num * num;
        return square;
    }

    void DisplayResult(string name, int square){
        Console.WriteLine($"{name}, the square of your number is {square}");
    }




    static void Main(string[] args)
    {
        Program pro = new Program();
        pro.DisplayWelcome();
        string name = pro.PromptUserName();
        int num = pro.PromptUserNumber();
        num = pro.SquareNumber(num);
        pro.DisplayResult(name, num);

    }
}