using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using WebstorePhones.Domain.Entities;
using WebstorePhones.Domain.Interfaces;

namespace WebstorePhones.WinForms
{
    public partial class AddPhone : Form
    {
        private readonly IPhoneService _phoneService;
        private readonly ILogger _logger;

        public AddPhone()
        {
            _phoneService = (IPhoneService)Program.ServiceProvider.GetService(typeof(IPhoneService));
            _logger = (ILogger)Program.ServiceProvider.GetService(typeof(ILogger));

            InitializeComponent();
        }

        private static string ValidateText(string textboxName, string textboxValue)
        {
            return textboxName switch
            {
                "TxtPrice" => CheckPriceValidity(textboxName, textboxValue),
                "TxtStock" => CheckStockValidity(textboxName, textboxValue),
                _ => CheckTextValidity(textboxName, textboxValue),
            };
        }

        private static string CheckTextValidity(string textboxName, string textboxValue)
        {
            if (textboxValue.Trim() == string.Empty)
            {
                return $"{textboxName[3..]} is empty.\n";
            }

            return string.Empty;
        }

        private static string CheckStockValidity(string textboxName, string textboxValue)
        {
            if (!int.TryParse(textboxValue, out _))
            {
                return $"{textboxName[3..]} needs to be a whole number.\n";
            }
            if (decimal.TryParse(textboxValue, out decimal stock))
            {
                return NumberCantBeNegative(textboxName, stock);
            }

            return string.Empty;
        }

        private static string CheckPriceValidity(string textboxName, string textboxValue)
        {
            var reg = new Regex("/[0-9]+[,][0-9]{2}/");

            if (!reg.IsMatch(textboxValue))
            {
                if (decimal.TryParse(textboxValue, out _))
                {
                    if (Convert.ToDecimal(textboxValue) != Math.Round(Convert.ToDecimal(textboxValue), 2))
                    {
                        return $"{textboxName[3..]} needs to have two or fewer decimals.\n";
                    }
                }
                else
                {
                    return $"{textboxName[3..]} needs to be a number.\n";
                }
            }
            if (decimal.TryParse(textboxValue, out decimal price))
            {
                return NumberCantBeNegative(textboxName, price);
            }

            return string.Empty;
        }

        private static string NumberCantBeNegative(string textboxName, decimal price)
        {
            if (price < 0)
            {
                return $"{textboxName[3..]} can't be negative.\n";
            }

            return string.Empty;
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
            List<Phone> phones = new() { phone };

            _phoneService.AddMissingPhones(phones);
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

            if (errorMessages.Length > 0)
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
