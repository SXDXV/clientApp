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
    public partial class EditingProfile : Form
    {
        Appeal appeal;
        UserProfile userProfile;
        public EditingProfile()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            appeal = new Appeal();
            appeal.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            userProfile = new UserProfile();
            SwitchForms.SwitchFormsMethod(ref userProfile, this);
        }
    }
}
