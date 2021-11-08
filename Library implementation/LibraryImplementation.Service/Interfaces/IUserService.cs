using System;
using System.Collections.Generic;
using LibraryImplementation.Domain.Models;

namespace LibraryImplementation.Service.Interfaces
{
    public interface IUserService
    {
        IList<User> GetAll();
        
        User Get(Guid userId);

        Guid Create(User user);
        
        void Update(User user);

        void Delete(Guid userId);
    }
}