using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using WebstorePhones.Business.Services;
using WebstorePhones.Domain.Objects;

namespace WebstorePhones.WinForms
{
    public partial class PhoneOverview : Form
    {
        private PhoneService phoneService = new();
        private List<Phone> phones;

        public PhoneOverview()
        {
            InitializeComponent();

            phones = phoneService.Get().ToList();

            UpdateListBoxPhoneOverview();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void UpdateLabels(int id)
        {
            lblBrand.Text = phones[id].Brand;
            lblType.Text = phones[id].Type;
            lblPrice.Text = phones[id].PriceWithTax.ToString();
            lblStock.Text = phones[id].Stock.ToString();
            lblDescription.Text = phones[id].Description;
        }

        private void UpdateListBoxPhoneOverview()
        {
            foreach (var phone in phones)
            {
                ListBoxPhoneOverview.Items.Add($"{phone.Brand} - {phone.Type}");
            }

            ListBoxPhoneOverview.SetSelected(0, true);
            UpdateLabels(ListBoxPhoneOverview.SelectedIndex);
        }

        private void ListBoxPhoneOverview_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateLabels(ListBoxPhoneOverview.SelectedIndex);
        }

        private void ButtonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TxtboxSearch_TextChanged(object sender, EventArgs e)
        {
            ListBoxPhoneOverview.Items.Clear();

            phones = phoneService.Search(TxtboxSearch.Text).ToList();

            if (TxtboxSearch.Text.Length > 3)
                UpdateListBoxPhoneOverview();
            if (string.IsNullOrEmpty(TxtboxSearch.Text))
            {
                phones = phoneService.Get().ToList();
                UpdateListBoxPhoneOverview();
            }
        }
    }
}
