using Microsoft.Extensions.DependencyInjection;
using SplitwiseSDK.DotNet.Abstract;
using SplitwiseSDK.DotNet.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace SplitwiseSDK.DotNet
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddSplitwise(this IServiceCollection services, Action<SplitwiseClientOptions> options)
        {
            SplitwiseClientOptions clientOptions = new();
            options(clientOptions);

            services.AddHttpClient<IUserService, UserService>(c =>
            {
                c.BaseAddress = new Uri($"https://secure.splitwise.com/api/{clientOptions.Version}/");
                c.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", clientOptions.ApiKey);
            });
            return services;
        }
    }
}
