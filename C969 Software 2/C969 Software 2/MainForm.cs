using System;
using System.Collections;
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
    public partial class MainForm : Form
    {
        public Login loginForm;

        public MainForm()
        {
            InitializeComponent();
            appointmentCalendar.DataSource = getCalendar(weekRadioButton.Checked);
            reminderCheck(appointmentCalendar);
            

            
           
        }

        public static void reminderCheck(DataGridView appointmentCalendar)
        {
            foreach (DataGridViewRow row in appointmentCalendar.Rows)
            {
                DateTime now = DateTime.UtcNow;
                DateTime start = DateTime.Parse(row.Cells[2].Value.ToString()).ToUniversalTime();
                TimeSpan nowUntilStartOfApp = now - start;
                if (nowUntilStartOfApp.TotalMinutes >= -15 && nowUntilStartOfApp.TotalMinutes < 1)
                {
                    MessageBox.Show($"Reminder: you have a meeting with {row.Cells[4].Value} at {row.Cells[2].Value}");
                }


            }
        }

        private void createCustomerButton_Click(object sender, EventArgs e)
        {
            CreateCustomer createCustomer = new CreateCustomer();
            createCustomer.Show();
        }

        private void updateCustomerButton_Click(object sender, EventArgs e)
        {
            UpdateCustomer updateCustomer = new UpdateCustomer();
            updateCustomer.Show();
        }

        private void deleteCustomerButton_Click(object sender, EventArgs e)
        {
            DeleteCustomer deleteCustomer = new DeleteCustomer();
            deleteCustomer.Show();
        }

        private void appointmentButton_Click(object sender, EventArgs e)
        {
            Appointments appointments = new Appointments();
            appointments.Show();
        }

        private void schedualButton_Click(object sender, EventArgs e)
        {
            Schedules schedules = new Schedules();
            schedules.Show();
        }

        private void customerReportButton_Click(object sender, EventArgs e)
        {
            CustomerReports customerReports = new CustomerReports();
            customerReports.Show();
        }

        private void addAppointmentButton_Click(object sender, EventArgs e)
        {
            AddAppointment addAppointment = new AddAppointment();
            addAppointment.mainFormObject = this;
            addAppointment.Show();
        }

        static public Array getCalendar(bool weekView)
        {

            MySqlConnection c = new MySqlConnection(SqlUpdater.conString);
            c.Open();
            string query = $"SELECT customerId, type, start, end, appointmentId, userId FROM appointment WHERE userid = '{SqlUpdater.getCurrentUserID()}'";
            MySqlCommand cmd = new MySqlCommand(query, c);
            MySqlDataReader rdr = cmd.ExecuteReader();

            Dictionary<int, Hashtable> appointments = SqlUpdater.getAppointments();//new Dictionary<int, Hashtable>();


            while (rdr.Read())
            {
                Hashtable appointment = new Hashtable();
                appointment.Add("customerId", rdr[0]);
                appointment.Add("type", rdr[1]);
                appointment.Add("start", rdr[2]);
                appointment.Add("end", rdr[3]);
                appointment.Add("userId", rdr[5]);

                appointment.Add(Convert.ToInt32(rdr[4]), appointment);

            }
            rdr.Close();

            foreach (var app in appointments.Values)
            {
                query = $"SELECT userName FROM user WHERE userId = '{app["userId"]}'";
                cmd = new MySqlCommand(query, c);
                rdr = cmd.ExecuteReader();
                rdr.Read();
                app.Add("userName", rdr[0]);
                rdr.Close();
            }

            foreach (var app in appointments.Values)
            {
                query = $"SELECT customerName FROM customer WHERE customerId = '{app["customerId"]}'";
                cmd = new MySqlCommand(query, c);
                rdr = cmd.ExecuteReader();
                rdr.Read();
                app.Add("customerName", rdr[0]);
                rdr.Close();
            }

            Dictionary<int, Hashtable> parsedAppointments = new Dictionary<int, Hashtable>();

            foreach (var app in appointments)
            {
                DateTime startTime = DateTime.Parse(app.Value["start"].ToString());
                DateTime endTime = DateTime.Parse(app.Value["end"].ToString());
                DateTime today = DateTime.UtcNow;

                if (weekView)
                {
                    DateTime sunday = today.AddDays(-(int)today.DayOfWeek);
                    DateTime saturday = today.AddDays(-(int)today.DayOfWeek + (int)DayOfWeek.Saturday);

                    if (startTime >= sunday && endTime < saturday)
                    {
                        parsedAppointments.Add(app.Key, app.Value);
                    }
                }
                else
                {
                    DateTime firstDayOfMonth = new DateTime(today.Year, today.Month, 1);
                    DateTime lastDayOfMonth = firstDayOfMonth.AddMonths(1).AddDays(-1);
                    if (startTime >= firstDayOfMonth && endTime < lastDayOfMonth)
                    {
                        parsedAppointments.Add(app.Key, app.Value);
                    }
                }
            }

            SqlUpdater.setAppointments(appointments);

            var appointmentArray = from row in parsedAppointments select new {
                ID = row.Key,
                Type = row.Value["type"],
                StartTime = SqlUpdater.convertToTimezone(row.Value["start"].ToString()),
                EndTime = SqlUpdater.convertToTimezone(row.Value["end"].ToString()),
                Customer = row.Value["customerName"]
            };

            c.Close();
        

                return appointmentArray.ToArray();
        }
        


        public void updateCalendar()
        {
            appointmentCalendar.DataSource = getCalendar(weekRadioButton.Checked);
            appointmentCalendar.Update();
            appointmentCalendar.Refresh();
           
        }

        private void updateAppointmentButton_Click(object sender, EventArgs e)
        {
            UpdateAppointment updateAppointment = new UpdateAppointment();
            updateAppointment.mainFormObject = this;
            updateAppointment.Show();
        }

        private void deleteAppointmentButton_Click(object sender, EventArgs e)
        {
            DeleteAppointment deleteAppointment = new DeleteAppointment();
            deleteAppointment.mainFormObject = this;
            deleteAppointment.Show();
        }

        private void weekRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            updateCalendar();
        }

        private void monthViewRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            updateCalendar();
        }
               
        
    }
}
