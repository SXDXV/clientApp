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
    public partial class Usertickets : Form
    {
        Forms.UserProfile userProfile;
        static string conUser = "server=localhost;user=root;password=12345;database=airport;port=3306";
        MySqlConnection connectionUser = new MySqlConnection(conUser);

        public Usertickets()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            userProfile = new Forms.UserProfile();
            SwitchForms.SwitchFormsMethod(ref userProfile, this);
        }

        private void Usertickets_Load(object sender, EventArgs e)
        {
            label2.Text = "Здравствуйте, " + DataTransfer.checkLogin + "!";
            DataTable dTable = new DataTable();
            DataSet ds = new DataSet();
            connectionUser.Open();
            string sqlQuerySelect = "SELECT * FROM airport.билеты WHERE `Паспортные данные` = '"+DataTransfer.checkPasport+"';";
            MySqlDataAdapter adapter = new MySqlDataAdapter(sqlQuerySelect, connectionUser);
            adapter.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
        }
    }
}
