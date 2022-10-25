using SplitwiseSDK.DotNet.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplitwiseSDK.DotNet.Abstract
{
    public interface IUserService
    {
        Task<User> GetCurrentUserAsync();
        Task<User> GetUserByIdAsync(int id);
    }
}
