using System;
using System.Text;
using System.Windows.Forms;
using WebstorePhones.Domain.Objects;

namespace AddPhone
{
    public partial class AddPhone : Form
    {

        public AddPhone()
        {
            InitializeComponent();
        }

        private string ValidateText(string textboxName, string textboxValue)
        {
            string errorMessage = string.Empty;

            if (textboxValue.Trim() == string.Empty)
            {
                errorMessage = $"{textboxName.Substring(3)} is empty.\n";
                return errorMessage;
            }
            if (textboxName == "txtPrice")
            {
                if (!decimal.TryParse(textboxValue, out _) && (textboxValue.IndexOf(',', (textboxValue.Length - 2), 1) < 2));
                {
                    errorMessage = $"{textboxName.Substring(3)} needs to a number\n";
                }
            }

            return errorMessage;
        }

        private Phone GetFieldValues()
        {
            return new Phone()
            {
                Brand = TxtBrand.Text,
                Type = TxtBrand.Text,
                Description = TxtDescription.Text,
                PriceWithTax = Convert.ToDecimal(TxtPrice.Text),
                Stock = Convert.ToInt32(TxtStock.Text)
            };
        }

        private void BtnApply_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new();

            sb.Append(ValidateText(nameof(TxtBrand), TxtBrand.Text));
            sb.Append(ValidateText(nameof(TxtType), TxtType.Text));
            sb.Append(ValidateText(nameof(TxtDescription), TxtDescription.Text));
            sb.Append(ValidateText(nameof(TxtPrice), TxtPrice.Text));
            //sb.Append(ValidateText(nameof(TxtBrand), TxtBrand.Text));


            MessageBox.Show(sb.ToString());
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnApply_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            

            e.Cancel = true;
        }
    }
}
