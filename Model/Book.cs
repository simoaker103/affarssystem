namespace DVGB07_lab4.Model
{
    class Book : Product
    {

        public string Author { get; set; }
        public string Genre { get; set; }
        public string Format { get; set; }
        public string Language { get; set; }

        public Book(string name, int price, string id, int quantity, string author = "", string genre = "", string format = "", string language = "")
        {
            base.Type = "Book";
            base.Name = name;
            base.Price = price;
            base.Id = id;
            base.Quantity = quantity;
            Author = author;
            Genre = genre;
            Format = format;
            Language = language;
        }

        public override string ToString()
        {
            return $"{Type},{Name},{Price},{Id},{Quantity},{Author},{Genre},{Format},{Language}";
        }
    }
}
