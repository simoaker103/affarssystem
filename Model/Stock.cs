using System;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Windows.Forms;
using System.Xml;

namespace DVGB07_lab4.Model
{
    class Stock
    {

        public BindingList<Product> ProductList { get; }
        public BindingSource ProductListSource { get; }

        private BindingList<Book> bookList;
        private BindingList<Movie> movieList;
        private BindingList<Game> gameList;
        
        public Stock()
        {
            bookList = new BindingList<Book>();
            movieList = new BindingList<Movie>();
            gameList = new BindingList<Game>();
            ProductListSource = new BindingSource();
            ProductList = new BindingList<Product>();
            /*
            {
                
                new Movie("Nyckeln till frihet", 99, "2-456", "DVD", 142),
                new Movie("Gudfadern", 99, "2-456", "DVD", 152),
                new Movie("Konungens återkomst", 199, "2-456", "Blu-Ray", 154),
                new Movie("Pulp fiction", 199, "2-456", "Blu-Ray"),
                new Movie("Schindlers list", 99, "2-456", "DVD"),

                new Book("Bello Gallico et Civili", 449, "1-654", "Julius Ceasar", "Historia", "Inbunden", "Latin"),
                new Book("How to Read a Book", 149, "1-325", "Mortimer J. Adler", "Kursliteratur", "Pocket"),
                new Book("Moby Dick", 49, "1-485", "Herman Melville", "Äventyr", "Pocket"),
                new Book("Great Gatsby", 79, "1-653", "F. Scott Fitzgerald", "Noir", "E-Bok"),
                new Book("House of Leaves", 49, "1-784", "Mark Z. Danielewski", "Skräck"),

                new Game("Elden Ring", 599, "3-654", "Playstation 5"),
                new Game("Demon's Souls", 499, "3-325", "Playstation 5"),
                new Game("Microsoft Flight Simulator", 499, "3-485", "PC"),
                new Game("Planescape Torment", 99, "3-653", "PC"),
                new Game("Disco Elysium", 399, "3-784", "PC")
            };
            */
            
        }

        public bool CheckStockStatus(DataGridViewSelectedRowCollection selectedRows)
        {
            foreach (DataGridViewRow item in selectedRows)
            {
                var p = (Product)item.DataBoundItem;
                if (p.Quantity < 1)
                    return false;
            }
            return true;
        }

        public void SaveToFile()
        {

            //https://docs.microsoft.com/en-us/dotnet/api/system.io.streamwriter?view=net-6.0

            using (StreamWriter sw = new StreamWriter("data.csv"))
            {
                foreach (var item in ProductList)
                {
                    if (item.Type == "Movie")
                        sw.WriteLine((Movie)item);

                    if (item.Type == "Book")
                        sw.WriteLine((Book)item);

                    if (item.Type == "Game")
                        sw.WriteLine((Game)item);
                }
            }
        }

        public void LoadFromFile()
        {

            //https://docs.microsoft.com/en-us/dotnet/api/system.io.streamwriter?view=net-6.0

            string line = "";
            try
            {
                using (StreamReader sr = new StreamReader("data.csv"))
                {
                    while ((line = sr.ReadLine()) != null)
                    {
                        string[] data = line.Split(',');

                        if (data[0] == "Book")
                            ProductList.Add(new Book(data[1], int.Parse(data[2]), data[3], int.Parse(data[4]), data[5], data[6], data[7], data[8]));

                        if (data[0] == "Movie")
                            ProductList.Add(new Movie(data[1], int.Parse(data[2]), data[3], int.Parse(data[4]), data[5], data[6]));

                        if (data[0] == "Game")
                            ProductList.Add(new Game(data[1], int.Parse(data[2]), data[3], int.Parse(data[4]), data[5]));
                    }
                }
            }
            catch(FileNotFoundException e)
            {
                Console.Write(e.StackTrace);
            }
            
        }

        public void SetProductList(string pCategory)
        {

            if (pCategory == "All")
            {
                ProductListSource.DataSource = ProductList;
            }

            if (pCategory == "Games")
            {
                gameList.Clear();
                foreach (var item in ProductList)
                {
                    if (item.Type == "Game")
                    {
                        gameList.Add((Game)item);
                    }
                }

                ProductListSource.DataSource = gameList;
            }

            if (pCategory == "Movies")
            {
                movieList.Clear();
                foreach (var item in ProductList)
                {
                    if (item.Type == "Movie")
                    {
                        movieList.Add((Movie)item);
                    }
                }

                ProductListSource.DataSource = movieList;
            }

            if (pCategory == "Books")
            {
                bookList.Clear();
                foreach (var item in ProductList)
                {
                    if (item.Type == "Book")
                    {
                        bookList.Add((Book)item);
                    }
                }
                ProductListSource.DataSource = bookList;
            }

        }

        public string[] CheckProductRegister(int i, string si)
        {
            string[] s = new string[2];

            foreach (Product item in ProductList.Where(p => p.Id == si))
            {
                s[0] = item.Type;
                s[1] = item.Name;
            }
               
            return s;

        }

        public void ReturnProducts(int i, string si)
        {
            foreach (Product item in ProductList.Where(p => p.Id == si))
            {
                item.Quantity += i;
            }
            ProductListSource.ResetBindings(false);
        }

