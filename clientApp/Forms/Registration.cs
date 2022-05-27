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

namespace clientApp
{
    public partial class Registration : Form
    {
        public string login;
        public string birth;
        public string gender;
        public string passport;
        public string eMail;
        public string numberOfPhone;
        public string password;

        static string con = "server=localhost;user=root;password=12345;database=airport;port=3306";
        MySqlConnection connection = new MySqlConnection(con);

        Sign sign;

        public Registration()
        {
            InitializeComponent();
        }

        private void label15_Click(object sender, EventArgs e)
        {
            sign = new Sign();
            SwitchForms.SwitchFormsMethod(ref sign, this);
        }

        private void Registration_Load(object sender, EventArgs e)
        {
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "yyyy-MM-dd";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //INSERT INTO `airport`.`пользователи_пп` (`Id`, `Логин`, `Пароль`, `Роль`) VALUES ('1', 'Lvbnhbq', '1111', '1');
            //INSERT INTO `airport`.`пользователи_пп` (`Паспортные данные`, `Фамилия`, `Имя`, `Отчество`, `Пол`, `Дата рождения`, `Почта`, `Мобильный телефон`, `Логин`, `Пароль`, `Роль`) VALUES ('1111 111111', '1', '1', '1', '1', '1997-09-09', 'в', 'в', 'в', 'в', '2');
            if (textBox1.Text!="" || textBox2.Text != "" || textBox3.Text != "" || textBox5.Text != "" || textBox6.Text != "" && radioButton1.Checked || radioButton2.Checked)
            {
                if (textBox2.Text == textBox3.Text)
                {
                    login = textBox1.Text;
                    string[] FIO = login.Split(' ');
                    string name = FIO[1];
                    string midname = FIO[2];
                    string lastname = FIO[1];
                    birth = dateTimePicker1.Text;
                    if (radioButton1.Checked) { gender = radioButton1.Text; }
                    else { gender = radioButton2.Text; }
                    passport = textBox6.Text;
                    if (textBox4.Text != "") { eMail = textBox4.Text; }
                    numberOfPhone = textBox5.Text;
                    password = textBox2.Text;

                    DataTable dTable = new DataTable();
                    String sqlQuery;

                    try
                    {
                        connection.Open();
                        //sqlQuery = ("INSERT INTO `airport`.`пользователи_пп` (`Логин`, `Пароль`, `Роль`) VALUES ('" + login + "', '" + password + "', '1');");
                        sqlQuery = ("INSERT INTO `airport`.`пользователи_пп` " +
                            "(`Паспортные данные`, `Фамилия`, `Имя`, `Отчество`, `Пол`, `Дата рождения`, `Почта`, `Мобильный телефон`, `Логин`, `Пароль`, `Роль`) VALUES " +
                            "('" + passport + "', '" + lastname + "', '" + name + "', '" + midname + "', '" + gender + "', '" + birth + "', '" + eMail + "', '" + numberOfPhone + "', '" + login + "', '" + password + "', '1');");
                        MySqlDataAdapter adapter = new MySqlDataAdapter(sqlQuery, connection);

                        connection.Close();
                        adapter.Fill(dTable);

                        sign = new Sign();
                        MessageBox.Show("Вы успешно зарегистрированы!", "Уведомление");
                        SwitchForms.SwitchFormsMethod(ref sign, this);
                        connection.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                        connection.Close();
                    }
                }
                else
                {
                    MessageBox.Show("Ваши пароли не совпадают!", "Ошибка!");
                }
            }
            else 
            {
                MessageBox.Show("Необходимо заполнить все обязательные поля!", "Ошибка!");
            }
        }
    }
}
