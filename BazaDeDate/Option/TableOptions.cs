/**************************************************************************
 *                                                                        *
 *  File:        TableOptions.cs                                          *
 *  Copyright:   (c) 2023, Pintilie Razvan-Nicolae                        *7
 *  E-mail:      razvan-nicolae.pintilie@student.tuiasi.ro                *
 *  Description: Options for a query.                                     *
 *                                                                        *
 *  This program is free software; you can redistribute it and/or modify  *
 *  it under the terms of the GNU General Public License as published by  *
 *  the Free Software Foundation. This program is distributed in the      *
 *  hope that it will be useful, but WITHOUT ANY WARRANTY; without even   *
 *  the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR   *
 *  PURPOSE. See the GNU General Public License for more details.         *
 *                                                                        *
 **************************************************************************/


namespace BazaDeDate.Option
{
    /// <summary>
    /// Options for a query. 
    /// </summary>
    public enum TableOptions
    {
        User = 1,
        DomainUser = 2,
        Email = 4,
        Domain = 8,
        Password = 16
    }
}
