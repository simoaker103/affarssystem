
namespace DVGB07_lab4
{
    partial class ReceiptForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.PrintDialog = new System.Windows.Forms.PrintDialog();
            this.PrintReceiptButton = new System.Windows.Forms.Button();
            this.CloseButton = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.TotalText = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.PriceTextList = new System.Windows.Forms.TextBox();
            this.NameTextList = new System.Windows.Forms.TextBox();
            this.DateLabel = new System.Windows.Forms.Label();
            this.PhoneLabel = new System.Windows.Forms.Label();
            this.AddressLabel = new System.Windows.Forms.Label();
            this.NameLabel = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // PrintDialog
            // 
            this.PrintDialog.UseEXDialog = true;
            // 
            // PrintReceiptButton
            // 
            this.PrintReceiptButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.PrintReceiptButton.Location = new System.Drawing.Point(43, 529);
            this.PrintReceiptButton.Name = "PrintReceiptButton";
            this.PrintReceiptButton.Size = new System.Drawing.Size(82, 23);
            this.PrintReceiptButton.TabIndex = 0;
            this.PrintReceiptButton.Text = "Print Receipt";
            this.PrintReceiptButton.UseVisualStyleBackColor = true;
            this.PrintReceiptButton.Click += new System.EventHandler(this.PrintReceiptButton_Click);
            // 
            // CloseButton
            // 
            this.CloseButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CloseButton.Location = new System.Drawing.Point(131, 529);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(75, 23);
            this.CloseButton.TabIndex = 1;
            this.CloseButton.Text = "Close";
            this.CloseButton.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Window;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.TotalText);
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.PriceTextList);
            this.panel1.Controls.Add(this.NameTextList);
            this.panel1.Controls.Add(this.DateLabel);
            this.panel1.Controls.Add(this.PhoneLabel);
            this.panel1.Controls.Add(this.AddressLabel);
            this.panel1.Controls.Add(this.NameLabel);
            this.panel1.Location = new System.Drawing.Point(-1, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(249, 519);
            this.panel1.TabIndex = 2;
            // 
            // TotalText
            // 
            this.TotalText.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TotalText.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TotalText.Location = new System.Drawing.Point(188, 487);
            this.TotalText.Name = "TotalText";
            this.TotalText.Size = new System.Drawing.Size(49, 14);
            this.TotalText.TabIndex = 8;
            this.TotalText.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // textBox1
            // 
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(13, 486);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(169, 14);
            this.textBox1.TabIndex = 7;
            this.textBox1.Text = "Total";
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Location = new System.Drawing.Point(13, 480);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(224, 2);
            this.panel2.TabIndex = 6;
            // 
            // PriceTextList
            // 
            this.PriceTextList.BackColor = System.Drawing.SystemColors.Window;
            this.PriceTextList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.PriceTextList.Location = new System.Drawing.Point(188, 129);
            this.PriceTextList.Margin = new System.Windows.Forms.Padding(0);
            this.PriceTextList.Multiline = true;
            this.PriceTextList.Name = "PriceTextList";
            this.PriceTextList.ReadOnly = true;
            this.PriceTextList.Size = new System.Drawing.Size(49, 348);
            this.PriceTextList.TabIndex = 5;
            this.PriceTextList.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // NameTextList
            // 
            this.NameTextList.BackColor = System.Drawing.SystemColors.Window;
            this.NameTextList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.NameTextList.Location = new System.Drawing.Point(13, 129);
            this.NameTextList.Multiline = true;
            this.NameTextList.Name = "NameTextList";
            this.NameTextList.ReadOnly = true;
            this.NameTextList.Size = new System.Drawing.Size(169, 348);
            this.NameTextList.TabIndex = 4;
            // 
            // DateLabel
            // 
            this.DateLabel.AutoSize = true;
            this.DateLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DateLabel.Location = new System.Drawing.Point(70, 106);
            this.DateLabel.Name = "DateLabel";
            this.DateLabel.Size = new System.Drawing.Size(106, 13);
            this.DateLabel.TabIndex = 3;
            this.DateLabel.Text = "2000-01-01 00:00:00";
            // 
            // PhoneLabel
            // 
            this.PhoneLabel.AutoSize = true;
            this.PhoneLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PhoneLabel.Location = new System.Drawing.Point(85, 68);
            this.PhoneLabel.Name = "PhoneLabel";
            this.PhoneLabel.Size = new System.Drawing.Size(76, 13);
            this.PhoneLabel.TabIndex = 2;
            this.PhoneLabel.Text = "031-165 46 45";
            // 
            // AddressLabel
            // 
            this.AddressLabel.AutoSize = true;
            this.AddressLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddressLabel.Location = new System.Drawing.Point(85, 52);
            this.AddressLabel.Name = "AddressLabel";
            this.AddressLabel.Size = new System.Drawing.Size(76, 13);
            this.AddressLabel.TabIndex = 1;
            this.AddressLabel.Text = "Karlavägen 12";
            // 
            // NameLabel
            // 
            this.NameLabel.AutoSize = true;
            this.NameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NameLabel.Location = new System.Drawing.Point(29, 9);
            this.NameLabel.Name = "NameLabel";
            this.NameLabel.Size = new System.Drawing.Size(189, 39);
            this.NameLabel.TabIndex = 0;
            this.NameLabel.Text = "Shop Corp.";
            // 
            // ReceiptForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(248, 560);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.CloseButton);
            this.Controls.Add(this.PrintReceiptButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ReceiptForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ReceiptForm";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PrintDialog PrintDialog;
        private System.Windows.Forms.Button PrintReceiptButton;
        private System.Windows.Forms.Button CloseButton;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label AddressLabel;
        private System.Windows.Forms.Label NameLabel;
        private System.Windows.Forms.Label PhoneLabel;
        private System.Windows.Forms.Label DateLabel;
        private System.Windows.Forms.TextBox PriceTextList;
        private System.Windows.Forms.TextBox NameTextList;
        private System.Windows.Forms.Panel panel2;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.TextBox TotalText;
        private System.Windows.Forms.TextBox textBox1;
    }
}