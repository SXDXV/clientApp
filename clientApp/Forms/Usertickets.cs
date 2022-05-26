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
    public partial class Usertickets : Form
    {
        Forms.UserProfile userProfile;

        public Usertickets()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            userProfile = new Forms.UserProfile();
            SwitchForms.SwitchFormsMethod(ref userProfile, this);
        }
    }
}
