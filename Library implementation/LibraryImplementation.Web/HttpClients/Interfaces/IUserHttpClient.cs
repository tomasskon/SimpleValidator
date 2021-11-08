using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LibraryImplementation.Web.ViewModels;
using LibraryImplementation.Web.ViewModels.User;

namespace LibraryImplementation.Web.HttpClients.Interfaces
{
    public interface IUserHttpClient
    {
        Task<IList<UserViewModel>> GetAll();

        Task<UserViewModel> GetById(Guid userId);

        Task<StandardErrorResponse> Update(UserViewModel user);

        Task<Tuple<Guid, StandardErrorResponse>> Create(CreateUserViewModel user);

        Task<bool> Delete(Guid userId);
    }
}