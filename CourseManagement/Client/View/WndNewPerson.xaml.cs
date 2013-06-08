using CourseManagement.Client.BusinessLogic;
using System;
using System.Data;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace CourseManagement.Client.View
{
    /// <summary>
    /// Interaktionslogik für wndNewPerson.xaml
    /// </summary>
    public partial class wndNewPerson : Window
    {
        private DataTable selectedPerson = null;
        private int studentNr = 0;
        private int kindOfPerson = 0;
        private int tutorNr = 0;
        private string surname = null;
        private string forename = null;
        private string birthyear = "";
        private string street = "";
        private string mobilePhone = "";
        private string mail = "";
        private string fax = "";
        private string privatePhone = "";
        private string gender = "";
        private bool isActive = true;
        private string title = "";
        private string city = "";
        private string cityCode = "";

        private string iban = "";
        private string bic = "";
        private string depositor = "";
        private string nameOfBank = "";

        private int userNr = 0;
        private string username = null;
        private string password = "";
        private bool isAdmin = false;



        /// <summary>
        /// standard constructor for window newPerson
        /// </summary>
        public wndNewPerson()
        {
            InitializeComponent();
            if (ActiveUser.userIsAdmin() == false) cbxRole.Items.RemoveAt(2);

        }

        public wndNewPerson(DataTable selectedPerson, int kindOfPerson)
        {
            InitializeComponent();
            if (ActiveUser.userIsAdmin() == false) cbxRole.Items.RemoveAt(2);
            this.kindOfPerson = kindOfPerson;
            this.selectedPerson = selectedPerson;
            fillingDataFieldsWithProvidedData();

            checkKindofPerson();
        }



        private void wndPerson_Loaded(object sender, RoutedEventArgs e)
        {
            changingRole();
        }

        private void ButtonSavePerson_Click(object sender, RoutedEventArgs e)
        {
            insertPerson();
        }

        private void insertPerson()
        {
            fillingNonMandatoryFields();
            if (cbxRole.SelectedIndex != -1)
            {
                if (surname != "")
                {
                    try
                    {
                        switch (((ComboBoxItem)cbxRole.SelectedItem).Content.ToString())
                        {
                            case "Student":
                                if (selectedPerson == null & studentNr == 0)
                                {
                                    StudentLogic.getInstance().create(surname,
                                        forename,
                                        birthyear,
                                        street,
                                        mobilePhone,
                                        mail,
                                        fax,
                                        privatePhone,
                                        gender,
                                        isActive,
                                        title,
                                        city,
                                        cityCode,
                                        iban,
                                        bic,
                                        depositor,
                                        nameOfBank);
                                    this.DialogResult = true;
                                }
                                else
                                {
                                    StudentLogic.getInstance().changeProperties(studentNr,
                                        surname,
                                        forename,
                                        birthyear,
                                        street,
                                        mobilePhone,
                                        mail,
                                        fax,
                                        privatePhone,
                                        gender,
                                        isActive,
                                        title,
                                        city,
                                        cityCode,
                                        iban,
                                        bic,
                                        depositor,
                                        nameOfBank);
                                    this.DialogResult = true;
                                }
                                break;
                            case "User":
                                if (selectedPerson == null & userNr == 0)
                                {
                                    UserLogic.getInstance().create(surname,
                                        forename,
                                        birthyear,
                                        street,
                                        mobilePhone,
                                        mail,
                                        fax,
                                        privatePhone,
                                        gender,
                                        isActive,
                                        title,
                                        city,
                                        cityCode,
                                        username,
                                        password,
                                        isAdmin);
                                    this.DialogResult = true;
                                }
                                else
                                {
                                    UserLogic.getInstance().changeProperties(userNr,
                                        surname,
                                        forename,
                                        birthyear,
                                        street,
                                        mobilePhone,
                                        mail,
                                        fax,
                                        privatePhone,
                                        gender,
                                        isActive,
                                        title,
                                        city,
                                        cityCode,
                                        username,
                                        password,
                                        isAdmin);
                                    this.DialogResult = true;
                                }
                                break;
                            case "Tutor":
                                if (selectedPerson == null & tutorNr == 0)
                                {
                                    TutorLogic.getInstance().create(surname,
                                        forename,
                                        birthyear,
                                        street,
                                        mobilePhone,
                                        mail,
                                        fax,
                                        privatePhone,
                                        gender,
                                        isActive,
                                        title,
                                        city,
                                        cityCode);
                                    this.DialogResult = true;
                                }
                                else
                                {
                                    TutorLogic.getInstance().changeProperties(tutorNr,
                                        surname,
                                        forename,
                                        birthyear,
                                        street,
                                        mobilePhone,
                                        mail,
                                        fax,
                                        privatePhone,
                                        gender,
                                        isActive,
                                        title,
                                        city,
                                        cityCode);
                                    this.DialogResult = true;
                                }

                                break;
                        }
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show("Netzwerk oder Datenbankfehler \nException: " + e.Message);
                    }
                    lblErrorKindOfPerson.Visibility = Visibility.Hidden;
                }
                else { MessageBox.Show("Bitte Nachnamen ausfüllen"); }
            }
            else
            {
                lblErrorKindOfPerson.Visibility = Visibility.Visible;
            }
        }

        private void ButtonApoprtPerson_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void checkKindofPerson()
        {

            switch (kindOfPerson)
            {
                case 0:
                    cbxRole.SelectedIndex = -1;
                    break;
                case 1:
                    cbxRole.SelectedItem = (ComboBoxItem)cbxiStudent;
                    fillingdataFieldsWithStudentData();
                    break;
                case 2:
                    if (ActiveUser.userIsAdmin() == true)
                    {
                        cbxRole.SelectedItem = (ComboBoxItem)cbxiUser;
                        fillingdataFieldsWithUserData();
                    }
                    break;
                case 3:
                    cbxRole.SelectedItem = (ComboBoxItem)cbxiTutor;
                    try
                    {
                        tutorNr = Convert.ToInt32(selectedPerson.Rows[0]["Id"]);
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show(e.Message);
                    }
                    break;
            }
            cbxRole.IsEnabled = false;
        }

        private void fillingDataFieldsWithProvidedData()
        {
            lblPerson.Content = "Person bearbeiten";


            try
            {
                tbSurname.Text = selectedPerson.Rows[0]["surname"].ToString();
                tbForename.Text = selectedPerson.Rows[0]["forename"].ToString();
                tbBirthyear.Text = selectedPerson.Rows[0]["birthyear"].ToString();
                tbStreet.Text = selectedPerson.Rows[0]["street"].ToString();
                tbMobil.Text = selectedPerson.Rows[0]["mobilePhone"].ToString();
                tbEmail.Text = selectedPerson.Rows[0]["mail"].ToString();
                tbFax.Text = selectedPerson.Rows[0]["fax"].ToString();
                tbPhone.Text = selectedPerson.Rows[0]["privatePhone"].ToString();
                tbGender.Text = selectedPerson.Rows[0]["gender"].ToString();

                if (selectedPerson.Rows[0]["Active"].ToString() == "True")
                {
                    chbxIsActive.IsChecked = true;
                }

                switch (selectedPerson.Rows[0]["Title"].ToString())
                {
                    case "Professor":
                        cbxTitle.SelectedItem = cbxiProf;
                        break;
                    case "Doktor":
                        cbxTitle.SelectedItem = cbxidoctor;
                        break;
                    default:
                        cbxTitle.SelectedItem = null;
                        break;
                }

                tbCity.Text = selectedPerson.Rows[0]["city"].ToString();
                tbCityCode.Text = selectedPerson.Rows[0]["citycode"].ToString();
            }
            catch (Exception e)
            {
                MessageBox.Show("Datanbanktitel haben sich geändert /nException: " + e.Message);
            }
        }

        private void fillingdataFieldsWithStudentData()
        {
            studentNr = Convert.ToInt32(selectedPerson.Rows[0]["Id"]);

            tbIBAN.Text = selectedPerson.Rows[0]["iban"].ToString();
            tbBIC.Text = selectedPerson.Rows[0]["bic"].ToString();
            tbDepositor.Text = selectedPerson.Rows[0]["depositor"].ToString();
            tbBank.Text = selectedPerson.Rows[0]["nameofBank"].ToString();
        }

        private void fillingdataFieldsWithUserData()
        {
            userNr = Convert.ToInt32(selectedPerson.Rows[0]["Id"]);

            if (selectedPerson.Rows[0]["admin"].ToString() == "True")
            {
                chbxAdmin.IsChecked = true;
            }
            tbUsername.Text = selectedPerson.Rows[0]["username"].ToString();
        }

        private void ComboBoxRole_SelectonChanged(object sender, SelectionChangedEventArgs e)
        {
            changingRole();
        }

        private void changingRole()
        {
            if (this.IsLoaded)
            {
                spUser.Height = 0;
                spStudent.Height = 0;

                if (cbxRole.SelectedItem != null)
                {
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


        private void fillingNonMandatoryFields()
        {
            forename = tbForename.Text;
            surname = tbSurname.Text;
            birthyear = tbBirthyear.Text.ToString();
            street = tbStreet.Text.ToString();
            mobilePhone = tbPhone.Text.ToString();
            mail = tbEmail.Text.ToString();
            fax = tbFax.Text.ToString();
            privatePhone = tbPhone.Text.ToString();
            gender = tbGender.Text.ToString();
            isActive = (bool)chbxIsActive.IsChecked;
            if (cbxTitle.SelectedItem != null) { title = ((ComboBoxItem)cbxTitle.SelectedItem).Content.ToString(); }
            city = tbCity.Text.ToString();
            cityCode = tbCityCode.Text.ToString();

            iban = tbIBAN.Text.ToString();
            bic = tbBIC.Text.ToString();
            depositor = tbDepositor.Text.ToString();
            nameOfBank = tbBank.Text.ToString();

            username = tbUsername.Text;
            password = pwbPassword.Password.ToString();
            isAdmin = (bool)chbxAdmin.IsChecked;
        }
    }
}
