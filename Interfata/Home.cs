/**************************************************************************
 *                                                                        *
 *  File:        Home.cs                                                  *
 *  Copyright:   (c) 2023, Anamaria-Larisa Pașa                           *
 *  Website:     http://florinleon.byethost24.com/lab_ip.htm              *
 *  Description: UserControl for Home page                                *
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
using BazaDeDate.Option;
using System;
using System.Windows.Forms;

namespace Exemplu_interfete
{
    /// <summary>
    /// UserControl for Home page
    /// </summary>
    public partial class Home : UserControl
    {
        private bool _clickedOnSearchBar;

        public Home()
        {
            InitializeComponent();
            _clickedOnSearchBar = false;
        }

        private void addPasswordButton_Click(object sender, EventArgs e)
        {
            Form1.AddPass.DeleteOnInstert = false;
            Form1.Instance.NavigateToPage("AddPassword", Form1.AddPass);
        }

        private void viewAccountButton_Click(object sender, EventArgs e)
        {
            try
            {
                Form1.ViewAcc.DataSet = Controller.Controller.Instance().GetAllUserPass(Form1.User);
                Form1.Instance.NavigateToPage("ViewAccount", Form1.ViewAcc);
            }
            catch (SearchPasswordsException)
            {
                MessageBox.Show("An error occurred when loading passwords.", "Error");
            }
            catch (Exception)
            {
                Form1.Instance.UnexpectedError();
            }
        }

        private void submitSignUpButton_Click(object sender, EventArgs e)
        {
            string search = searchWordText.Text;

            if (search.StartsWith("your search here"))
                search = string.Empty;

            if (search == string.Empty)
            {
                viewAccountButton_Click(sender, null);
                return;
            }

            try
            {
                TableOptions option = (TableOptions)(2 << dropDownSearch.SelectedIndex);
                Form1.ViewAcc.DataSet = Controller.Controller.Instance().Search(option, search, Form1.User);
                Form1.Instance.NavigateToPage("ViewAccount", Form1.ViewAcc);
            }
            catch (SearchPasswordsException)
            {
                MessageBox.Show("An error occurred when loading passwords.", "Error");
            }
            catch (Exception)
            {
                Form1.Instance.UnexpectedError();
            }
        }

        private void nameSignUpText_MouseClick(object sender, MouseEventArgs e)
        {
            if (!_clickedOnSearchBar)
            {
                _clickedOnSearchBar = true;
                searchWordText.Text = string.Empty;
            }
        }

        private void searchWordText_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                submitSignUpButton_Click(sender, null);
            }
        }

        private void containerPanel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
