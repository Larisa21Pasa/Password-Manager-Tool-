/**************************************************************************
 *                                                                        *
 *  File:        PasswordsTable.cs                                        *
 *  Copyright:   (c) 2023, Pintilie Razvan-Nicolae                        *
 *  E-mail:      razvan-nicolae.pintilie@student.tuiasi.ro                *
 *  Description: Custom Exception for SearchPassword                      *                              
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

namespace BazaDeDate.Exceptions
{
    /// <summary>
    /// Custom Exception for SearchPassword
    /// </summary>
    public class SearchPasswordsException : Exception
    {
        public SearchPasswordsException(string message) : base(message)
        {

        }
    }
}