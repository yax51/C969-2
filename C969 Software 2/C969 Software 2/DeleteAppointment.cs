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
    public partial class DeleteAppointment : Form
    {
        public DeleteAppointment()
        {
            InitializeComponent();
        }

        
        public MainForm mainFormObject;
        public static Dictionary<string, string> appointmentDetails = new Dictionary<string, string>();
        
        public static bool deleteAppointment()
        {
            MySqlConnection c = new MySqlConnection(SqlUpdater.conString);
            c.Open();

            string recDelete = $"DELETE FROM appointment" +
                $" WHERE appointmentId = '{appointmentDetails["appointmentId"]}'";
            MySqlCommand cmd = new MySqlCommand(recDelete, c);
            int appointmentDeleted = cmd.ExecuteNonQuery();
            c.Close();

            if (appointmentDeleted != 0)
                return true;
            else
                return false;

        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            DialogResult confirmDelete = MessageBox.Show("Are you sure you want to delete this appointment?", "Confirm Delete", MessageBoxButtons.YesNo);
            if (confirmDelete == DialogResult.Yes)
            {
                if (deleteAppointment())
                    MessageBox.Show($"Cusomter: {appointmentDetails["type"]} was deleted");
                else
                    MessageBox.Show($"Cusomter: {appointmentDetails["type"]} was not deleted");

            }
            Close();

        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            string appointmentId = appointmentIdBox.Text;
            appointmentDetails = SqlUpdater.getAppointmentDetails(appointmentId);
            customerIdLabel.Text = appointmentDetails["customerId"];
            typeLabel.Text = appointmentDetails["type"];
            startLabel.Text = appointmentDetails["start"];
            endLabel.Text = appointmentDetails["end"];

        }


    }
}
