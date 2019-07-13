using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace C969_Software_2
{
    class appointmentException : ApplicationException
    {
        public void businessHours()
        {
            MessageBox.Show("Exception occured. Please reschedule for normal business hours.");

        }

        public void appOverlap()
        {
            MessageBox.Show("Exception occured. This appointment time has already been taken.");
        }
    }
}
