using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ValidatorsUnitTests.Source.Validators;
using ValidatorsUnitTests.Source.Validators.ConfigurationModels;

namespace ValidatorsUnitTests.Source.UnitTests
{
    [TestClass]
    public class PhoneNumberValidatorUnitTests
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
        public void Phone_number_is_blank_should_not_be_valid()
        {
            SetUp();
            
            var isValid = PhoneNumberValidator.IsPhoneNumberValid("   ");
            Assert.AreEqual(false, isValid, "Not a valid phone number because its empty spaces only and is too short.");
        }
        
        //unit test name is incorrect should be Phone_number_Is_Too_Short_should_not_be_valid
        [TestMethod]
        public void Phone_number_Is_Blank_should_not_be_valid()
        {
            SetUp();
            
            var isValid = PhoneNumberValidator.IsPhoneNumberValid("8647");
            Assert.AreEqual(false, isValid, "Not a valid phone number because its too short.");
        }

        [TestMethod]
        public void Phone_number_has_forbidden_characters()
        {
            SetUp();
            
            var isValid = PhoneNumberValidator.IsPhoneNumberValid("+370647a7^)2");
            Assert.AreEqual(false, isValid, "Not a valid phone number because it has invalid characters.");
        }

        [TestMethod]
        public void Phone_number_is_valid_with_eight_at_the_beggining()
        {
            SetUp();
            
            var isValid = PhoneNumberValidator.IsPhoneNumberValid("864777262");
            Assert.AreEqual(true, isValid, "Valid number.");
        }

        [TestMethod]
        public void Phone_number_is_valid()
        {
            SetUp();
            
            var isValid = PhoneNumberValidator.IsPhoneNumberValid("+37064777262");
            Assert.AreEqual(true, isValid, "Valid number.");
        }

        //this unit test is incorrect because it should assert false but asserts true
        // [TestMethod]
        // public void Phone_number_with_country_number_has_plus()
        // {
        //     var isValid = PhoneNumberValidator.IsPhoneNumberValid("+864777262");
        //     Assert.AreEqual(true, isValid, "Number not valid, has plus with country number.");
        // }

        //my addition changed true to false
        [TestMethod]
        public void Phone_number_with_country_number_has_plus()
        {
            SetUp();
            
            var isValid = PhoneNumberValidator.IsPhoneNumberValid("+864777262");
            Assert.AreEqual(false, isValid, "Number not valid, has plus with country number.");
        }
        
        //same issue here the phone number is not valid but the unit test is asserting true
        // [TestMethod]
        // public void Phone_number_with_international_code_does_not_have_plus()
        // {
        //     SetUp();
        //     
        //     var isValid = PhoneNumberValidator.IsPhoneNumberValid("37064777262");
        //     Assert.AreEqual(true, isValid, "Number not valid, does not have plus with international code.");
        // }
        
        //my addition changed true to false
        [TestMethod]
        public void Phone_number_with_international_code_does_not_have_plus()
        {
            SetUp();
            
            var isValid = PhoneNumberValidator.IsPhoneNumberValid("37064777262");
            Assert.AreEqual(false, isValid, "Number not valid, does not have plus with international code.");
        }
        
        //same issue here the phone number is not valid but the unit test is asserting true
        // [TestMethod]
        // public void Phone_number_has_wrong_first_character()
        // {
        //     SetUp();
        //     
        //     var isValid = PhoneNumberValidator.IsPhoneNumberValid("-a37064777262");
        //     Assert.AreEqual(true, isValid, "Number not valid, wrong character at the beggining.");
        // }
        
        //my addition changed true to false
        [TestMethod]
        public void Phone_number_has_wrong_first_character()
        {
            SetUp();
            
            var isValid = PhoneNumberValidator.IsPhoneNumberValid("-a37064777262");
            Assert.AreEqual(false, isValid, "Number not valid, wrong character at the beggining.");
        }

        //same issue here the phone number is not valid but the unit test is asserting true
        // [TestMethod]
        // public void Phone_number_()
        // {
        //     SetUp();
        //     
        //     var isValid = PhoneNumberValidator.IsPhoneNumberValid("-a37064777262");
        //     Assert.AreEqual(true, isValid, "Number not valid, wrong character at the beggining.");
        // }
        
        //my addition changed true to false
        [TestMethod]
        public void Phone_number_()
        {
            SetUp();
            
            var isValid = PhoneNumberValidator.IsPhoneNumberValid("-a37064777262");
            Assert.AreEqual(false, isValid, "Number not valid, wrong character at the beggining.");
        }
        
        [TestMethod]
        public void Phone_number_is_too_long()
        {
            SetUp();
            
            var isValid = PhoneNumberValidator.IsPhoneNumberValid("+370647772622222");
            Assert.AreEqual(false, isValid, "Number too long.");
        }
    }
}