        public void AddProductToList(string[] s, string type)
        {
            string name, id, author, genre, format, lang, runTime, platform;
            int price;

            name = s[0];
            price = int.Parse(s[1]);

            if(type == "Book")
            {
                id = s[2];
                author = s[3];
                genre = s[4];
                format = s[5];
                lang = s[6];

                Book book = new Book(name, price, id, 1, author, genre, format, lang);
                ProductList.Add(book);
            }

            if(type == "Movie")
            {
                id = s[2];
                format = s[3];
                runTime = s[4] == "0" ? "" : s[4] + " min";

                Movie movie = new Movie(name, price, id, 1, format, runTime);
                ProductList.Add(movie);
            }
            
            if(type == "Game")
            {
                id = s[2];
                platform = s[3];

                Game game = new Game(name, price, id, 1, platform);
                ProductList.Add(game);
            }
        }

        public bool CheckDuplicates(string id)
        {
            foreach (var item in ProductList)
            {                
                if(item.Id == id)
                {
                    return false;
                }
            }
            return true;
        }

        public void UpdateQuantity(DataGridViewSelectedRowCollection selectedRows, int nrOfItems)
        {
            foreach (DataGridViewRow item in selectedRows)
            {
                var p = (Product)item.DataBoundItem;
                p.Quantity += nrOfItems;
            }
            ProductListSource.ResetBindings(false);
        }

        public void SearchProduct(string s, string pCategory)
        {
            string s1 = s.ToLower();
            foreach (var item in ProductList)
            {
                if (pCategory == "All")
                {
                    var list = ProductList.Where(p => p.Name.ToLower().StartsWith(s1)).ToList();
                    ProductListSource.DataSource = list;
                }

                if (pCategory == "Books")
                {
                    var list = bookList.Where(p => p.Name.ToLower().StartsWith(s1));
                    ProductListSource.DataSource = list;
                }

                if (pCategory == "Games")
                {
                    var list = gameList.Where(p => p.Name.ToLower().StartsWith(s1));
                    ProductListSource.DataSource = list;
                }

                if (pCategory == "Movies")
                {
                    var list = movieList.Where(p => p.Name.ToLower().StartsWith(s1));
                    ProductListSource.DataSource = list;
                }
            }
        }

        public bool LoadDataFromWebClient()
        {
            WebClient client = new WebClient();
            var text = client.DownloadString("https://hex.cse.kau.se/~jonavest/csharp-api/");
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(text);

            if (doc.FirstChild.FirstChild.OuterXml.Contains("error"))
                return false;
                
            XmlNodeList booksList = doc.GetElementsByTagName("book");
            XmlNodeList gamesList = doc.GetElementsByTagName("game");
            XmlNodeList moviesList = doc.GetElementsByTagName("movie");

            foreach (XmlNode book in booksList)
            {
                string id = book.SelectSingleNode("id").InnerText;
                string name = book.SelectSingleNode("name").InnerText;
                int price = int.Parse(book.SelectSingleNode("price").InnerText);
                int quantity = int.Parse(book.SelectSingleNode("stock").InnerText);
                string genre = book.SelectSingleNode("genre") == null ? "" : book.SelectSingleNode("genre").InnerText;
                string author = book.SelectSingleNode("author") == null ? "" : book.SelectSingleNode("author").InnerText;
                string format = book.SelectSingleNode("format") == null ? "" : book.SelectSingleNode("format").InnerText;
                string language = book.SelectSingleNode("language") == null ? "" : book.SelectSingleNode("language").InnerText;

                var list = ProductList.Where(p => p.Id == id);

                if(list.Count() == 1)
                {
                    Product p = list.First();
                    p.Price = price;
                    p.Quantity = quantity;
                }
                else
                {
                    ProductList.Add(new Book(name, price, id, quantity, author, genre, format, language));
                }
            }

            foreach (XmlNode game in gamesList)
            {
                string id = game.SelectSingleNode("id").InnerText;
                string name = game.SelectSingleNode("name").InnerText;
                int price = int.Parse(game.SelectSingleNode("price").InnerText);
                int quantity = int.Parse(game.SelectSingleNode("stock").InnerText);
                string platform = game.SelectSingleNode("platform") == null ? "" : game.SelectSingleNode("platform").InnerText;

                var list = ProductList.Where(p => p.Id == id);

                if (list.Count() == 1)
                {
                    Product p = list.First();
                    p.Price = price;
                    p.Quantity = quantity;
                }
                else
                {
                    ProductList.Add(new Game(name, price, id, quantity, platform));
                }
            }

            foreach (XmlNode movie in moviesList)
            {
                string id = movie.SelectSingleNode("id").InnerText;
                string name = movie.SelectSingleNode("name").InnerText;
                int price = int.Parse(movie.SelectSingleNode("price").InnerText);
                int quantity = int.Parse(movie.SelectSingleNode("stock").InnerText);
                string format = movie.SelectSingleNode("format") == null ? "" : movie.SelectSingleNode("format").InnerText;
                string runTime = movie.SelectSingleNode("playtime") == null ? "" : movie.SelectSingleNode("playtime").InnerText;

                var list = ProductList.Where(p => p.Id == id);

                if (list.Count() == 1)
                {
                    Product p = list.First();
                    p.Price = price;
                    p.Quantity = quantity;
                }
                else
                {
                    ProductList.Add(new Movie(name, price, id, quantity, format, runTime));
                }
            }

            //SaveDataToWebClient();
            return true;
        }

        public void SaveDataToWebClient()
        {
            foreach (var product in ProductList)
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create($"https://hex.cse.kau.se/~jonavest/csharp-api/?action=update&id={product.Id}&stock={product.Quantity}");
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                response.Close();
            }
        }
    }
}
