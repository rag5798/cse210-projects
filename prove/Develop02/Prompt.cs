using System;
class Prompt{
    public List<string> prompts = new List<string>
    {
        "Imagine you are a software engineer working on a project that will change the world. Describe the project and its potential impact.",
        "Write a 400-word story about a hacker who uses their skills for good.",
        "Write a poem about the beauty of coding.",
        "Create a short story about a programmer who creates an AI that becomes too powerful to control.",
        "Write a 500-word essay on the impact of artificial intelligence on the job market."
    };

    public void displayprompt(){
        Console.WriteLine($"The current prompts are:");
        for (int x = 0; x<prompts.Count();x++){
            Console.WriteLine($"{x+1}.) {prompts[x]}\n");
        }
    }

    public int displaypromptchoice(){
        Console.WriteLine("Please selcet the prompt you would like to respond too");
        int answer=-1;
        while(answer-1>prompts.Count || answer-1<0){
            while(!int.TryParse(Console.ReadLine(), out answer)){
                Console.WriteLine("That was invalid. Enter a valid option.");
            }
        }
        return answer;
    }

    public void addprompt(){
        Console.WriteLine("Please enter a prompt: ");
        string prompt = Console.ReadLine();
        prompts.Add(prompt);
        Console.WriteLine($"You added the propmpt: {prompt}\n");
    }

    public void removeprompt(){
        int index;
        displayprompt();
        Console.WriteLine("Please enter the number associated with the prompt that you want to use: ");
        Boolean done = false;
        while (done==false){
            try{
            index = int.Parse(Console.ReadLine());
            done=true;
            if (index- 1 > prompts.Count() || index-1<0){
                removeprompt();
            }else{
                Console.WriteLine($"You removed prompt {index}");
            }
            }catch{
                displayprompt();
                Console.WriteLine("\nPlease enter a valid number");
            }
        }

    }

    public string entertext(int promptnum){
        Console.WriteLine(prompts[promptnum]);
        Console.WriteLine("Please enter your response:");
        string response=Console.ReadLine();
        return response;
    }
}