using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C969_Software_2
{
    class Logger
    {
        public static void writeUserLoginLog(int userId)
        {
            string path = "log.text";
            string log = $"User with ID {userId} logged in at {SqlUpdater.createTimestamp()}" + Environment.NewLine;

            File.AppendAllText(path, log);

        }
    }
}
