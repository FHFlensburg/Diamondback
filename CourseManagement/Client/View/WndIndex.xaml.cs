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
using Microsoft.Windows.Controls.Ribbon;
using System.Data;


namespace CourseManagement.Client.View
{
    /// <summary>
    /// Interaktionslogik für WndIndex.xaml
    /// </summary>
    public partial class WndIndex : RibbonWindow
    {
        public WndIndex()
        {
            InitializeComponent();
        }

        private void Ribbon_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            Controller.Start.viewChanged(this, e);
            //Noch zu überarbeiten und zu prüfen ob sauberer Stil
             
        }

        private void RibbonButtonNewCourse_Click(object sender, RoutedEventArgs e)
        {
            WndNewCourse aNewCourse = new WndNewCourse();
            aNewCourse.ShowDialog();
        }

        private void RibbonButtonNewPerson_Click(object sender, RoutedEventArgs e)
        {
            wndNewPerson aNewPerson = new wndNewPerson();
            aNewPerson.ShowDialog();
        }

        private void RibbonButtonNewRoom_Click(object sender, RoutedEventArgs e)
        {
            WndNewRoom aNewRoom = new WndNewRoom();
            aNewRoom.ShowDialog();
        }

        private void Row_DoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (sender != null)
            {
                try
                {
                    WndParticipant2Course aNewAllocation = new WndParticipant2Course();
                    //next one throws exception, needs some polish
                    //aNewAllocation.dgParticipant.DataContext = this.dgCourse.DataContext;
                    aNewAllocation.ShowDialog();
                }
                catch
                {
                    MessageBox.Show("Something went wrong");
                }
            }
        }

       

    }
}
