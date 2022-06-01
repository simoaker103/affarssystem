namespace DVGB07_lab4.Model
{
    class Movie : Product
    {
        public string Format { get; set; }
        public string RunTime { get; set; }

        public Movie(string name, int price, string id, int quantity, string format = "", string runTime = "")
        {
            base.Type = "Movie";
            base.Name = name;
            base.Price = price;
            base.Id = id;
            base.Quantity = quantity;
            Format = format;
            RunTime = runTime;
        }

        public override string ToString()
        {
            return $"{Type},{Name},{Price},{Id},{Quantity},{Format},{RunTime}";
        }
    }
}
