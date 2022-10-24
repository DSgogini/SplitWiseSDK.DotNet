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
