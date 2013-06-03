using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Data;
using CourseManagement.Client.BusinessLogic;

namespace CourseManagement.Client.View
{
    /// <summary>
    /// Interaktionslogik für wndParticipant2Course.xaml
    /// </summary>
    public partial class WndParticipant2Course : Window
    {
        /// <summary>
        /// Temporary Data Storage with either all courses or all students
        /// to fill the listboxes
        /// </summary>
        DataTable temporaryData = null;
        
        int selectedCourse = 0;
        
       

        public WndParticipant2Course()
        {
            //this(-1);

        }

        public WndParticipant2Course(int selectedCourse)
        {
            InitializeComponent();
            temporaryData = CourseLogic.getInstance().getAll();

            fillingListboxeswithData();

            if(selectedCourse != -1)
            {
            foreach (ListBoxItem aListboxItem in lbxCourses.Items)
            {
                if(Convert.ToInt32(aListboxItem.Tag) == selectedCourse)
                {
                    lbxCourses.SelectedItem = aListboxItem;
                }
            }
            }
        }

        private void fillingListboxeswithData()
        {            
            foreach (DataRow aDataRow in temporaryData.Rows)
            {
                ListBoxItem ListboxItemCourse = new ListBoxItem();
                ListboxItemCourse.Content = aDataRow["Title"];
                ListboxItemCourse.Tag = aDataRow["CourseNr"];
                lbxCourses.Items.Add(ListboxItemCourse);            
            }
            temporaryData = StudentLogic.getInstance().getAll();
            foreach (DataRow aDataRow in temporaryData.Rows)
            {
                ListBoxItem ListBoxItemStudents = new ListBoxItem();
                string aString = aDataRow["Forename"].ToString() + " " + aDataRow["Surname"].ToString();
                ListBoxItemStudents.Content = aString;
                ListBoxItemStudents.Tag = aDataRow["ID"];
                lbxPartcicipants.Items.Add(ListBoxItemStudents);
            }
        }

        private void close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        


        /// <summary>
        /// Idea? Slecting one Course Shows Students of this course in green color in the other listbox or something like this.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lbxCourses_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //MessageBox.Show(((ListBoxItem)lbxCourses.SelectedItem).Tag.ToString());
            selectedCourse = Convert.ToInt32(((ListBoxItem)lbxCourses.SelectedItem).Tag);
            DataTable studentsFromSelectedCourse = StudentLogic.getInstance().getByCourse(selectedCourse);

            foreach (ListBoxItem aListBoxItem in lbxPartcicipants.Items)
            {
                aListBoxItem.Foreground = Brushes.Black;
                foreach (DataRow dr in studentsFromSelectedCourse.Rows)
                {

                    if (Convert.ToInt32(dr["ID"]) == Convert.ToInt32(aListBoxItem.Tag))
                    {
                        aListBoxItem.Foreground = Brushes.Green;
                    }
                }
            }
        }

        private void ButtonAddPerson2Course_CLick(object sender, RoutedEventArgs e)
        {
            if(lbxCourses.SelectedItem != null && lbxPartcicipants.SelectedItems != null)
            {
               foreach(ListBoxItem aListBOxItem in lbxPartcicipants.SelectedItems)
               {
                   //Jeder Student der grün ist, ist schon in dem Kurs, daher abfangen das er nicht doppelt
                   //hinzugefügt wird.
                   //Wie besser und gleich kurz?  So doch schon etwas unsauber
                   if (aListBOxItem.Foreground != Brushes.Green)  
                   {
                       
                       int i = Convert.ToInt32(((ListBoxItem)aListBOxItem).Tag);
                       MessageBox.Show(selectedCourse.ToString() + i.ToString());
                       //PaymentLogic.getInstance().create(selectedCourse, i);
                   }
               }
            }
        }


    }
}
