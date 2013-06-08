using CourseManagement.Client.BusinessLogic;
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
    /// Interaktionslogik für WndChangePsw.xaml
    /// </summary>
    public partial class WndChangePsw : Window
    {
        public WndChangePsw()
        {
            InitializeComponent();
        }

        private void btn_save_Click(object sender, RoutedEventArgs e)
        {
            if (!ActiveUser.correctPasswort(pswBxOld.Password)) MessageBox.Show("Altes Passwort ist falsch");
            else if (!ActiveUser.possiblePassword(pswBxNew.Password)) MessageBox.Show("Neues Passwort entspricht nicht den Anforderungen:\nMindestens 5 Zeichen.");
            else if (pswBxNew.Password != pswBxNew2.Password) MessageBox.Show("Wiederholung unterscheidet sich vom Neuen Passwort");
            else
            {
                ActiveUser.changePassword(pswBxNew.Password);
                this.Close();
            }
        }
    }
}
