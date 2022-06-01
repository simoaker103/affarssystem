namespace DVGB07_lab4.Model
{
    public class Purchase
    {
        public string Type { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public string Id { get; set; }
        public string Date{ get; set; }

        public Purchase(string type, string name, int price, string id, string date)
        {
            Type = type;
            Name = name;
            Price = price;
            Id = id;
            Date = date;
        }

        public override string ToString()
        {
            return $"{Type},{Name},{Price},{Id},{Date}";
        }
    }
}