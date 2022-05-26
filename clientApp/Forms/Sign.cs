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
            Registration registration = new Registration();
            SwitchForms.SwitchFormsMethod<Registration, Sign>(ref registration, this);
        }

        private void label7_Click(object sender, EventArgs e)
        {
            Forms.Information information = new Forms.Information();
            SwitchForms.SwitchFormsMethod<Forms.Information, Sign>(ref information, this);
        }
    }
}
