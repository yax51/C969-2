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
    public struct Customer
    {
        public string customerName;
        public int numberOfApps;
    }

    public partial class CustomerReports : Form
    {
        public CustomerReports()
        {
            InitializeComponent();
            customerReportView.DataSource = getReport();
        }

        public static DataTable getReport()
        {
            Dictionary<int, Hashtable> appointments = SqlUpdater.getAppointments();

            DataTable dt = new DataTable();
            dt.Clear();
            dt.Columns.Add("customer");
            dt.Columns.Add("appointments");

            IEnumerable<string> customers = appointments.Select(i => i.Value["customerName"].ToString()).Distinct();

            foreach (string customer in customers)
            {
                DataRow row = dt.NewRow();
                row["customer"] = customer;
                row["appointments"] = appointments.Where(i => i.Value["customerName"].ToString() == customer.ToString()).Count().ToString();
                dt.Rows.Add(row);

            }
            return dt;

        }
    }
}
