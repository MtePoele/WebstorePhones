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
            
            foreach (var phone in phones)
            {
                listBoxPhoneOverview.Items.Add($"{phone.Brand} - {phone.Type}");
            }
            listBoxPhoneOverview.SetSelected(0, true);
            
            UpdateLabels(listBoxPhoneOverview.SelectedIndex);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void listBoxPhoneOverview_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateLabels(listBoxPhoneOverview.SelectedIndex);
        }

        private void UpdateLabels(int id)
        {
            lblBrand.Text = phones[id].Brand;
            lblType.Text = phones[id].Type;
            lblPrice.Text = phones[id].PriceWithTax.ToString();
            lblStock.Text = phones[id].Stock.ToString();
            lblDescription.Text = phones[id].Description;
        }
    }
}
