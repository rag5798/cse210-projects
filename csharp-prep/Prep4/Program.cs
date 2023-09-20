using System;

class Program
{
    static void Main(string[] args)
    {
        List<int> list = new List<int>();
        Console.WriteLine("Enter a list of numbers, type 0 when finished.");
        Console.Write("Enter number: ");
        int num = int.Parse(Console.ReadLine());
        list.Add(num);
        while (num!=0){
            Console.Write("Enter number: ");
            num = int.Parse(Console.ReadLine());
            list.Add(num);
        }
        int sum = list.Sum();
        double avg = list.Average();
        int max = list.Max();
        Console.WriteLine($"The sum is: {sum}\nThe average is: {avg}\nThe largest number is: {max}");
    }
}