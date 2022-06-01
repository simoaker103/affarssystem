namespace DVGB07_lab4.Model
{
    class Game : Product
    {
        public string Platform { get; set; }

        public Game(string name, int price, string id, int quantity, string platform = "")
        {
            base.Type = "Game";
            base.Name = name;
            base.Price = price;
            base.Id = id;
            base.Quantity = quantity;
            Platform = platform;
        }

        public override string ToString()
        {
            return $"{Type},{Name},{Price},{Id},{Quantity},{Platform}";
        }
    }
}
