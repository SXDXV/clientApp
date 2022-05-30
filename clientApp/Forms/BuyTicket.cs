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
        static string conUser = "server=localhost;user=userAir;password=userAir12345;database=airport;port=3306";
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
                int place = Convert.ToInt32(numericUpDown1.Value);
                int flight = Convert.ToInt32(DataTransfer.checkCodeFlight.ToString());
                string passport;
                string eMail = "";
                string numberOfPhone;
                passport = textBox6.Text;
                if (textBox4.Text != "") { eMail = textBox4.Text; }
                numberOfPhone = textBox5.Text;

                DataTable dTable = new DataTable();
                DataTable dTable2 = new DataTable();
                DataTable dTable3 = new DataTable();
                string sqlQuerySelect;
                string sqlQueryAdd;
                string sqlQueryIns;

                string dataFormat = DataTransfer.checkBirth;
                dataFormat = dataFormat.Remove(10, 8);
                string[] format = dataFormat.Split('.');
                string dataCor = format[2] + "-" + format[1] + "-" + format[0];

                try
                {
                    connectionAdmin.Open();
                    sqlQuerySelect = "SELECT * FROM airport.билеты;";
                    MySqlDataAdapter adapter = new MySqlDataAdapter(sqlQuerySelect, connectionAdmin);
                    adapter.Fill(dTable);

                    //INSERT INTO `airport`.`клиенты` (`Паспортные данные`, `Фамилия`, `Имя`, `Отчество`, `Пол`, `Дата рождения`, `Почта`, `Мобильный телефон`) VALUES ('8888 888888', 'ф', 'и', 'о', 'м', '0200-11-08', 'fffff@gmail.com', '+79112045854');
                    sqlQueryIns = "INSERT INTO `airport`.`клиенты` (`Паспортные данные`, `Фамилия`, `Имя`, `Отчество`, `Пол`, `Дата рождения`, `Почта`, `Мобильный телефон`) VALUES ('"+passport+"', '"+lastname+"', '"+name+"', '"+midname+"', '"+DataTransfer.checkGender+"', '"+ dataCor+ "', '"+eMail+"', '"+numberOfPhone+"');";
                    MySqlDataAdapter adapter3 = new MySqlDataAdapter(sqlQueryIns, connectionAdmin);
                    adapter3.Fill(dTable3);

                    sqlQueryAdd = "INSERT INTO `airport`.`билеты` (`Номер билета`, `Паспортные данные`, `Место`, `Код рейса`, `Цена(без скидки)`) VALUES ('"+ (Convert.ToInt32(dTable.Rows[dTable.Rows.Count-1]["Номер билета"]) + 1) +"', '"+passport+"', '"+place+"', '"+flight+"', '"+DataTransfer.checkPriceBiz +"');";
                    MySqlDataAdapter adapter2 = new MySqlDataAdapter(sqlQueryAdd, connectionAdmin);
                    adapter2.Fill(dTable2);
                    connectionAdmin.Close();
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

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            label11.Text = "Цена: " + DataTransfer.checkPrice.ToString();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            label11.Text = "Цена: " + DataTransfer.checkPriceBiz.ToString();
        }
    }
}
