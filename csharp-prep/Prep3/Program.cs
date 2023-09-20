using System;


class Program
{
    static void Main(string[] args)
    {
        int guess;
        Random rnd = new Random();
        int magicNum = rnd.Next(100);
        Console.Write("What is the magic number? ");
        //int magicNum = int.Parse(Console.ReadLine());
        Console.WriteLine("What is your guess? ");
        guess = int.Parse(Console.ReadLine());
        if (guess>magicNum){
            Console.WriteLine("Lower");
        }else if (guess<magicNum){
            Console.WriteLine("Higher");
        }else if (guess==magicNum){
            Console.WriteLine("You guessed it!");
        }
        while (magicNum!=guess){
        Console.Write("What is your guess? ");
        guess = int.Parse(Console.ReadLine());
        
        if (guess>magicNum){
            Console.WriteLine("Lower");
        }else if (guess<magicNum){
            Console.WriteLine("Higher");
        }else if (guess==magicNum){
            Console.WriteLine("You guessed it!");
            break;
        }
        }
    }
}