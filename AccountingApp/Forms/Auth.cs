using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AccountingApp.Forms
{
    public partial class Auth : Form
    {
        public Auth()
        {
            InitializeComponent();
        }

        private void login_Click(object sender, EventArgs e)
        {
          
            // Вызываем метод проверки пары логина/пароля
            if (App.instance.CheckAuth(usernameBox.Text, passwordBox.Text))
            {
                // И если ок - закрываем авторизацию
                DialogResult = DialogResult.OK;
                Close();
            }
            else
                // Иначе крякаем ошибочкой
                MessageBox.Show("Неверное имя пользователя или пароль.");
            
        }
    }
}
