using DVGB07_lab4.Model;
using System;
using System.Collections.Generic;

namespace DVGB07_lab4
{
    class Controller
    {

        View view;
        Stock stock;
        Cart cart;
        Sales sales;

        public Controller(View view)
        {
            stock = new Stock();
            sales = new Sales();
            cart = new Cart(stock, sales);
            this.view = view;
        }

        public void AddBookClicked(string[] s, string type)
        {
            stock.AddProductToList(s, type);
            stock.SetProductList(view.GetSelectedProductTab());           
        }

        public void AddMovieClicked(string[] s, string type)
        {
            stock.AddProductToList(s, type);
            stock.SetProductList(view.GetSelectedProductTab());
        }

        public void AddGameClicked(string[] s, string type)
        {
            stock.AddProductToList(s, type);
            stock.SetProductList(view.GetSelectedProductTab());
        }

        public void RemoveClicked()
        {
            var sr = view.GetSelectedStockRows();
            if (!stock.CheckStockStatus(sr))
                return;

            if (view.ShowRemoveDialog())
            {
                stock.UpdateQuantity(sr, -1);
            }
               
        }

        public void FormLoaded()
        {
            sales.LoadFromFile();
            stock.LoadFromFile();
            stock.SetProductList(view.GetSelectedProductTab());
            view.GetStockGridView().DataSource = stock.ProductListSource;

        }

        public bool CheckDuplicates(string s)
        {
            return stock.CheckDuplicates(s);
        }

        public bool PlaceOrderClicked(decimal v)
        {
            int i = decimal.ToInt32(v);
            if (i < 1)
                return false;
            stock.UpdateQuantity(view.GetSelectedStockRows(), i);
            return true;
        }

        public void CheckoutComboChanged()
        {
            stock.SetProductList(view.GetSelectedComboItem());
            view.GetCheckoutGridView().DataSource = stock.ProductListSource;
        }

        public void MainTabChanged(string s)
        {

            stock.LoadDataFromWebClient();

            if (s == "Stock")
                stock.SetProductList(view.GetSelectedProductTab());

            if (s == "Checkout")
                stock.SetProductList(view.GetSelectedComboItem());
        }

        public void ProductTabChanged()
        {
            stock.SetProductList(view.GetSelectedProductTab());
        }

        public bool AddToCartClicked()
        {
            var sr = view.GetSelectedCheckoutRows();
            Product p = (Product)sr[0].DataBoundItem;

            if (p.Quantity < 1)
                return false;

            Item i = p.ProductToItem();
            cart.CartList.Add(i);

            List<string> s = cart.ItemListToString();
            view.UpdateCartList(s);
            stock.UpdateQuantity(sr, -1);

            return true;
        }

        public void RemoveFromCartClicked(string s)
        {
            string id = s.Split('(', ')')[1];
            cart.RemoveFromCart(id);
            List<string> list = cart.ItemListToString();
            view.UpdateCartList(list);
        }

        public bool EmptyCartClicked(int i)
        {
            if (i < 1)
                return false;

            cart.EmptyCart();
            return true; 
        }

        public string[] ProductIdChanged(int i, string si)
        {
            string[] sa = stock.CheckProductRegister(i, si);

            return sa;
        }

        public bool ReturnClicked(int i, string si)
        {
            if(!sales.CheckSoldItems(i, si))
                return false;

            stock.ReturnProducts(i, si);
            sales.RemoveFromSalesList(i, si);

            return true;
        }

        public bool BuyClicked(int i)
        {
            if (i < 1)
                return false;

            Receipt r = cart.GenerateReceipt();
            view.DisplayReceipt(r);

            stock.SaveDataToWebClient();

            stock.LoadDataFromWebClient();
            stock.SetProductList(view.GetSelectedComboItem());

            return true;
        }

        public void FormClosing()
        {
            stock.SaveToFile();
            sales.SaveToFile();
        }

        public List<string> TotalSalesClicked(string y, string m)
        {
            switch (m)
            {
                case "January":
                    m = "01";
                    break;
                case "February":
                    m = "02";
                    break;
                case "March":
                    m = "03";
                    break;
                case "April":
                    m = "04";
                    break;
                case "May":
                    m = "05";
                    break;
                case "June":
                    m = "06";
                    break;
                case "July":
                    m = "07";
                    break;
                case "August":
                    m = "08";
                    break;
                case "September":
                    m = "09";
                    break;
                case "October":
                    m = "10";
                    break;
                case "November":
                    m = "11";
                    break;
                case "December":
                    m = "12";
                    break;
                default:
                    break;
            }
            List<string> list = sales.GetTotalSales(y, m);

            return list;
        }

        public List<(string, int)> TopTenClicked(string y, string m)
        {
            switch (m)
            {
                case "January":
                    m = "01";
                    break;
                case "February":
                    m = "02";
                    break;
                case "March":
                    m = "03";
                    break;
                case "April":
                    m = "04";
                    break;
                case "May":
                    m = "05";
                    break;
                case "June":
                    m = "06";
                    break;
                case "July":
                    m = "07";
                    break;
                case "August":
                    m = "08";
                    break;
                case "September":
                    m = "09";
                    break;
                case "October":
                    m = "10";
                    break;
                case "November":
                    m = "11";
                    break;
                case "December":
                    m = "12";
                    break;
                default:
                    break;
            }
            List<(string, int)> list = sales.GetTopSales(y, m);

            return list;
        }

        public void SearchTextChanged(string s)
        {
            stock.SearchProduct(s, view.GetSelectedComboItem());
        }

        public void updateClicked()
        {
            if (stock.LoadDataFromWebClient())
                stock.SetProductList(view.GetSelectedProductTab());
            else
                view.showSyncErrorDialog();
        }

        public void syncClicked()
        {
            stock.SaveDataToWebClient();
        }
    }
}
