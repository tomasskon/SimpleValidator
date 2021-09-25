
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ValidatorsUnitTests.Source.Validators;

namespace ValidatorsUnitTests.Source.UnitTests
{
    [TestClass]
    public class PhoneNumberValidatorUnitTests
    {
        [TestMethod]
        public void Phone_number_is_blank_should_not_be_valid()
        {
            var isValid = PhoneNumberValidator.isPhoneNumberValid("   ");
            Assert.AreEqual(false, isValid, "Not a valid phone number because its empty spaces only and is too short.");
        }

        [TestMethod]
        public void Phone_number_Is_Blank_should_not_be_valid()
        {
            var isValid = PhoneNumberValidator.isPhoneNumberValid("8647");
            Assert.AreEqual(false, isValid, "Not a valid phone number because its too short.");
        }

        [TestMethod]
        public void Phone_number_has_forbidden_characters()
        {
            var isValid = PhoneNumberValidator.isPhoneNumberValid("+370647a7^)2");
            Assert.AreEqual(false, isValid, "Not a valid phone number because it has invalid characters.");
        }

        [TestMethod]
        public void Phone_number_is_valid_with_eight_at_the_beggining()
        {
            var isValid = PhoneNumberValidator.isPhoneNumberValid("864777262");
            Assert.AreEqual(true, isValid, "Valid number.");
        }

        [TestMethod]
        public void Phone_number_is_valid()
        {
            var isValid = PhoneNumberValidator.isPhoneNumberValid("+37064777262");
            Assert.AreEqual(true, isValid, "Valid number.");
        }

        [TestMethod]
        public void Phone_number_with_country_number_has_plus()
        {
            var isValid = PhoneNumberValidator.isPhoneNumberValid("+864777262");
            Assert.AreEqual(true, isValid, "Number not valid, has plus with country number.");
        }

        [TestMethod]
        public void Phone_number_with_international_code_does_not_have_plus()
        {
            var isValid = PhoneNumberValidator.isPhoneNumberValid("37064777262");
            Assert.AreEqual(true, isValid, "Number not valid, does not have plus with international code.");
        }

        [TestMethod]
        public void Phone_number_has_wrong_first_character()
        {
            var isValid = PhoneNumberValidator.isPhoneNumberValid("-a37064777262");
            Assert.AreEqual(true, isValid, "Number not valid, wrong character at the beggining.");
        }

        [TestMethod]
        public void Phone_number_()
        {
            var isValid = PhoneNumberValidator.isPhoneNumberValid("-a37064777262");
            Assert.(true, isValid, "Number not valid, wrong character at the beggining.");
        }

        [TestMethod]
        public void Phone_number_is_too_long()
        {
            var isValid = PhoneNumberValidator.isPhoneNumberValid("+370647772622222");
            Assert.AreEqual(false, isValid, "Number too long.");
        }

    }
}
