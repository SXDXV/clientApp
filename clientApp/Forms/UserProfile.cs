using clientApp.Classes;
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
    public partial class UserProfile : Form
    {
        Forms.Administration administration = new Forms.Administration();
        Forms.Flight flight = new Forms.Flight();
        Forms.Usertickets usertickets = new Forms.Usertickets();
        Sign sign = new Sign();

        public UserProfile()
        {
            InitializeComponent();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            SwitchForms.SwitchFormsMethod(ref administration, this);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SwitchForms.SwitchFormsMethod(ref flight, this);
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
