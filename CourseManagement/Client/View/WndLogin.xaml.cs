﻿using CourseManagement.Client.BusinessLogic;
using System;
using System.Windows;

namespace CourseManagement.Client.View
{
    /// <summary>
    /// Interaktionslogik für WndLogin.xaml
    /// </summary>
    public partial class WndLogin : Window
    {
        public WndLogin()
        {
            InitializeComponent(); 

            //Nur im Testbetrieb
            tbPasswordStatus.Text = "user: admin, psw: admin";
            tbUsername.Text = "admin";
            pwbPassword.Password = "admin";
        }

        //Zusammen mit checkPassword auszulagern
        private int countLoginAttempts = 0; 

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            
            if (checkPassword(tbUsername.Text,pwbPassword.Password))
            {
                DialogResult = true;
            }
            else
            {
                
                tbPasswordStatus.Text = "Passwort falsch(" + ++countLoginAttempts + ". Versuch)";
            }
        }

        private bool checkPassword(string userName, string password)
        {
            bool passwordOkay = false;
            try
            {
                passwordOkay= ActiveUser.login(userName, password);
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
            }
            return passwordOkay;
        }
    }
}
