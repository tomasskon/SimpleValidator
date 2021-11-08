using System;
using LibraryImplementation.Domain.Exceptions;
using LibraryImplementation.Domain.Models;
using LibraryImplementation.Repository.Interfaces;
using LibraryImplementation.Service.Interfaces;
using Moq;
using NUnit.Framework;

namespace LibraryImplementation.Service.Tests
{
    [TestFixture]
    public class UserServiceTests
    {
        private Mock<IUserRepository> _userRepositoryMock;
        private Mock<IUserValidationService> _userValidationService;
        private IUserService _userService;

        private User _testUser = new()
        {
            Id = Guid.NewGuid(),
            Name = "TestUser",
            Surname = "TestUser",
            PhoneNumber = "+37012345678",
            Email = "test@email.com",
            Address = "TestAddress",
            Password = "TestPassword!"
        };
        
        [SetUp]
        public void SetUp()
        {
            _userRepositoryMock = new Mock<IUserRepository>();
            _userValidationService = new Mock<IUserValidationService>();
            _userService = new UserService(_userRepositoryMock.Object, _userValidationService.Object);
        }

        [Test]
        public void GivenUserRepository_WhenGetAllUsers_UserRepositoryGetAllCalledOnce()
        {
            _userRepositoryMock.Setup(x => x.GetAll()).Verifiable();

            _userService.GetAll();
            
            _userRepositoryMock.Verify(x => x.GetAll(), Times.Once);
        }
        
        [Test]
        public void GivenUserRepository_WhenGet_UserRepositoryGetCalledOnce()
        {
            _userRepositoryMock.Setup(x => x.Get(_testUser.Id)).Returns(_testUser).Verifiable();

            var user = _userService.Get(_testUser.Id);
            
            AssertUserEquality(_testUser, user);
            _userRepositoryMock.Verify(x => x.Get(_testUser.Id), Times.Once);
        }
        
        [Test]
        public void GivenUserRepository_WhenGetNonExistingUser_ThrowsUserNotFoundException()
        {
            _userRepositoryMock.Setup(x => x.Get(_testUser.Id)).Returns((User)null).Verifiable();

            Assert.Throws<UserNotFoundException>(() => _userService.Get(_testUser.Id));
            _userRepositoryMock.Verify(x => x.Get(_testUser.Id), Times.Once);
        }
        
        [Test]
        public void GivenUserRepository_WhenCreateUser_UserRepositoryCreateCalledOnce()
        {
            _userRepositoryMock.Setup(x => x.Create(_testUser)).Returns(_testUser.Id).Verifiable();

            var userId = _userService.Create(_testUser);
            var userParameter = (User)_userRepositoryMock.Invocations[0].Arguments[0];
            
            AssertUserEquality(_testUser, userParameter);
            Assert.AreEqual(_testUser.Id, userId);
            _userRepositoryMock.Verify(x => x.Create(_testUser), Times.Once);
        }
        
        [Test]
        public void GivenUserValidationService_WhenCreateOrUpdateUserInvalidUser_InvalidUserPasswordException()
        {
            _userValidationService.Setup(x => x.ValidateUser(_testUser)).Throws<InvalidUserPasswordException>().Verifiable();
            SetUpRepositoryMethodsForValidationExceptions();
            
            Assert.Throws<InvalidUserPasswordException>(() => _userService.Create(_testUser));
            Assert.Throws<InvalidUserPasswordException>(() => _userService.Update(_testUser));
            
            AssertRepositoryMethodsWereNotRunWithValidationExceptions();
        }
        
        [Test]
        public void GivenUserValidationService_WhenCreateOrUpdateUserInvalidUser_InvalidUserEmailException()
        {
            _userValidationService.Setup(x => x.ValidateUser(_testUser)).Throws<InvalidUserEmailException>().Verifiable();
            SetUpRepositoryMethodsForValidationExceptions();
            
            Assert.Throws<InvalidUserEmailException>(() => _userService.Create(_testUser));
            Assert.Throws<InvalidUserEmailException>(() => _userService.Update(_testUser));
            
            AssertRepositoryMethodsWereNotRunWithValidationExceptions();
        }
        
        [Test]
        public void GivenUserValidationService_WhenCreateOrUpdateUserInvalidUser_InvalidUserPhoneNumberException()
        {
            _userValidationService.Setup(x => x.ValidateUser(_testUser)).Throws<InvalidUserPhoneNumberException>().Verifiable();
            SetUpRepositoryMethodsForValidationExceptions();
            
            Assert.Throws<InvalidUserPhoneNumberException>(() => _userService.Create(_testUser));
            Assert.Throws<InvalidUserPhoneNumberException>(() => _userService.Update(_testUser));
            
            AssertRepositoryMethodsWereNotRunWithValidationExceptions();
        }

