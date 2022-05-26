using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using clientApp.Classes;

namespace clientApp.Forms
{
    public partial class Information : Form
    {
        public Information()
        {
            InitializeComponent();
        }

        private void Information_Load(object sender, EventArgs e)
        {
            string textInfo;
            string path;
            try
            {
                //StreamReader sr = new StreamReader(AppDomain.Current.BaseDirectory,);
                //AppDomain.CurrentDomain.BaseDirectory
                /*path = Directory.GetCurrentDirectory();
                List<string>[] paths;
                paths.Append(path.Split('/'));
                for (int i=0; i<paths.Length; i++)
                {
                    if (paths[i]=="bin") paths.
                }*/
                StreamReader sr = new StreamReader("F:/Диста 20-21/курсач/client/clientApp/clientApp/TextFiles/Information.txt");
                textInfo = sr.ReadLine();
                while (textInfo != null)
                {
                    textBox1.Text = textInfo.ToString();
                    textInfo = sr.ReadLine();
                }
                sr.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                MessageBox.Show("Извлечение выполнено успешно");
            }
        }

        private void label15_Click(object sender, EventArgs e)
        {
            Sign sign = new Sign();
            SwitchForms.SwitchFormsMethod(ref sign, this);
        }
    }
}
