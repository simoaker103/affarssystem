using DVGB07_lab4.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace DVGB07_lab4
{
    partial class View : Form
    {
        Controller c;

        public View()
        {
            InitializeComponent();
            c = new Controller(this);
        }

        public void ShowReturnDialog(string message)
        {
            Form form = new ReturnProductDialog(message);
            form.ShowDialog(this);
        }

        public string GetSelectedProductTab()
        {
            return tabControl2.SelectedTab.Text;
        }

        public string GetSelectedComboItem()
        {
            return CheckoutComboBox.Text;
        }

        public DataGridViewSelectedRowCollection GetSelectedStockRows()
        {
            return StockGridView.SelectedRows;
        }

        public DataGridViewSelectedRowCollection GetSelectedCheckoutRows()
        {
            return CheckoutGridView.SelectedRows;
        }
        
        public DataGridView GetStockGridView()
        {
            return StockGridView;
        }

        public DataGridView GetCheckoutGridView()
        {
            return CheckoutGridView;
        }

        public void UpdateCartList(List<string> s)
        {
            CartListBox.Items.Clear();
            foreach (var item in s)
            {
                CartListBox.Items.Add(item);
            }
        }

        private bool CheckFormFields()
        {
            string tab = GetSelectedProductTab();

            errorProvider1.Clear();
            errorProvider2.Clear();
            errorProvider3.Clear();
            errorProvider4.Clear();

            TextBox nameText = tab == "Books" ? NameBookText : tab == "Games" ? NameGameText : NameMovieText;
            TextBox priceText = tab == "Books" ? PriceBookText : tab == "Games" ? PriceGameText : PriceMovieText;
            TextBox idText = tab == "Books" ? IdBookText : tab == "Games" ? IdGameText : IdMovieText;

            bool priceError = int.TryParse(priceText.Text, out int i) && i >= 0;
            bool idError = int.TryParse(idText.Text, out int i2) && i2 <= 999 && i2 >= 1 && c.CheckDuplicates(idText.Text);
            bool nameError = !nameText.Text.Any(char.IsDigit) && nameText.Text.Trim().Length > 0;
            bool authorError = true;

            if (tab == "Books")
                authorError = AuthorBookText.Text.Trim().Length >= 0 ? !AuthorBookText.Text.Any(char.IsDigit) : true;

            if (!priceError)
                errorProvider1.SetError(priceText, "Enter a positive integer");

            if (!idError)
                errorProvider2.SetError(idText, "Enter a unique ID between 1-999");

            if (!nameError)
                errorProvider3.SetError(nameText, "Enter a valid product name");

            if (!authorError)
                errorProvider4.SetError(AuthorBookText, "Enter a valid author name");

            if (priceError && idError && nameError && authorError)
                return true;
            else
                return false;
        }
        
        public void DisplayReturnDialog(Form form)
        {
            form.ShowDialog(this);
        }
        public bool ShowRemoveDialog()
        {
            Form rd = new RemoveProductDialog();
            rd.ShowDialog(this);
            return rd.DialogResult == DialogResult.Yes;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            c.FormLoaded();
            StockGridView.Columns["Type"].Visible = false;
            CheckoutComboBox.SelectedItem = "All";

            tabControl2_SelectedIndexChanged(sender, e);
        }

        private void PlaceOrderButton_Click(object sender, EventArgs e)
        {
            if (c.PlaceOrderClicked(PlaceOrderNumUpDown.Value))
                PlaceOrderNumUpDown.Value = 0;
        }

        private void tabControl2_SelectedIndexChanged(object sender, EventArgs e)
        {
            c.ProductTabChanged();
            StockGridView.Columns["Type"].Visible = false;
        }

        private void AddBookButton_Click(object sender, EventArgs e)
        {
            if (!CheckFormFields())
                return;

            string[] s = new string[7];
            s[0] = NameBookText.Text;
            s[1] = PriceBookText.Text;
            s[2] = IdBookText.Text;
            s[3] = AuthorBookText.Text;
            s[4] = GenreBookComboBox.Text;
            s[5] = FormatBookComboBox.Text;
            s[6] = LanguageBookComboBox.Text;

            c.AddBookClicked(s, "Book");
        }

        private void RemoveButton_Click(object sender, EventArgs e)
        {
            c.RemoveClicked();
        }

        private void AddMovieButton_Click(object sender, EventArgs e)
        {
            if (!CheckFormFields())
                return;

            string[] s = new string[5];
            s[0] = NameMovieText.Text;
            s[1] = PriceMovieText.Text;
            s[2] = IdMovieText.Text;
            s[3] = FormatMovieComboBox.Text;
            s[4] = RunTimeNumUpDown.Text;

            c.AddMovieClicked(s, "Movie");
        }

        private void AddGameButton_Click(object sender, EventArgs e)
        {
            if (!CheckFormFields())
                return;

            string[] s = new string[5];
            s[0] = NameGameText.Text;
            s[1] = PriceGameText.Text;
            s[2] = IdGameText.Text;
            s[3] = PlatformComboBox.Text;

            c.AddGameClicked(s, "Game");
        }

        private void CheckoutComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(SearchText.Text != "")
            {
                SearchText.Text = "";
            }

            c.CheckoutComboChanged();

            if (CheckoutComboBox.Text != "All")
                CheckoutGridView.Columns["Type"].Visible = false;
            else
                CheckoutGridView.Columns["Type"].Visible = true;
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            c.MainTabChanged(tabControl1.SelectedTab.Text);
        }

        private void StockGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            errorProvider1.Clear();
            errorProvider2.Clear();
            errorProvider3.Clear();
            errorProvider4.Clear();

            string tab = tabControl2.SelectedTab.Text;
            Product item = (Product)StockGridView.SelectedRows[0].DataBoundItem;

            if (StockGridView.SelectedRows.Count < 1)
                return;

            if (tab == "Books")
            {
                Book book = (Book)item;

                NameBookText.Text = book.Name;
                PriceBookText.Text = book.Price.ToString();
                IdBookText.Text = book.Id;
            }

            if (tab == "Movies")
            {
                Movie movie = (Movie)item;

                NameMovieText.Text = movie.Name;
                PriceMovieText.Text = movie.Price.ToString();
                IdMovieText.Text = movie.Id;
            }

            if (tab == "Games")
            {
                Game game = (Game)item;

                NameGameText.Text = game.Name;
                PriceGameText.Text = game.Price.ToString();
                IdGameText.Text = game.Id;
            }
        }

        public void showSyncErrorDialog()
        {
            var dialog = new SyncErrorDialog();
            dialog.ShowDialog(this);
        }

        private void AddToCartButton_Click(object sender, EventArgs e)
        {
            if (!c.AddToCartClicked())
                MessageBox.Show("Not availible");
        }

        private void EmptyCartButton_Click(object sender, EventArgs e)
        {
            int i = CartListBox.Items.Count;

            if (c.EmptyCartClicked(i) == true)
                CartListBox.Items.Clear();

        }

        private void RemoveFromCartButton_Click(object sender, EventArgs e)
        {
            if (CartListBox.SelectedItems.Count < 1)
                return;

            string s = CartListBox.SelectedItem.ToString();
            c.RemoveFromCartClicked(s);
        }

        private void ReturnItemButton_Click(object sender, EventArgs e)
        {
            Form rd = new ReturnProductForm(c, this);
            rd.ShowDialog(this);
        }

        private void BuyButton_Click(object sender, EventArgs e)
        {
            int i = CartListBox.Items.Count;

            if(c.BuyClicked(i) ==  true)
                CartListBox.Items.Clear();
        }

        public void DisplayReceipt(Receipt r)
        {
            Form rf = new ReceiptForm(r);
            rf.ShowDialog(this);
        }

        private void CheckoutGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            AddToCartButton_Click(sender, e);
        }

        private void Controller_FormClosing(object sender, FormClosingEventArgs e)
        {
            EmptyCartButton_Click(sender, e);
            c.FormClosing();
        }

        private void TotalSalesButton_Click(object sender, EventArgs e)
        {
            string m = MonthComboBox.Text;
            string y = YearComboBox.Text;
            var list = c.TotalSalesClicked(y, m);

            Form totalSalesForm = new TotalSalesDialog(list, m, y);
            totalSalesForm.ShowDialog(this);
        }

        private void TopTenButton_Click(object sender, EventArgs e)
        {
            string m = MonthComboBox.Text;
            string y = YearComboBox.Text;
            var l = c.TopTenClicked(y, m);

            Form topTenSalesForm = new TopTenSalesDialog(l);
            topTenSalesForm.ShowDialog(this);
        }

        private void YearComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(YearComboBox.SelectedIndex != -1 && MonthComboBox.SelectedIndex != -1)
                TotalSalesButton.Enabled = true;
            else
                TotalSalesButton.Enabled = false;

            if (YearComboBox.SelectedIndex != -1 || MonthComboBox.SelectedIndex != -1)
                TopTenButton.Enabled = true;
            else
                TopTenButton.Enabled = false;

        }

        private void MonthComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (YearComboBox.SelectedIndex != -1 && MonthComboBox.SelectedIndex != -1)
                TotalSalesButton.Enabled = true;
            else
                TotalSalesButton.Enabled = false;

            if (YearComboBox.SelectedIndex != -1 || MonthComboBox.SelectedIndex != -1)
                TopTenButton.Enabled = true;
            else
                TopTenButton.Enabled = false;

        }

        private void SearchText_TextChanged(object sender, EventArgs e)
        {
            string s = SearchText.Text;
            c.SearchTextChanged(s);
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            c.updateClicked();
        }

        private void syncButton_Click(object sender, EventArgs e)
        {
            c.syncClicked();
        }
    }
}
