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

namespace C969_Software_2
{
    public struct UserReport
    {
        public int userId;
        public string userName;
        public string type;
        public string startTime;
        public string endTime;
        public string customerName;

    }


    public partial class Schedules : Form
    {
        public Schedules()
        {
            InitializeComponent();
            userReport.DataSource = getReport();
        }

        public static Array getReport()
        {
            Dictionary<int, Hashtable> userReport = SqlUpdater.getAppointments();

            var appointmentArray = from row in userReport
                                   select new
                                   {
                                       UserName = row.Value["username"],
                                       Type = row.Value["type"],
                                       StartTime = SqlUpdater.convertToTimezone(row.Value["start"].ToString()),
                                       EndTime = SqlUpdater.convertToTimezone(row.Value["start"].ToString()),
                                       Customer = row.Value["customerName"]
                                   };

            return appointmentArray.ToArray();
        }
    }
}


