using System.Collections.Generic;
using Biblioteka;
using LibraryImplementation.Domain.Exceptions;
using LibraryImplementation.Domain.Models;
using LibraryImplementation.Service.Interfaces;

namespace LibraryImplementation.Service
{
    public class UserValidationService : IUserValidationService
    {
        private EmailValidator _emailValidator;
        private PasswordChecker _passwordChecker;
        private PhoneValidator _phoneValidator;
        
        public UserValidationService()
        {
            _emailValidator = new EmailValidator();
            _passwordChecker = new PasswordChecker();
            _phoneValidator = new PhoneValidator();
        }
        
        public void ValidateUser(User user)
        {
            SetUpEmailValidationRules();
            ValidateEmail(user.Email);
        
            SetUpPasswordValidationRules();
            ValidatePassword(user.Password);
        
            SetUpPhoneValidationRules();
            ValidatePhone(user.PhoneNumber);
        }
        
        private void SetUpEmailValidationRules()
        {
            ValuesForValidations.ValidDomainNames = new List<string>{ "gmail", "email"};
            ValuesForValidations.ValidTLDNames = new List<string> {"com", "lt"};
        }
        
        private void SetUpPasswordValidationRules()
        {
            ValuesForValidations.SpecialSymbols = new List<char>{ '!', '?'};
        }
        
        private void SetUpPhoneValidationRules()
        {
            _phoneValidator.AddValidationRule(12, "+370");
            ValuesForValidations.SpecialSymbolsForPhoneNumbers = new List<char> {'+'};
        }
        
        private void ValidateEmail(string email)
        {
            if (!_emailValidator.IsEmailValid(email))
                throw new InvalidUserEmailException($"Provided user email {email} is invalid");
        }
        
        private void ValidatePassword(string password)
        {
            if (!_passwordChecker.IsPasswordValid(password))
                throw new InvalidUserPasswordException($"Provided user password is invalid");
        }
        
        private void ValidatePhone(string phoneNumber)
        {
            if (!_phoneValidator.IsPhoneNumberValid(phoneNumber))
                throw new InvalidUserPhoneNumberException($"Provided user phone number: {phoneNumber} is invalid");
        }
    }
}