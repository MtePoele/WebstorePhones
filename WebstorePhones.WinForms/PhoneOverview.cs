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
        private PhoneService phoneSerivce = new();
        private List<Phone> listPhones;
        BindingSource bindingSource = new();

        public PhoneOverview()
        {
            InitializeComponent();

            GetPhones();


            UpdateListBox();
        }

        private void GetPhones()
        {
            listPhones = phoneSerivce.Get().ToList();
        }

        private void UpdateListBox()
        {
            bindingSource.DataSource = listPhones;

            ListBoxPhoneOverview.DataSource = bindingSource;
            ListBoxPhoneOverview.DisplayMember = nameof(Phone.FullName);

            bindingSource.ResetBindings(false);
        }

        private void UpdateLabels(Phone phone)
        {
            lblBrand.Text = phone.Brand;
            lblType.Text = phone.Type;
            lblPrice.Text = phone.PriceWithTax.ToString();
            lblStock.Text = phone.Stock.ToString();
            lblDescription.Text = phone.Description;
        }

        private void ButtonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ListBoxPhoneOverview_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateLabels((Phone)ListBoxPhoneOverview.SelectedItem);
        }

        private void TxtboxSearch_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TxtboxSearch.Text))
                GetPhones();
            if (TxtboxSearch.Text.Length > 3)
                listPhones = phoneSerivce.Search(TxtboxSearch.Text).ToList();

            if (listPhones.Count > 0)
                UpdateListBox();
            // TODO If search field updates, it needs to redraw listbox and refill labels
            // TODO Empty listbox if no valid items were found, also empty labels.
        }
    }
}
