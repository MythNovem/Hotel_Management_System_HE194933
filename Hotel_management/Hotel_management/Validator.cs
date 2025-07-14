using System;
using System.Text.RegularExpressions;

namespace HotelManagement
{
    internal static class Validator
    {
        public static string ValidateUsername(string username)
        {
            if (string.IsNullOrWhiteSpace(username))
                return "Username is required.";

            if (username.Length < 3)
                return "Username must be at least 3 characters.";

            return null;
        }

        public static string ValidatePassword(string password)
        {
            if (string.IsNullOrWhiteSpace(password))
                return "Password is required.";

            if (password.Length < 4)
                return "Password must be at least 4 characters.";

            return null;
        }

        public static string ValidateEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return "Email is required.";

            // Simple email pattern
            string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            if (!Regex.IsMatch(email, pattern))
                return "Invalid email format.";

            return null;
        }

        public static string ValidatePhone(string phone)
        {
            if (string.IsNullOrWhiteSpace(phone))
                return "Phone number is required.";

            if (!Regex.IsMatch(phone, @"^[0-9]{9,11}$"))
                return "Invalid phone number format.";

            return null;
        }

        public static string ValidateNotEmpty(string fieldName, string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                return $"{fieldName} is required.";

            return null;
        }

        public static string ValidateDateRange(DateTime start, DateTime end)
        {
            if (start >= end)
                return "Check-in date must be before check-out date.";

            if (start < DateTime.Today)
                return "Check-in date cannot be in the past.";

            return null;
        }

        public static string ValidateDeletableUser(string roleName)
        {
            if (string.IsNullOrWhiteSpace(roleName))
                return "Role is required.";

            if (roleName.Trim().ToLower() == "admin")
                return "Cannot delete admin user.";

            return null;
        }
        public static string ValidatePrice(string priceText)
        {
            if (string.IsNullOrWhiteSpace(priceText))
                return "Price is required.";

            if (!decimal.TryParse(priceText, out decimal price) || price < 0)
                return "Invalid price.";

            return null;
        }

    }
}