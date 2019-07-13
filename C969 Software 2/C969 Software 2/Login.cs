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
using System.Globalization;


namespace C969_Software_2
{
    public partial class Login : Form
    {
        public string errorMessage = "The username and password are incorrect";

        public Login()
        {
            InitializeComponent();

            if (CultureInfo.CurrentUICulture.LCID == 2058)
            {
                titleLabel.Text = "Por favor Iniciar sesión";
                usernameLabel.Text = "nombre de usuario";
                passwordLabel.Text = "Contraseña";
                loginButton.Text = "Iniciar sesión";
                cancelButton.Text = "Cancelar";
                errorMessage = "El nombre de usuario y la contraseña son incorrectos";
            }
        }

        static public int FindUser(string userName, string password)
        {
            MySqlConnection C = new MySqlConnection(SqlUpdater.conString);
            C.Open();
            MySqlCommand cmd = new MySqlCommand($"SELECT userId FROM user WHERE userName = '{userName}' AND password = '{password}'", C);
            MySqlDataReader rdr = cmd.ExecuteReader();

            if (rdr.HasRows)
            {
                rdr.Read();
                SqlUpdater.setCurrentUserID(Convert.ToInt32(rdr[0]));
                SqlUpdater.setCurrentUserName(userName);
                rdr.Close();
                return SqlUpdater.getCurrentUserID();
            }
            return 0;

        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            if (FindUser(username.Text, password.Text) != 0)
            {
                this.Hide();
                MainForm MainForm = new MainForm();
                MainForm.loginForm = this;
                Logger.writeUserLoginLog(SqlUpdater.getCurrentUserID());
                MainForm.Show();
            }
            else
            {
                MessageBox.Show(errorMessage);
                password.Text = "";
            }
        }
    }
}
