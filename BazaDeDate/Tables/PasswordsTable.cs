/**************************************************************************
 *                                                                        *
 *  File:        PasswordsTable.cs                                        *
 *  Copyright:   (c) 2023, Pintilie Razvan-Nicolae                        *
 *  E-mail:      razvan-nicolae.pintilie@student.tuiasi.ro                *
 *  Description: A class that provides methods                            *
 *               for "Passwords" table from a data base.                  *
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
using System.Data.SQLite;
using BazaDeDate.Security;
using BazaDeDate.Option;
using System.Collections.Generic;
using BazaDeDate.DataClasses;
using BazaDeDate.Exceptions;
using System.IO;

namespace BazaDeDate.Tables
{
    /// <summary>
    /// Provides CRUD data base operation for "Passwords" table.
    /// </summary>
    public class PasswordsTable
    {
        private SQLiteConnection _connection;
        static private string s_tableName = "Passwords";
        static private string s_mostPowerfullEncoding = "1.9 TDI";
        static private string s_connectionString = "Data Source=./DataBase.db;Version=3";

        /// <summary>
        /// Parameterless constructor.
        /// Realizes a connection to "DataBase.db".
        /// </summary>
        public PasswordsTable()
        {

        }

        /// <summary>
        /// Adds new values to the table
        /// </summary>
        /// <param name="user"></param>
        /// <param name="password"></param>        
        /// <returns>true if the pair exists and false if not.</returns>
        public bool Add(User user, Password password)
        {
            string encryptedPassword = Cryptography.Encrypt(password.PasswordValue, s_mostPowerfullEncoding);

            using (_connection = new SQLiteConnection(s_connectionString))
            {
                _connection.Open();
                try
                {
                    string query = "INSERT INTO " + s_tableName + "(USER, EMAIL, PASSWORD, DOMAIN, DOMAIN_USER) VALUES (@user, @email, @password, @domain, @domainUser);";
                    using (SQLiteCommand command = new SQLiteCommand(query, _connection))
                    {
                        command.Parameters.AddWithValue("@user", user.UserName);
                        command.Parameters.AddWithValue("@domainUser", password.DomainUser);
                        command.Parameters.AddWithValue("@email", password.Email);
                        command.Parameters.AddWithValue("@password", encryptedPassword);
                        command.Parameters.AddWithValue("@domain", password.Domain);

                        int rowsAffected = command.ExecuteNonQuery();

                        return rowsAffected > 0;
                    }
                }
                catch (SQLiteException ex)
                {
                    string errorMessage = "New password record couldn't be added!\nTry again!";
                    throw new AddPasswordsException(errorMessage);
                }
            }
        }

        /// <summary>
        /// Searches for the values matching the components of the struct.
        /// </summary>
        /// <param name="searchOption">an enum that specifies which field to be searched in the table.</param>
        /// <param name="searchedWord">the value of the searched field.</param>
        /// <returns>a list of SearchedResult</returns>
        public List<SearchResult> Search(TableOptions searchOption, string searchedWord, User user)
        {
            List<SearchResult> results = new List<SearchResult>();
            string encryptedPassword = string.Empty;
            bool empty = true;
            if ((searchOption & TableOptions.Password) != 0 && !string.IsNullOrEmpty(searchedWord))
            {
                encryptedPassword = Cryptography.Encrypt(searchedWord, s_mostPowerfullEncoding);
            }

            using (_connection = new SQLiteConnection(s_connectionString))
            {
                _connection.Open();
                try
                {
                    string query = "SELECT * FROM " + s_tableName + " WHERE 1 = 1";

                    if ((searchOption & TableOptions.User) != 0 && user != null)
                    {
                        query += $" AND USER = '{user.UserName}'";
                        empty = false;
                    }

                    if ((searchOption & TableOptions.DomainUser) != 0 && !string.IsNullOrEmpty(searchedWord))
                    {
                        query += " AND DOMAIN_USER LIKE '%" + searchedWord + "%'";
                        empty = false;
                    }

                    if ((searchOption & TableOptions.Email) != 0 && !string.IsNullOrEmpty(searchedWord))
                    {
                        query += " AND EMAIL LIKE '%" + searchedWord + "%'";
                        empty = false;
                    }

                    if ((searchOption & TableOptions.Domain) != 0 && !string.IsNullOrEmpty(searchedWord))
                    {
                        query += " AND DOMAIN LIKE '%" + searchedWord + "%'";
                        empty = false;
                    }

                    if ((searchOption & TableOptions.Password) != 0 && !string.IsNullOrEmpty(searchedWord))
                    {
                        query += " AND PASSWORD = \"" + encryptedPassword + "\"";
                        empty = false;
                    }

                    if (empty)
                    {
                        query += " AND -1 = 1";
                    }

                    using (SQLiteCommand command = new SQLiteCommand(query, _connection))
                    {
                        using (SQLiteDataReader reader = command.ExecuteReader())
                        {

                            while (reader.Read())
                            {
                                int returnedId = Convert.ToInt32(reader["ID"]);
                                string returnedUser = Convert.ToString(reader["USER"]);
                                string returnedDomainUser = Convert.ToString(reader["DOMAIN_USER"]);
                                string returnedEmail = Convert.ToString(reader["EMAIL"]);
                                string returnedDomain = Convert.ToString(reader["DOMAIN"]);
                                string returnedencryptedPassword = Convert.ToString(reader["PASSWORD"]);
                                string decryptedPassword = Cryptography.Decrypt(returnedencryptedPassword, s_mostPowerfullEncoding);

                                SearchResult result = new SearchResult(
                                    user: returnedUser,
                                    domainUser: returnedDomainUser,
                                    email: returnedEmail,
                                    domain: returnedDomain,
                                    password: decryptedPassword
                                );

                                results.Add(result);
                            }
                        }
                    }
                }

                catch (SQLiteException)
                {
                    string errorMessage = "Couldn't search for the provided fields!";
                    throw new SearchPasswordsException(errorMessage);
                }
            }

            return results;
        }


        /// <summary>
        /// Deletes the values matching the components of the struct.
        /// </summary>
        /// <param name="deleteOption">a struct containing the values to be deleted.</param>
        /// <returns>A boolean value indicating the success or failure of the deletion operation.</returns>
        public bool Delete(DeleteOptions deleteOption, User user)
        {
            bool success = false;
            using (_connection = new SQLiteConnection(s_connectionString))
            {
                _connection.Open();
                try
                {
                    string query = "DELETE FROM " + s_tableName + " WHERE 1 = 1";
                    bool empty = true;

                    if (user != null)
                    {
                        query += $" AND USER = '{user.UserName}'";
                        empty = false;
                    }

                    if (!string.IsNullOrEmpty(deleteOption.User))
                    {
                        query += " AND DOMAIN_USER LIKE '%" + deleteOption.User + "%'";
                        empty = false;
                    }

                    if (!string.IsNullOrEmpty(deleteOption.Email))
                    {
                        query += " AND EMAIL = \"" + deleteOption.Email + "\"";
                        empty = false;
                    }

                    if (!string.IsNullOrEmpty(deleteOption.Domain))
                    {
                        query += " AND DOMAIN = \"" + deleteOption.Domain + "\"";
                        empty = false;
                    }

                    if (!string.IsNullOrEmpty(deleteOption.Password))
                    {
                        string encryptedPassword = Cryptography.Encrypt(deleteOption.Password, "1.9 TDI");
                        query += " AND PASSWORD = \"" + encryptedPassword + "\"";
                        empty = false;
                    }

                    if (empty == true)
                    {
                        query += " AND -1 = 1";
                    }

                    using (SQLiteCommand command = new SQLiteCommand(query, _connection))
                    {
                        int rowsAffected = command.ExecuteNonQuery();
                        success = rowsAffected > 0;
                    }
                }
                catch (SQLiteException)
                {
                    string errorMessage = "Password record couldn't be deleted!";
                    throw new DeletePasswordException(errorMessage);
                }
            }

            return success;
        }
    }
}