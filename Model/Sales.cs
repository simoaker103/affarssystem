using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace DVGB07_lab4.Model
{
    class Sales
    {
        public List<Purchase> SalesList { get; }

        public Sales()
        {
            SalesList = new List<Purchase>();
        }

        public void SaveToFile()
        {
            //https://docs.microsoft.com/en-us/dotnet/api/system.io.streamwriter?view=net-6.0

            using (StreamWriter sw = new StreamWriter("sales.csv"))
            {
                foreach (var item in SalesList)
                {
                    sw.WriteLine(item);
                }
            }
        }

        public void LoadFromFile()
        {

            //https://docs.microsoft.com/en-us/dotnet/api/system.io.streamwriter?view=net-6.0

            string line = "";
            try
            {
                using (StreamReader sr = new StreamReader("sales.csv"))
                {
                    while ((line = sr.ReadLine()) != null)
                    {
                        string[] data = line.Split(',');
                        SalesList.Add(new Purchase(data[0], data[1], int.Parse(data[2]), data[3], data[4]));
                    }
                }
            }
            catch (FileNotFoundException e)
            {
                Console.Write(e.StackTrace);
            }

            

            
        }

        public List<(string, int)> GetTopSales(string year, string month)
        {
            if (year == "")
                year = DateTime.Now.Year.ToString();

            List<Purchase> listFiltered = new List<Purchase>();

            // Filtrerar på månad / år

            foreach (var item in SalesList)
            {
                if (item.Date.Contains(year) && item.Date.Contains(month + "-"))
                    listFiltered.Add(item);
            }

            // Lägger in en av varje produkt i en ny lista

            List<string> listToCompare = new List<string>();
            foreach (var item in listFiltered)
            {
                if(!listToCompare.Any(p => p == item.Id))
                {
                    listToCompare.Add(item.Id);
                }
            }

            // Räknar hur många produkter det finns av varje
            // och lägger in resultatet i topSalesList

            List<(string, int)> topSalesList = new List<(string, int)>();
            foreach (var item in listToCompare)
            {
                int i = listFiltered.Count(p => p.Id == item);
                topSalesList.Add((listFiltered.Find(p => p.Id == item).Name, i));
            }

            // https://zetcode.com/csharp/sortlist/

            // Sorterar listan
            topSalesList.Sort((e1, e2) =>
            {
                return e2.Item2.CompareTo(e1.Item2);
            });
            
            return topSalesList;
        }

        
        public List<string> GetTotalSales(string year, string month)
        {

            List<Purchase> listFiltered = new List<Purchase>();
            List<string> totalSales = new List<string>();

            // Filtrerar på månad / år

            foreach (var item in SalesList)
            {
                if (item.Date.Contains(year) && item.Date.Contains(month + "-"))
                    listFiltered.Add(item);
            }

            foreach (var item in listFiltered)
            {
                totalSales.Add(item.ToString());
            }

            return totalSales;

        }

        public bool CheckSoldItems(int i, string si)
        {
            foreach (var item in SalesList)
            {
                var list = SalesList.Where(p => p.Id == si);
                if (i <= list.Count())
                    return true;
                else
                    return false;

            }
            return false;
        }

        public void RemoveFromSalesList(int nr, string si)
        {
            int i = 1;
            foreach (var item in SalesList.Where(p => p.Id == si).ToList())
            {
                SalesList.Remove(item);
                if (nr == i)
                    break;
                
                i++;
            }
        }
    }
}
