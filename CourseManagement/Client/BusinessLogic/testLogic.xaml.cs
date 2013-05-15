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
using CourseManagement.Client.DB.Model;

namespace CourseManagement.Client.BusinessLogic
{
    /// <summary>
    /// Interaktionslogik für testLogic.xaml
    /// </summary>
    public partial class testLogic : Window
    {
        public testLogic()
        {
            ActiveUser.login("admin", "admin");
            InitializeComponent();
            dg_Test.DataContext = LogicUtils.getNewDataTable(new Course());
        }

        private void btnTest_Click(object sender, RoutedEventArgs e)
        {
            ActiveUser.login("admin", "admin");
            StudentLogic pl = StudentLogic.getInstance();
           // dg_Test.CanUserAddRows = false;
            //dg_Test.CanUserDeleteRows = false;
            
            dg_Test.IsReadOnly = true;
            dg_Test.DataContext = pl.getAll();
            
            
        }

        private void tb_test_TextChanged(object sender, TextChangedEventArgs e)
        {
            StudentLogic pl = StudentLogic.getInstance();
            //dg_Test.DataContext = pl.search(tb_test.Text);
        }

        private void btn_test2_Click(object sender, RoutedEventArgs e)
        {
            //TestData.generateTestData();
        }


    }
}
