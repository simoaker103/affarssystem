using System.Collections.Generic;
using System.Windows.Forms;

namespace DVGB07_lab4
{
    public partial class TotalSalesDialog : Form
    {
        List<string> list;
        public TotalSalesDialog(List<string> list, string m, string y)
        {
            InitializeComponent();

            this.list = list;

            foreach (var item in list)
            {
                TotalListBox.Items.Add(item);
            }

            MonthLabel.Text = m;
            YearLabel.Text = y + ",";
            TotalLabel.Text = list.Count.ToString();
        }

    }
}
