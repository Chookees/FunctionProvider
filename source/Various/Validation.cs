﻿namespace FunctionProvider.Various
{
    using System.Text.RegularExpressions;

    public sealed class Validation
    {
        #region Lazy initialization

        private static readonly Lazy<Validation> lazy = new Lazy<Validation>(() => new Validation());

        public static Validation Task { get { return lazy.Value; } }

        private Validation() { }

        #endregion

        /// <summary>
        /// Validates if the input string is a valid email address.
        /// </summary>
        /// <param name="email">The email address to validate.</param>
        /// <returns>True if the email is valid, otherwise false.</returns>
        public bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Validates if the input string is a valid phone number.
        /// </summary>
        /// <param name="phoneNumber">The phone number to validate.</param>
        /// <returns>True if the phone number is valid, otherwise false.</returns>
        public bool IsValidPhoneNumber(string phoneNumber)
        {
            return Regex.IsMatch(phoneNumber, @"^\+?[1-9]\d{1,14}$");
        }

        /// <summary>
        /// Validates if the input string is a valid URL.
        /// </summary>
        /// <param name="url">The URL to validate.</param>
        /// <returns>True if the URL is valid, otherwise false.</returns>
        public bool IsValidUrl(string url)
        {
            return Uri.TryCreate(url, UriKind.Absolute, out Uri uriResult)
                   && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);
        }
    }
}
