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
    public partial class Flight : Form
    {
        Forms.UserProfile userProfile;
        Forms.BuyTicket buyTicket;

        public Flight()
        {
            InitializeComponent();
        }

        private void Flight_Load(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            userProfile = new Forms.UserProfile();
            SwitchForms.SwitchFormsMethod(ref userProfile, this);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            buyTicket = new Forms.BuyTicket();
            buyTicket.Show();
        }
    }
}
