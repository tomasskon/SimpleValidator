﻿namespace LibraryImplementation.Contracts.User
{
    public class CreateUserContract
    {
        public string Name { get; set; }
        
        public string Surname { get; set; }
        
        public string PhoneNumber { get; set; }
        
        public string Email { get; set; }
        
        public string Address { get; set; }
        
        public string Password { get; set; }
    }
}