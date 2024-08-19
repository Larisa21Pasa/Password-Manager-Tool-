/**************************************************************************
 *                                                                        *
 *  File:        PasswordsTable.cs                                        *
 *  Copyright:   (c) 2023, Pintilie Razvan-Nicolae                        *
 *  E-mail:      razvan-nicolae.pintilie@student.tuiasi.ro                *
 *  Description: A class containing function for                          *
 *               creating tables in given DataBase                        *               
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
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using BazaDeDate.Exceptions;

namespace BazaDeDate.Tables
{
    /// <summary>
    /// A class containing function for creating tables in given DataBase
    /// </summary>
    public class CreateTable
    {
        static private string s_connectionString = "Data Source=./DataBase.db;Version=3";

        /// <summary>
        /// Creates Users Table
        /// </summary>
        /// <returns>true if the operation could be completed and false if not</returns>
        static public bool CreateUsersTable()
        {
            try
            {
                bool success = false;
                using (var connection = new SQLiteConnection(s_connectionString))
                {
                    connection.Open();

                    string createTableQuery = @"
                        CREATE TABLE IF NOT EXISTS Users (
                        ID INTEGER PRIMARY KEY AUTOINCREMENT,
                        USER TEXT NOT NULL UNIQUE,
                        TOKEN TEXT NOT NULL,
                        SALT TEXT NOT NULL,
                        UNIQUE(TOKEN, ID, USER)
                    );";

                    using (var command = new SQLiteCommand(createTableQuery, connection))
                    {
                        int rowsAffected = command.ExecuteNonQuery();
                        success = rowsAffected > 0;
                    }
                }

                return success;

            }
            catch (SQLiteException)
            {
                string errorMessage = "Error creating Users table!";
                throw new CreateTableException(errorMessage);
            }
        }

        /// <summary>
        /// Creates Passwords Table
        /// </summary>
        /// <returns>true if the operation could be completed and false if not</returns>
        static public bool CreatePasswordsTable()
        {
            try
            {
                bool success = false;
                using (var connection = new SQLiteConnection(s_connectionString))
                {
                    connection.Open();

                    string createTableQuery = @"
                        CREATE TABLE IF NOT EXISTS Passwords (
                        ID INTEGER NOT NULL UNIQUE,
                        USER TEXT NOT NULL,
                        DOMAIN_USER TEXT NOT NULL,
                        EMAIL TEXT NOT NULL,
                        DOMAIN TEXT NOT NULL,
                        PASSWORD TEXT NOT NULL,
                        PRIMARY KEY(ID AUTOINCREMENT),
                        UNIQUE(USER, DOMAIN, PASSWORD, EMAIL),
                        UNIQUE(EMAIL, DOMAIN, PASSWORD)
                    );";

                    using (var command = new SQLiteCommand(createTableQuery, connection))
                    {
                        int rowsAffected = command.ExecuteNonQuery();
                        success = rowsAffected > 0;
                    }
                }

                return success;

            }
            catch (SQLiteException)
            {
                string errorMessage = "Error creating Users table!";
                throw new CreateTableException(errorMessage);
            }
        }
    }
}
