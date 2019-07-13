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
    public partial class DeleteCustomer : Form
    {
        public DeleteCustomer()
        {
            InitializeComponent();
        }

        public static Dictionary<string, string> customerDetails = new Dictionary<string, string>();

        public bool deleteCustomer()
        {
            MySqlConnection c = new MySqlConnection(SqlUpdater.conString);
            c.Open();

            string recUpdate = $"DELETE FROM customer" +
                $" WHERE customerName = '{customerDetails["customerName"]}'";
            MySqlCommand cmd = new MySqlCommand(recUpdate, c);
            int customerUpdated = cmd.ExecuteNonQuery();

            recUpdate = $"DELETE FROM address" +
                $" WHERE address = '{customerDetails["address"]}'";
            cmd = new MySqlCommand(recUpdate, c);
            int addressUpdated = cmd.ExecuteNonQuery();

            

            c.Close();

            if (customerUpdated != 0 && addressUpdated != 0)
                return true;
            else
                return false;
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            int customerId = SqlUpdater.findCustomer(searchBar.Text);
            if (customerId != 0)
            {
                customerDetails = SqlUpdater.getCustomerDetails(customerId);
                nameLabel.Text = customerDetails["customerName"];
                phoneLabel.Text = customerDetails["phone"];
                addressLabel.Text = customerDetails["address"];
                cityLabel.Text = customerDetails["city"];
                zipLabel.Text = customerDetails["zip"];
                countryLabel.Text = customerDetails["country"];
                if (customerDetails["active"] == "true")
                    activeLabel.Text = "Active";
                else
                    activeLabel.Text = "Inactive";
            }
            else
            {
                MessageBox.Show("Unable to find customer");
            }
            
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            DialogResult confirmDelete = MessageBox.Show("Are you sure you want to delete this contact?", "Confirm Delete", MessageBoxButtons.YesNo);
            if(confirmDelete == DialogResult.Yes)
            {
                if (deleteCustomer())
                    MessageBox.Show($"Cusomter: {customerDetails["customerName"]} was deleted");
                else
                    MessageBox.Show($"Cusomter: {customerDetails["customerName"]} was not deleted");

            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
