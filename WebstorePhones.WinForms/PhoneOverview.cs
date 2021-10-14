﻿using System;
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
            listPhones = phoneService.Get().ToList();
        }

        private void UpdateListBox()
        {
            bindingSource.DataSource = listPhones;

            ListBoxPhoneOverview.DataSource = bindingSource;
            ListBoxPhoneOverview.DisplayMember = nameof(Phone.FullName);

            if (listPhones.Count > 0)
            {
                UpdateLabels(listPhones[ListBoxPhoneOverview.SelectedIndex]);
            }

            if (listPhones.Count == 0)
            {
                EmptyListBox();
            }

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

        private void EmptyListBox()
        {
            if (listPhones.Count == 0)
            {
                lblBrand.Text = string.Empty;
                lblType.Text = string.Empty;
                lblPrice.Text = string.Empty;
                lblStock.Text = string.Empty;
                lblDescription.Text = string.Empty;
            }
        }

        private void TxtboxSearch_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TxtboxSearch.Text))
                GetPhones();

            if (TxtboxSearch.Text.Length > 3)
                listPhones = phoneService.Search(TxtboxSearch.Text).ToList();

            UpdateListBox();
        }

        private void ListBoxPhoneOverview_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listPhones.Count > 0)
                UpdateLabels((Phone)ListBoxPhoneOverview.SelectedItem);
        }

        private void ButtonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
