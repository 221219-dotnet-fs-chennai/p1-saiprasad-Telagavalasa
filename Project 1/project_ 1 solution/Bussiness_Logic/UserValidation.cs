using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Bussiness_Logic
{
    public  class UserValidation
    {
        public  static bool isValidEmail(string email)
        {
            string pattern = @"^\w+@\w+\.\w{2,4}$";
            if (Regex.IsMatch(email, pattern))
            {
                return true;
            }
            else
            { return false; }

        }
        public static bool isValidPassword(string password)
        {
            string pattern = @"^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9]).{8,20}$";
            if (Regex.IsMatch(password, pattern))
            {
                return true;
            }
            else
            { return false; }

        }
        public static bool isValidPhone(string phone)
        {
            string pattern = @"^[6-9]\d{9}$";
            if (Regex.IsMatch(phone, pattern))
            {
                return true;
            }
            else
            { return false; }

        }
        public static bool isValidZipcode(string zipcode)
        {
            string pattern = @"^[1-9]\d{5}$";
            if (Regex.IsMatch(zipcode, pattern) || zipcode == null)
            {
                return true;
            }
            else
            { return false; }

        }

    }
}
