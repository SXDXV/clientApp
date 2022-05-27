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
    public static class ControlID
    {
        public static string checkLogin { get; set; }
        public static string checkPassword { get; set; }
    }
    public partial class Sign : Form
    {
        static string conUser = "server=localhost;user=userAir;password=;database=airport;port=3306";
        MySqlConnection connectionUser = new MySqlConnection(conUser);
        
        // Импользуемые формы
        Registration registration;
        Forms.Information information;
        Forms.UserProfile userProfile;

        //public static string checkLogin { get; set; }
        //public static string checkPassword { get; set; }

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
            string checkLog = textBox1.Text;
            string checkPass = textBox2.Text;
            try
            {
                connectionUser.Open();
                DataTable dTable = new DataTable();
                //String sqlQuery = "SELECT * FROM airport.пользователи_пп where Логин = '"+checkLogin+"' and Пароль = '"+checkPassword+"';";
                String sqlQuery = "SELECT * FROM airport.`пользователи_пп` where `Логин` = '" + checkLog + "' and `Пароль` = '" + checkPass + "';";
                MySqlDataAdapter adapter = new MySqlDataAdapter(sqlQuery, connectionUser);
                adapter.Fill(dTable);
                if (dTable.Rows.Count != 0)
                {
                    ControlID.checkLogin = checkLog;
                    ControlID.checkPassword = checkPass;
                    userProfile = new Forms.UserProfile();
                    SwitchForms.SwitchFormsMethod(ref userProfile, this);
                }
                else
                {
                    MessageBox.Show("Подождите, такого пользователя не существует. Проверьте введенные данные, или зарегистрируйтесь еще раз.", "Ой...");
                }
                connectionUser.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
