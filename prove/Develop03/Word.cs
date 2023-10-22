using System.Runtime.InteropServices;

class Word{
    private string word;
    private string blankword = "";
    private List<string> indexchecker;

    public string RemoveWord(string text){
        if (indexchecker.Count() == 0){
            return "quit";
        }
        string[] splitwords = text.Split(' ');
        Random rand = new Random();
        int index = rand.Next(indexchecker.Count());
        int splitindex = Array.IndexOf(splitwords, indexchecker[index]);
        indexchecker.RemoveAt(index);
        if (splitindex==-1){
            return "An error has ocurred";
        }
        word = splitwords[splitindex];

        blankword = "";
        for(int x=0; x<word.Length;x++){
            blankword += "_";
        }

        splitwords[splitindex] = blankword;
        
        string newtext = "";
        for(int x=0;x<splitwords.Length;x++){
            newtext += splitwords[x];
            newtext += " ";
        }

        return newtext;
    
        //version 2
        /*string[] splitwords = text.Split(' ');
        bool[] removedwordcheck = new bool[splitwords.Length];

        for(int x=0; x<splitwords.Length; x++){
            removedwordcheck[x] = false;
        }
        
        Random rand = new Random();
        //add more indexes to remove more words
        int index = rand.Next(indexcheaker.Length-1);
        Console.WriteLine(index);
        Console.WriteLine(indexcheaker[index]);
        //Console.WriteLine(index);
        //Console.WriteLine(removedwordcheck[index]);
        while(indexcheaker[index]==true){
            index = rand.Next(splitwords.Length-1);
        }
        indexcheaker[index] = true;
        word = splitwords[index];
        for(int x=0; x<word.Length; x++){
            blankword += "_";
        }
        splitwords[index] = blankword;
        blankword = "";

        string newtext = "";
        for(int x=0; x<splitwords.Length;x++){
            newtext += splitwords[x];
            newtext += " ";
        }
        return newtext;*/




        //version 1
        //words = splitwords.ToList();
        //List<string> brokenscripture = splitwords.Where(x => !x.Contains("_")).ToList();
        /*for(int x=0; x<brokenscripture.Count();x++){
            Console.WriteLine(brokenscripture[x]);
        }*/

        /*for(int x=0; x<brokenscripture.Count(); x++){
            if (brokenscripture[x].Contains("_")){
                continue;
            }else{
                words.Add(brokenscripture[x]);
            }
        }*/
        /*Random rand = new Random();
        int index = rand.Next(brokenscripture.Count());
        word = brokenscripture[index];
        string blank = "";
        for (int x=0; x<word.Length;x++){
            blank +="_";
        }
        int replaceindex = words.IndexOf(word);
        words.Insert(replaceindex, blank);
        words.RemoveAt(replaceindex+1);
        string newtext="";
        for(int x=0; x<words.Count(); x++){
            newtext+=words[x] + " ";
        }
        return newtext;*/
    } 

    public void SetIndexChecker(string text){
        string[] splitwords = text.Split(' ');
        indexchecker = new List<string>();
        for(int x=0; x<splitwords.Length; x++){
            indexchecker.Add(splitwords[x]);
        }
    }

    public int AlmostEmpty(){
        return indexchecker.Count();
    }
}