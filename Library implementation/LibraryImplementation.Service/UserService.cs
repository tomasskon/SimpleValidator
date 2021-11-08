using System;
using System.Collections.Generic;
using LibraryImplementation.Domain.Exceptions;
using LibraryImplementation.Domain.Models;
using LibraryImplementation.Repository.Interfaces;
using LibraryImplementation.Service.Interfaces;

namespace LibraryImplementation.Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IUserValidationService _userValidationService;
        
        public UserService(IUserRepository userRepository, IUserValidationService userValidationService)
        {
            _userRepository = userRepository;
            _userValidationService = userValidationService;
        }

        public IList<User> GetAll()
        {
            return _userRepository.GetAll();
        }

        public User Get(Guid userId)
        {
            var user = _userRepository.Get(userId);
            
            if (user == null)
                throw new UserNotFoundException($"There is no user with id: {userId}");
            
            return user;
        }

        public Guid Create(User user)
        {
            _userValidationService.ValidateUser(user);
            return _userRepository.Create(user);
        }

        public void Update(User user)
        {
            _userValidationService.ValidateUser(user);

            if (!_userRepository.CheckIfUserExists(user.Id))
                throw new UserNotFoundException($"There is no user with id: {user.Id} to be updated");
            
            _userRepository.Update(user);
        }

        public void Delete(Guid userId)
        {
            if (!_userRepository.CheckIfUserExists(userId))
                throw new UserNotFoundException($"There is no user with id: {userId} to be deleted");
            
            _userRepository.Delete(userId);
        }
    }
}