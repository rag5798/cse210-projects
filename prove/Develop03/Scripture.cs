using System.Runtime.InteropServices;

class Scripture{
    private string scripture;
    private List<string> scripturetext = new List<string>(){
        "Trust in the Lord with all thine heart; and lean not unto thine own understanding. In all thy ways acknowledge him, and he shall direct thy paths.",
        "And it came to pass that I, Nephi, said unto my father: I will go and do the things which the Lord hath commanded, for I know that the Lord giveth no commandments unto the children of men, save he shall prepare a way for them that they may accomplish the thing which he commandeth them.",
        "For behold, this is my work and my glory—to bring to pass the immortality and eternal life of man."
    };

    public string displayscripture(int index){
        return scripturetext[index];
    }

    public int randomint(){
        Random rand = new Random();
        int index = rand.Next(scripturetext.Count());
        return index;
    }


}