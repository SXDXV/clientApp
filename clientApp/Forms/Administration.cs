using clientApp.Classes;
using MySql.Data.MySqlClient;
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
    public partial class Administration : Form
    {
        string check;
        static string con = "server=localhost;user=root;password=12345;database=airport;port=3306";
        MySqlConnection connection = new MySqlConnection(con);
        // Импользуемые формы
        Forms.UserProfile userProfile;

        public Administration()
        {
            InitializeComponent();
        }

        private void Administration_Load(object sender, EventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            /* Переход от формы к форме при помощи обощенного метода 
            ("Форма которая открывается","Форма которая закрывается")*/
            userProfile = new Forms.UserProfile();
            SwitchForms.SwitchFormsMethod(ref userProfile, this);
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            check = comboBox1.SelectedItem.ToString();
            try
            {
                connection.Open();
                string sql = "SELECT * FROM " + check + ";";
                MySqlDataAdapter adapter = new MySqlDataAdapter(sql, connection);
                DataSet ds = new DataSet();
                adapter.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
                connection.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            check = comboBox1.SelectedItem.ToString();
            try
            {
                connection.Open();
                string sql = "SELECT * FROM " + check + ";";
                MySqlDataAdapter adapter = new MySqlDataAdapter(sql, connection);
                DataSet ds = new DataSet();
                adapter.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
                connection.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataTable dTable = new DataTable();
            string sqlQuery;
            string nameTable = comboBox1.Text;

            try
            {
                connection.Open();
                sqlQuery = "DELETE FROM `" + comboBox1.SelectedItem.ToString() + "` WHERE " + dataGridView1.Columns[0].HeaderText.ToString() + " = '" + dataGridView1.CurrentRow.Cells[0].Value + "'";
                MySqlDataAdapter adapter = new MySqlDataAdapter(sqlQuery, connection);

                connection.Close();
                adapter.Fill(dTable);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            try
            {
                connection.Open();
                string sql = "SELECT * FROM `" + nameTable + "`;";
                MySqlDataAdapter adapter = new MySqlDataAdapter(sql, connection);
                DataSet ds = new DataSet(); adapter.Fill(ds); dataGridView1.DataSource = ds.Tables[0];
                connection.Close();
            }
            catch (Exception ex)
            { 
                MessageBox.Show(ex.ToString()); 
            }
        }
    }
}
