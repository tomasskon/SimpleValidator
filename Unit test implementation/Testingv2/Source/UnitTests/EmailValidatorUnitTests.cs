using Microsoft.VisualStudio.TestTools.UnitTesting;
using ValidatorsUnitTests.Source.Validators;

namespace ValidatorsUnitTests
{
    [TestClass]
    public class EmailValidatorUnitTests
    {
        [TestMethod]
        public void Email_is_blank_spaces_should_not_be_valid()
        {
            var isValid = EmailValidator.isEmailValid("   ");
            Assert.AreEqual(false, isValid, "Not a valid email because its empty spaces only and is too short.");
        }

        [TestMethod]
        public void Email_is_too_short_should_not_be_valid()
        {
            var isValid = EmailValidator.isEmailValid("a");
            Assert.AreEqual(false, isValid, "Not a valid email because its too short.");
        }

        [TestMethod]
        public void Email_does_not_have_at_sign_not_valid()
        {
            var isValid = EmailValidator.isEmailValid("lisauskas.rytisgmail.com");
            Assert.AreEqual(false, isValid, "Not a valid email because it does not have @ sign.");
        }

        [TestMethod]
        public void Email_have_spaces_not_valid()
        {
            var isValid = EmailValidator.isEmailValid("lisa uskas.rytis gmail.com");
            Assert.AreEqual(false, isValid, "Not a valid email because it has spaces.");
        }

        [TestMethod]
        public void Email_does_not_have_dot_in_domain()
        {
            var isValid = EmailValidator.isEmailValid("lisauskas.rytis@gmailcom");
            Assert.AreEqual(false, isValid, "Not a valid email, no dot in domain.");
        }

        [TestMethod]
        public void Email_has_a_dot_before_at_sign_not_valid()
        {
            var isValid = EmailValidator.isEmailValid("lisauskas.rytis.@gmail.com");
            Assert.AreEqual(false, isValid, "Not a valid email, dot before @");
        }

        [TestMethod]
        public void Email_has_invalid_domain()
        {
            var isValid = EmailValidator.isEmailValid("lisauskas.rytis@yhaha.com");
            Assert.AreEqual(false, isValid, "Not a valid email, invalid domain");
        }

        [TestMethod]
        public void Email_has_invalid_TLD()
        {
            var isValid = EmailValidator.isEmailValid("lisauskas.rytis@gmail.rusijas");
            Assert.AreEqual(false, isValid, "Not a valid email, invalid TLD");
        }

        [TestMethod]
        public void Email_has_forbidden_characters_not_valid()
        {
            var isValid = EmailValidator.isEmailValid("lisauskas.&^!#4)(_+#!rytis@gmail.com");
            Assert.AreEqual(false, isValid, "Not a valid email, forbidden characters");
        }

        [TestMethod]
        public void Email_has_at_sign_at_the_wrong_place_not_valid()
        {
            var isValid = EmailValidator.isEmailValid("lisaus@kas.rytis@gmail.com");
            Assert.AreEqual(false, isValid, "Not a valid email, @ in the middle of the name");
        }

        [TestMethod]
        public void Email_does_not_have_domain()
        {
            var isValid = EmailValidator.isEmailValid("lisaus@kas.rytis@.com");
            Assert.AreEqual(false, isValid, "Not a valid email, no domain");
        }

        [TestMethod]
        public void Email_does_not_have_TLD()
        {
            var isValid = EmailValidator.isEmailValid("lisaus@kas.rytis@gmail.");
            Assert.AreEqual(false, isValid, "Not a valid email, no TLD");
        }





    }
}
