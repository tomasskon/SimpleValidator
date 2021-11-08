using System;

namespace LibraryImplementation.Repository.Entities
{
    public class UserEntity
    {
        public Guid Id { get; set; }
        
        public string Name { get; set; }
        
        public string Surname { get; set; }
        
        public string PhoneNumber { get; set; }
        
        public string Email { get; set; }
        
        public string Address { get; set; }
        
        public string Password { get; set; }
    }
}