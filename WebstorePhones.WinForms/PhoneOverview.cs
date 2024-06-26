﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using WebstorePhones.Domain.Entities;
using WebstorePhones.Domain.Interfaces;

namespace WebstorePhones.WinForms
{
    public partial class PhoneOverview : Form
    {
        private readonly IPhoneService _phoneService;
        private List<Phone> phones;
        readonly BindingSource bindingSource = new();

        public PhoneOverview()
        {
            _phoneService = (IPhoneService)Program.ServiceProvider.GetService(typeof(IPhoneService));

            InitializeComponent();

            GetPhones();

            UpdateListBox();
        }

        private void GetPhones()
        {
            phones = _phoneService.Get().ToList();
        }

        private void UpdateListBox()
        {
            bindingSource.DataSource = phones;

            ListBoxPhoneOverview.DataSource = bindingSource;
            ListBoxPhoneOverview.DisplayMember = nameof(Phone.FullName);

            if (phones.Count > 0)
            {
                UpdateLabels(phones[ListBoxPhoneOverview.SelectedIndex]);
            }

            if (phones.Count == 0)
            {
                EmptyListBox();
                ButtonDelete.Enabled = false;
            }

            bindingSource.ResetBindings(false);
        }

        private void UpdateLabels(Phone phone)
        {
            lblBrand.Text = phone.Brand.BrandName;
            lblType.Text = phone.Type;
            lblPrice.Text = phone.PriceWithTax.ToString();
            lblStock.Text = phone.Stock.ToString();
            lblDescription.Text = phone.Description;
        }

        private void EmptyListBox()
        {
            lblBrand.Text = string.Empty;
            lblType.Text = string.Empty;
            lblPrice.Text = string.Empty;
            lblStock.Text = string.Empty;
            lblDescription.Text = string.Empty;
        }

        private async void TxtboxSearch_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TxtboxSearch.Text))
                GetPhones();
            if (TxtboxSearch.Text.Length > 3)
            {
                phones = (await _phoneService.SearchAsync(TxtboxSearch.Text)).ToList();
            }

            UpdateListBox();
        }

        private void ListBoxPhoneOverview_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (phones.Count > 0)
            {
                UpdateLabels((Phone)ListBoxPhoneOverview.SelectedItem);
                ButtonDelete.Enabled = true;
            }
        }

        private void ButtonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ButtonAdd_Click(object sender, EventArgs e)
        {
            Form form = new AddPhone();
            DialogResult dialogResult = form.ShowDialog();

            if (dialogResult == DialogResult.OK)
            {
                GetPhones();
                UpdateListBox();
            }
        }

        private async void ButtonDelete_Click(object sender, EventArgs e)
        {
            DialogResult confirmResult = MessageBox.Show(
                "Confirmation dialog",
                "Do you really want to delete this phone?",
                MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {
                await _phoneService.DeleteAsync(phones[ListBoxPhoneOverview.SelectedIndex].Id);
                GetPhones();
                UpdateListBox();
            }
        }
    }
}
