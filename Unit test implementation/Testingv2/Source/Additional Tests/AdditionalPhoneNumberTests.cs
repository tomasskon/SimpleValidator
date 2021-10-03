using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ValidatorsUnitTests.Source.Validators;
using ValidatorsUnitTests.Source.Validators.ConfigurationModels;

namespace ValidatorsUnitTests.Source.Additional_Tests
{
    [TestClass]
    public class AdditionalPhoneNumberTests
    {
        private void SetUp()
        {
            Configuration.PhoneNumberConfiguration = new Number
            {
                CountryCodes = new Dictionary<string, int>
                {
                    {"+227", 8},
                    {"+371", 8}
                }
            };
        }

        [TestMethod]
        public void GivenPhoneValidator_WhenCountryCodeIsFromConfiguration_ReturnsTrue()
        {
            SetUp();
            
            var isValid = PhoneNumberValidator.IsPhoneNumberValid("+37112345678");
            Assert.AreEqual(true, isValid);
        }
        
        [TestMethod]
        public void GivenPhoneValidator_WhenCountryCodeIsNotFromConfiguration_ReturnsFalse()
        {
            SetUp();
            
            var isValid = PhoneNumberValidator.IsPhoneNumberValid("+22112345678");
            Assert.AreEqual(false, isValid);
        }
    }
}