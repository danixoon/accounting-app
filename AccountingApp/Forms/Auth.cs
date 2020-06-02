﻿using System;
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
          
            if (App.instance.CheckAuth(usernameBox.Text, passwordBox.Text))
            {
                DialogResult = DialogResult.OK;
                Close();
            }
            else
                MessageBox.Show("Неверное имя пользователя или пароль.");
            
        }
    }
}