class Word{
    private string word;
    private List<string> words = new List<string>();

    public string removeword(string text){
        string[] splitwords = text.Split(' ');
        words = splitwords.ToList();
        List<string> brokenscripture = words.Where(x => !x.Contains("_")).ToList();
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
        Random rand = new Random();
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
        return newtext;
    } 
}