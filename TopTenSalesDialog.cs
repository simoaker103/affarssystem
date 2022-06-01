using System.Collections.Generic;
using System.Windows.Forms;

namespace DVGB07_lab4
{
    public partial class TopTenSalesDialog : Form
    {

        public TopTenSalesDialog(List<(string, int)> l)
        {
            InitializeComponent();
            var list = l;

            TopTenTextBox.Text = "";

            for (int i = 0; i < list.Count; i++)
            {
                TopTenTextBox.Text += $"{i + 1}. {list[i].Item1} ({list[i].Item2.ToString()})\n";
                
                if (i == 9)
                    break;
            }
            
        }
    }
}
