using System;

namespace DVGB07_lab4.Model
{

    class Item
    {
        public string Type { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public string Id { get; set; }

        public override string ToString()
        {
            return Name + " (" + Id + ")";
        }
        public Purchase ItemToPurchase()
        {
            Purchase p = new Purchase(Type, Name, Price, Id, DateTime.Now.ToString());
            return p;
        }
        

    }

}
