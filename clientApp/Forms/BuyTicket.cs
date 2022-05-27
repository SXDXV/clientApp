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
    public partial class BuyTicket : Form
    {
        Appeal appeal;

        static string conAdmin = "server=localhost;user=root;password=12345;database=airport;port=3306";
        static string conUser = "server=localhost;user=userAir;password=;database=airport;port=3306";
        MySqlConnection connectionAdmin = new MySqlConnection(conAdmin);
        MySqlConnection connectionUser = new MySqlConnection(conUser);

        public BuyTicket()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" || textBox2.Text != "" || textBox3.Text != "" || textBox4.Text != "" || textBox5.Text != "" || textBox6.Text != "" && radioButton1.Checked || radioButton2.Checked)
            {
                string login = textBox1.Text;
                string[] FIO = login.Split(' ');
                string name = FIO[1];
                string midname = FIO[2];
                string lastname = FIO[0];
                string passport;
                string eMail = "";
                string numberOfPhone;
                passport = textBox6.Text;
                if (textBox4.Text != "") { eMail = textBox4.Text; }
                numberOfPhone = textBox5.Text;

                DataTable dTable = new DataTable();
                string sqlQueryDel;
                string sqlQueryAdd;

                try
                {
                    //connectionAdmin.Open();
                    ////sqlQuery = ("INSERT INTO `airport`.`пользователи_пп` (`Логин`, `Пароль`, `Роль`) VALUES ('" + login + "', '" + password + "', '1');");
                    //sqlQueryDel = ("DELETE FROM `airport`.`пользователи_пп` WHERE `Логин` = '" + DataTransfer.checkLogin + "' and `Пароль` = '" + DataTransfer.checkPassword + "';");
                    ////"('" + passport + "', '" + lastname + "', '" + name + "', '" + midname + "', '" + gender + "', '" + birth + "', '" + eMail + "', '" + numberOfPhone + "', '" + login + "', '" + password + "', '1');");
                    //MySqlDataAdapter adapter = new MySqlDataAdapter(sqlQueryDel, connectionAdmin);
                    //adapter.Fill(dTable);
                    //connectionAdmin.Close();

                    //connectionAdmin.Open();
                    //sqlQueryAdd = ("INSERT INTO `airport`.`пользователи_пп` " +
                    //    "(`Паспортные данные`, `Фамилия`, `Имя`, `Отчество`, `Пол`, `Дата рождения`, `Почта`, `Мобильный телефон`, `Логин`, `Пароль`, `Роль`) VALUES " +
                    //    "('" + passport + "', '" + lastname + "', '" + name + "', '" + midname + "', '" + gender + "', '" + birth + "', '" + eMail + "', '" + numberOfPhone + "', '" + DataTransfer.checkLogin + "', '" + DataTransfer.checkPassword + "', '" + DataTransfer.checkRole + "');");
                    //MySqlDataAdapter adapter2 = new MySqlDataAdapter(sqlQueryAdd, connectionAdmin);
                    //adapter2.Fill(dTable);
                    //MessageBox.Show("Вы успешно сменили персональные данные!", "Уведомление");
                    //connectionAdmin.Close();

                    //MessageBox.Show("Билет успешно оформлен!", "Уведомление");
                    //this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    connectionAdmin.Close();
                }
            }
            else
            {
                MessageBox.Show("Введен неверный пароль", "Ошибка");
            }

        }

        private void label8_Click(object sender, EventArgs e)
        {
            appeal = new Appeal();
            appeal.Show();
        }

        private void BuyTicket_Load(object sender, EventArgs e)
        {
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "yyyy-MM-dd";

            try
            {
                connectionAdmin.Open();
                string sqlQuery = "SELECT * FROM airport.пользователи_пп where `Логин` = '" + DataTransfer.checkLogin + "' and `Пароль` = '" + DataTransfer.checkPassword + "';";
                DataTable dTable = new DataTable();
                MySqlDataAdapter adapter = new MySqlDataAdapter(sqlQuery, connectionUser);
                adapter.Fill(dTable);

                textBox1.Text = dTable.Rows[0]["Логин"].ToString();
                dateTimePicker1.Text = DateTime.Now.ToString();
                textBox6.Text = dTable.Rows[0]["Паспортные данные"].ToString();
                textBox4.Text = dTable.Rows[0]["Почта"].ToString();
                textBox5.Text = dTable.Rows[0]["Мобильный телефон"].ToString();
                textBox7.Text = DataTransfer.checkCodeFlight.ToString();
                connectionAdmin.Close();
            }
            catch (Exception ex)
            {
                connectionAdmin.Open();
                MessageBox.Show(ex.Message);
            }
        }

        private void label11_Click(object sender, EventArgs e)
        {

        }
    }
}
