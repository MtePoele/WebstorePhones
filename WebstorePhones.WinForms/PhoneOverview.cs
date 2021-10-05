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
                listBox1.Items.Add($"{phone.Brand} - {phone.Type}");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }
    }
}
