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
    public partial class Administration : Form
    {
        // Импользуемые формы
        Forms.UserProfile userProfile;

        public Administration()
        {
            InitializeComponent();
        }

        private void Administration_Load(object sender, EventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            /* Переход от формы к форме при помощи обощенного метода 
            ("Форма которая открывается","Форма которая закрывается")*/
            userProfile = new Forms.UserProfile();
            SwitchForms.SwitchFormsMethod(ref userProfile, this);
        }
    }
}
