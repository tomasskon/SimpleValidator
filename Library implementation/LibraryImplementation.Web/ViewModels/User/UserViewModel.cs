using System;
using System.ComponentModel.DataAnnotations;

namespace LibraryImplementation.Web.ViewModels.User
{
    public class UserViewModel
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