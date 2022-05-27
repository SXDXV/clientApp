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
    public partial class Flight : Form
    {
        string date;
        string townFrom;
        string townTo;

        Forms.UserProfile userProfile;
        Forms.BuyTicket buyTicket;

        static string con = "server=localhost;user=root;password=12345;database=airport;port=3306";
        MySqlConnection connectionUser = new MySqlConnection(con);

        public Flight()
        {
            InitializeComponent();
        }

        private void Flight_Load(object sender, EventArgs e)
        {
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "yyyy-MM-dd";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            userProfile = new Forms.UserProfile();
            SwitchForms.SwitchFormsMethod(ref userProfile, this);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            buyTicket = new Forms.BuyTicket();
            buyTicket.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            date = dateTimePicker1.Text;
            townFrom = comboBox1.SelectedItem.ToString();
            townTo = comboBox2.SelectedItem.ToString();

            DataTable dTable = new DataTable();
            try
            {
                connectionUser.Open();
                string sql = "SELECT * FROM airport.рейсы where Дата = '"+date+"' and Откуда = '"+townFrom+"' and Куда = '"+townTo+"';";
                MySqlDataAdapter adapter = new MySqlDataAdapter(sql, connectionUser);
                DataSet ds = new DataSet();
                adapter.Fill(dTable);
                dataGridView1.DataSource = ds.Tables[0];
                connectionUser.Close();

                DataTransfer.checkDate = date;
                DataTransfer.checkCodeFlight = Convert.ToInt32(dTable.Rows[0]["Код рейса"]); ;
                DataTransfer.checkPrice = Convert.ToInt32(dTable.Rows[0]["Цена(без скидки)"]);

            }
            catch (Exception ex)
            {
                connectionUser.Close();
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
