using clientApp.Classes;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace clientApp.Forms
{

    public partial class UserProfile : Form
    {
        Forms.Administration administration;
        Forms.Flight flight;
        Forms.Usertickets usertickets;
        Forms.EditingProfile editingProfile;
        Sign sign = new Sign();

        static string conAdmin = "server=localhost;user=root;password=12345;database=airport;port=3306";
        static string conUser = "server=localhost;user=userAir;password=;database=airport;port=3306";
        MySqlConnection connectionAdmin = new MySqlConnection(conAdmin);
        MySqlConnection connectionUser = new MySqlConnection(conUser);

        int role; // 1 - обычный пользователь; 2 - администратор

        public UserProfile()
        {
            InitializeComponent();
        }

        private void UserProfile_Load(object sender, EventArgs e)
        {
            role = 1;
            string login = DataTransfer.checkLogin;
            string password = DataTransfer.checkPassword;
            //string login = sign.checkLogin;
            //string password = sign.checkPassword;
            try
            {
                connectionUser.Open();
                DataTable dTable = new DataTable();
                String sqlQuery = "SELECT * FROM airport.`пользователи_пп` where `Логин` = '" + login + "' and `Пароль` = '" + password + "' and Роль = '"+role+"';";
                MySqlDataAdapter adapter = new MySqlDataAdapter(sqlQuery, connectionUser);
                adapter.Fill(dTable);
                if (dTable.Rows.Count == 0)
                {
                    role = 2;
                }
                else
                {
                    role = 1;
                }
                DataTransfer.checkRole = role;
                connectionUser.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {
            SwitchForms.SwitchFormsMethod(ref sign, this);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            flight = new Forms.Flight();
            SwitchForms.SwitchFormsMethod(ref flight, this);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            usertickets = new Forms.Usertickets();
            SwitchForms.SwitchFormsMethod(ref usertickets, this);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            editingProfile = new Forms.EditingProfile();
            SwitchForms.SwitchFormsMethod(ref editingProfile, this);
        }

        private void label6_Click(object sender, EventArgs e)
        {
            if (role == 2)
            {
                administration = new Forms.Administration();
                SwitchForms.SwitchFormsMethod(ref administration, this);
            }
            else { MessageBox.Show("Извините, но вы не являетесь администратором", "Ты куда?"); }
        }
    }
}
