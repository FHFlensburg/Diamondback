using CourseManagement.Client.BusinessLogic;
using System;
using System.Data;
using System.Windows;
using System.Windows.Controls;

namespace CourseManagement.Client.View
{
    /// <summary>
    /// Interaktionslogik für WndNewPayment.xaml
    /// </summary>
    public partial class WndNewPayment : Window
    {
        int selectedTag = 0;
        DataTable course = CourseLogic.getInstance().getAll();
        DataTable datatable = new DataTable
        {
            Columns = 
                     { "ID", 
                        "Vorname",
                        "Nachname",
                        "Bezahlt" 
                     }
        };


        public WndNewPayment()
        {
            InitializeComponent();
            setGuiElements();
        }

        private void cbPaymentCourse_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //dgPayment.
            lblPaymentGrid.Visibility = System.Windows.Visibility.Visible;
            dgPayment.Visibility = System.Windows.Visibility.Visible;

            selectedTag = Convert.ToInt32(((ComboBoxItem)cbPaymentCourse.SelectedItem).Tag);

            
            dgPayment.DataContext = StudentLogic.getInstance().getByCourse(selectedTag);
            //for (int j = 0; j < student.Rows.Count; j++)
            //{
            //    DataRow dataRow = datatable.NewRow();
            //    dataRow["ID"] = student.Rows[j][0];
            //    dataRow["Vorname"] = student.Rows[j]["Forename"];
            //    dataRow["Nachname"] = student.Rows[j]["Surname"];
            //    datatable.Rows.Add(dataRow);
            //    dgPayment.ItemsSource = datatable.DefaultView;
            //}
        }

        private void setGuiElements()
        {
           

           for (int i = 0; i < course.Rows.Count; i++)
           {
               ComboBoxItem cbItem = new ComboBoxItem();
               cbItem.Content = course.Rows[i]["Title"].ToString();
               cbItem.Tag = course.Rows[i]["CourseNr"].ToString();

               cbPaymentCourse.Items.Add(cbItem);
           }

           
        }
    }
}
