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
        public BuyTicket()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Билет успешно оформлен!", "Уведомление");
            this.Close();
        }

        private void label8_Click(object sender, EventArgs e)
        {
            appeal = new Appeal();
            appeal.Show();
        }
    }
}
