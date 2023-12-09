

class User
{
    private string username;

    private int pin;

    public User(string u, int p)
    {
        username = u;
        pin = p;
    }

    public User(string u){
        username = u;
        pin = 1111;
    }

    public User()
    {
        username = "";
        pin = 1111;
    }

    public void SetUserName(string u)
    {
        username = u;
    }

    public string GetUserName()
    {
        return username;
    }

    public void SetPin(int p)
    {
        pin = p;
    }

    public int GetPin()
    {
        return pin;
    }

    public bool CheckUserName()
    {
        string filePath = "Users.txt";
        bool exists = false;
        using (StreamReader reader = new StreamReader(filePath))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                if (line.Contains(username))
                {
                    exists = true;
                    break;
                }
            }
        }
        if (exists)
        {
            //Console.WriteLine("The username exists. Please Choose a different Username.");
            return true;
        }
        else
        {
            //Console.WriteLine("User Created");
            return false;
        }


    }

    public bool CheckPin()
    {
        string filePath = "Users.txt";
        bool exists = false;
        using (StreamReader reader = new StreamReader(filePath))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                if (line.Contains(pin.ToString()))
                {
                    exists = true;
                    break;
                }
            }
        }
        if (exists)
        {
            //Console.WriteLine("The username exists. Please Choose a different Username.");
            return true;
        }
        else
        {
            //Console.WriteLine("User Created");
            return false;
        }
    }

    public void SaveUserToFile()
    {
        string filePath = "Users.txt";
        string line = $"{username},{pin}";
        File.AppendAllText(filePath, line + Environment.NewLine);

    }

    public void RemoveUser()
    {
        string filePath = "Users.txt";
        string search = username;
        string[] lines = File.ReadAllLines(filePath);
        List<string> updatedLines = new List<string>();
        foreach (string line in lines)
        
        {
            if (!line.Contains(search))
            
            {
                updatedLines.Add(line);
            }
        }
        File.WriteAllLines(filePath, updatedLines.ToArray());

    }
}