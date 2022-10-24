using SplitWiseSDK.DotNet.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplitWiseSDK.DotNet.Abstract
{
    public interface IUserService
    {
        Task<User> GetCurrentUserAsync();
    }
}
