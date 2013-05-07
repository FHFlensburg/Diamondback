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

            Controller.Start.foo(this, e);
            

            
            //Auszulagern nach Controller. Test zur Unterscheidung welcher Tab ausgewählt ist
            //-> funktioniert!
             
            //if (mainRibbon.SelectedIndex == 1)
            //{
            //    MessageBox.Show("Winner");
            //}
            //else
            //{
            //    MessageBox.Show("Looser");
            //}
             
        }

       

    }
}
