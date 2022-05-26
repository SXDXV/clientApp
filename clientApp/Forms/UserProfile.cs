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
        Forms.Administration administration;
        Forms.Flight flight;
        Forms.Usertickets usertickets;
        Forms.EditingProfile editingProfile;
        Sign sign;

        public UserProfile()
        {
            InitializeComponent();
        }

        private void UserProfile_Load(object sender, EventArgs e)
        {
            administration = new Forms.Administration();
            flight = new Forms.Flight();
            usertickets = new Forms.Usertickets();
            editingProfile = new Forms.EditingProfile();
            sign = new Sign();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            SwitchForms.SwitchFormsMethod(ref sign, this);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SwitchForms.SwitchFormsMethod(ref flight, this);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SwitchForms.SwitchFormsMethod(ref usertickets, this);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SwitchForms.SwitchFormsMethod(ref editingProfile, this);
        }

        private void label6_Click(object sender, EventArgs e)
        {
            SwitchForms.SwitchFormsMethod(ref administration, this);
        }
    }
}
