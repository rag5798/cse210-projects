using System.Drawing;

class Square : Shape
{
    private double side {get; set;}
    
    public Square(string nameofcolor, double length) : base(nameofcolor){
        SetColor(nameofcolor);
        side = length;
    }

    public override double GetArea()
    {
        throw new NotImplementedException();
    }
}