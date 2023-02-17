using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


namespace BusinessLogic
{
    public class Validation
    {
        // Email validation
        public bool ValidateEmail(string email)
        {
           string emailpattern = @"^[\w-\.]+@([\w-]+\.)+[\w-]{2,7}$";
            if (Regex.IsMatch(email, emailpattern))
            {
                return true;
            }
            return false;

        }
        public bool ValidatePhoneNumber(string phoneNumber)
        {
            string phonepattern = @"\(?\d{3}\)?(-|.|\s)?\d{3}(-|.)?\d{4}";
            if (Regex.IsMatch(phoneNumber, phonepattern))
            {
                return true;
            }
            return false;
        }
        public bool ValidatePassword(string password) {
            string passwordpattern = @"^(?=.*\d)(?=.*[a-z])(?=.*[A-Z]).{4,8}$";
            if (Regex.IsMatch(password, passwordpattern))
            {
                return true;
            }
            return false;

        }
    }
}
