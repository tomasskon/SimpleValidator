using ValidatorsUnitTests.Source.Validators.ConfigurationModels;

namespace ValidatorsUnitTests.Source.Validators
{
    public static class Configuration
    {
        public static Password PasswordConfiguration { get; set; }
        
        public static Number PhoneNumberConfiguration { get; set; }
        
        public static Email EmailConfiguration { get; set; }
    }
}