using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

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
        }

        //Zusammen mit checkPassword auszulagern
        private int countLoginAttempts = 0; 

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            
            if (checkPassword())
            {
                DialogResult = true;
            }
            else
            {
                
                tbPasswordStatus.Text = "Passwort falsch(" + ++countLoginAttempts + ". Versuch)";
            }
        }

        private bool checkPassword()
        {
            //TODO
            //DB Abfrage nach Password
            //Hier noch weg zu lagern
            return true;
        }
    }
}
