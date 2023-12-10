

class Menu
{

    public User UserMenu()
    {
        
        //User Creation/Login menu
        Console.WriteLine("WELCOME TO THE LIBRARY");
        Console.WriteLine("Please Select an option from the menu using the associated number:");
        Console.WriteLine("1.) Login\n2.) Create User");
        int num;
        bool test = int.TryParse(Console.ReadLine(), out num);
        while (test == false || num > 2 || num < 0)
        {
            Console.WriteLine("Please Select an option from the menu using the associated number:");
            Console.WriteLine("1.) Login\n2.) Create User");
            test = int.TryParse(Console.ReadLine(), out num);
        }
        User u = new User();
        if (num == 1)
        {
            string filepath = "Users.txt";
            bool exists = File.Exists(filepath);
            if (exists == false)
            {
                Console.WriteLine("Please Create a User Before Login");
                UserMenu();
            }
            bool isempty = new FileInfo(filepath).Length == 0;
            if (isempty == true)
            {
                Console.WriteLine("Please Create a User Before Login");
                UserMenu();
            }
            Console.WriteLine("\nPlease Login to Access Your Account");
            Console.Write("Please input a username: ");
            string user = Console.ReadLine();
            u.SetUserName(user);

            int pin;
            test = int.TryParse(Console.ReadLine(), out pin);
            while (test == false || pin > 9999 || pin < 1000)
            {
                Console.Write("Please input a 4 digit pin:");
                test = int.TryParse(Console.ReadLine(), out pin);
            }
            u.SetPin(pin);
            bool checkuser = u.CheckUserName();
            bool checkpin = u.CheckPin();
            while (checkuser == false || checkpin == false)
            {
                Console.Write("Please input a username:");
                user = Console.ReadLine();
                u.SetUserName(user);

                test = int.TryParse(Console.ReadLine(), out pin);
                while (test == false || pin > 9999 || pin < 1000)
                {
                    Console.Write("Please input a 4 digit pin:");
                    test = int.TryParse(Console.ReadLine(), out pin);
                }
                u.SetPin(pin);
                checkuser = u.CheckUserName();
                checkpin = u.CheckPin();
            }

        }else if (num == 2)
        {
            string filepath = "Users.txt";
            bool fileexists = File.Exists(filepath);
            Console.Write("Please input a username:");
            string user = Console.ReadLine();
            u.SetUserName(user);
            if (fileexists == true)
            {
                bool exists = u.CheckUserName();
                while (exists == true)
                {
                    Console.WriteLine("*Username is in use*");
                    Console.Write("Please input a username:");
                    user = Console.ReadLine();
                    u.SetUserName(user);
                    exists = u.CheckUserName();
                }
            }
            


            Console.Write("Please input a 4 digit pin:");
            int pin;
            test = int.TryParse(Console.ReadLine(), out pin);
            while (test == false || pin > 9999 || pin < 1000)
            {
                Console.Write("Please input a 4 digit pin:");
                test = int.TryParse(Console.ReadLine(), out pin);
            }

            u.SetPin(pin);
            u.SaveUserToFile();
            Console.WriteLine("***User Created***");
        }else
        {
            Console.WriteLine("An Error Has Occured");
        }
        return u;
        //End of User Menu
    }
    //Start of Return Menu
    public void ReturnBook(User u)
    {
        string filepath = $"{u.GetUserName()}books.txt";
        bool fileexists = File.Exists(filepath);
        if (fileexists == false)
        {
            Console.WriteLine("Please Borrow a Book Before Returning One");
            BookMenu(u);
        }
        FileInfo isempty = new FileInfo(filepath);
        if (isempty.Length == 0)
        {
            Console.WriteLine("Please Borrow a Book Before Returning One");
            BookMenu(u);
        }
        
        string[] fields;
        List<dynamic> bookssplit = new List<dynamic>();
        using (StreamReader reader = new StreamReader(filepath))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                fields = line.Split(',');
                // Do something with the fields
                foreach (string x in fields){
                    bookssplit.Add(x);
                }
            }

        }
        List<dynamic> books = new List<dynamic>(){};
        for (int x = 0; x<bookssplit.Count(); x++)
        {
            if (bookssplit[x] == "Book")
            {
                Book b = new Book();
                b.SetName(bookssplit[x-3]);
                b.SetAuthor(bookssplit[x-2]);
                b.SetGenre(bookssplit[x-1]);
                b.SetQuantity(int.Parse(bookssplit[x+1]));
                books.Add(b);
            }else if (bookssplit[x] == "Magazine")
            {
                Magazine m = new Magazine();
                m.SetName(bookssplit[x-3]);
                m.SetAuthor(bookssplit[x-2]);
                m.SetPublishDate(bookssplit[x-1]);
                m.SetQuantity(int.Parse(bookssplit[x+1]));
                books.Add(m);
            }else if (bookssplit[x] == "ComicBook")
            {
                ComicBook cb = new ComicBook();
                cb.SetName(bookssplit[x-4]);
                cb.SetAuthor(bookssplit[x-3]);
                cb.SetVolume(bookssplit[x-2]);
                cb.SetBookNumber(int.Parse(bookssplit[x-1]));
                cb.SetQuantity(int.Parse(bookssplit[x+1]));
                books.Add(cb);
            }else if (bookssplit[x] == "Movie"){
                Movie m = new Movie();
                m.SetName(bookssplit[x-4]);
                m.SetAuthor(bookssplit[x-3]);
                m.SetGenre(bookssplit[x-2]);
                m.SetRating(bookssplit[x-1]);
                m.SetQuantity(bookssplit[x+1]);
                books.Add(m);
            }else if (bookssplit[x] == "VideoGame"){
                VideoGame vg = new VideoGame();
                vg.SetName(bookssplit[x-3]);
                vg.SetAuthor(bookssplit[x-2]);
                vg.SetSystem(bookssplit[x-1]);
                vg.SetQuantity(bookssplit[x+1]);
                books.Add(vg);
            }
        }
        foreach (Item i in books)
        {
            Console.Write($"{books.IndexOf(i)+1}.) ");
            i.Display();
        }
        Console.WriteLine("Please use the Corresponding Numbers to select a Book to Borrow");
        int bookchoice;
        bool testchoice = int.TryParse(Console.ReadLine(), out bookchoice);
        while (testchoice == false || bookchoice < 1 || bookchoice > books.Count())
        {
            foreach (Item i in books)
            {
                Console.Write($"{books.IndexOf(i)+1}.) ");
                i.Display();
            }
            Console.WriteLine("Please use the Corresponding Numbers to select a Book to Borrow");
            testchoice = int.TryParse(Console.ReadLine(), out bookchoice);
        }

        bool book = false;
        bool magazine = false;
        bool comicbook = false;
        bool movie = false;
        bool videogame = false;
        try
        {
            books[bookchoice-1].GetGenre();
            book = true;
        }catch (Exception){
            book = false;
        }

        try
        {
            books[bookchoice-1].GetPublishDate();
            magazine = true;
        }catch (Exception){
            magazine = false;
        }

        try
        {
            books[bookchoice-1].GetVolume();
            comicbook = true;
        }catch (Exception){
            comicbook = false;
        }

        try
        {
            books[bookchoice-1].GetRating();
            movie = true;
        }catch (Exception){
            movie = false;
        }

        try
        {
            books[bookchoice-1].GetSystem();
            videogame = true;
        }catch (Exception){
            videogame = false;
        }

        if (book == true){
            filepath = $"{u.GetUserName()}books.txt";
            string name = books[bookchoice-1].GetName();
            string author = books[bookchoice-1].GetAuthor();
            string genre = books[bookchoice-1].GetGenre();
            string type = books[bookchoice-1].GetBookType();
            int quantity = books[bookchoice-1].GetQuantity();
            string texttoremove = $"{name},{author},{genre},{type},1";
            string fileContents = File.ReadAllText(filepath);
            fileContents = fileContents.Replace(texttoremove, string.Empty);
            File.WriteAllText(filepath, fileContents);
            List<string> lines = File.ReadAllLines(filepath).ToList();
            lines.RemoveAll(string.IsNullOrWhiteSpace);
            File.WriteAllLines(filepath, lines);

            
            int num = 0;
            while (File.ReadAllText("Books.txt").Contains(texttoremove) == false)
            {
                texttoremove = $"{name},{author},{genre},{type},{num}";
                num++;
            }
            string texttoreplace = $"{name},{author},{genre},{type},{num}";
            fileContents = File.ReadAllText("Books.txt");
            fileContents = fileContents.Replace(texttoremove, texttoreplace);
            File.WriteAllText("Books.txt", fileContents);
        }else if (magazine == true){
            filepath = $"{u.GetUserName()}books.txt";
            string name = books[bookchoice-1].GetName();
            string author = books[bookchoice-1].GetAuthor();
            string publishdate = books[bookchoice-1].GetPublishDate();
            string type = books[bookchoice-1].GetBookType();
            int quantity = books[bookchoice-1].GetQuantity();
            string texttoremove = $"{name},{author},{publishdate},{type},1";
            string fileContents = File.ReadAllText(filepath);
            fileContents = fileContents.Replace(texttoremove, string.Empty);
            File.WriteAllText(filepath, fileContents);
            List<string> lines = File.ReadAllLines(filepath).ToList();
            lines.RemoveAll(string.IsNullOrWhiteSpace);
            File.WriteAllLines(filepath, lines);

            
            int num = 0;
            while (File.ReadAllText("Books.txt").Contains(texttoremove) == false)
            {
                texttoremove = $"{name},{author},{publishdate},{type},{num}";
                num++;
            }
            string texttoreplace = $"{name},{author},{publishdate},{type},{num}";
            fileContents = File.ReadAllText("Books.txt");
            fileContents = fileContents.Replace(texttoremove, texttoreplace);
            File.WriteAllText("Books.txt", fileContents);
        }else if (comicbook == true){
            filepath = $"{u.GetUserName()}books.txt";
            string name = books[bookchoice-1].GetName();
            string author = books[bookchoice-1].GetAuthor();
            string volume = books[bookchoice-1].GetVolume();
            int booknumber = books[bookchoice-1].GetBookNumber();
            string type = books[bookchoice-1].GetBookType();
            int quantity = books[bookchoice-1].GetQuantity();
            string texttoremove = $"{name},{author},{volume},{booknumber},{type},1";
            string fileContents = File.ReadAllText(filepath);
            fileContents = fileContents.Replace(texttoremove, string.Empty);
            File.WriteAllText(filepath, fileContents);
            List<string> lines = File.ReadAllLines(filepath).ToList();
            lines.RemoveAll(string.IsNullOrWhiteSpace);
            File.WriteAllLines(filepath, lines);

            
            int num = 0;
            while (File.ReadAllText("Books.txt").Contains(texttoremove) == false)
            {
                texttoremove = $"{name},{author},{volume},{booknumber},{type},{num}";
                num++;
            }
            string texttoreplace = $"{name},{author},{volume},{booknumber},{type},{num}";
            fileContents = File.ReadAllText("Books.txt");
            fileContents = fileContents.Replace(texttoremove, texttoreplace);
            File.WriteAllText("Books.txt", fileContents);
        }else if (movie == true){
            filepath = $"{u.GetUserName()}books.txt";
            string name = books[bookchoice-1].GetName();
            string author = books[bookchoice-1].GetAuthor();
            string genre = books[bookchoice-1].GetGenre();
            string rating = books[bookchoice-1].GetRating();
            string type = books[bookchoice-1].GetBookType();
            int quantity = books[bookchoice-1].GetQuantity();
            string texttoremove = $"{name},{author},{genre},{rating},{type},1";
            string fileContents = File.ReadAllText(filepath);
            fileContents = fileContents.Replace(texttoremove, string.Empty);
            File.WriteAllText(filepath, fileContents);
            List<string> lines = File.ReadAllLines(filepath).ToList();
            lines.RemoveAll(string.IsNullOrWhiteSpace);
            File.WriteAllLines(filepath, lines);

            
            int num = 0;
            while (File.ReadAllText("Books.txt").Contains(texttoremove) == false)
            {
                texttoremove = $"{name},{author},{genre},{rating},{type},{num}";
                num++;
            }
            string texttoreplace = $"{name},{author},{genre},{rating},{type},{num}";
            fileContents = File.ReadAllText("Books.txt");
            fileContents = fileContents.Replace(texttoremove, texttoreplace);
            File.WriteAllText("Books.txt", fileContents);
        }else if (videogame == true){
            filepath = $"{u.GetUserName()}books.txt";
            string name = books[bookchoice-1].GetName();
            string author = books[bookchoice-1].GetAuthor();
            string system = books[bookchoice-1].GetSystem();
            string type = books[bookchoice-1].GetBookType();
            int quantity = books[bookchoice-1].GetQuantity();
            string texttoremove = $"{name},{author},{system},{type},1";
            string fileContents = File.ReadAllText(filepath);
            fileContents = fileContents.Replace(texttoremove, string.Empty);
            File.WriteAllText(filepath, fileContents);
            List<string> lines = File.ReadAllLines(filepath).ToList();
            lines.RemoveAll(string.IsNullOrWhiteSpace);
            File.WriteAllLines(filepath, lines);

            
            int num = 0;
            while (File.ReadAllText("Books.txt").Contains(texttoremove) == false)
            {
                texttoremove = $"{name},{author},{system},{type},{num}";
                num++;
            }
            string texttoreplace = $"{name},{author},{system},{type},{num}";
            fileContents = File.ReadAllText("Books.txt");
            fileContents = fileContents.Replace(texttoremove, texttoreplace);
            File.WriteAllText("Books.txt", fileContents);
        }else{
            Console.WriteLine("An Error has Occured");
        }
    }
    //End of Return Menu


    //Borrow Book Menu
    public void BorrowBook(User u)
    {
        string userfile = $"{u.GetUserName()}books.txt";
        if (File.Exists(userfile) == false)
        {
            using (FileStream fs = new FileStream(userfile, FileMode.Create))
            {
                fs.Close();
            }
        }

        string filepath = "Books.txt";
        FileInfo info = new FileInfo("Books.txt");
        bool fileexists = File.Exists(filepath);
        if (fileexists == false || info.Length == 0)
        {
            Console.WriteLine("No Books Are Avalible. Please Consider Donating to Start Our Public Collection");
            BookMenu(u);
        }

        string[] fields;
        List<dynamic> bookssplit = new List<dynamic>();
        using (StreamReader reader = new StreamReader(filepath))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                fields = line.Split(',');
                foreach (string x in fields){
                    bookssplit.Add(x);
                }
            }

        }
        List<dynamic> books = new List<dynamic>(){};
        for (int x = 0; x<bookssplit.Count(); x++)
        {
            if (bookssplit[x] == "Book")
            {
                Book b = new Book();
                b.SetName(bookssplit[x-3]);
                b.SetAuthor(bookssplit[x-2]);
                b.SetGenre(bookssplit[x-1]);
                b.SetQuantity(int.Parse(bookssplit[x+1]));
                books.Add(b);
            }else if (bookssplit[x] == "Magazine")
            {
                Magazine m = new Magazine();
                m.SetName(bookssplit[x-3]);
                m.SetAuthor(bookssplit[x-2]);
                m.SetPublishDate(bookssplit[x-1]);
                m.SetQuantity(int.Parse(bookssplit[x+1]));
                books.Add(m);
            }else if (bookssplit[x] == "ComicBook")
            {
                ComicBook cb = new ComicBook();
                cb.SetName(bookssplit[x-4]);
                cb.SetAuthor(bookssplit[x-3]);
                cb.SetVolume(bookssplit[x-2]);
                cb.SetBookNumber(int.Parse(bookssplit[x-1]));
                cb.SetQuantity(int.Parse(bookssplit[x+1]));
                books.Add(cb);
            }else if (bookssplit[x] == "Movie"){
                Movie m = new Movie();
                m.SetName(bookssplit[x-4]);
                m.SetAuthor(bookssplit[x-3]);
                m.SetGenre(bookssplit[x-2]);
                m.SetRating(bookssplit[x-1]);
                m.SetQuantity(int.Parse(bookssplit[x+1]));
                books.Add(m);
            }else if (bookssplit[x] == "VideoGame"){
                VideoGame vg = new VideoGame();
                vg.SetName(bookssplit[x-3]);
                vg.SetAuthor(bookssplit[x-2]);
                vg.SetSystem(bookssplit[x-1]);
                vg.SetQuantity(int.Parse(bookssplit[x+1]));
                books.Add(vg);
            }
        }

        if (books.Count() < 10)
        {
            foreach (Item i in books)
            {
                Console.Write($"{books.IndexOf(i)+1}.) ");
                i.Display();
            }
            Console.WriteLine("Please use the Corresponding Numbers to select a Book to Borrow");
            int bookchoice;
            bool testchoice = int.TryParse(Console.ReadLine(), out bookchoice);
            while (testchoice == false || bookchoice < 1 || bookchoice > books.Count())
            {
                foreach (Item i in books)
                {
                    Console.Write($"{books.IndexOf(i)+1}.) ");
                    i.Display();
                }
                Console.WriteLine("Please use the Corresponding Numbers to select a Book to Borrow");
                testchoice = int.TryParse(Console.ReadLine(), out bookchoice);
            }
            /*bool book = false;
            bool magazine = false;
            bool comicbook = false;
            bool movie = false;
            bool videogame = false;
            try
            {
                books[bookchoice-1].GetGenre();
                book = true;
            }catch (Exception){
                book = false;
            }

            try
            {
                books[bookchoice-1].GetPublishDate();
                magazine = true;
            }catch (Exception){
                magazine = false;
            }

            try
            {
                books[bookchoice-1].GetVolume();
                comicbook = true;
            }catch (Exception){
                comicbook = false;
            }

            try
            {
                string rating = books[bookchoice-1].GetRating();
                Console.WriteLine(rating);
                movie = true;
            }catch (Exception){
                movie = false;
            }

            try
            {
                books[bookchoice-1].GetSystem();
                videogame = true;
            }catch (Exception){
                videogame = false;
            }*/

            string typeofitem = books[bookchoice-1].Check();
            
            if (typeofitem == "Book")
            {
                filepath = $"{u.GetUserName()}books.txt";
                string name = books[bookchoice-1].GetName();
                string author = books[bookchoice-1].GetAuthor();
                string genre = books[bookchoice-1].GetGenre();
                string type = books[bookchoice-1].GetBookType();
                int quantity = books[bookchoice-1].GetQuantity();
                if (quantity == 0){
                    Console.WriteLine("This Book is Out of Stock");
                    return;
                }
                string texttoappend = $"{name},{author},{genre},{type},1";
                if (File.ReadAllText(filepath).Contains(texttoappend))
                {
                    Console.WriteLine("You have already Borrowed this book");
                    return;
                }
                File.AppendAllText(filepath, texttoappend + Environment.NewLine);

                string texttoreplace = $"{name},{author},{genre},{type},{quantity-1}";
                string ogtext = $"{name},{author},{genre},{type},{quantity}";
                string fileContents = File.ReadAllText("Books.txt");
                fileContents = fileContents.Replace(ogtext, texttoreplace);
                File.WriteAllText("Books.txt", fileContents);
            }else if (typeofitem == "Magazine"){
                filepath = $"{u.GetUserName()}books.txt";
                string name = books[bookchoice-1].GetName();
                string author = books[bookchoice-1].GetAuthor();
                string publishdate = books[bookchoice-1].GetPublishDate();
                string type = books[bookchoice-1].GetBookType();
                int quantity = books[bookchoice-1].GetQuantity();
                if (quantity == 0){
                    Console.WriteLine("This Book is Out of Stock");
                    return;
                }
                string texttoappend = $"{name},{author},{publishdate},{type},1";
                if (File.ReadAllText(filepath).Contains(texttoappend))
                {
                    Console.WriteLine("You have already Borrowed this book");
                    return;
                }
                File.AppendAllText(filepath, texttoappend + Environment.NewLine);

                string texttoreplace = $"{name},{author},{publishdate},{type},{quantity-1}";
                string ogtext = $"{name},{author},{publishdate},{type},{quantity}";
                string fileContents = File.ReadAllText("Books.txt");
                fileContents = fileContents.Replace(ogtext, texttoreplace);
                File.WriteAllText("Books.txt", fileContents);
            }else if (typeofitem == "ComicBook"){
                filepath = $"{u.GetUserName()}books.txt";
                string name = books[bookchoice-1].GetName();
                string author = books[bookchoice-1].GetAuthor();
                string volume = books[bookchoice-1].GetVolume();
                int booknumber = books[bookchoice-1].GetBookNumber();
                string type = books[bookchoice-1].GetBookType();
                int quantity = books[bookchoice-1].GetQuantity();
                if (quantity == 0){
                    Console.WriteLine("This Book is Out of Stock");
                    return;
                }
                string texttoappend = $"{name},{author},{volume},{booknumber},{type},1";
                if (File.ReadAllText(filepath).Contains(texttoappend))
                {
                    Console.WriteLine("You have already Borrowed this book");
                    return;
                }
                File.AppendAllText(filepath, texttoappend + Environment.NewLine);

                string texttoreplace = $"{name},{author},{volume},{booknumber},{type},{quantity-1}";
                string ogtext = $"{name},{author},{volume},{booknumber},{type},{quantity}";
                string fileContents = File.ReadAllText("Books.txt");
                fileContents = fileContents.Replace(ogtext, texttoreplace);
                File.WriteAllText("Books.txt", fileContents);
            }else if (typeofitem == "Movie"){
                Console.WriteLine(books[bookchoice-1].GetRating());
                filepath = $"{u.GetUserName()}books.txt";
                string name = books[bookchoice-1].GetName();
                string author = books[bookchoice-1].GetAuthor();
                string genre = books[bookchoice-1].GetGenre();
                string rating = books[bookchoice-1].GetRating();
                string type = books[bookchoice-1].GetBookType();
                int quantity = books[bookchoice-1].GetQuantity();
                if (quantity == 0){
                    Console.WriteLine("This Book is Out of Stock");
                    return;
                }
                string texttoappend = $"{name},{author},{genre},{rating},{type},1";
                if (File.ReadAllText(filepath).Contains(texttoappend))
                {
                    Console.WriteLine("You have already Borrowed this book");
                    return;
                }
                File.AppendAllText(filepath, texttoappend + Environment.NewLine);


                string texttoreplace = $"{name},{author},{genre},{rating},{type},{quantity-1}";
                string ogtext = $"{name},{author},{genre},{rating},{type},{quantity}";
                string fileContents = File.ReadAllText("Books.txt");
                fileContents = fileContents.Replace(ogtext, texttoreplace);
                File.WriteAllText("Books.txt", fileContents);
            }else if (typeofitem == "VideoGame"){
                filepath = $"{u.GetUserName()}books.txt";
                string name = books[bookchoice-1].GetName();
                string author = books[bookchoice-1].GetAuthor();
                string system = books[bookchoice-1].GetSystem();
                string type = books[bookchoice-1].GetBookType();
                int quantity = books[bookchoice-1].GetQuantity();
                if (quantity == 0){
                    Console.WriteLine("This Book is Out of Stock");
                    return;
                }
                string texttoappend = $"{name},{author},{system},{type},1";
                if (File.ReadAllText(filepath).Contains(texttoappend))
                {
                    Console.WriteLine("You have already Borrowed this book");
                    return;
                }
                File.AppendAllText(filepath, texttoappend + Environment.NewLine);

                string texttoreplace = $"{name},{author},{system},{type},{quantity-1}";
                string ogtext = $"{name},{author},{system},{type},{quantity}";
                string fileContents = File.ReadAllText("Books.txt");
                fileContents = fileContents.Replace(ogtext, texttoreplace);
                File.WriteAllText("Books.txt", fileContents);
            }else{
                Console.WriteLine("An Error has occured");
            }
            
        }else{
            Console.WriteLine("Please enter your search for a book to borrow (name, or author, or type):");
            string search = Console.ReadLine();
            filepath = "books.txt";
            int lineNumber = 0;
            List<int> foundon = new List<int>();
            using (StreamReader reader = new StreamReader(filepath))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    lineNumber++;
                    if (line.Contains(search))
                    {
                        foundon.Add(lineNumber);
                    }
                }
            }
            if (foundon.Count() == 0)
             {
                return;
            }
            int num = 1;
            foreach (int i in foundon)
            {
                Console.Write($"{num}.) ");
                books[i-1].Display();
                num++;
            }
            Console.WriteLine("Please use the Corresponding Numbers to select a Book to Borrow");
            int bookchoice;
            bool testchoice = int.TryParse(Console.ReadLine(), out bookchoice);
            while (testchoice == false || bookchoice < 1 || bookchoice > foundon.Count())
            {
                num = 1;
                foreach (int i in foundon)
                {
                    Console.Write($"{num}.) ");
                    books[i-1].Display();
                    num++;
                }
                Console.WriteLine("Please use the Corresponding Numbers to select a Book to Borrow");
                testchoice = int.TryParse(Console.ReadLine(), out bookchoice);
            }
            bool book = false;
            bool magazine = false;
            bool comicbook = false;
            bool movie = false;
            bool videogame = false;
            try
            {
                books[foundon[bookchoice-1]-1].GetGenre();
                book = true;
            }catch (Exception){
                book = false;
            }

            try
            {
                books[foundon[bookchoice-1]-1].GetPublishDate();
                magazine = true;
            }catch (Exception){
                magazine = false;
            }

            try
            {
                books[foundon[bookchoice-1]-1].GetVolume();
                comicbook = true;
            }catch (Exception){
                comicbook = false;
            }

            try
            {
                string rate = books[foundon[bookchoice-1]-1].GetRating();
                movie = true;
            }catch (Exception){
                movie = false;
            }

            try
            {
                books[foundon[bookchoice-1]-1].GetSystem();
                videogame = true;
            }catch (Exception){
                videogame = false;
            }
            
            if (book == true)
            {
                filepath = $"{u.GetUserName()}books.txt";
                string name = books[foundon[bookchoice-1]-1].GetName();
                string author = books[foundon[bookchoice-1]-1].GetAuthor();
                string genre = books[foundon[bookchoice-1]-1].GetGenre();
                string type = books[foundon[bookchoice-1]-1].GetBookType();
                int quantity = books[foundon[bookchoice-1]-1].GetQuantity();
                if (quantity == 0){
                    Console.WriteLine("This Book is Out of Stock");
                    return;
                }
                string texttoappend = $"{name},{author},{genre},{type},1";
                if (File.ReadAllText(filepath).Contains(texttoappend))
                {
                    Console.WriteLine("You have already Borrowed this book");
                    return;
                }
                File.AppendAllText(filepath, texttoappend + Environment.NewLine);
            }else if (magazine == true){
                filepath = $"{u.GetUserName()}books.txt";
                string name = books[foundon[bookchoice-1]-1].GetName();
                string author = books[foundon[bookchoice-1]-1].GetAuthor();
                string publishdate = books[foundon[bookchoice-1]-1].GetPublishDate();
                string type = books[foundon[bookchoice-1]-1].GetBookType();
                int quantity = books[foundon[bookchoice-1]-1].GetQuantity();
                if (quantity == 0){
                    Console.WriteLine("This Book is Out of Stock");
                    return;
                }
                string texttoappend = $"{name},{author},{publishdate},{type},1";
                if (File.ReadAllText(filepath).Contains(texttoappend))
                {
                    Console.WriteLine("You have already Borrowed this book");
                    return;
                }
                File.AppendAllText(filepath, texttoappend + Environment.NewLine);
            }else if (comicbook == true){
                filepath = $"{u.GetUserName()}books.txt";
                string name = books[foundon[bookchoice-1]-1].GetName();
                string author = books[foundon[bookchoice-1]-1].GetAuthor();
                string volume = books[foundon[bookchoice-1]-1].GetVolume();
                int booknumber = books[foundon[bookchoice-1]-1].GetBookNumber();
                string type = books[foundon[bookchoice-1]-1].GetBookType();
                int quantity = books[foundon[bookchoice-1]-1].GetQuantity();
                if (quantity == 0){
                    Console.WriteLine("This Book is Out of Stock");
                    return;
                }
                string texttoappend = $"{name},{author},{volume},{booknumber},{type},{quantity}";
                if (File.ReadAllText(filepath).Contains(texttoappend))
                {
                    Console.WriteLine("You have already Borrowed this book");
                    Console.WriteLine();
                    return;
                }
                File.AppendAllText(filepath, texttoappend + Environment.NewLine);
            }else if (movie == true){
                filepath = $"{u.GetUserName()}books.txt";
                string name = books[foundon[bookchoice-1]-1].GetName();
                string author = books[foundon[bookchoice-1]-1].GetAuthor();
                string genre = books[foundon[bookchoice-1]-1].GetGenre();
                string rating = books[foundon[bookchoice-1]-1].GetRating();
                string type = books[foundon[bookchoice-1]-1].GetBookType();
                int quantity = books[foundon[bookchoice-1]-1].GetQuantity();
                if (quantity == 0){
                    Console.WriteLine("This Book is Out of Stock");
                    return;
                }
                string texttoappend = $"{name},{author},{genre},{rating},{type},{quantity}";
                if (File.ReadAllText(filepath).Contains(texttoappend))
                {
                    Console.WriteLine("You have already Borrowed this book");
                    Console.WriteLine();
                    return;
                }
                File.AppendAllText(filepath, texttoappend + Environment.NewLine);
            }else if (videogame == true){
                filepath = $"{u.GetUserName()}books.txt";
                string name = books[foundon[bookchoice-1]-1].GetName();
                string author = books[foundon[bookchoice-1]-1].GetAuthor();
                string system = books[foundon[bookchoice-1]-1].GetSystem();
                string type = books[foundon[bookchoice-1]-1].GetBookType();
                int quantity = books[foundon[bookchoice-1]-1].GetQuantity();
                if (quantity == 0){
                    Console.WriteLine("This Book is Out of Stock");
                    return;
                }
                string texttoappend = $"{name},{author},{system},{type},1";
                if (File.ReadAllText(filepath).Contains(texttoappend))
                {
                    Console.WriteLine("You have already Borrowed this book");
                    return;
                }
                File.AppendAllText(filepath, texttoappend + Environment.NewLine);
            }else{
                Console.WriteLine("An Error has occured");
            }
            

        }
    }
    //End of Borrow Book Menu

    public void BookMenu(User u)
    {
        //Start of Library Menu
        Console.WriteLine("Please Select an option from the menu using the associated number:");
        Console.WriteLine("1.) Check Out A Book\n2.) Return Book\n3.) Donate Book");
        int choice;
        bool valid = int.TryParse(Console.ReadLine(), out choice);
        while (valid == false || choice > 3 || choice < 0)
        {
            Console.WriteLine("Please Select an option from the menu using the associated number:");
            Console.WriteLine("1.) Check Out A Book\n2.) Return Book\n3.) Donate Book");
            valid = int.TryParse(Console.ReadLine(), out choice);
        }

        if (choice == 1)
        {
            BorrowBook(u);

        }else if (choice == 2)
        {
            ReturnBook(u);
        }else if (choice == 3)
        {
            Console.WriteLine("What type of Book are you Donating?");
            Console.WriteLine("1.) Book\n2.) Magazine\n3.) Comic Book\n4.) Movie\n5.) Video Game");
            int booktype;
            bool testchoice = int.TryParse(Console.ReadLine(), out booktype);
            while (testchoice == false || booktype > 5 || booktype < 0)
            {
                Console.WriteLine("What type of Book are you Donating?");
                Console.WriteLine("1.) Book\n2.) Magazine\n3.) Comic Book\n4.) Movie\n5.) Video Game");
                testchoice = int.TryParse(Console.ReadLine(), out booktype);
            }

            if (booktype == 1)
            {   
                Book b = new Book();
                Console.Write("What is the title of the Book: ");
                string title = Console.ReadLine();
                b.SetName(title);

                Console.Write("Who is the author of the Book: ");
                string author = Console.ReadLine();
                b.SetAuthor(author);

                Console.Write("What is the genre of the Book: ");
                string genre = Console.ReadLine();
                b.SetGenre(genre);

                Console.Write("How many Books are you Donating: ");
                int quantity;
                bool testquant = int.TryParse(Console.ReadLine(), out quantity);
                while (testquant == false)
                {
                    Console.Write("How many Books are you Donating: ");
                    testquant = int.TryParse(Console.ReadLine(), out quantity);
                }
                b.SetQuantity(quantity);

                Console.WriteLine("You Donated the Book:");
                b.Display();
                b.AddToFile();
            }else if (booktype == 2)
            {
                Magazine m = new Magazine();
                Console.Write("What is the title of the Magazine: ");
                string title = Console.ReadLine();
                m.SetName(title);

                Console.Write("Who is the author of the Magazine: ");
                string author = Console.ReadLine();
                m.SetAuthor(author);

                Console.Write("What Year was the Magazine made: ");
                int year;
                bool testyear = int.TryParse(Console.ReadLine(), out year);
                while (testyear == false || year < 1800 || year > 2024)
                {
                    Console.Write("What Year was the Magazine: ");
                    testyear = int.TryParse(Console.ReadLine(), out year);
                }

                Console.Write("What month was the Magazine made:");
                int month;
                bool testmonth = int.TryParse(Console.ReadLine(), out month);
                while (testmonth == false || month < 1 || month > 12)
                {
                    Console.Write("What month was the Magazine made:");
                    testmonth = int.TryParse(Console.ReadLine(), out month);
                }

                Console.Write("What day was the Magazine made:");
                int day;
                bool testday = int.TryParse(Console.ReadLine(), out day);
                while (testmonth == false || day < 1 || day > 31)
                {
                    Console.Write("What day was the Magazine made:");
                    testmonth = int.TryParse(Console.ReadLine(), out day);
                }

                string date = $"{day}/{month}/{year}";
                m.SetPublishDate(date);

                Console.Write("How many Books are you Donating: ");
                int quantity;
                bool testquant = int.TryParse(Console.ReadLine(), out quantity);
                while (testquant == false)
                {
                    Console.Write("How many Books are you Donating: ");
                    testquant = int.TryParse(Console.ReadLine(), out quantity);
                }
                m.SetQuantity(quantity);

                Console.WriteLine("You Donated the Magazine:");
                m.Display();
                m.AddToFile();
            }else if (booktype == 3)
            {
                ComicBook cb = new ComicBook();
                Console.Write("What is the title of the Book: ");
                string title = Console.ReadLine();
                cb.SetName(title);

                Console.Write("Who is the author of the Book: ");
                string author = Console.ReadLine();
                cb.SetAuthor(author);

                Console.Write("What is the volume number: ");
                int volume;
                bool testvolume = int.TryParse(Console.ReadLine(), out volume);
                while (testvolume == false || volume < 1)
                {
                    Console.Write("What is the volume number: ");
                    testvolume = int.TryParse(Console.ReadLine(), out volume);
                }
                cb.SetVolume(volume.ToString());

                Console.Write("What is the issue number: ");
                int issue;
                bool testissue = int.TryParse(Console.ReadLine(), out issue);
                while (testissue == false || volume < 1)
                {
                    Console.Write("What is the issue number: ");
                    testissue = int.TryParse(Console.ReadLine(), out issue);
                }
                cb.SetBookNumber(issue);

                Console.Write("How many Books are you Donating: ");
                int quantity;
                bool testquant = int.TryParse(Console.ReadLine(), out quantity);
                while (testquant == false)
                {
                    Console.Write("How many Books are you Donating: ");
                    testquant = int.TryParse(Console.ReadLine(), out quantity);
                }
                cb.SetQuantity(quantity);

                Console.WriteLine("You Donated the Comic Book:");
                cb.Display();
                cb.AddToFile();
            }else if (booktype == 4)
            {
                Movie m = new Movie();
                Console.Write("What is the title of the Movie: ");
                string title = Console.ReadLine();
                m.SetName(title);

                Console.Write("Who is the Director of the Movie: ");
                string author = Console.ReadLine();
                m.SetAuthor(author);

                Console.Write("What is the genre of the Book: ");
                string genre = Console.ReadLine();
                m.SetGenre(genre);

                Console.Write("Out of 10, rate this movie: ");
                int num;
                bool testnum = int.TryParse(Console.ReadLine(), out num);
                while (testnum == false || num < 1 || num > 10){
                    Console.Write("Out of 10, rate this movie: ");
                    testnum = int.TryParse(Console.ReadLine(), out num);
                }
                m.SetRating(num.ToString());


                Console.Write("How many copies are you Donating: ");
                int quantity;
                bool testquant = int.TryParse(Console.ReadLine(), out quantity);
                while (testquant == false)
                {
                    Console.Write("How many copies are you Donating: ");
                    testquant = int.TryParse(Console.ReadLine(), out quantity);
                }
                m.SetQuantity(quantity);

                Console.WriteLine("You Donated the Movie:");
                m.Display();
                m.AddToFile();

                Console.WriteLine("This is the end of Movie Creation");
            }else if (booktype == 5)
            {
                VideoGame vg = new VideoGame();
                Console.Write("What is the title of the Video Game: ");
                string title = Console.ReadLine();
                vg.SetName(title);

                Console.Write("Who is the publisher of the Video Game: ");
                string author = Console.ReadLine();
                vg.SetAuthor(author);

                Console.Write("What system is the Video Game for: ");
                string system = Console.ReadLine();
                vg.SetSystem(system);

                Console.Write("How many copies are you Donating: ");
                int quantity;
                bool testquant = int.TryParse(Console.ReadLine(), out quantity);
                while (testquant == false)
                {
                    Console.Write("How many copies are you Donating: ");
                    testquant = int.TryParse(Console.ReadLine(), out quantity);
                }
                vg.SetQuantity(quantity);

                Console.WriteLine("You Donated the Video Game:");
                vg.Display();
                vg.AddToFile();
            }
        }
    }
}