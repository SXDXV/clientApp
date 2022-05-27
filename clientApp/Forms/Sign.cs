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

namespace clientApp
{
    public partial class Sign : Form
    {
        //string check;
        static string conAdmin = "server=localhost;user=root;password=12345;database=airport;port=3306";
        static string conUser = "server=localhost;user=userAir;password=userAir;database=airport;port=3306";
        MySqlConnection connectionAdmin = new MySqlConnection(conAdmin);
        MySqlConnection connectionUser = new MySqlConnection(conUser);
        // Импользуемые формы
        Registration registration;
        Forms.Information information;
        Forms.UserProfile userProfile;

        public Sign()
        {
            InitializeComponent();
        }

        private void Sign_Load(object sender, EventArgs e)
        {
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void label6_Click(object sender, EventArgs e)
        {
            registration = new Registration();
            SwitchForms.SwitchFormsMethod(ref registration, this);
            //SwitchForms.SwitchFormsMethod<Registration, Sign>(ref registration, this);
        }

        private void label7_Click(object sender, EventArgs e)
        {
            /* Переход от формы к форме при помощи обощенного метода 
            ("Форма которая открывается","Форма которая закрывается")*/
            information = new Forms.Information();
            SwitchForms.SwitchFormsMethod(ref information, this);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                connection.Open();
                MySqlDataAdapter adapter = new MySqlDataAdapter(,connection);
                DataSet ds = new DataSet();
                adapter.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
                connection.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }


            userProfile = new Forms.UserProfile();
            SwitchForms.SwitchFormsMethod(ref userProfile, this);
        }
    }
}
