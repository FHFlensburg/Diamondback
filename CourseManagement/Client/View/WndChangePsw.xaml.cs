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
        /// <summary>
        /// Default Constructor
        /// </summary>
        public WndChangePsw()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Saves the changed password or shows a Messagebox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_save_Click(object sender, RoutedEventArgs e)
        {
            try
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
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
