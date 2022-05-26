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
            // Создание экземпляра формы
            Registration registration = new Registration();
            // Присвоение координат открытия новой формы
            registration.StartPosition = FormStartPosition.Manual;
            registration.Location = Location;
            // Показ новой формы и скрытие текущей
            registration.Show();
            this.Hide();
        }
    }
}
