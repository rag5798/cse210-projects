
using System.ComponentModel.DataAnnotations;

class Reflection : Activity{
    List<string> prompts = new List<string>{
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    };

    List<string> reflectionprompt = new List<string>{
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What made this time different than other times when you were not as successful?",
        "What is your favorite thing about this experience?",
        "What could you learn from this experience that applies to other situations?",
        "What did you learn about yourself through this experience?",
        "How can you keep this experience in mind in the future?"
    };

    List<string> answers = new List<string>();

    List<string> usedprompts = new List<string>();

    public string DisplayPrompt(){
        Random rand = new Random();
        int index = rand.Next(0, 4);
        usedprompts.Add(prompts[index]);
        return prompts[index];
    }

    public string DisplayReflectPropmt(){
        Random rand = new Random();
        int index = rand.Next(0, 9);
        return reflectionprompt[index];
    }

    public string DisplayAnswers(int index){
        return answers[index];
    }

    public void RunReflection(){
        Prepare();
        DateTime start = DateTime.Now;
        DateTime end = start.AddSeconds(GetDuration());

        while(DateTime.Now < end){
            Console.WriteLine(DisplayPrompt());
            Console.WriteLine(DisplayReflectPropmt());
            string answer = Console.ReadLine();
            answers.Add(answer);
        }
        EndMessage(1);
        Console.WriteLine("Your Responses were: \n");
        Thread.Sleep(1000);
        for (int x = 0; x < answers.Count(); x++){
            Console.WriteLine(usedprompts[x]);
            Console.WriteLine(answers[x] + "\n");
        }
        
    }
}