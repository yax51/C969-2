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
    public partial class UpdateAppointment : Form
    {
        public UpdateAppointment()
        {
            InitializeComponent();
        }

        public MainForm mainFormObject;
        public static Dictionary<string, string> aForm = new Dictionary<string, string>();

        public bool updateAppointment(Dictionary<string, string> updatedForm)
        {
            MySqlConnection c = new MySqlConnection(SqlUpdater.conString);
            c.Open();


            string recUpdate = $"UPDATE appointment" +
                 $" SET customerId = '{updatedForm["customerId"]}', start = '{updatedForm["start"]}', end = '{updatedForm["end"]}', type = '{updatedForm["type"]}', lastUpdate = '{SqlUpdater.createTimestamp()}', lastUpdateBy = '{SqlUpdater.getCurrentUserName()}'" +
                 $" WHERE appointmentId = '{aForm["appointmentId"]}'";
            MySqlCommand cmd = new MySqlCommand(recUpdate, c);
            int appointmentUpdated = cmd.ExecuteNonQuery();
            c.Close();

            if (appointmentUpdated != 0 )
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
            string appointmentId = searchBar.Text;
            aForm = SqlUpdater.getAppointmentDetails(appointmentId);
            customerIdBox.Text = aForm["customerId"];
            typeBox.Text = aForm["type"];
            startTimeBox.Value = DateTime.Parse(SqlUpdater.convertToTimezone(aForm["start"]));
            endTimeBox.Value = DateTime.Parse(SqlUpdater.convertToTimezone(aForm["end"]));

        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            Dictionary<string, string> updatedForm = new Dictionary<string, string>();
            updatedForm.Add("type", typeBox.Text);
            updatedForm.Add("customerId", customerIdBox.Text);
            updatedForm.Add("start", startTimeBox.Value.ToUniversalTime().ToString());
            updatedForm.Add("end", endTimeBox.Value.ToUniversalTime().ToString());

            if(updateAppointment(updatedForm))
            {
                MessageBox.Show("Update successful!");
                mainFormObject.updateCalendar();
                Close();
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
