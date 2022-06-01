using System;
using System.Windows.Forms;

namespace DVGB07_lab4
{
    partial class ReturnProductForm : Form
    {
        Controller c;
        View view;

        public ReturnProductForm(Controller c, View view)
        {
            InitializeComponent();
            this.c = c;
            this.view = view;
        }

        private void ProductId_TextChanged(object sender, EventArgs e)
        {
            int i = ProductId.Text.Length;
            string si = ProductId.Text;

            string[] s = c.ProductIdChanged(i, si);
            if (s[0] != null)
            {
                CategoryText.Text = s[0];
                NameText.Text = s[1];
            }
            else
            {
                CategoryText.ResetText();
                NameText.ResetText();
            }

            if (NameText.Text != "" && decimal.ToInt32(ReturnNumUpDown.Value) != 0)
                ReturnButton.Enabled = true;
            else
                ReturnButton.Enabled = false;

        }

        private void ReturnNumUpDown_ValueChanged(object sender, EventArgs e)
        {
            if(NameText.Text != "" && decimal.ToInt32(ReturnNumUpDown.Value) != 0)
                ReturnButton.Enabled = true;
            else
                ReturnButton.Enabled = false;
        }

        private void ReturnButton_Click(object sender, EventArgs e)
        {
            string si = ProductId.Text;
            int i = decimal.ToInt32(ReturnNumUpDown.Value);

            if (!c.ReturnClicked(i, si))
                view.ShowReturnDialog("Not in sales register.");
            else
                view.ShowReturnDialog("Item(s) returned!");
        }
    }
}
