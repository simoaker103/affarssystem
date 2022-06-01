
namespace DVGB07_lab4
{
    partial class TopTenSalesDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TopTenSalesDialog));
            this.TopTenTextBox = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // TopTenTextBox
            // 
            this.TopTenTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TopTenTextBox.Location = new System.Drawing.Point(0, 30);
            this.TopTenTextBox.Name = "TopTenTextBox";
            this.TopTenTextBox.Size = new System.Drawing.Size(268, 200);
            this.TopTenTextBox.TabIndex = 1;
            this.TopTenTextBox.Text = resources.GetString("TopTenTextBox.Text");
            this.TopTenTextBox.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // TopTenSalesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(268, 261);
            this.Controls.Add(this.TopTenTextBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TopTenSalesForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Top Ten Sales";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label TopTenTextBox;
    }
}