
namespace WebstorePhones.WinForms
{
    partial class PhoneOverview
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.TxtboxSearch = new System.Windows.Forms.TextBox();
            this.ListBoxPhoneOverview = new System.Windows.Forms.ListBox();
            this.ButtonExit = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblBrand = new System.Windows.Forms.Label();
            this.lblType = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblPrice = new System.Windows.Forms.Label();
            this.lblStock = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblDescription = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // TxtboxSearch
            // 
            this.TxtboxSearch.Location = new System.Drawing.Point(12, 12);
            this.TxtboxSearch.Name = "TxtboxSearch";
            this.TxtboxSearch.PlaceholderText = "Search";
            this.TxtboxSearch.Size = new System.Drawing.Size(303, 27);
            this.TxtboxSearch.TabIndex = 0;
            this.TxtboxSearch.TextChanged += new System.EventHandler(this.TxtboxSearch_TextChanged);
            // 
            // ListBoxPhoneOverview
            // 
            this.ListBoxPhoneOverview.FormattingEnabled = true;
            this.ListBoxPhoneOverview.ItemHeight = 20;
            this.ListBoxPhoneOverview.Location = new System.Drawing.Point(12, 45);
            this.ListBoxPhoneOverview.Name = "ListBoxPhoneOverview";
            this.ListBoxPhoneOverview.Size = new System.Drawing.Size(303, 364);
            this.ListBoxPhoneOverview.TabIndex = 1;
            this.ListBoxPhoneOverview.SelectedIndexChanged += new System.EventHandler(this.ListBoxPhoneOverview_SelectedIndexChanged);
            // 
            // ButtonExit
            // 
            this.ButtonExit.Location = new System.Drawing.Point(1020, 412);
            this.ButtonExit.Name = "ButtonExit";
            this.ButtonExit.Size = new System.Drawing.Size(94, 29);
            this.ButtonExit.TabIndex = 2;
            this.ButtonExit.Text = "Exit";
            this.ButtonExit.UseVisualStyleBackColor = true;
            this.ButtonExit.Click += new System.EventHandler(this.ButtonExit_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(334, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "Brand:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(334, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "Type:";
            // 
            // lblBrand
            // 
            this.lblBrand.AutoSize = true;
            this.lblBrand.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblBrand.Location = new System.Drawing.Point(448, 15);
            this.lblBrand.Name = "lblBrand";
            this.lblBrand.Size = new System.Drawing.Size(2, 22);
            this.lblBrand.TabIndex = 5;
            // 
            // lblType
            // 
            this.lblType.AutoSize = true;
            this.lblType.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblType.Location = new System.Drawing.Point(448, 46);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(2, 22);
            this.lblType.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(613, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 20);
            this.label3.TabIndex = 7;
            this.label3.Text = "Price:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(613, 48);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 20);
            this.label4.TabIndex = 8;
            this.label4.Text = "Stock:";
            // 
            // lblPrice
            // 
            this.lblPrice.AutoSize = true;
            this.lblPrice.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblPrice.Location = new System.Drawing.Point(692, 13);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(2, 22);
            this.lblPrice.TabIndex = 9;
            // 
            // lblStock
            // 
            this.lblStock.AutoSize = true;
            this.lblStock.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblStock.Location = new System.Drawing.Point(692, 48);
            this.lblStock.Name = "lblStock";
            this.lblStock.Size = new System.Drawing.Size(2, 22);
            this.lblStock.TabIndex = 10;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(334, 82);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(88, 20);
            this.label7.TabIndex = 11;
            this.label7.Text = "Description:";
            // 
            // lblDescription
            // 
            this.lblDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblDescription.Location = new System.Drawing.Point(334, 113);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(780, 296);
            this.lblDescription.TabIndex = 12;
            this.lblDescription.Text = "lblDescription";
            // 
            // PhoneOverview
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1126, 450);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.lblStock);
            this.Controls.Add(this.lblPrice);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblType);
            this.Controls.Add(this.lblBrand);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ButtonExit);
            this.Controls.Add(this.ListBoxPhoneOverview);
            this.Controls.Add(this.TxtboxSearch);
            this.Name = "PhoneOverview";
            this.Text = "Phoneshop";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TxtboxSearch;
        private System.Windows.Forms.ListBox ListBoxPhoneOverview;
        private System.Windows.Forms.Button ButtonExit;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblBrand;
        private System.Windows.Forms.Label lblType;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.Label lblStock;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblDescription;
    }
}

