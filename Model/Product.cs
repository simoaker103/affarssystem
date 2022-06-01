namespace DVGB07_lab4.Model
{
    class Product
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public string Id { get; set; }
        public int Quantity { get; set; }
        public string Type { get; set; }

        public Item ProductToItem()
        {
            Item item = new Item();
            item.Type = Type;
            item.Name = Name;
            item.Price = Price;
            item.Id = Id;

            return item;
        }

    }

}