using System;
using LibraryImplementation.Domain.Exceptions;
using LibraryImplementation.Domain.Models;
using NUnit.Framework;

namespace LibraryImplementation.Service.Tests
{
    [TestFixture]
    public class UserValidationServiceTests
    {
        private UserValidationService _userValidationService;

        private User _testUser;

        [SetUp]
        public void SetUp()
        {
            _testUser = new User
            {
                Id = Guid.NewGuid(),
                Name = "TestUser",
                Surname = "TestUser",
                PhoneNumber = "+37012345678",
                Email = "test@email.com",
                Address = "TestAddress",
                Password = "TestPassword!"
            };
        }

        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            _userValidationService = new UserValidationService();
        }

        [Test]
        public void GivenUserValidationService_WhenValidateUserWithIncorrectEmail_ThrowsInvalidUserEmailException()
        {
            _testUser.Email = "bademailadress";

            Assert.Throws<InvalidUserEmailException>(() => _userValidationService.ValidateUser(_testUser));
        }

        [Test]
        public void GivenUserValidationService_WhenValidateUserWithIncorrectPassword_ThrowsInvalidUserPasswordException()
        {
            _testUser.Password = "badpassword";

            Assert.Throws<InvalidUserPasswordException>(() => _userValidationService.ValidateUser(_testUser));
        }
        
        [Test]
        public void GivenUserValidationService_WhenValidateUserWithIncorrectPhone_ThrowsInvalidUserPhoneNumberException()
        {
            _testUser.PhoneNumber = "+3231";

            Assert.Throws<InvalidUserPhoneNumberException>(() => _userValidationService.ValidateUser(_testUser));
        }
        
        [Test]
        public void GivenUserValidationService_WhenValidateCorrectUser_DoesNotThrowAnyException()
        {
            Assert.DoesNotThrow(() => _userValidationService.ValidateUser(_testUser));
        }
    }
}