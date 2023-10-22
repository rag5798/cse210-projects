using System;

class Program
{
    static void Main(string[] args)
    {
        Random rand = new Random();
        int index = rand.Next(41955);
        Scripture script = new Scripture();
        Reference refer = new Reference();
        Word w = new Word();
        bool cont = true;
        string text = script.GetScriptureFromFile(index);
        text = text.Remove(text.Length - 1);
        text = text.Remove(text.Length - 1);
        text = text.Substring(1);
        string header = refer.GetHeaderFromFile(index);
        header = header.Substring(1);
        w.SetIndexChecker(text);
        while(cont==true){
            Console.WriteLine($"{header} {text}");
            Console.WriteLine("Press enter to continue or enter 'quit' to finish:");
            string answ = Console.ReadLine();
            if (answ == "quit"){
                cont=false;
            }else{
                int times = rand.Next(1, 4);
                if(w.AlmostEmpty()==0){
                    cont = false;
                }else if(w.AlmostEmpty()==1){
                    times = 1;
                }else if(w.AlmostEmpty()<4){
                    times = rand.Next(1, w.AlmostEmpty());
                }
                times = rand.Next(1, 4);
                for(int x=0; x<times; x++){
                    text = w.RemoveWord(text);
                    Console.Clear();
                }
                
                
                /*string newstring = text.Replace(" ", "");
                bool containsAllUnderscores = newstring.All(c => c == '_');
                if (containsAllUnderscores==true){
                    cont=false;
                }*/
                //Console.WriteLine(text);
            }
        }
        /*List<string> broken = w.removeword(text);
        for (int x=0; x<broken.Count(); x++){
            Console.Write(broken[x] + " ");
        }*/

    }
}