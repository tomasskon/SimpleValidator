using LibraryImplementation.Domain.Models;

namespace LibraryImplementation.Service.Interfaces
{
    public interface IUserValidationService
    {
        void ValidateUser(User user);
    }
}