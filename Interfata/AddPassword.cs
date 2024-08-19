/**************************************************************************
 *                                                                        *
 *  File:        AddPassword.cs                                           *
 *  Copyright:   (c) 2023, Anamaria-Larisa Pașa                           *
 *  Website:     http://florinleon.byethost24.com/lab_ip.htm              *
 *  Description: UserControl for Add Password Page                        *
 *                                                                        *
 *  This program is free software; you can redistribute it and/or modify  *
 *  it under the terms of the GNU General Public License as published by  *
 *  the Free Software Foundation. This program is distributed in the      *
 *  hope that it will be useful, but WITHOUT ANY WARRANTY; without even   *
 *  the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR   *
 *  PURPOSE. See the GNU General Public License for more details.         *
 *                                                                        *
 **************************************************************************/


using BazaDeDate.DataClasses;
using BazaDeDate.Exceptions;
using BazaDeDate.Option;
using GenerareParola.Option;
using System;
using System.Windows.Forms;

namespace Exemplu_interfete
{
    /// <summary>
    /// UserControl for Add Password Page
    /// </summary>
    public partial class AddPassword : UserControl
    {
        private string _domainToDelete;
        private string _userToDelete;
        private string _emailToDelete;
        private string _passwordToDelete;

        /// <summary>
        /// Flag to delete the password set when initializing the control 
        /// </summary>
        public bool DeleteOnInstert { get; set; }

        /// <summary>
        /// Domain displayed
        /// </summary>
        public string Domain 
        {
            set
            {
                _domainToDelete = value;
                domainTextBox.Text = value;
            }
        }

        /// <summary>
        /// User displayed
        /// </summary>
        public string User
        {
            set
            {
                _userToDelete = value;
                userTextBox.Text = value;
            }
        }

        /// <summary>
        /// Email displayed
        /// </summary>
        public string Email
        {
            set
            {
                _emailToDelete = value;
                emailTextBox.Text = value;
            }
        }

        /// <summary>
        /// Password displayed
        /// </summary>
        public string Passoword
        {
            set
            {
                _passwordToDelete = value;
                passwordTextBox.Text = value;
            }
        }

        public AddPassword()
        {
            InitializeComponent();
        }

        private void AddPassword_Load(object sender, EventArgs e)
        {

        }

        private void generatePasswordButton_Click(object sender, EventArgs e)
        {
            GeneratorOptions options = GeneratorOptions.None;

            if (lowLetterCheckBox.Checked)
                options |= GeneratorOptions.LowerAlpha;
            if (capitalLetterCheckBox.Checked)
                options |= GeneratorOptions.UpperAlpha;
            if (digitCheckBox.Checked)
                options |= GeneratorOptions.Numeric;
            if (specialCharCheckBox.Checked)
                options |= GeneratorOptions.Special;

            try
            {
                int passLength = (int)lengthPasswordDropDown.Value;
                passwordTextBox.Text = Controller.Controller.Instance().GeneratePassword(options, passLength);
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("Invalid length! Length should be between 1 and 20", "Error");
            }
            catch (Exception)
            {
                Form1.Instance.UnexpectedError();
            }
        }

        private void displayPasswordCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            passwordTextBox.UseSystemPasswordChar = !displayPasswordCheckBox.Checked;
        }

        private void submitNewDomainButton_Click(object sender, EventArgs e)
        {
            var user = new User(
                    userName: Form1.User
                );

            var pass = new Password(
                    domainUser: userTextBox.Text,
                    email: emailTextBox.Text,
                    domain: domainTextBox.Text,
                    passwordValue: passwordTextBox.Text
                );

            try
            {
                if (DeleteOnInstert)
                    Controller.Controller.Instance()
                        .DeletePassword(new DeleteOptions(
                            _userToDelete,
                            _emailToDelete,
                            _domainToDelete,
                            _passwordToDelete
                        ), Form1.User);

                Controller.Controller.Instance().AddPassword(user, pass);

                if (DeleteOnInstert)
                {
                    DeleteOnInstert = false;
                    Form1.ViewAcc.DataSet = Controller.Controller.Instance().GetAllUserPass(Form1.User);
                    Form1.Instance.NavigateToPage("ViewAccount", Form1.ViewAcc);
                }
                else
                    Form1.Instance.NavigateToPage("Home", Form1.HomePage);
            }
            catch (DeletePasswordException)
            {
                MessageBox.Show("Password couldn't be deleted!", "Error");
            }
            catch (AddPasswordsException)
            {
                MessageBox.Show("Password couldn't be added", "Error");
            }
            catch (SearchPasswordsException)
            {
                MessageBox.Show("Password couldn't be loaded", "Error");
            }
            catch (Exception)
            {
                Form1.Instance.UnexpectedError();
            }
        }
    }
}
