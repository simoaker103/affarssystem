using System;
using System.Collections.Generic;
using System.Linq;

namespace DVGB07_lab4.Model
{
    class Cart
    {
        public List<Item> CartList { get; }

        private Stock stock;
        private Sales sales;

        public Cart(Stock stock, Sales sales)
        {
            CartList = new List<Item>();
            this.stock = stock;
            this.sales = sales;
        }

        /*
        public static Cart Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Cart();
                }
                return instance;
            }
        }
        */

        public void EmptyCart()
        {
            foreach (Item item in CartList)
            {
                foreach (var item2 in stock.ProductList)
                {
                    if (item.Id == item2.Id)
                    {
                        item2.Quantity++;
                    }
                }
            }
            CartList.Clear();
            stock.ProductListSource.ResetBindings(false);
        }

        public void RemoveFromCart(string id)
        {
            for (int i = 0; i < CartList.Count; i++)
            {
                if(CartList[i].Id == id)
                {
                    CartList.Remove(CartList[i]);

                    foreach (Product item2 in stock.ProductList.Where(p => p.Id == id))
                    {
                        item2.Quantity++;
                        stock.ProductListSource.ResetBindings(false);
                        return;
                    }
                }
            }
        }

        public Receipt GenerateReceipt()
        {
            Receipt r = new Receipt();

            foreach (Item item in CartList)
            {
                Purchase purchase = item.ItemToPurchase();
                sales.SalesList.Add(purchase);
                r.AddToReceiptList(purchase);

            }

            CartList.Clear();

            return r;
        }

        public List<string> ItemListToString()
        {
            List<string> list = new List<string>();
            foreach (var item in CartList)
            {
                list.Add(item.ToString());
            }
            return list;
        }
    }
}
