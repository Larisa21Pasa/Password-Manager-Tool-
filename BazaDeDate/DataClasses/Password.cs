/**************************************************************************
 *                                                                        *
 *  File:        PasswordsTable.cs                                        *
 *  Copyright:   (c) 2023, Pintilie Razvan-Nicolae                        *
 *  E-mail:      razvan-nicolae.pintilie@student.tuiasi.ro                *
 *  Description: A class holding the info for a new password.             *
 *                                                                        *
 *  This program is free software; you can redistribute it and/or modify  *
 *  it under the terms of the GNU General Public License as published by  *
 *  the Free Software Foundation. This program is distributed in the      *
 *  hope that it will be useful, but WITHOUT ANY WARRANTY; without even   *
 *  the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR   *
 *  PURPOSE. See the GNU General Public License for more details.         *
 *                                                                        *
 **************************************************************************/

namespace BazaDeDate.DataClasses
{
    /// <summary>
    /// A class holding the info for a new password.
    /// </summary>
    public class Password
    {
        public string Email { get; set; }
        public string Domain { get; set; }
        public string PasswordValue { get; set; }
        public string DomainUser { get; set; }

        public Password(string email, string domain, string passwordValue, string domainUser)
        {
            DomainUser = domainUser;
            Email = email;
            Domain = domain;
            PasswordValue = passwordValue;
        }
    }
}
