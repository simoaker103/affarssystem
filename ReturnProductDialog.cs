using System.Windows.Forms;


namespace DVGB07_lab4
{
    public partial class ReturnProductDialog : Form
    {
        public ReturnProductDialog(string message)
        {
            InitializeComponent();
            ReturnDialogLabel.Text = message;
        }

    }
}
