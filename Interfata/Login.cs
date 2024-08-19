/**************************************************************************
 *                                                                        *
 *  File:        Login.cs                                                 *
 *  Copyright:   (c) 2023, Anamaria-Larisa Pașa                           *
 *  Website:     http://florinleon.byethost24.com/lab_ip.htm              *
 *  Description: UserControl for Login page                               *
 *                                                                        *
 *  This program is free software; you can redistribute it and/or modify  *
 *  it under the terms of the GNU General Public License as published by  *
 *  the Free Software Foundation. This program is distributed in the      *
 *  hope that it will be useful, but WITHOUT ANY WARRANTY; without even   *
 *  the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR   *
 *  PURPOSE. See the GNU General Public License for more details.         *
 *                                                                        *
 **************************************************************************/


using BazaDeDate.Exceptions;
using System;
using System.Windows.Forms;
namespace Exemplu_interfete
{
    /// <summary>
    /// UserControl for Login page
    /// </summary>
    public partial class Login : UserControl
    {

        private Controller.Controller _controlor = Controller.Controller.Instance();

        public Login()
        {
            InitializeComponent();
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            string user = userPC.Text;
            string pass = pinPCText.Text;
            if (user != string.Empty && pass != string.Empty)
            {
                try
                {
                    Form1.User = user;
                    if (_controlor.Log_In(user, pass))
                    {
                        Form1.Instance.NavigateToPage("Home", Form1.HomePage);
                    }
                    else
                        MessageBox.Show("Invalid username or password", "Error");
                }
                catch (CheckHashException)
                {
                    MessageBox.Show("Invalid username or password", "Error");
                }
                catch (Exception)
                {
                    Form1.Instance.UnexpectedError();
                }
            }
            else
            {
                MessageBox.Show("Both fields must contain data", "Error");
            }
        }

        private void signUpButton_Click(object sender, EventArgs e)
        {
            SignUp signUp = new SignUp();
            Form1.Instance.NavigateToPage("SignUp", signUp);

        }

        private void LoginPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureInfoLogin_Click(object sender, EventArgs e)
        {

        }

        private void managementLabelInfo_Click(object sender, EventArgs e)
        {

        }

        private void pinPCText_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                loginButton_Click(sender, null);
                e.Handled = true;
            }
        }
    }
      
}
