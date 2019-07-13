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
    public partial class AddAppointment : Form
    {
        public AddAppointment()
        {
            InitializeComponent();
            endTimeBox.Value = endTimeBox.Value.AddHours(1);
        }

        public MainForm mainFormObject;

        public static bool appHasConflict(DateTime startTime, DateTime endTime)
        {
            foreach (var app in SqlUpdater.getAppointments().Values)
            {
                if (startTime < DateTime.Parse(app["end"].ToString()) && DateTime.Parse(app["start"].ToString()) < endTime)
                    return true;
            }
            return false;
        }

        public static bool outsideBusinessHours(DateTime startTime, DateTime endTime)
        {
            startTime = startTime.ToLocalTime();
            endTime = endTime.ToLocalTime();
            DateTime businessStart = DateTime.Today.AddHours(8);
            DateTime businessEnd = DateTime.Today.AddHours(17);
            if (startTime.TimeOfDay > businessStart.TimeOfDay && startTime.TimeOfDay < businessEnd.TimeOfDay &&
                endTime.TimeOfDay > businessStart.TimeOfDay && endTime.TimeOfDay < businessEnd.TimeOfDay)
                return false;
            return true;
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            string timestamp = SqlUpdater.createTimestamp();
            int userId = SqlUpdater.getCurrentUserID();
            string username = SqlUpdater.getCurrentUserName();
            DateTime startTime = startTimeBox.Value.ToUniversalTime();
            DateTime endTime = endTimeBox.Value.ToUniversalTime();


            try
            {
                if (appHasConflict(startTime, endTime))
                    throw new appointmentException();
                else
                {
                    try
                    {
                        if (outsideBusinessHours(startTime, endTime))
                            throw new appointmentException();
                        else
                        {
                            SqlUpdater.createRecord(timestamp, username, "appointment", $"'{customerIdBox.Text}', '{startTimeBox.Value.ToUniversalTime().ToString("u")}', '{endTimeBox.Value.ToUniversalTime().ToString("u")}', '{typeBox.Text}'", userId);
                            mainFormObject.updateCalendar();
                            

                            Close();

                        }
                    }
                    catch (appointmentException ex) { ex.businessHours(); }

                }
            }
            catch (appointmentException ex) { ex.appOverlap(); }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}



