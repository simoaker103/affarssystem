using System.Collections.Generic;

namespace DVGB07_lab4.Model
{
    class Receipt
    {
        public string Name { get; }
        public string Address { get; }
        public string Phone { get; }
        public List<Purchase> PurchasedItems { get; }

        public Receipt()
        {
            Name = "Shop";
            Address = "Karlavägen 12";
            Phone = "031-165 46 45";
            PurchasedItems = new List<Purchase>();
        }

        public void AddToReceiptList(Purchase p)
        {
            PurchasedItems.Add(p);
        }
    }
}
