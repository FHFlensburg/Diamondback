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

        public WndParticipant2Course()
        {
            InitializeComponent();

            fillingListboxeswithData();

        }

        private void fillingListboxeswithData()
        {
            temporaryData = CourseLogic.getInstance().getAll();
            for (int i = 0; i < temporaryData.Rows.Count; i++)
            {
                lbxCourses.Items.Add(temporaryData.Rows[i]["Title"]);
            }

            temporaryData = StudentLogic.getInstance().getAll();
            for (int i = 0; i < temporaryData.Rows.Count; i++)
            {
                lbxPartcicipants.Items.Add(temporaryData.Rows[i]["Surname"]);
            }
        }

        private void close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void add_Click(object sender, RoutedEventArgs e)
        {

        }

        /// <summary>
        /// 2late for more today
        /// Idea? Slecting one Course Shows Students of this course in green color in the other listbox or something like this.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lbxCourses_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataTable studentsOfSelectedCourse = null;

            //for (int i = 0; i < lbxPartcicipants.Items.Count;i++)
            //{
                
            //    if(StudentLogic.getInstance().search(lbxCourses.SelectedItem)

            //}
        }
    }
}
