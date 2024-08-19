/**************************************************************************
 *                                                                        *
 *  File:        AddPassword.cs                                           *
 *  Copyright:   (c) 2023, Budu Daniel                                    *
 *  Website:     http://florinleon.byethost24.com/lab_ip.htm              *
 *  Description: Controller for interface logic                           *
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
using BazaDeDate.Option;
using BazaDeDate.Tables;
using GenerareParola.Generator;
using GenerareParola.Option;
using System.Collections.Generic;

namespace Controller
{
    /// <summary>
    /// Controller for interface logic
    /// </summary>
    public class Controller
    {
        private readonly PasswordsTable _passTable;
        private readonly UsersTable _usersTable;

        private static Controller _instance;

        /// <summary>
        /// Constructor Controller class
        /// </summary>
        private Controller()
        {
            _passTable = new PasswordsTable();
            _usersTable = new UsersTable();

            CreateTable.CreateUsersTable();
            CreateTable.CreatePasswordsTable();
        }

        /// <summary>
        /// Return the only instance of the class
        /// </summary>
        /// <returns>The only instance of the class</returns>
        public static Controller Instance()
        {
            if (_instance == null)
                _instance = new Controller();
            return _instance;
        }

        /// <summary>
        /// Verifies user log in success
        /// </summary>
        /// <param name="user">Username</param>
        /// <param name="pass">Password</param>
        /// <returns>true if login was made successfully, false otherwise</returns>
        public bool Log_In(string user, string pass)
        {
            return _usersTable.CheckHash(user, pass);
        }

        /// <summary>
        /// Creates a new user
        /// </summary>
        /// <param name="user">Username</param>
        /// <param name="pass">Password</param>
        /// <returns>true if sign up was made successfully, false otherwise</returns>
        public bool Sign_Up(string user, string pass)
        {
            return _usersTable.Add(user, pass);
        }

        /// <summary>
        /// Searches for matching password entries
        /// </summary>
        /// <param name="searchOption">Field search option</param>
        /// <param name="searchWord">String used for matching</param>
        /// <param name="user">The password owner</param>
        /// <returns>List of SearchResults containing all matches</returns>
        public List<SearchResult> Search(TableOptions searchOption, string searchWord, string user)
        {
            return _passTable.Search(searchOption | TableOptions.User, searchWord, new User(user));
        }

        /// <summary>
        /// Searches for all password owned by a specific user
        /// </summary>
        /// <param name="user">The password owner</param>
        /// <returns>List of SearchResults containing all passwords</returns>
        public List<SearchResult> GetAllUserPass(string user)
        {
            return _passTable.Search(TableOptions.User, null, new User(user));
        }

        /// <summary>
        /// Generates a random password based on some generate options 
        /// </summary>
        /// <param name="options">Options for the generate process</param>
        /// <param name="length">Length of password</param>
        /// <returns>A random generated password</returns>
        public string GeneratePassword(GeneratorOptions options, int length)
        {
            IGenerator generator = new PasswordGenerator();

            if ((options & GeneratorOptions.LowerAlpha) != 0)
                generator.SetLowerAlpha();

            if ((options & GeneratorOptions.UpperAlpha) != 0)
                generator.SetUpperAlpha();

            if ((options & GeneratorOptions.Numeric) != 0)
                generator.SetNumeric();

            if ((options & GeneratorOptions.Special) != 0)
                generator.SetSpecial();

            generator.SetLength(length);

            return generator.Generate();
        }

        /// <summary>
        /// Add new password entry
        /// </summary>
        /// <param name="user">Username</param>
        /// <param name="pass">Password</param>
        public void AddPassword(User user, Password pass)
        {
            _passTable.Add(user, pass);
        }

        /// <summary>
        /// Delete a password
        /// </summary>
        /// <param name="options">Options</param>
        /// <param name="user">Username</param>
        public void DeletePassword(DeleteOptions options, string user)
        {
            _passTable.Delete(options, new User(user));
        }
    }
}
