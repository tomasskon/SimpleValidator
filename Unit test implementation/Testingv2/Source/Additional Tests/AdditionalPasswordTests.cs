using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ValidatorsUnitTests.Source.Validators;
using ValidatorsUnitTests.Source.Validators.ConfigurationModels;

namespace ValidatorsUnitTests.Source.Additional_Tests
{
    [TestClass]
    public class AdditionalPasswordTests
    {
        private void SetUp()
        {
            Configuration.PasswordConfiguration = new Password
            {
                PasswordLength = 8,
                SpecialSymbols = new List<char> {'@', '!', '$'}
            };
        }

        [TestMethod]
        public void GivenPasswordValidator_WhenPasswordIsValid_ReturnsTrue()
        {
            SetUp();

            var isValid = PasswordValidator.IsPasswordValid("AntonioGe@orghini8734");
            Assert.AreEqual(true, isValid, "A valid password.");
        }
    }
}