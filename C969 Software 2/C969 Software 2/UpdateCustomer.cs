using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace C969_Software_2
{
    public partial class UpdateCustomer : Form
    {
        public UpdateCustomer()
        {
            InitializeComponent();
        }

        public static Dictionary<string, string> cForm = new Dictionary<string, string>();

        public bool updateCustomer(Dictionary<string, string> updatedForm)
        {
            MySqlConnection c = new MySqlConnection(SqlUpdater.conString);
            c.Open();

            //Customer table
            string recUpdate = $"UPDATE customer" +
                $" SET customerName = '{updatedForm["customerName"]}', active = '{updatedForm["active"]}', lastUpdate = '{SqlUpdater.createTimestamp()}', lastUpdateBy = '{SqlUpdater.getCurrentUserName()}'" +
                $" WHERE customerName = '{cForm["customerName"]}'";
            MySqlCommand cmd = new MySqlCommand(recUpdate, c);
            int customerUpdated = cmd.ExecuteNonQuery();

            //Address table
            recUpdate = $"UPDATE address" +
                $" SET address = '{updatedForm["address"]}', postalCode = '{updatedForm["zip"]}', phone = '{updatedForm["phone"]}', lastUpdate = '{SqlUpdater.createTimestamp()}', lastUpdateBy = '{SqlUpdater.getCurrentUserName()}'" +
                $" WHERE address = '{cForm["address"]}'";
            cmd = new MySqlCommand(recUpdate, c);
            int addressUpdated = cmd.ExecuteNonQuery();



            //City Table
            recUpdate = $"UPDATE city" +
                $" SET city = '{updatedForm["city"]}', lastUpdate = '{SqlUpdater.createTimestamp()}', lastUpdateBy = '{SqlUpdater.getCurrentUserName()}'" +
                $" WHERE city = '{cForm["city"]}'";
            cmd = new MySqlCommand(recUpdate, c);
            int cityUpdated = cmd.ExecuteNonQuery();

            //Country Table
            recUpdate = $"UPDATE country" +
                $" SET country = '{updatedForm["country"]}', lastUpdate = '{SqlUpdater.createTimestamp()}', lastUpdateBy = '{SqlUpdater.getCurrentUserName()}'" +
                $" WHERE country = '{cForm["country"]}'";
            cmd = new MySqlCommand(recUpdate, c);
            int countryUpdated = cmd.ExecuteNonQuery();

            c.Close();

            if (customerUpdated != 0 && addressUpdated != 0 && cityUpdated != 0 && countryUpdated != 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            int customerId = SqlUpdater.findCustomer(searchBar.Text);
            if (customerId != 0)
            {
                cForm = SqlUpdater.getCustomerDetails(customerId);
                customerNameBox.Text = cForm["customerName"];
                customerPhoneBox.Text = cForm["phone"];
                customerCityBox.Text = cForm["city"];
                customerAddessBox.Text = cForm["address"];
                customerZipBox.Text = cForm["zip"];
                customerCountryBox.Text = cForm["country"];
                if (cForm["active"] == "true")
                    activeYes.Checked = true;
                
                else
                
                    activeNo.Checked = true;
            }
            else
            {
                    MessageBox.Show("Unable to find customer");
            }
            
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            Dictionary<string, string> updatedForm = new Dictionary<string, string>();
            updatedForm.Add("customerName", customerNameBox.Text);
            updatedForm.Add("phone", customerPhoneBox.Text);
            updatedForm.Add("address", customerAddessBox.Text);
            updatedForm.Add("city", customerCityBox.Text);
            updatedForm.Add("country", customerCountryBox.Text);
            updatedForm.Add("zip", customerZipBox.Text);
            updatedForm.Add("active", activeYes.Checked ? "1" : "0");

            if (updateCustomer(updatedForm))
            {
                MessageBox.Show("Updated succesfull");
            }
            else
            {
                MessageBox.Show("Update failed");
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }

}


