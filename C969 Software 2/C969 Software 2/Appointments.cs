﻿using System;
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
    public struct AppReport
    {
        public string month;
        public string appType;
        public int quantity;
    }


    public partial class Appointments : Form
    {
        public Appointments()
        {
            InitializeComponent();
            appReport.DataSource = getReport();
        }

        public static Array getReport()
        {
            List<AppReport> appReports = new List<AppReport>();
            List<Hashtable> appTypes = new List<Hashtable>();
            SortedList months = new SortedList();
            months.Add(1, "Janurary");
            months.Add(2, "Feburary");
            months.Add(3, "March");
            months.Add(4, "April");
            months.Add(5, "May");
            months.Add(6, "June");
            months.Add(7, "July");
            months.Add(8, "August");
            months.Add(9, "September");
            months.Add(10, "October");
            months.Add(11, "November");
            months.Add(12, "December");

            foreach (var app in SqlUpdater.getAppointments().Values)
            {
                int appMonth = DateTime.Parse(app["start"].ToString()).Month;
                bool duplicate = false;
                foreach (AppReport r in appReports)
                {
                    if(r.month == months[appMonth].ToString() && r.appType == app["type"].ToString())
                    {
                        duplicate = true;
                    }
                }
                if (!duplicate)
                {
                    AppReport appReport = new AppReport();
                    appReport.month = months[appMonth].ToString();
                    appReport.appType = app["type"].ToString();

                    appReport.quantity = SqlUpdater.getAppointments().Where(i => i.Value["type"].ToString() == app["type"].ToString() && DateTime.Parse(i.Value["start"].ToString()).Month == appMonth).Count();

                    appReports.Add(appReport);

                }
            }

            var appointmentArray = from row in appReports
                                   select new
                                   {
                                       Month = row.month,
                                       Type = row.appType,
                                       Quantity = row.quantity
                                   };
            return appointmentArray.ToArray();



        }

    }
}
