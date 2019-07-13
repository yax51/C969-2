using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace C969_Software_2
{
    public partial class CreateCustomer : Form
    {
        public CreateCustomer()
        {
            InitializeComponent();
        }

        private void customerCreateButton_Click(object sender, EventArgs e)
        {
            string timestamp = SqlUpdater.createTimestamp();
            string userName = SqlUpdater.getCurrentUserName();

            if (string.IsNullOrEmpty(customerNameText.Text) ||
                string.IsNullOrEmpty(customerPhoneText.Text) ||
                string.IsNullOrEmpty(customerCityText.Text) ||
                string.IsNullOrEmpty(customerCountryText.Text) ||
                string.IsNullOrEmpty(customerZipText.Text) ||
                string.IsNullOrEmpty(customerAddressText.Text) ||
                (activeYes.Checked == false && activeNo.Checked == false))
            {
                MessageBox.Show("Please complete all fields");
            }
            else
            {
                int countryId = SqlUpdater.createRecord(timestamp, userName, "country", $"'{customerCountryText.Text}'");
                int cityId = SqlUpdater.createRecord(timestamp, userName, "city", $"'{customerCityText.Text}', '{countryId}'");
                int addressId = SqlUpdater.createRecord(timestamp, userName, "address", $"'{customerAddressText.Text}', '', '{cityId}', '{customerZipText.Text}', '{customerPhoneText.Text}'");
                SqlUpdater.createRecord(timestamp, userName, "customer", $"'{ customerNameText.Text}', '{addressId}', '{(activeYes.Checked ? 1 : 0)}'");

                Close();
            }


        }

        private void customerCancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }




}
