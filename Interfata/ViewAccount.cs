/**************************************************************************
 *                                                                        *
 *  File:        AddPassword.cs                                           *
 *  Copyright:   (c) 2023, Anamaria-Larisa Pașa                           *
 *  Website:     http://florinleon.byethost24.com/lab_ip.htm              *
 *  Description: UserControl for View Account Page                        *
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
using System.Collections.Generic;
using System.Windows.Forms;
using BazaDeDate.DataClasses;
using BazaDeDate.Exceptions;
using BazaDeDate.Option;

namespace Exemplu_interfete
{
    /// <summary>
    /// UserControl for View Account Page
    /// </summary>
    public partial class ViewAccount : UserControl
    {
        private readonly List<string> _passwords;

        /// <summary>
        /// Data stored displayed in page
        /// </summary>
        public List<SearchResult> DataSet
        {
            set
            {
                dataGridView2.Rows.Clear();
                _passwords.Clear();

                for (int i = 0; i < value.Count; ++i)
                {
                    string[] row1 = new string[] { (i + 1).ToString(), value[i].DomainUser, value[i].Domain, value[i].Email, new string('*', value[i].Password.Length) };
                    dataGridView2.Rows.Add(row1);
                    _passwords.Add(value[i].Password);
                }

                displayPasswordCheckBox.Checked = false;
            }
        }

        public ViewAccount()
        {
            InitializeComponent();
            _passwords = new List<string>();
        }

        private void ViewAccount_Load(object sender, EventArgs e)
        {
           
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            if (dataGridView2.Rows.Count == 0)
                return;

            int selectedRow = dataGridView2.SelectedCells[0].RowIndex;
            DeleteOptions options = new DeleteOptions(
                (string)dataGridView2.Rows[selectedRow].Cells[1].Value,
                (string)dataGridView2.Rows[selectedRow].Cells[2].Value,
                (string)dataGridView2.Rows[selectedRow].Cells[3].Value,
                (string)dataGridView2.Rows[selectedRow].Cells[4].Value
            );

            try
            {
                Controller.Controller.Instance().DeletePassword(options, Form1.User);
                dataGridView2.Rows.RemoveAt(selectedRow);
            }
            catch (DeletePasswordException)
            {
                MessageBox.Show("Password couldn't be deleted!", "Error");
            }
            catch (Exception)
            {
                MessageBox.Show("An unknown error occurred", "Error");
            }

        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            if (dataGridView2.Rows.Count == 0)
                return;

            int selectedRow = dataGridView2.SelectedCells[0].RowIndex;

            Form1.AddPass.User = (string)dataGridView2.Rows[selectedRow].Cells[1].Value;
            Form1.AddPass.Domain = (string)dataGridView2.Rows[selectedRow].Cells[2].Value;
            Form1.AddPass.Email = (string)dataGridView2.Rows[selectedRow].Cells[3].Value;
            Form1.AddPass.Passoword = _passwords[selectedRow];

            Form1.AddPass.DeleteOnInstert = true;

            Form1.Instance.NavigateToPage("AddPassword", Form1.AddPass);
        }

        private void displayPasswordCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView2.Rows)
            {
                row.Cells[4].Value = displayPasswordCheckBox.Checked ?
                    _passwords[row.Index] : new string('*', _passwords[row.Index].Length);
            }
        }
    }
}
