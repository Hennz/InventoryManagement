using InventoryManagement.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Services
{
    public class PasswordPolicyValidation: IPasswordPolicyValidation
    {
        private static int pwMinLenth = 8;
        //private static bool _passwordShouldContainLowercase = true;
        //private static bool _passwordShouldContainUppercase = true;
        //private static bool _passwordShouldContainDigit = true;
        //private static bool pwRequireSpecialChar = true;
        //private static bool pwRequireDigits = true;
        public int GetPasswordValidation(string password)
        {
            int validationNumber=0;

            if (password.Any(char.IsDigit))
                validationNumber++;

            if (password.Length >= pwMinLenth)
                validationNumber++;

                return validationNumber;
        }
    }
}
