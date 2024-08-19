﻿/**************************************************************************
 *                                                                        *
 *  File:        UppderAlphaRandomCharacter.cs                            *
 *  Copyright:   (c) 2023, Budaca Marius-Andrei                           *
 *  E-mail:      marius-andrei.budaca@student.tuiasi.ro                   *
 *  Description: Generates a random upper case alpha character.           *
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

namespace GenerareParola.RandomCharacter
{
    /// <summary>
    /// Generates a random upper case alpha character
    /// </summary>
    internal class UppderAlphaRandomCharacter : IRandomCharacter
    {
        private readonly Random _random;

        /// <summary>
        /// Generates a random upper case alpha character
        /// </summary>
        /// <param name="seed">Random seed</param>
        public UppderAlphaRandomCharacter(int seed)
        {
            _random = new Random(seed);
        }
        public char NextChar()
        {
            return (char)('A' + _random.Next(26));
        }
    }
}
