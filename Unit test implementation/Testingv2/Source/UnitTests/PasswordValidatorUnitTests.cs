using Microsoft.VisualStudio.TestTools.UnitTesting;
using ValidatorsUnitTests.Source.Validators;

namespace ValidatorsUnitTests
{
    [TestClass]
    public class PasswordValidatorUnitTests
    {
        [TestMethod]
        public void Password_is_blank_spaces_should_not_be_valid()
        {
            var isValid = PasswordValidator.IsPasswordValid("   ");
            Assert.AreEqual(false, isValid, "Not a valid password because its empty spaces only and is too short.");
        }

        [TestMethod]
        public void Password_is_too_short_should_not_be_valid()
        {
            var isValid = PasswordValidator.IsPasswordValid("a");
            Assert.AreEqual(false, isValid, "Not a valid password because its too short.");
        }

        [TestMethod]
        public void Password_does_not_have_upper_case_should_not_be_valid()
        {
            var isValid = PasswordValidator.IsPasswordValid("abba");
            Assert.AreEqual(false, isValid, "Not a valid password because it does not have upper case letter and is too short.");
        }

        [TestMethod]
        public void Password_is_default_good_should_be_valid()
        {
            var isValid = PasswordValidator.IsPasswordValid("AntonioGeorghini8734");
            Assert.AreEqual(true, isValid, "A valid password.");
        }

        [TestMethod]
        public void Password_is_common_should_not_be_valid()
        {
            var isValid = PasswordValidator.IsPasswordValid("123");
            Assert.AreEqual(false, isValid, "Common password, should not be valid.");
        }

        [TestMethod]
        public void Password_does_not_have_numbers()
        {
            var isValid = PasswordValidator.IsPasswordValid("AntonioGeorghini");
            Assert.AreEqual(false, isValid, "No numbers in a password.");
        }


    }
}
