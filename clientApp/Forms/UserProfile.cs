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
        Sign sign;

        static string conAdmin = "server=localhost;user=root;password=12345;database=airport;port=3306";
        static string conUser = "server=localhost;user=userAir;password=;database=airport;port=3306";
        MySqlConnection connectionAdmin = new MySqlConnection(conAdmin);
        MySqlConnection connectionUser = new MySqlConnection(conUser);

        int role = 1; // 1 - обычный пользователь; 2 - администратор

        public UserProfile()
        {
            InitializeComponent();
        }

        private void UserProfile_Load(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {
            sign = new Sign();
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
            administration = new Forms.Administration();
            SwitchForms.SwitchFormsMethod(ref administration, this);
        }
    }
}
