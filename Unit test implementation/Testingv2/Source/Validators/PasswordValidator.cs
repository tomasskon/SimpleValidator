using System.Linq;
using ValidatorsUnitTests.Source.Validators;

namespace ValidatorsUnitTests
{
    public static class PasswordValidator
    {

        public static bool IsPasswordValid(string password)
        {
            return CheckPasswordLength(password)
                   && CheckPasswordBlankSpaces(password)
                   && CheckPasswordUpperCases(password)
                   && CheckPasswordContainsNumbers(password)
                   && CheckContainsSpecialSymbol(password);
        }

        private static bool CheckPasswordLength(string password) => password.Length >= Configuration.PasswordConfiguration.PasswordLength;

        private static bool CheckPasswordBlankSpaces(string password) => !password.Contains(" ");

        private static bool CheckPasswordUpperCases(string password) => password.Any(char.IsUpper);

        private static bool CheckPasswordContainsNumbers(string password) => password.Any(char.IsNumber);

        private static bool CheckContainsSpecialSymbol(string password) => Configuration.PasswordConfiguration.SpecialSymbols.Any(password.Contains);
    }
}