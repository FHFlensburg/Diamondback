using CourseManagement.Client.BusinessLogic;
using System;
using System.Collections.Generic;
using System.Data;
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
    /// Interaktionslogik für WndNewPayment.xaml
    /// </summary>
    public partial class WndNewPayment : Window
    {
        public WndNewPayment()
        {
            InitializeComponent();
            setGuiElements();
        }

        private void cbPaymentCourse_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            lblPaymentGrid.Visibility = System.Windows.Visibility.Visible;
            dgPayment.Visibility = System.Windows.Visibility.Visible;
        }

        private void setGuiElements()
        {
            DataTable course = CourseLogic.getInstance().getAll();
            for(int i = 0; i < course.Rows.Count; i++)
            {
                ComboBoxItem cbItem = new ComboBoxItem();
                cbItem.Content = course.Rows[i]["Title"].ToString();
                cbItem.Tag=course.Rows[i]["CourseNr"].ToString();

                cbPaymentCourse.Items.Add(cbItem);
            }


            DataTable datatable = new DataTable
            {
                Columns = 
                     { "ID", 
                        "Vorname",
                        "Nachname",
                        "Bezahlt" 
                     }
            };

            DataTable student = StudentLogic.getInstance().getAll();
            for (int i = 0; i < student.Rows.Count; i++)
            {
                //DataRow datarow = datatable.NewRow();
                //datarow["ID"] = course.Rows[i][0].ToString();
                //datarow["Vorname"] = course.Rows[i]["Vorname"].ToString();
                //datarow["Nachname"] = course.Rows[i]["Nachname"].ToString();
                //datarow["Bezahlt"] = course.Rows[i]["Bezahlt"].ToString();
                //datatable.Rows.Add(datarow);
                //dgPayment.ItemsSource = datatable.DefaultView;
            }
        }
    }
}
