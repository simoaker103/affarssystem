using DVGB07_lab4.Model;
using System;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;

namespace DVGB07_lab4
{
    partial class ReceiptForm : Form
    {
        private PrintDocument receiptToPrint;
        private Bitmap memoryImage;
        private int totalCost;

        public ReceiptForm(Receipt r)
        {
            InitializeComponent();
            receiptToPrint = new PrintDocument();
            receiptToPrint.PrintPage += new PrintPageEventHandler(this.Receipt_PrintPage);

            foreach (var item in r.PurchasedItems)
            {
                NameTextList.AppendText(item.Name + Environment.NewLine);
                PriceTextList.AppendText(item.Price.ToString() + Environment.NewLine);
                totalCost += item.Price;
            }

            DateLabel.Text = r.PurchasedItems[0].Date;
            TotalText.Text = totalCost.ToString();
        }

        private void PrintReceiptButton_Click(object sender, EventArgs e)
        {

            //https://stackoverflow.com/questions/10605840/print-panel-in-windows-form-c-sharp

            memoryImage = new Bitmap(panel1.Width, panel1.Height);
            panel1.DrawToBitmap(memoryImage, new Rectangle(0, 0, panel1.Width, panel1.Height));

            // Set the Document property to the PrintDocument for 
            // which the PrintPage Event has been handled. To display the
            // dialog, either this property or the PrinterSettings property 
            // must be set 
            PrintDialog.Document = receiptToPrint;

            DialogResult result = PrintDialog.ShowDialog();

            // If the result is OK then print the document.
            if (result == DialogResult.OK)
            {
                receiptToPrint.Print();
            }
            
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            if (memoryImage != null)
            {
                e.Graphics.DrawImage(memoryImage, 0, 0);
                base.OnPaint(e);
            }
        }

        private void Receipt_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Rectangle pagearea = e.PageBounds;
            e.Graphics.DrawImage(memoryImage, (pagearea.Width / 2) - (this.panel1.Width / 2), this.panel1.Location.Y);
        }
    }
}
