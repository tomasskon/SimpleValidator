using System;
using System.Linq;

namespace ValidatorsUnitTests.Source.Validators
{
    public static class PhoneNumberValidator
    {
        private static readonly Tuple<string, int> _lithuanianCountryCode = new Tuple<string, int>("+370", 8);
        
       public static bool IsPhoneNumberValid(string phoneNumber) {
           phoneNumber = CheckIfNumberStartsWith8(phoneNumber);
           
            return
                CheckBlankSpaces(phoneNumber)
                && CheckForbiddenCharacters(phoneNumber)
                && CheckCountryCodeAndLength(phoneNumber);
       }

       private static string CheckIfNumberStartsWith8(string phoneNumber)
       {
           if (phoneNumber.StartsWith('8') && phoneNumber.Length == 9)
               return $"+370{phoneNumber.Remove(0, 1)}";

           return phoneNumber;
       }

       private static bool CheckBlankSpaces(string phoneNumber)
       {
           return !phoneNumber.Contains(" ");
       }

       private static bool CheckForbiddenCharacters(string phoneNumber)
       {
           var phone = phoneNumber;

           if (phone.StartsWith('+'))
               phone = phone.Remove(0, 1);
           
           return !phone.Any(char.IsLetter);
       }

       private static bool CheckCountryCodeAndLength(string phoneNumber)
       {
           return CheckLithuanianCountryCode(phoneNumber) || CheckCountryCodesFromConfiguration(phoneNumber);
       }

       private static bool CheckLithuanianCountryCode(string phoneNumber)
       {
           if (!phoneNumber.StartsWith(_lithuanianCountryCode.Item1))
               return false;

           var remainder = phoneNumber.Remove(0, _lithuanianCountryCode.Item1.Length);

           return remainder.Length == _lithuanianCountryCode.Item2;
       }

       private static bool CheckCountryCodesFromConfiguration(string phoneNumber)
       {
           foreach (var (key, value) in Configuration.PhoneNumberConfiguration.CountryCodes)
           {
               if (!phoneNumber.StartsWith(key)) 
                   continue;
               
               var remainder = phoneNumber.Remove(0, key.Length);

               if (remainder.Length == value)
                   return true;
           }

           return false;
       }
    }
}
