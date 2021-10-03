using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ValidatorsUnitTests.Source.Validators;
using ValidatorsUnitTests.Source.Validators.ConfigurationModels;

namespace ValidatorsUnitTests
{
    [TestClass]
    public class EmailValidatorUnitTests
    {
        private void SetUp()
        {
            //this list could be technically fetched from api to know up to date valid tlds
            Configuration.EmailConfiguration = new Email
            {
                ValidTLD = new List<string> {"com", "lt", "ru"}
            };
        }
        
        [TestMethod]
        public void Email_is_blank_spaces_should_not_be_valid()
        {
            SetUp();
            
            var isValid = EmailValidator.IsEmailValid("   ");
            Assert.AreEqual(false, isValid, "Not a valid email because its empty spaces only and is too short.");
        }

        [TestMethod]
        public void Email_is_too_short_should_not_be_valid()
        {
            SetUp();
            
            var isValid = EmailValidator.IsEmailValid("a");
            Assert.AreEqual(false, isValid, "Not a valid email because its too short.");
        }

        [TestMethod]
        public void Email_does_not_have_at_sign_not_valid()
        {
            SetUp();
            
            var isValid = EmailValidator.IsEmailValid("lisauskas.rytisgmail.com");
            Assert.AreEqual(false, isValid, "Not a valid email because it does not have @ sign.");
        }

        [TestMethod]
        public void Email_have_spaces_not_valid()
        {
            SetUp();
            
            var isValid = EmailValidator.IsEmailValid("lisa uskas.rytis gmail.com");
            Assert.AreEqual(false, isValid, "Not a valid email because it has spaces.");
        }

        [TestMethod]
        public void Email_does_not_have_dot_in_domain()
        {
            SetUp();
            
            var isValid = EmailValidator.IsEmailValid("lisauskas.rytis@gmailcom");
            Assert.AreEqual(false, isValid, "Not a valid email, no dot in domain.");
        }

        [TestMethod]
        public void Email_has_a_dot_before_at_sign_not_valid()
        {
            SetUp();
            
            var isValid = EmailValidator.IsEmailValid("lisauskas.rytis.@gmail.com");
            Assert.AreEqual(false, isValid, "Not a valid email, dot before @");
        }

        //this unit test is wrong, because the domain is completely valid
        // [TestMethod]
        // public void Email_has_invalid_domain()
        // {
        //     var isValid = EmailValidator.IsEmailValid("lisauskas.rytis@yhaha.com");
        //     Assert.AreEqual(false, isValid, "Not a valid email, invalid domain");
        // }

        [TestMethod]
        public void Email_has_invalid_TLD()
        {
            SetUp();
            
            var isValid = EmailValidator.IsEmailValid("lisauskas.rytis@gmail.rusijas");
            Assert.AreEqual(false, isValid, "Not a valid email, invalid TLD");
        }

        //this unit test is incorrect as well since the characters used here are actually valid if it is written in local part
        //the allowed characters: printable characters !#$%&'*+-/=?^_`{|}~
        //source: https://en.wikipedia.org/wiki/Email_address
        // [TestMethod]
        // public void Email_has_forbidden_characters_not_valid()
        // {
        //     var isValid = EmailValidator.IsEmailValid("lisauskas.&^!#4)(_+#!rytis@gmail.com");
        //     Assert.AreEqual(false, isValid, "Not a valid email, forbidden characters");
        // }

        [TestMethod]
        public void Email_has_at_sign_at_the_wrong_place_not_valid()
        {
            SetUp();
            
            var isValid = EmailValidator.IsEmailValid("lisaus@kas.rytis@gmail.com");
            Assert.AreEqual(false, isValid, "Not a valid email, @ in the middle of the name");
        }

        [TestMethod]
        public void Email_does_not_have_domain()
        {
            SetUp();
            
            var isValid = EmailValidator.IsEmailValid("lisaus@kas.rytis@.com");
            Assert.AreEqual(false, isValid, "Not a valid email, no domain");
        }

        //this unit test isn't really logical, because it already contains two @ signs so it is already invalid
        // [TestMethod]
        // public void Email_does_not_have_TLD()
        // {
        //     var isValid = EmailValidator.IsEmailValid("lisaus@kas.rytis@gmail.");
        //     Assert.AreEqual(false, isValid, "Not a valid email, no TLD");
        // }
        
        //this is how I would write the unit test.
        [TestMethod]
        public void Email_does_not_have_TLD()
        {
            SetUp();
            
            var isValid = EmailValidator.IsEmailValid("test.test@gmail.");
            Assert.AreEqual(false, isValid, "Not a valid email, no TLD");
        }
    }
}
