/**************************************************************************
 *                                                                        *
 *  File:        UsersTable.cs                                            *
 *  Copyright:   (c) 2023, Pintilie Razvan-Nicolae                        *
 *  E-mail:      razvan-nicolae.pintilie@student.tuiasi.ro                *
 *  Description: A class that provides methods                            *
 *               for "Users" table from a data base.                      *
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
using BazaDeDate.Exceptions;

namespace BazaDeDate.Tables
{
    /// <summary>
    /// Provides data base operation for "Users" table.
    /// </summary>
    public class UsersTable
    {
        private SQLiteConnection _connection;
        static private string s_tableName = "Users";
        static private string s_connectionString = "Data Source=./DataBase.db;Version=3";
        /// <summary>
        /// Parameterless constructor.
        /// Realizes a connection to "DataBase.db".
        /// </summary>
        public UsersTable()
        {

        }

        /// <summary>
        /// Adds new values to the table
        /// </summary>
        /// <param name="user"></param>
        /// <param name="token"></param>
        /// <returns>true if the operation could be completed and false if not</returns>
        public bool Add(string user, string token)
        {
            (string hashedToken, string salt) = Cryptography.HashToken(token);
            /*Console.WriteLine("Salt: {0}", salt);*/
            using (_connection = new SQLiteConnection(s_connectionString))
            {
                _connection.Open();
                try
                {
                    string query = "INSERT INTO " + s_tableName + "(USER, TOKEN, SALT) VALUES (@user, @token, @salt);";

                    int rowsAffected;
                    using (SQLiteCommand command = new SQLiteCommand(query, _connection))
                    {
                        command.Parameters.AddWithValue("@user", user);
                        command.Parameters.AddWithValue("@token", hashedToken);
                        command.Parameters.AddWithValue("@salt", salt);

                        rowsAffected = command.ExecuteNonQuery();
                    }

                    return rowsAffected > 0;
                }
                catch (SQLiteException)
                {
                    string errorMessage = "User couldn't be load!";
                    throw new AddUsersException(errorMessage);
                }
            }
        }

        /// <summary>
        /// Updates the token of an user
        /// </summary>
        /// <param name="user"></param>
        /// <param name="newToken"></param>
        /// <returns>true if the operation could be completed and false if not</returns>
        public bool UpdateToken(string user, string newToken)
        {
            using (_connection = new SQLiteConnection(s_connectionString))
            {
                _connection.Open();
                try
                {
                    // Generate new salt and hash the new token
                    (string hashedToken, string newSalt) = Cryptography.HashToken(newToken);

                    string query = "UPDATE " + s_tableName + " SET TOKEN = @newToken, SALT = @newSalt WHERE USER = @user;";

                    int rowsAffected;

                    using (SQLiteCommand command = new SQLiteCommand(query, _connection))
                    {
                        command.Parameters.AddWithValue("@newToken", hashedToken);
                        command.Parameters.AddWithValue("@newSalt", newSalt);
                        command.Parameters.AddWithValue("@user", user);

                        rowsAffected = command.ExecuteNonQuery();
                    }

                    if (rowsAffected > 0)
                    {
                        return true;
                    }
                }
                catch (SQLiteException)
                {
                    string errorMessage = "Token couldn't be updated!";
                    throw new UpdateTokenException(errorMessage);
                }
            }

            return false;
        }


        /// <summary>
        /// Checks if the pair (user, token) exists in the table.
        /// </summary>
        /// <param name="user"></param>
        /// <param name="token"></param>
        /// <returns>true if the pair exists and false if not.</returns>
        public bool CheckHash(string user, string token)
        {
            using (_connection = new SQLiteConnection(s_connectionString))
            {
                _connection.Open();
                try
                {
                    string query = "SELECT * FROM " + s_tableName + " WHERE USER = \"" + user + "\";";

                    using (SQLiteCommand command = new SQLiteCommand(query, _connection))
                    {
                        using (SQLiteDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int returnedId = Convert.ToInt32(reader["ID"]);
                                string returnedUser = Convert.ToString(reader["USER"]);
                                string returnedToken = Convert.ToString(reader["TOKEN"]);
                                string returnedSalt = Convert.ToString(reader["SALT"]);


                                if (returnedUser == user)
                                {
                                    // Verify the token by hashing it with the stored salt
                                    (string hashedToken, _) = Cryptography.HashToken(token, returnedSalt);

                                    // Console.WriteLine("hashedToken: {0}, returnedToken: {1}", hashedToken, returnedToken);

                                    if (String.Equals(returnedToken, hashedToken, StringComparison.Ordinal))
                                    {
                                        return true;
                                    }
                                }
                            }
                        }
                    }
                }
                catch (SQLiteException)
                {
                    string errorMessage = "Log in couldn't be performed!";
                    throw new CheckHashException(errorMessage);
                }
            }

            return false;
        }

    }
}
