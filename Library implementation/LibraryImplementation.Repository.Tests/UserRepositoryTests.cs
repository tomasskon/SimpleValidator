using System;
using System.Linq;
using AutoMapper;
using LibraryImplementation.Domain.Models;
using LibraryImplementation.Repository.Entities;
using LibraryImplementation.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;

namespace LibraryImplementation.Repository.Tests
{
    [TestFixture]
    public class UserRepositoryTests : RepositoryTestBase
    {
        private IUserRepository _userRepository;
        private IMapper _mapper;
        private UserEntity _testUserEntity = new()
        {
            Name = "TestUser",
            Surname = "TestUser",
            PhoneNumber = "+37012345678",
            Email = "test@email.com",
            Address = "TestAddress",
            Password = "TestPassword!"
        };

        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            var mapperConfiguration = new MapperConfiguration(c =>
                c.CreateMap<UserEntity, User>().ReverseMap()
            );

            _mapper = mapperConfiguration.CreateMapper();

            _userRepository = new UserRepository(DbContext, _mapper);
        }
        
        [SetUp]
        public void SetUp()
        {
            _testUserEntity.Id = Guid.Empty;
            DbContext.Users.Add(_testUserEntity);
            DbContext.SaveChanges();
            DbContext.Entry(_testUserEntity).State = EntityState.Detached;
        }
        
        [TearDown]
        public void TearDown()
        {
            DbContext.Database.ExecuteSqlRaw("DELETE FROM Users");
        }
        
        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            DbContext.Database.ExecuteSqlRaw("DELETE FROM Users");
            DbContext.Database.CloseConnection();
            DbContext.Dispose();
        }

        [Test]
        public void GivenUserRepository_WhenGetAll_ReturnsListOfUsers()
        {
            var users = _userRepository.GetAll();
            
            AssertExpectedUserEqualsActual(_mapper.Map<User>(_testUserEntity), users[0]);
        }
        
        [Test]
        public void GivenUserRepository_WhenGet_ReturnsUser()
        {
            var users = _userRepository.Get(_testUserEntity.Id);
            
            AssertExpectedUserEqualsActual(_mapper.Map<User>(_testUserEntity), users);
        }
        
        [Test]
        public void GivenUserRepository_WhenGetNonExistingUser_ReturnNull()
        {
            var users = _userRepository.Get(Guid.Empty);
            
            Assert.IsNull(users);
        }

        [Test]
        public void GivenUserRepository_WhenCreateUser_UserCreated()
        {
            var user = new User
            {
                Name = "TestUser",
                Surname = "TestUser",
                PhoneNumber = "+37012345678",
                Email = "test@email.com",
                Address = "TestAddress",
                Password = "TestPassword!"
            };

            var userId = _userRepository.Create(user);
            user.Id = userId;

            var userEntity = DbContext.Users.Single(x => x.Id == userId);
            
            AssertExpectedUserEqualsActual(user, _mapper.Map<User>(userEntity));
        }
        
        [Test]
        public void GivenUserRepository_WhenUpdateUser_UserUpdated()
        {
            var user = _mapper.Map<User>(_testUserEntity);
            user.Name = "UpdatedUser";
            user.PhoneNumber = "+37000000000";
            
            _userRepository.Update(user);

            var userEntity = DbContext.Users.Single(x => x.Id == user.Id);
            
            AssertExpectedUserEqualsActual(user, _mapper.Map<User>(userEntity));
        }

        [Test]
        public void GivenUserRepository_WhenDeleteUser_UserDeleted()
        {
            _userRepository.Delete(_testUserEntity.Id);

            var userEntity = DbContext.Users.SingleOrDefault(x => x.Id == _testUserEntity.Id);
            
            Assert.IsNull(userEntity);
        }

        
        [Test]
        public void GivenUserRepository_WhenCheckIfUserExists_ReturnsTrue()
        {
            var exists = _userRepository.CheckIfUserExists(_testUserEntity.Id);
            
            Assert.IsTrue(exists);
        }

        [Test]
        public void GivenUserRepository_WhenCheckIfUserExistsForNonExistingUser_ReturnsFalse()
        {
            var exists = _userRepository.CheckIfUserExists(Guid.Empty);
            
            Assert.IsFalse(exists);
        }

        private void AssertExpectedUserEqualsActual(User expectedUser, User actualUser)
        {
            Assert.AreEqual(expectedUser.Id, actualUser.Id);
            Assert.AreEqual(expectedUser.Name, actualUser.Name);
            Assert.AreEqual(expectedUser.Surname, actualUser.Surname);
            Assert.AreEqual(expectedUser.Email, actualUser.Email);
            Assert.AreEqual(expectedUser.Address, actualUser.Address);
            Assert.AreEqual(expectedUser.Password, actualUser.Password);
            Assert.AreEqual(expectedUser.PhoneNumber, actualUser.PhoneNumber);
        }
    }
}