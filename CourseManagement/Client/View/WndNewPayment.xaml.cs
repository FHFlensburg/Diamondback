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
        int selectedTag = 0;

        public WndNewPayment()
        {
            InitializeComponent();
            setGuiElements();
        }

        private void cbPaymentCourse_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            lblPaymentGrid.Visibility = System.Windows.Visibility.Visible;
            dgPayment.Visibility = System.Windows.Visibility.Visible;

            selectedTag = Convert.ToInt16(((ComboBoxItem)cbPaymentCourse.SelectedItem).Tag);
        }

        private void setGuiElements()
        {
           DataTable datatable = new DataTable
            {
                Columns = 
                     { "ID", 
                        "Vorname",
                        "Nachname",
                        "Bezahlt" 
                     }
            };

            DataTable course = CourseLogic.getInstance().getAll();
            for(int i = 0; i < course.Rows.Count; i++)
            {
                ComboBoxItem cbItem = new ComboBoxItem();
                cbItem.Content = course.Rows[i]["Title"].ToString();
                cbItem.Tag=course.Rows[i]["CourseNr"].ToString();

                cbPaymentCourse.Items.Add(cbItem);
            }

            DataTable student = StudentLogic.getInstance().getByCourse(26);
            for (int j = 0; j < student.Rows.Count; j++)
            {
                DataRow dataRow = datatable.NewRow();
                dataRow["ID"] = student.Rows[j][0];
                dataRow["Vorname"] = student.Rows[j]["Forename"];
                dataRow["Nachname"] = student.Rows[j]["Surname"];
                datatable.Rows.Add(dataRow);
                dgPayment.ItemsSource = datatable.DefaultView;
            }
        }
    }
}
