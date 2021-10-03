using System.Linq;

namespace ValidatorsUnitTests.Source.Validators
{
    public static class EmailValidator
    {
        private const string _localPartValidCharacters = "!#$%&'*+-/=?^_`{|}~.";

        public static bool IsEmailValid(string email)
        {
            return
                CheckBlankSpaces(email)
                && CheckAtSign(email)
                && CheckEmailValidity(email);
        }
        
        private static bool CheckEmailValidity(string email)
        {
            var split = email.Split('@');

            return
                CheckIfEmailContainsOnlyOneAtSign(split)
                && CheckEmailLocalPart(split[0])
                && CheckEmailDomainPart(split[1]);
        }

        private static bool CheckEmailDomainPart(string domain)
        { 
            var split = domain.Split('.');
            
            return 
                CheckDomainContainsOnlyOneDot(split)
                && CheckDomainIsNotEmpty(split[0])
                && CheckTldIsNotEmpty(split[1])
                && CheckDomainHyphen(split[0])
                && CheckTldValidity(split[1]);
        }

        private static bool CheckTldValidity(string tld) => Configuration.EmailConfiguration.ValidTLD.Contains(tld);

        private static bool CheckBlankSpaces(string email) => !email.Contains(" ");

        private static bool CheckAtSign(string email) => email.Contains('@');

        private static bool CheckDomainIsNotEmpty(string domain) => !string.IsNullOrEmpty(domain);

        private static bool CheckTldIsNotEmpty(string tld) => !string.IsNullOrEmpty(tld);

        private static bool CheckDomainContainsOnlyOneDot(string[] domainSplit) => domainSplit.Length == 2;

        private static bool CheckIfEmailContainsOnlyOneAtSign(string[] emailSplit) => emailSplit.Length == 2;

        private static bool CheckEmailLocalPart(string local)
        {
            return 
                CheckEmailLocalPartContainsValidCharacters(local)
                && CheckEmailLocalPartDots(local);
        }

        private static bool CheckEmailLocalPartContainsValidCharacters(string local)
        {
            local = _localPartValidCharacters.Aggregate(local, (current, symbol) => current.Replace(symbol, 'a'));

            return local.All(char.IsLetterOrDigit);
        }

        private static bool CheckEmailLocalPartDots(string local)
        {
            if (local.StartsWith('.') || local.EndsWith('.'))
                return false;

            return !CheckConsecutiveDots(local);
        }

        private static bool CheckDomainHyphen(string domain)
        {
            if (domain.StartsWith('-') || domain.EndsWith('-'))
                return false;

            return !CheckConsecutiveHyphens(domain);
        }

        private static bool CheckConsecutiveHyphens(string domain) =>
            domain.Where((t, i) => t == '-' && domain[i + 1] == '-').Any();

        private static bool CheckConsecutiveDots(string local) =>
            local.Where((t, i) => t == '.' && local[i + 1] == '.').Any();
    }
}
