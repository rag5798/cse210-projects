
abstract class Item{
    private string name {get; set;}
    private string author {get; set;}
    private string type {get; set;}
    private int quantity {get; set;}

    protected Item(string n, string a, string t, int q){
        name = n;
        author = a;
        type = t;
        quantity = q;
    }

    protected Item(){
        name = "";
        author = "";
        type = "";
        quantity = 1;
    }

    public void SetName(string n){
        name = n;
    }

    public string GetName(){
        return name;
    }

    public void SetAuthor(string a){
        author = a;
    }

    public string GetAuthor(){
        return author;
    }

    public void SetType(string t){
        type = t;
    }

    public string GetBookType(){
        return type;
    }

    public void SetQuantity(int q){
        quantity = q;
    }

    public int GetQuantity(){
        return quantity;
    }

    public abstract void AddToFile();

    public abstract void Remove();

    public abstract void Check();
}