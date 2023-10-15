using System;

class Program
{
    static void Main(string[] args)
    {
        Random rand = new Random();
        Scripture script = new Scripture();
        Reference refer = new Reference();
        Word w = new Word();
        int index = script.randomint();
        bool cont = true;
        string text = script.displayscripture(index);
        string header = refer.displayheader(index);
        while(cont==true){
            Console.WriteLine($"{header} {text}");
            Console.WriteLine("Press enter to continue or enter 'quit' to finish:");
            string answ = Console.ReadLine();
            if (answ == "quit"){
                cont=false;
            }else{
                //int times = rand.Next(1, 4);
                //for(int x=0; x<times; x++){
                text = w.removeword(text);
                Console.Clear();
                //}
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