
class User{

    private string username;
    private int pin;
    private int points;

    private List<int> goalscompleted = new List<int>();

    public User(){
        username = "admin";
        pin = 1234;
        points = 0;
    }

    public User(string name, int num){
        username = name;
        pin = num; 
        points = 0;
    }

    public string GetUsername(){
        return username;
    }

    public void SetUsername(string name){
        username = name;
    }

    public int GetPin(){
        return pin;
    }

    public void SetPin(int num){
        pin = num;
    }

    public int GetPoints(){
        return points;
    }

    public void SetPoints(int num){
        points += num;
    }

    public void SaveUserToMasterFile()
    {
        string fileName = "users.txt";
        try
        {
            using (StreamWriter sr = new StreamWriter(fileName, true))
            {
                sr.WriteLine($"Username: {GetUsername()}\nID: {GetPin()}\nPoints: {GetPoints()}\n");
            }
        }
        catch (Exception e)
        {
            Console.WriteLine($"The file {fileName} could not be read:");
            Console.WriteLine(e.Message);
        }
    } 

    //Tried a different way that saves user and user made goals together
    /*public void SaveUserFile()
    {
        string fileName = $"{username}.txt";
        bool exists = File.Exists(fileName);
        int number = 1;
        while (exists == true){
            fileName = $"{username}{number}.txt";
            exists = File.Exists(fileName);            
            number ++;
        }
        try
        {
            using (StreamWriter sr = new StreamWriter(fileName, true))
            {
                sr.WriteLine($"Username: {GetUsername()}\nID: {GetPin()}\nPoints: {GetPoints()}\n");
            }
        }
        catch (Exception e)
        {
            Console.WriteLine($"The file {fileName} could not be read:");
            Console.WriteLine(e.Message);
        }
    }*/

    
}