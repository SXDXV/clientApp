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
        // Импользуемые формы
        Registration registration = new Registration();
        Forms.Information information = new Forms.Information();
        Forms.UserProfile userProfile = new Forms.UserProfile();

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
            SwitchForms.SwitchFormsMethod(ref registration, this);
            //SwitchForms.SwitchFormsMethod<Registration, Sign>(ref registration, this);
        }

        private void label7_Click(object sender, EventArgs e)
        {
            /* Переход от формы к форме при помощи обощенного метода 
            ("Форма которая открывается","Форма которая закрывается")*/
            SwitchForms.SwitchFormsMethod(ref information, this);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SwitchForms.SwitchFormsMethod(ref userProfile, this);
        }
    }
}
