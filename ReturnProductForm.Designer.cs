
namespace DVGB07_lab4
{
    partial class ReturnProductForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.ReturnNumUpDown = new System.Windows.Forms.NumericUpDown();
            this.ProductId = new System.Windows.Forms.TextBox();
            this.ReturnButton = new System.Windows.Forms.Button();
            this.CategoryText = new System.Windows.Forms.TextBox();
            this.NameText = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.ReturnNumUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Quantity";
            // 
            // ReturnNumUpDown
            // 
            this.ReturnNumUpDown.Location = new System.Drawing.Point(12, 82);
            this.ReturnNumUpDown.Name = "ReturnNumUpDown";
            this.ReturnNumUpDown.ReadOnly = true;
            this.ReturnNumUpDown.Size = new System.Drawing.Size(53, 20);
            this.ReturnNumUpDown.TabIndex = 4;
            this.ReturnNumUpDown.ValueChanged += new System.EventHandler(this.ReturnNumUpDown_ValueChanged);
            // 
            // ProductId
            // 
            this.ProductId.Location = new System.Drawing.Point(12, 29);
            this.ProductId.Name = "ProductId";
            this.ProductId.Size = new System.Drawing.Size(100, 20);
            this.ProductId.TabIndex = 5;
            this.ProductId.TextChanged += new System.EventHandler(this.ProductId_TextChanged);
            // 
            // ReturnButton
            // 
            this.ReturnButton.Enabled = false;
            this.ReturnButton.Location = new System.Drawing.Point(12, 108);
            this.ReturnButton.Name = "ReturnButton";
            this.ReturnButton.Size = new System.Drawing.Size(75, 23);
            this.ReturnButton.TabIndex = 6;
            this.ReturnButton.Text = "Return";
            this.ReturnButton.UseVisualStyleBackColor = true;
            this.ReturnButton.Click += new System.EventHandler(this.ReturnButton_Click);
            // 
            // CategoryText
            // 
            this.CategoryText.Location = new System.Drawing.Point(146, 29);
            this.CategoryText.Name = "CategoryText";
            this.CategoryText.ReadOnly = true;
            this.CategoryText.Size = new System.Drawing.Size(100, 20);
            this.CategoryText.TabIndex = 7;
            // 
            // NameText
            // 
            this.NameText.Location = new System.Drawing.Point(146, 79);
            this.NameText.Name = "NameText";
            this.NameText.ReadOnly = true;
            this.NameText.Size = new System.Drawing.Size(100, 20);
            this.NameText.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Product ID";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(143, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Category";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(143, 63);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Name";
            // 
            // ReturnProductForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(265, 142);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.NameText);
            this.Controls.Add(this.CategoryText);
            this.Controls.Add(this.ReturnButton);
            this.Controls.Add(this.ProductId);
            this.Controls.Add(this.ReturnNumUpDown);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ReturnProductForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Return";
            ((System.ComponentModel.ISupportInitialize)(this.ReturnNumUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown ReturnNumUpDown;
        private System.Windows.Forms.TextBox ProductId;
        private System.Windows.Forms.Button ReturnButton;
        private System.Windows.Forms.TextBox CategoryText;
        private System.Windows.Forms.TextBox NameText;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}