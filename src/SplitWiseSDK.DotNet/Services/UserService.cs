using Newtonsoft.Json;
using SplitWiseSDK.DotNet.Abstract;
using SplitWiseSDK.DotNet.Entity;
using SplitWiseSDK.DotNet.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplitWiseSDK.DotNet.Services
{
    internal class UserService : IUserService
    {
        private readonly HttpClient _httpClient;
        public UserService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<User> GetUserByIdAsync(int id)
        {
            if (id == default)
            {
                throw new ArgumentNullException(nameof(id));
            }

            var response = await _httpClient.GetAsync($"get_user/{id}");
            if (response.IsSuccessStatusCode)
            {
                var jsonString = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<UserApiRespose>(jsonString).User;
            }
            else if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
            {
                throw new UnauthorizedException("");
            }
            else if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                throw new NotFoundException("");
            }
            else if (response.StatusCode == System.Net.HttpStatusCode.Forbidden)
            {
                throw new ForbiddenException("");
            }
            else
            {
                throw new Exception();
            }
        }

        async Task<User> IUserService.GetCurrentUserAsync()
        {
            var response = await _httpClient.GetAsync("get_current_user");
            if (response.IsSuccessStatusCode)
            {
                string jsonString = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<UserApiRespose>(jsonString).User;
            }
            else if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
            {
                throw new UnauthorizedException("");
            }
            else
                throw new Exception();
        }
    }
}
