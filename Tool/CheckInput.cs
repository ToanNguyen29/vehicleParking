using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FinalWindow.Tool
{
    public static class CheckInput
    {
        public static bool checkEmailIsValid(string email)
        {
            var trimmedEmail = email.Trim();

            if (trimmedEmail.EndsWith("."))
            {
                return false; // suggested by @TK-421
            }
            try
            {
                var addr = new MailAddress(email);
                return addr.Address == trimmedEmail;
            }
            catch
            {
                return false;
            }
        }

        public static bool checkAlphabeticCharacters(string str)
        {
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] < 65 || str[i] > 122 || (str[i] < 97 && str[i] > 90))
                {
                    return false;
                }
            }
            return true;
        }
        public static bool CheckYear(string year)
        {
            int result;
            int year1 = Int32.Parse(year.Substring(0, 4));
            string Timenow = DateTime.Now.ToString("yyyy-MM-dd h:mm:ss tt");
            int year2 = Int32.Parse(Timenow.Substring(0, 4));
            result = year2 - year1;

            if (result < 17 || result > 60)
                return false;
            else
                return true;
        }
        public static bool checkAlphanumericCharacters(string str)
        {
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] < 57 && str[i] > 48)
                {
                    return true;
                }
            }
            return false;
        }

        public const string motif_phone1 = @"^([\+]?33[-]?|[0])?[1-9][0-9]{8}$";
        public const string motif_phone2 = @"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$";
        public static bool IsPhoneNbr(string number)
        {
            if (number != null)
            {
                if (Regex.IsMatch(number, motif_phone1) || Regex.IsMatch(number, motif_phone2))
                {
                    return true;
                }
                else return false;
            }
            else return false;
        }
    }
}
