using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace alkilab.validators
{
    public class BasicValidator
    {

        const string emailRegex = @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" + @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$";

        public bool ValidateEmail(string stringToValidate) {
            return Regex.IsMatch(stringToValidate, emailRegex, RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
        }

        public bool ValidateText(string stringToValidate) {
            return Regex.IsMatch(stringToValidate, @"^[a-zA-Z]+$", RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
        }

        public bool ValidateAlphaNumeric(string stringToValidate) {
            return Regex.IsMatch(stringToValidate, @"^[a-zA-Z0-9]+$");
        }

        /// <summary>
        /// Validates these rules for the password:
        /// 1. the password should contain 8 to 15 characters
        /// 2. the password must have at least 1 letter, 1 number 
        /// and 1 Uppercase letter
        /// </summary>
        /// <param name="stringToValidate"></param>
        /// <returns></returns>
        public bool ValidatePassword(string stringToValidate) {
            return Regex.IsMatch(stringToValidate, @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{8,15}$");
        }
    }
}
