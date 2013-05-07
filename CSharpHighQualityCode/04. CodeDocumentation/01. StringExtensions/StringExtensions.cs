// ********************************
// <copyright file="StringExtensions.cs" company="Telerik Academy">
// Copyright (c) 2013 Telerik Academy. All rights reserved.
// </copyright>
//
// ********************************
namespace TelerikStringExtensions
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Security.Cryptography;
    using System.Text;
    using System.Text.RegularExpressions;

    /// <summary>
    /// Extension methods for <see cref="System.String"/> class.
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// Converts the string instance to a MD5 hash.
        /// </summary>
        /// <param name="input">String to get the MD5 hash.</param>
        /// <returns>Hexadecimal representation of the input string.</returns>
        public static string ToMd5Hash(this string input)
        {
            var md5Hash = MD5.Create();

            var data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));
            
            var builder = new StringBuilder();

            for (int i = 0; i < data.Length; i++)
            {
                builder.Append(data[i].ToString("x2"));
            }

            return builder.ToString();
        }

        /// <summary>
        /// Represents the boolean interpretation of the strings "true", "ok", "yes", "1", "да".
        /// </summary>
        /// <param name="input">String value that will be converted to boolean.</param>
        /// <returns>True if the input string can be converted.</returns>
        public static bool ToBoolean(this string input)
        {
            var stringTrueValues = new[] { "true", "ok", "yes", "1", "да" };
            return stringTrueValues.Contains(input.ToLower());
        }

        /// <summary>
        /// Converts the string instance to <see cref="System.Int16"/>.
        /// </summary>
        /// <param name="input">String value that will be converted.</param>
        /// <returns><see cref="System.Int16"/> representation of the input string.</returns>
        /// <remarks>Returns 0 if the input string is not a number.</remarks>
        public static short ToShort(this string input)
        {
            short shortValue;
            short.TryParse(input, out shortValue);
            return shortValue;
        }

        /// <summary>
        /// Converts the string instance to <see cref="System.Int32"/>.
        /// </summary>
        /// <param name="input">String value that will be converted.</param>
        /// <returns><see cref="System.Int32"/> representation of the input string.</returns>
        /// <remarks>Returns 0 if the input string is not a number.</remarks>
        public static int ToInteger(this string input)
        {
            int integerValue;
            int.TryParse(input, out integerValue);
            return integerValue;
        }

        /// <summary>
        /// Converts the string instance to <see cref="System.Int64"/>.
        /// </summary>
        /// <param name="input">String value that will be converted.</param>
        /// <returns><see cref="System.Int64"/> representation of the input string.</returns>
        /// <remarks>Returns 0 if the input string is not a number.</remarks>
        public static long ToLong(this string input)
        {
            long longValue;
            long.TryParse(input, out longValue);
            return longValue;
        }

        /// <summary>
        /// Converts the string instance to <see cref="System.DateTime"/>.
        /// </summary>
        /// <param name="input">String value that will be converted.</param>
        /// <returns><see cref="System.DateTime"/> representation of the input string.</returns>
        public static DateTime ToDateTime(this string input)
        {
            DateTime dateTimeValue;
            DateTime.TryParse(input, out dateTimeValue);
            return dateTimeValue;
        }

        /// <summary>
        /// Capitalizes the first letter of the current string instance.
        /// </summary>
        /// <param name="input">The string that will be modified.</param>
        /// <returns>String with a capitalized first letter.</returns>
        public static string CapitalizeFirstLetter(this string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return input;
            }

            return input.Substring(0, 1).ToUpper(CultureInfo.CurrentCulture) + input.Substring(1, input.Length - 1);
        }

        /// <summary>
        /// Returns a substring between <paramref name="startString"/> and <paramref name="endString"/> starting from <paramref name="startFrom"/>.
        /// </summary>
        /// <param name="input">The current string instance.</param>
        /// <param name="startString">The left substring from which to start the search.</param>
        /// <param name="endString">The right substring from which to start the search.</param>
        /// <param name="startFrom">Position from which to start the search.</param>
        /// <returns>Substring between <paramref name="startString"/> and <paramref name="endString"/> starting from <paramref name="startFrom"/>.</returns>
        public static string GetStringBetween(this string input, string startString, string endString, int startFrom = 0)
        {
            input = input.Substring(startFrom);
            startFrom = 0;
            if (!input.Contains(startString) || !input.Contains(endString))
            {
                return string.Empty;
            }

            var startPosition = input.IndexOf(startString, startFrom, StringComparison.Ordinal) + startString.Length;
            if (startPosition == -1)
            {
                return string.Empty;
            }

            var endPosition = input.IndexOf(endString, startPosition, StringComparison.Ordinal);
            if (endPosition == -1)
            {
                return string.Empty;
            }

            return input.Substring(startPosition, endPosition - startPosition);
        }

        /// <summary>
        /// Converts all cyrillic letters in the string to the corresponding latin letters.
        /// </summary>
        /// <param name="input">The current string instance.</param>
        /// <returns>String containing the latin representation of all cyrillic letters that appear in the input string.</returns>
        public static string ConvertCyrillicToLatinLetters(this string input)
        {
            var bulgarianLetters = new[]
                                       {
                                           "а", "б", "в", "г", "д", "е", "ж", "з", "и", "й", "к", "л", "м", "н", "о", "п",
                                           "р", "с", "т", "у", "ф", "х", "ц", "ч", "ш", "щ", "ъ", "ь", "ю", "я"
                                       };
            var latinRepresentationsOfBulgarianLetters = new[]
                                                             {
                                                                 "a", "b", "v", "g", "d", "e", "j", "z", "i", "y", "k",
                                                                 "l", "m", "n", "o", "p", "r", "s", "t", "u", "f", "h",
                                                                 "c", "ch", "sh", "sht", "u", "i", "yu", "ya"
                                                             };
            for (var i = 0; i < bulgarianLetters.Length; i++)
            {
                input = input.Replace(bulgarianLetters[i], latinRepresentationsOfBulgarianLetters[i]);
                input = input.Replace(bulgarianLetters[i].ToUpper(), latinRepresentationsOfBulgarianLetters[i].CapitalizeFirstLetter());
            }

            return input;
        }

        /// <summary>
        /// Converts all latin letters in the string to the corresponding cyrillic letters.
        /// </summary>
        /// <param name="input">The current string instance.</param>
        /// <returns>String containing the cyrillic representation of all latin letters that appear in the input string.</returns>
        public static string ConvertLatinToCyrillicKeyboard(this string input)
        {
            var latinLetters = new[]
                                   {
                                       "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p",
                                       "q", "r", "s", "t", "u", "v", "w", "x", "y", "z"
                                   };

            var bulgarianRepresentationOfLatinKeyboard = new[]
                                                             {
                                                                 "а", "б", "ц", "д", "е", "ф", "г", "х", "и", "й", "к",
                                                                 "л", "м", "н", "о", "п", "я", "р", "с", "т", "у", "ж",
                                                                 "в", "ь", "ъ", "з"
                                                             };

            for (int i = 0; i < latinLetters.Length; i++)
            {
                input = input.Replace(latinLetters[i], bulgarianRepresentationOfLatinKeyboard[i]);
                input = input.Replace(latinLetters[i].ToUpper(), bulgarianRepresentationOfLatinKeyboard[i].ToUpper());
            }

            return input;
        }

        /// <summary>
        /// Converts a string to a valid username by replacing all cyrillic letters with the corresponding latin letters and removes all non-alphanumeric characters (excluding the symbols '_', '.' and '-').
        /// </summary>
        /// <param name="input">The current string instance.</param>
        /// <returns>String consisting of alphanumeric characters (including the symbols '_', '.' and '-').</returns>
        public static string ToValidUsername(this string input)
        {
            input = input.ConvertCyrillicToLatinLetters();
            return Regex.Replace(input, @"[^a-zA-z0-9_\.]+", string.Empty);
        }

        /// <summary>
        /// Converts a string to a valid file name by replacing all cyrillic letters with the corresponding latin letters and removes all non-alphanumeric characters (excluding the symbols '_', '.' and '-'). All spaces are replaced with the symbol '-'.
        /// </summary>
        /// <param name="input">The current string instance.</param>
        /// <returns>String consisting of alphanumeric characters (including the symbols '_', '.' and '-').</returns>
        public static string ToValidLatinFileName(this string input)
        {
            input = input.Replace(" ", "-").ConvertCyrillicToLatinLetters();
            return Regex.Replace(input, @"[^a-zA-z0-9_\.\-]+", string.Empty);
        }

        /// <summary>
        /// Gets the first characters of a string starting from the beginning and 
        /// whose length is the lesser of the string's length and <paramref name="charsCount"/> 
        /// </summary>
        /// <param name="input">The current string instance.</param>
        /// <param name="charsCount">Number of characters in the substring.</param>
        /// <returns>String containing the first characters of the current string instance.</returns>
        public static string GetFirstCharacters(this string input, int charsCount)
        {
            return input.Substring(0, Math.Min(input.Length, charsCount));
        }

        /// <summary>
        /// Gets the extension of a string represented as a file name.
        /// </summary>
        /// <param name="fileName">The current string instance.</param>
        /// <returns>String representing the file extension.</returns>
        /// <remarks>Returns an empty string if the input is nat a correct file name.</remarks>
        public static string GetFileExtension(this string fileName)
        {
            if (string.IsNullOrWhiteSpace(fileName))
            {
                return string.Empty;
            }

            string[] fileParts = fileName.Split(new[] { "." }, StringSplitOptions.None);
            if (fileParts.Count() == 1 || string.IsNullOrEmpty(fileParts.Last()))
            {
                return string.Empty;
            }

            return fileParts.Last().Trim().ToLower();
        }

        /// <summary>
        /// Gets the corresponding content type of a file extension.
        /// </summary>
        /// <param name="fileExtension">The current string instance.</param>
        /// <returns>String representation of the content type.</returns>
        public static string ToContentType(this string fileExtension)
        {
            var fileExtensionToContentType = new Dictionary<string, string>
                                                 {
                                                     { "jpg", "image/jpeg" },
                                                     { "jpeg", "image/jpeg" },
                                                     { "png", "image/x-png" },
                                                     {
                                                         "docx",
                                                         "application/vnd.openxmlformats-officedocument.wordprocessingml.document"
                                                     },
                                                     { "doc", "application/msword" },
                                                     { "pdf", "application/pdf" },
                                                     { "txt", "text/plain" },
                                                     { "rtf", "application/rtf" }
                                                 };
            if (fileExtensionToContentType.ContainsKey(fileExtension.Trim()))
            {
                return fileExtensionToContentType[fileExtension.Trim()];
            }

            return "application/octet-stream";
        }

        /// <summary>
        /// Converts a string into a sequence of bytes.
        /// </summary>
        /// <param name="input">The current string instance.</param>
        /// <returns>Byte array containing the byte representation of the string chars.</returns>
        public static byte[] ToByteArray(this string input)
        {
            var bytesArray = new byte[input.Length * sizeof(char)];
            Buffer.BlockCopy(input.ToCharArray(), 0, bytesArray, 0, bytesArray.Length);
            return bytesArray;
        }
    }
}
