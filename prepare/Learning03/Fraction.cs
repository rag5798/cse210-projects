
class Fractions{
    private int topnum {get; set;}
    private int bottomnum {get; set;}
    
    public Fractions(){
        topnum=1;
        bottomnum=1;
    }

    public Fractions(int num){
        topnum=num;
        bottomnum=1;
    }

    public Fractions(int up, int down){
        topnum=up;
        bottomnum=down;
    }

    public void display(){
        Console.WriteLine($"{topnum}/{bottomnum}");
    }

    public string GetFractionString(){
        if (bottomnum == 0){
            string error = "Cannot divide by zero";
            return error;
        }else{
            string fraction = $"{topnum}/{bottomnum}";
            return fraction;
        }
        
    }


    public double GetDecimalValue(){
            double deci = (double)topnum/(double)bottomnum;
            return deci;

    }

    public int GetTop(){
        return topnum;
    }

    public void SetTop(int top){
        topnum = top;
    }

    public int GetBottom(){
        return bottomnum;
    }

    public void SetBottom(int bottom){
        bottomnum = bottom;
    }

    
}