using Microsoft.Extensions.DependencyInjection;
using SplitWiseSDK.DotNet.Abstract;
using SplitWiseSDK.DotNet.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace SplitWiseSDK.DotNet
{
    public class SplitWiseClientOptions
    {
        public string Version { get; set; } = "v3.0";
        public string ApiKey { get; set; }
        public string ClientSecret { get; set; }
        public string ConsumerKey { get; set; }
    }

    public static class DependencyInjection
    {
        public static IServiceCollection AddSplitWise(this IServiceCollection services, Action<SplitWiseClientOptions> options)
        {
            SplitWiseClientOptions clientOptions = new SplitWiseClientOptions();
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
