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
    /// Interaktionslogik für wndNewPerson.xaml
    /// </summary>
    public partial class wndNewPerson : Window
    {
        public wndNewPerson()
        {
            InitializeComponent();
        }

        private void ComboBoxRole_SelectonChanged(object sender, SelectionChangedEventArgs e)
        {
            //Tutor"/>
                    //<ComboBoxItem x:Name="cbxiStudent" Content="Student"/>
                    //<ComboBoxItem x:Name="cbxiUser" Content="User" /
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
