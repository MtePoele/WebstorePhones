using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using WebstorePhones.Domain.Objects;

namespace AddPhone
{
    public partial class AddPhoneForm : Form
    {

        public AddPhoneForm()
        {
            InitializeComponent();
        }

        private string ValidateText(string textboxName, string textboxValue)
        {
            string errorMessage = string.Empty;

            //if (textboxValue.Trim() == string.Empty)
            //{
            //    errorMessage = $"{textboxName.Substring(3)} is empty.\n";
            //}
            if (textboxName == "TxtPrice")
            {
                var reg = new Regex(@"[0-9]*[,][0-9]{2}");

                if (!reg.IsMatch(textboxValue))
                {
                    // TODO It accepts "55,333333333" as valid number.
                    errorMessage = $"{textboxName.Substring(3)} needs to be a number.\n";
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
            //sb.Append(ValidateText(nameof(TxtStock), TxtStock.Text));

            string errorMessages = sb.ToString();

            if (errorMessages.Length > 1)
            {
                MessageBox.Show(errorMessages);
            }
            else
            {
                // TODO Add to database with textbox values.
            }
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
