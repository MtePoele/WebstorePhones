using System;
using System.Text;
using System.Windows.Forms;

namespace AddPhone
{
    public partial class AddPhone : Form
    {
        public AddPhone()
        {
            InitializeComponent();
        }

        private string ValidateText(string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                return " is leeg.";
            }
            else
            {
                return string.Empty;
            }
        }

        private void BtnApply_Click(object sender, EventArgs e)
        {
            string errorMessage = string.Empty;

            StringBuilder sb = new();


            MessageBox.Show(errorMessage);
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TxtBrand_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true;
            MessageBox.Show(ValidateText(this.Text));
        }

        private void TxtType_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true;

        }

        private void TxtDescription_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true;

        }

        private void TxtPrice_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true;

        }

        private void TxtStock_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true;

        }
    }
}
