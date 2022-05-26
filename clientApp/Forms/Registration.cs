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
        public Registration()
        {
            InitializeComponent();
        }

        private void label15_Click(object sender, EventArgs e)
        {
            // Создание экземпляра формы
            Sign sign = new Sign();
            // Присвоение координат открытия новой формы
            sign.StartPosition = FormStartPosition.Manual;
            sign.Location = Location;
            // Показ новой формы и скрытие текущей
            sign.Show();
            this.Hide();
        }
    }
}
