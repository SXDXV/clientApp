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
        static string conUser = "server=localhost;user=userAir;password=userAir12345;database=airport;port=3306";
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
                string sqlQuery = "SELECT * FROM airport.`пользователи_пп` where `Логин` = '" + checkLog + "' and `Пароль` = MD5('" + checkPass + "');";
                MySqlDataAdapter adapter = new MySqlDataAdapter(sqlQuery, connectionUser);
                adapter.Fill(dTable);
                if (dTable.Rows.Count != 0)
                {
                    DataTransfer.checkLogin = checkLog;
                    DataTransfer.checkPassword = dTable.Rows[0]["Пароль"].ToString();
                    DataTransfer.checkGender = dTable.Rows[0]["Пол"].ToString();
                    DataTransfer.checkBirth = dTable.Rows[0]["Дата рождения"].ToString();
                    DataTransfer.checkPasport = dTable.Rows[0]["Паспортные данные"].ToString();
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
