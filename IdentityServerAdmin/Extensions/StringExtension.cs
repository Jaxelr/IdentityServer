// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.
// Jaxel: Taken from  https://github.com/IdentityModel/IdentityModel

using System;
using System.Security.Cryptography;
using System.Text;

namespace IdentityServerAdmin
{
    /// <summary>
    /// Extensions for strings
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// Creates a SHA256 hash of the specified input.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns>A hash</returns>
        public static string ToSha256(this string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return string.Empty;
            }
            byte[] bytes = Encoding.UTF8.GetBytes(input);
            byte[] hash = SHA256.HashData(bytes);

            return Convert.ToBase64String(hash);
        }

        /// <summary>
        /// Creates a SHA512 hash of the specified input.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns>A hash</returns>
        public static string ToSha512(this string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return string.Empty;
            }
            byte[] bytes = Encoding.UTF8.GetBytes(input);
            byte[] hash = SHA512.HashData(bytes);

            return Convert.ToBase64String(hash);
        }
    }
}
