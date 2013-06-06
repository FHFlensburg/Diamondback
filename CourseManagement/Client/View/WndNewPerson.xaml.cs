﻿using System;
using System.Data;
using System.Windows;
using System.Windows.Controls;

namespace CourseManagement.Client.View
{
    /// <summary>
    /// Interaktionslogik für wndNewPerson.xaml
    /// </summary>
    public partial class wndNewPerson : Window
    {
        private DataTable selectedPerson = null;
        private string surname = "";
        private string forename = "";
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

        private string username = "";
        private string password = "";
        private bool admin = false;



        /// <summary>
        /// standard constructor for window newPerson
        /// </summary>
        public wndNewPerson()
        {
            InitializeComponent();
            lblPerson.Content = "Neue Person";
        }

        public wndNewPerson(DataTable selectedPerson)
        {
            InitializeComponent();

            this.selectedPerson = selectedPerson;

            fillingDataFieldsWithProvidedData(selectedPerson);
                

        }

        private void ButtonSavePerson_Click(object sender, RoutedEventArgs e)
        {

            this.Close();
        }

        private void ButtonApoprtPerson_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void fillingDataFieldsWithProvidedData(DataTable selectedPerson)
        {
            lblPerson.Content = "Person bearbeiten";

            tbLastname.Text = selectedPerson.Rows[0]["surname"].ToString();
            tbFirstname.Text = selectedPerson.Rows[0]["forename"].ToString();
            tbBirthyear.Text = selectedPerson.Rows[0]["birthyear"].ToString();
            tbStreet.Text = selectedPerson.Rows[0]["street"].ToString();
            tbMobil.Text = selectedPerson.Rows[0]["mobilphone"].ToString();
            tbEmail.Text = selectedPerson.Rows[0]["mail"].ToString();
            tbFax.Text = selectedPerson.Rows[0]["fax"].ToString();
            tbPhone.Text = selectedPerson.Rows[0]["privatePhone"].ToString();
            tbGender.Text = selectedPerson.Rows[0]["gender"].ToString();

            if (Convert.ToBoolean(selectedPerson.Rows[0]["active"]))
            {
                chbxIsActive.IsChecked = true;
            }

            switch (selectedPerson.Rows[0]["title"].ToString())
            {
                case "Professor":
                    chbxTitle.SelectedItem = cbxiProf;
                    break;
                case "Doktor":
                    chbxTitle.SelectedItem = cbxidoctor;
                    break;
                default:
                    chbxTitle.SelectedItem = null;
                    break;
            }

            tbCity.Text = selectedPerson.Rows[0]["city"].ToString();
            tbCityCode.Text = selectedPerson.Rows[0]["citycode"].ToString();

            tbIBAN.Text = selectedPerson.Rows[0]["iban"].ToString();
            tbBIC.Text = selectedPerson.Rows[0]["bic"].ToString();
            tbDebitor.Text = selectedPerson.Rows[0]["depositor"].ToString();
            tbBank.Text = selectedPerson.Rows[0]["nameofBank"].ToString();

            tbUsername.Text = selectedPerson.Rows[0]["username"].ToString();

            if (Convert.ToBoolean(selectedPerson.Rows[0]["admin"]))
            {
                chbxAdmin.IsChecked = true;
            }
        }

        private void ComboBoxRole_SelectonChanged(object sender, SelectionChangedEventArgs e)
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



        #endregion



    }
}
