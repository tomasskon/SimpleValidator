using System;
using System.Collections.Generic;
using System.Net.Http.Json;
using System.Threading.Tasks;
using LibraryImplementation.Web.HttpClients.Interfaces;
using LibraryImplementation.Web.ViewModels;
using LibraryImplementation.Web.ViewModels.User;

namespace LibraryImplementation.Web.HttpClients
{
    public class UserHttpClient : GenericHttpClient, IUserHttpClient
    {
        public async Task<IList<UserViewModel>> GetAll()
        {
            using var httpClient = CreateHttpClient();

            var response = await httpClient.GetAsync("User/GetAll");

            if (response.IsSuccessStatusCode)
                return await response.Content.ReadFromJsonAsync<IList<UserViewModel>>();

            return null;
        }

        public async Task<UserViewModel> GetById(Guid userId)
        {
            using var httpClient = CreateHttpClient();

            var response = await httpClient.GetAsync($"User/GetById?userId={userId}");

            if (response.IsSuccessStatusCode)
                return await response.Content.ReadFromJsonAsync<UserViewModel>();

            return null;
        }

        public async Task<StandardErrorResponse> Update(UserViewModel user)
        {
            using var httpClient = CreateHttpClient();

            var response = await httpClient.PutAsync("User/UpdateUser", CreateJsonContent(user));

            if(response.IsSuccessStatusCode)
                return null;

            return await response.Content.ReadFromJsonAsync<StandardErrorResponse>();
        }

        public async Task<Tuple<Guid, StandardErrorResponse>> Create(CreateUserViewModel user)
        {
            using var httpClient = CreateHttpClient();

            var response = await httpClient.PostAsync("User/CreateUser", CreateJsonContent(user));

            if (response.IsSuccessStatusCode)
            {
                var id = await response.Content.ReadFromJsonAsync<Guid>();
                return new Tuple<Guid, StandardErrorResponse>(id, null);
            }

            var error = await response.Content.ReadFromJsonAsync<StandardErrorResponse>();
            return new Tuple<Guid, StandardErrorResponse>(Guid.Empty, error);
        }

        public async Task<bool> Delete(Guid userId)
        {
            using var httpClient = CreateHttpClient();

            var response = await httpClient.DeleteAsync($"User/DeleteUser?userId={userId}");

            return response.IsSuccessStatusCode;
        }
    }
}