using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace clientApp.Classes
{
    class SwitchForms
    {
        Form form1, form2;

        public SwitchForms(Form f1, Form f2)
        {
            form1 = f1;
            form2 = f2;
        }

        // Обобщенный метод открытия формы
        public static void SwitchFormsMethod<TForm1, TForm2>(ref TForm1 classForm, TForm2 f2)
            where TForm1 : Form, new()
            where TForm2 : Form, new()
        {
            classForm = new TForm1();
            // Присвоение координат открытия новой формы
            classForm.StartPosition = FormStartPosition.CenterScreen;
            // Показ новой формы и скрытие текущей
            classForm.Show();
            f2.Hide();
        }
    }
}
