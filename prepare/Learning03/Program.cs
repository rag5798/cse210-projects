using System;

class Program
{
    static void Main(string[] args)
    {
        Fractions fract1 = new Fractions();
        Fractions fract2 = new Fractions(1);
        Fractions fract3 = new Fractions(1,9);
        Console.WriteLine(fract1.GetFractionString());
        Console.WriteLine(fract1.GetTop());
        Console.WriteLine(fract1.GetBottom());
        fract1.SetTop(9);
        fract1.SetBottom(25);
        Console.WriteLine(fract1.GetFractionString());
        Console.WriteLine(fract1.GetDecimalValue());
    }
}