using CourseManagement.Client.BusinessLogic;
using System;
using System.Windows;
using System.Windows.Controls;

namespace CourseManagement.Client.View
{
    /// <summary>
    /// Interaktionslogik für wndNewPerson.xaml
    /// </summary>
    public partial class wndNewPerson : Window
    {
        public wndNewPerson()
        {
            InitializeComponent();
            if (ActiveUser.userIsAdmin() == false) cbxRole.Items.RemoveAt(2) ;
        }

        private void ComboBoxRole_SelectonChanged(object sender, SelectionChangedEventArgs e)
        {
            if (this.IsLoaded)
            {
                spUser.Height = 0;
                spStudent.Height = 0;

                switch (((ComboBoxItem)cbxRole.SelectedItem).Content.ToString())
                {
                    case "Student":
                        spStudent.Height = Double.NaN;
                        break;
                    case "User":
                        spUser.Height = Double.NaN;
                        break;
                }
            }
        }
    }
}
