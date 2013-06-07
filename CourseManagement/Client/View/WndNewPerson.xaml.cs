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
            if (ActiveUser.userIsAdmin() == false) cbxRole.Items.RemoveAt(2) ;
            lblPerson.Content = "Neue Person";
        }

        public wndNewPerson(DataTable selectedPerson, int kindOfPerson)
        {
            InitializeComponent();

            this.kindOfPerson = kindOfPerson;
            this.selectedPerson = selectedPerson;

            fillingDataFieldsWithProvidedData();

            if (kindOfPerson == 1)
            {
                fillingdataFieldsWithStudentData();
                cbxRole.SelectedItem = cbxiStudent;
            }
            if (kindOfPerson == 2) 
            {
                fillingdataFieldsWithUserData();
                cbxRole.SelectedItem = cbxiUser;
            }

            changingRole();
                

        }

        private void ButtonSavePerson_Click(object sender, RoutedEventArgs e)
        {
            insertPerson();
            this.Close();
        }

        private void insertPerson()
        {
            fillingNonMandatoryFields();
            try
            {
                switch (((ComboBoxItem)cbxRole.SelectedItem).Content.ToString())
                {
                    case "Student":
                        if (validateDatafields())
                        {
                            if(selectedPerson == null & studentNr == 0)
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
                            }
                            }        
                        break;
                    case "User":
                        
                        if (validateDatafields() & validateUsername())
                        {
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
                            }
                        }
                        break;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Netzwerk oder Datenbankfehler /nException: " + e.Message); 
            }
        }

        private void ButtonApoprtPerson_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
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

                //if (Convert.ToBoolean(selectedPerson.Rows[0]["isActive"]))
                //{
                //    chbxIsActive.IsChecked = true;
                //}

                switch (selectedPerson.Rows[0]["title"].ToString())
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
            if (Convert.ToBoolean(selectedPerson.Rows[0]["admin"]))
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

        #region filling variables and doing validation for mandatory fields. 

        

        private bool validateDatafields()
        {
            bool validate = false;

            if (validateForename()
                & validateSurname())
            {
                validate = true;
            }

            return validate;
        }

        private void fillingNonMandatoryFields()
        {
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

            password = pwbPassword.Password.ToString();
            isAdmin = (bool)chbxAdmin.IsChecked;
        }

        /// <summary>
        /// At least for and surname shouls be mandatory, so we dont have empty user
        /// </summary>
        /// <returns></returns>
        /// 
        private bool validateForename()
        {
            bool validate = false;
            if (tbForename.Text != null)
            {
                forename = tbForename.Text;
                lblForename.Foreground = Brushes.Black;
                validate = true;
            }
            else
            {
                tbForename.Foreground = Brushes.Red;
                validate = false;
            }
            return validate;
        }

        private bool validateSurname()
        {
            bool validate = false;
            if (tbSurname.Text != null)
            {
                surname = tbSurname.Text;
                lblSurname.Foreground = Brushes.Black;
                validate = true;
            }
            else
            {
                lblSurname.Foreground = Brushes.Red;
                validate = false;
            }
            return validate;
        }

        private bool validateUsername()
        {
            bool validate = false;
            if (tbUsername.Text != null)
            {
                username = tbUsername.Text;
                lblUsername.Foreground = Brushes.Black;
                validate = true;
            }
            else
            {
                lblUsername.Foreground = Brushes.Red;
                validate = false;
            }
            return validate;
        }

        #endregion



    }
}
