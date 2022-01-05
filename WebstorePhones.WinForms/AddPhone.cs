using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using WebstorePhones.Domain.Interfaces;
using WebstorePhones.Domain.Objects;

namespace WebstorePhones.WinForms
{
    public partial class AddPhone : Form
    {
        private IPhoneService _phoneService;

        public AddPhone()
        {
            _phoneService = (IPhoneService)Program.ServiceProvider.GetService(typeof(IPhoneService));

            InitializeComponent();
        }

        private string ValidateText(string textboxName, string textboxValue)
        {
            string errorMessage = string.Empty;

            switch (textboxName)
            {
                case "TxtPrice":
                    var reg = new Regex("/[0-9]+[,][0-9]{2}/");

                    if (!reg.IsMatch(textboxValue))
                    {
                        if (decimal.TryParse(textboxValue, out _))
                        {
                            if (Convert.ToDecimal(textboxValue) != Math.Round(Convert.ToDecimal(textboxValue), 2))
                            {
                                errorMessage = $"{textboxName.Substring(3)} needs to have two or fewer decimals.\n";
                            }
                        }
                        else
                        {
                            errorMessage = $"{textboxName.Substring(3)} needs to be a number.\n";
                        }

                    }
                    break;
                case "TxtStock":
                    if (!int.TryParse(textboxValue, out _))
                    {
                        errorMessage = $"{textboxName.Substring(3)} needs to be a number.\n";
                    }
                    break;
                default:
                    if (textboxValue.Trim() == string.Empty)
                    {
                        errorMessage = $"{textboxName.Substring(3)} is empty.\n";
                    }
                    break;
            }

            return errorMessage;
        }

        private void AddPhoneToDatabase()
        {
            Phone phone = new()
            {
                Brand = new Brand() { BrandName = TxtBrand.Text },
                Type = TxtType.Text,
                Description = TxtDescription.Text,
                PriceWithTax = Convert.ToDecimal(TxtPrice.Text),
                Stock = Convert.ToInt32(TxtStock.Text)
            };

            _phoneService.AddToDatabase(phone);
        }

        private void BtnApply_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new();

            sb.Append(ValidateText(nameof(TxtBrand), TxtBrand.Text));
            sb.Append(ValidateText(nameof(TxtType), TxtType.Text));
            sb.Append(ValidateText(nameof(TxtDescription), TxtDescription.Text));
            sb.Append(ValidateText(nameof(TxtPrice), TxtPrice.Text));
            sb.Append(ValidateText(nameof(TxtStock), TxtStock.Text));

            string errorMessages = sb.ToString();

            if (errorMessages.Length > 1)
            {
                MessageBox.Show(errorMessages);
            }
            else
            {
                AddPhoneToDatabase();
                this.DialogResult = DialogResult.OK;
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
