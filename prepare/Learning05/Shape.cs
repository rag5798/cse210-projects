public abstract class Shape{
    private string color {get; set;}

    private double Area {get; set;}

    public Shape(string nameofcolor){
        SetColor(nameofcolor);
    }

    public abstract double GetArea();

    public void SetColor(string nameofcolor){
        color = nameofcolor;
    }

    public void SetArea(double num){
        Area = num;
    }
}