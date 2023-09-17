using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Please enter your percentage grade: ");
        int grade = Console.Read();
        string letter;

        if (grade>=90){
            letter = "A";
            Console.WriteLine($"You got an {letter}");
        }else if(grade>=80){
            letter = "B";
            Console.WriteLine($"You got an {letter}");
        }else if(grade>=70){
            letter = "C";
            Console.WriteLine($"You got an {letter}");
        }else if(grade>=60){
            letter = "D";
            Console.WriteLine($"You got an {letter}");
        }else if(grade<60){
            letter = "F";
            Console.WriteLine($"You got an {letter}");
        }else{
            Console.WriteLine("Error");
        }
    }
}