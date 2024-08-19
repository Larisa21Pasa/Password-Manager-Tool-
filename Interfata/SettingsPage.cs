/**************************************************************************
 *                                                                        *
 *  File:        SettingsPage.cs                                          *
 *  Copyright:   (c) 2023, Anamaria-Larisa Pașa                           *
 *  Website:     http://florinleon.byethost24.com/lab_ip.htm              *
 *  Description: UserControl for Settings Page                            *
 *                                                                        *
 *  This program is free software; you can redistribute it and/or modify  *
 *  it under the terms of the GNU General Public License as published by  *
 *  the Free Software Foundation. This program is distributed in the      *
 *  hope that it will be useful, but WITHOUT ANY WARRANTY; without even   *
 *  the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR   *
 *  PURPOSE. See the GNU General Public License for more details.         *
 *                                                                        *
 **************************************************************************/

using System;
using System.Windows.Forms;

namespace Interfata
{
    /// <summary>
    /// UserControl for Settings page
    /// </summary>
    public partial class SettingsPage : UserControl
    {
        private bool isDarkTheme = false;

        public event EventHandler<string> ThemeButtonClicked;

        public SettingsPage()
        {
            InitializeComponent();
        }

        private void themes_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            string buttonText = button.Text;
            ThemeButtonClicked?.Invoke(this, buttonText);

            isDarkTheme = buttonText.Equals("Dark", StringComparison.OrdinalIgnoreCase);
            UpdateButtonTheme();
        }

        private void UpdateButtonTheme()
        {
            if (isDarkTheme)
            {
                themes.Text = "Light";
            }
            else
            {
                themes.Text = "Dark";
            }
        }

        private void containerPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
