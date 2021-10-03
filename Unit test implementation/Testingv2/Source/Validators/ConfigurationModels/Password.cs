using System.Collections.Generic;

namespace ValidatorsUnitTests.Source.Validators.ConfigurationModels
{
    public class Password
    {
        public int PasswordLength { get; set; }
        
        public List<char> SpecialSymbols { get; set; }
    }
}