/**************************************************************************
 *                                                                        *
 *  File:        SignUp.cs                                                *
 *  Copyright:   (c) 2023, Anamaria-Larisa Pașa                           *
 *  Website:     http://florinleon.byethost24.com/lab_ip.htm              *
 *  Description: UserControl for SignUp Page                              *
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
    /// UserControl for SignUp Page
    /// </summary>
    public partial class SignUp : UserControl
    {

        private Controller.Controller _controller = Controller.Controller.Instance();
        public SignUp()
        {
            InitializeComponent();
        }

        private void SignUp_Load(object sender, EventArgs e)
        {

        }

        private void submitSignUpButton_Click(object sender, EventArgs e)
        {
            string user = nameSignUpText.Text;
            string pass = pinPCSignUpText.Text;

            if (user != string.Empty && pass != string.Empty)
            {
                try
                {
                    if (_controller.Sign_Up(user, pass))
                    {
                        if (!Form1.Instance.PanelContainer.Controls.ContainsKey("Home"))
                        {
                            Home home = Form1.HomePage;
                            home.Dock = DockStyle.Fill;
                            Form1.Instance.PanelContainer.Controls.Add(home);
                        }
                        Form1.Instance.PanelContainer.Controls["Home"].BringToFront();
                        Form1.Instance.BackButton.Visible = true;
                    }
                }
                catch (AddUsersException)
                {
                    MessageBox.Show("An error occurred when creating the new user", "Error");
                }
                catch (Exception)
                {
                    Form1.Instance.UnexpectedError();
                }
            }
            else
            {
                MessageBox.Show("Both fields must contain data!", "Error");
            }
        }

        private void nameLabel_Click(object sender, EventArgs e)
        {

        }

        private void pinPCSignUpText_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                submitSignUpButton_Click(sender, null);
                e.Handled = true;
            }
        }

        private void nameSignUpText_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
            }
        }
    }
    
}
