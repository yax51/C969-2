using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;


namespace C969_Software_2
{
    class SqlUpdater
    {
        private static Dictionary<int, Hashtable> _appointments = new Dictionary<int, Hashtable>();
        private static int _currentUserID;
        private static string _currentUserName;
        public static string conString = "server=52.206.157.109 ;database=U04R8h ;uid=U04R8h ;password=53688320537; convert zero datetime = True; ";

        public static int getCurrentUserID()
        {
            return _currentUserID;
        }

        public static void setCurrentUserID(int currentUserID)
        {
            _currentUserID = currentUserID;
        }

        public static string getCurrentUserName()
        {
            return _currentUserName;
        }

        public static void setCurrentUserName(string currentUserName)
        {
            _currentUserName = currentUserName;
        }

        public static string createTimestamp()
        {
            return DateTime.Now.ToString("u");
        }


        public static Dictionary<int, Hashtable> getAppointments()
        {
            return _appointments;
        }

        public static void setAppointments(Dictionary<int, Hashtable> appointments)
        {
            _appointments = appointments;
        }

        public static string convertToTimezone(string dateTime)
        {
           
            DateTime utcDateTime = DateTime.Now;
            string localDateTime = utcDateTime.ToString("MM/dd/yyyy hh:mm tt");

            return localDateTime;
        }

        public static int newID(List<int> idlist)
        {
            int highestID = 0;
            foreach (int id in idlist)
            {
                if (id > highestID)
                    highestID = id;
            }
            return highestID + 1;
        }

        public static int createID(string table)
        {
            MySqlConnection c = new MySqlConnection(conString);
            c.Open();
            MySqlCommand cmd = new MySqlCommand($"SELECT {table+"Id"} FROM {table}", c);
            MySqlDataReader rdr = cmd.ExecuteReader();
            List<int> idlist = new List<int>();
            while (rdr.Read())
            {
                idlist.Add(Convert.ToInt32(rdr[0]));
            }
            rdr.Close();
            c.Close();
            return newID(idlist);
        }


        public static int createRecord(string timestamp, string userName, string table, string partOfQuery, int userId = 0)
        {
            int recId = createID(table);
            string recInsert;
            if (userId == 0)
            {
                recInsert = $"INSERT INTO {table}" +
                $" VALUES ('{recId}', {partOfQuery}, '{timestamp}', '{userName}', '{timestamp}', '{userName}')";
            }
            else
            {
                recInsert = $"INSERT INTO {table} (appointmentId, customerId, start, end, type, userId, createDate, createdBy, lastUpdate, lastUpdateBy)" +
                $" VALUES ('{recId}', {partOfQuery}, '{userId}', '{timestamp}', '{userName}', '{timestamp}', '{userName}')";
            }

            MySqlConnection c = new MySqlConnection(conString);
            c.Open();
            MySqlCommand cmd = new MySqlCommand(recInsert, c);
            cmd.ExecuteNonQuery();
            
            return recId;

        }

        public static int findCustomer(string search)
        {
            int customerId;
            string query;
            if (int.TryParse(search, out customerId))
            {
                query = $"SELECT customerId FROM customer WHERE customerid = '{search.ToString()}'";
            }
            else
            {
                query = $"SELECT customerId FROM customer WHERE customerName LIKE '{search}'";
            }

            MySqlConnection c = new MySqlConnection(SqlUpdater.conString);
            c.Open();
            MySqlCommand cmd = new MySqlCommand(query, c);
            MySqlDataReader rdr = cmd.ExecuteReader();

            if (rdr.HasRows)
            {
                rdr.Read();
                customerId = Convert.ToInt32(rdr[0]);
                rdr.Close();
                c.Close();
                return customerId;
            }
            return 0;

        }

        public static Dictionary<string, string> getCustomerDetails(int customerId)
        {
            string query = $"SELECT * FROM customer WHERE customerId = '{customerId.ToString()}'";
            MySqlConnection c = new MySqlConnection(SqlUpdater.conString);
            c.Open();
            MySqlCommand cmd = new MySqlCommand(query, c);
            MySqlDataReader rdr = cmd.ExecuteReader();
            rdr.Read();

            Dictionary<string, string> customerDict = new Dictionary<string, string>();
            customerDict.Add("customerName", rdr[1].ToString());
            customerDict.Add("addressId", rdr[2].ToString());
            customerDict.Add("active", rdr[3].ToString());
            rdr.Close();

            query = $"SELECT * FROM address WHERE addressId = '{customerDict["addressId"]}'";
            cmd = new MySqlCommand(query, c);
            rdr = cmd.ExecuteReader();
            rdr.Read();

            customerDict.Add("address", rdr[1].ToString());
            customerDict.Add("cityId", rdr[3].ToString());
            customerDict.Add("zip", rdr[4].ToString());
            customerDict.Add("phone", rdr[5].ToString());
            rdr.Close();

            query = $"SELECT * FROM city WHERE cityId = '{customerDict["cityId"]}'";
            cmd = new MySqlCommand(query, c);
            rdr = cmd.ExecuteReader();
            rdr.Read();

            customerDict.Add("city", rdr[1].ToString());
            customerDict.Add("countryId", rdr[2].ToString());
            rdr.Close();

            query = $"SELECT * FROM country WHERE countryId = '{customerDict["countryId"]}'";
            cmd = new MySqlCommand(query, c);
            rdr = cmd.ExecuteReader();
            rdr.Read();

            customerDict.Add("country", rdr[1].ToString());
            rdr.Close();
            c.Close();

            return customerDict;
        }

        public static Dictionary<string, string> getAppointmentDetails(string appointmentId)
        {
            string query = $"SELECT * FROM appointment WHERE appointmentId = '{appointmentId}'";
            MySqlConnection c = new MySqlConnection(SqlUpdater.conString);
            c.Open();
            MySqlCommand cmd = new MySqlCommand(query, c);
            MySqlDataReader rdr = cmd.ExecuteReader();
            rdr.Read();

            Dictionary<string, string> appointmentDict = new Dictionary<string, string>();
            appointmentDict.Add("appointmentId", appointmentId);
            appointmentDict.Add("customerId", rdr[1].ToString());
            appointmentDict.Add("type", rdr[13].ToString());
            appointmentDict.Add("start", rdr[7].ToString());
            appointmentDict.Add("end", rdr[8].ToString());
            
            rdr.Close();

            return appointmentDict;

        }
    }
}