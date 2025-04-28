using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ticket_Project.Utils
{
    internal class ValidationHelper
    {
        

        public static bool IsNullOrEmpty(string value)
        {
            return string.IsNullOrEmpty(value);
        }

        public static bool IsValidEmail(string email)
        {
            if (string.IsNullOrEmpty(email))
                return false;

            
            return email.Contains("@") && email.Contains(".");
        }

        public static bool IsValidDni(string dni)
        {
            if (string.IsNullOrEmpty(dni))
                return false;

           
            dni = dni.ToUpper();
            if (dni.Length != 9 || !int.TryParse(dni.Substring(0, 8), out _) || !char.IsLetter(dni[8]))
                return false;

            return true;
        }

        public static bool IsValidAge(int age)
        {
            return age > 0 && age < 150; 
        }

        public static bool IsValidStringLength(string value, int minLength, int maxLength)
        {
            if (value == null)
                return false;

            return value.Length >= minLength && value.Length <= maxLength;
        }
    }
}