        private void SetUpRepositoryMethodsForValidationExceptions()
        {
            _userRepositoryMock.Setup(x => x.Create(_testUser)).Verifiable();
            _userRepositoryMock.Setup(x => x.Update(_testUser)).Verifiable();
        }
        
        private void AssertRepositoryMethodsWereNotRunWithValidationExceptions()
        {
            _userValidationService.Verify(x => x.ValidateUser(_testUser), Times.Exactly(2));
            _userRepositoryMock.Verify(x => x.Create(_testUser), Times.Never);
            _userRepositoryMock.Verify(x => x.Update(_testUser), Times.Never);
        }

        [Test]
        public void GivenUserRepository_WhenUpdateUser_UserRepositoryUpdateCalledOnce()
        {
            _userRepositoryMock.Setup(x => x.Update(_testUser)).Verifiable();
            _userRepositoryMock.Setup(x => x.CheckIfUserExists(_testUser.Id)).Returns(true);

            _userService.Update(_testUser);
            var updatedUserId = (Guid)_userRepositoryMock.Invocations[0].Arguments[0];
            
            Assert.AreEqual(_testUser.Id, updatedUserId);
            _userRepositoryMock.Verify(x => x.Update(_testUser), Times.Once);
        }
        
        [Test]
        public void GivenUserRepository_WhenUpdateUser_UserRepositoryCheckIfUserExistsCalledOnce()
        {
            _userRepositoryMock.Setup(x => x.Update(_testUser));
            _userRepositoryMock.Setup(x => x.CheckIfUserExists(_testUser.Id)).Returns(true).Verifiable();

            _userService.Update(_testUser);
            
            _userRepositoryMock.Verify(x => x.CheckIfUserExists(_testUser.Id), Times.Once);
        }
        
        [Test]
        public void GivenUserRepository_WhenUpdateNonExistingUser_ThrowsUserNotFoundException()
        {
            _userRepositoryMock.Setup(x => x.Update(_testUser)).Verifiable();
            _userRepositoryMock.Setup(x => x.CheckIfUserExists(_testUser.Id)).Returns(false);

            Assert.Throws<UserNotFoundException>(() => _userService.Update(_testUser));
            _userRepositoryMock.Verify(x => x.Update(_testUser), Times.Never);
        }
        
        [Test]
        public void GivenUserRepository_WhenDeleteUser_UserRepositoryDeleteCalledOnce()
        {
            _userRepositoryMock.Setup(x => x.Delete(_testUser.Id)).Verifiable();
            _userRepositoryMock.Setup(x => x.CheckIfUserExists(_testUser.Id)).Returns(true);

            _userService.Delete(_testUser.Id);
            var deletedUserId = (Guid)_userRepositoryMock.Invocations[0].Arguments[0];

            Assert.AreEqual(_testUser.Id, deletedUserId);
            _userRepositoryMock.Verify(x => x.Delete(_testUser.Id), Times.Once);
        }
        
        [Test]
        public void GivenUserRepository_WhenDeleteUser_UserRepositoryCheckIfUserExistsCalledOnce()
        {
            _userRepositoryMock.Setup(x => x.Delete(_testUser.Id));
            _userRepositoryMock.Setup(x => x.CheckIfUserExists(_testUser.Id)).Returns(true).Verifiable();

            _userService.Delete(_testUser.Id);

            _userRepositoryMock.Verify(x => x.CheckIfUserExists(_testUser.Id), Times.Once);
        }

        [Test]
        public void GivenUserRepository_WhenDeleteNonExistingUser_ThrowsUserNotFoundException()
        {
            _userRepositoryMock.Setup(x => x.Delete(_testUser.Id));
            _userRepositoryMock.Setup(x => x.CheckIfUserExists(_testUser.Id)).Returns(false);
            
            Assert.Throws<UserNotFoundException>(() => _userService.Delete(_testUser.Id));
        }

        private void AssertUserEquality(User expectedUser, User actualUser)
        {
            Assert.AreEqual(expectedUser.Id, actualUser.Id);
            Assert.AreEqual(expectedUser.Name, actualUser.Name);
            Assert.AreEqual(expectedUser.PhoneNumber, actualUser.PhoneNumber);
        }
    }
}