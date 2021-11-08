using System;
using System.Collections.Generic;
using LibraryImplementation.Domain.Models;

namespace LibraryImplementation.Repository.Interfaces
{
    public interface IUserRepository
    {
        IList<User> GetAll();
        
        User Get(Guid userId);

        Guid Create(User user);
        
        void Update(User user);

        void Delete(Guid userId);

        bool CheckIfUserExists(Guid userId);
    }
}