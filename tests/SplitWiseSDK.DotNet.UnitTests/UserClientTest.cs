
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SplitWiseSDK.DotNet.Abstract;
using System;
using System.IO;
using Xunit;

namespace SplitWiseSDK.DotNet.UnitTests
{
    public class UserClientTest
    {
        private readonly ServiceProvider _serviceProvider;
        private readonly IConfiguration _configuration;
        public UserClientTest()
        {
            _configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", false, false)
                .AddEnvironmentVariables()
                .Build();

            var services = new ServiceCollection();
            services.AddSplitWise(x =>
            {
                x.Version = _configuration.GetSection("SpitWiseOpts:Version").Value;// "v3.0";
                x.ApiKey = _configuration.GetSection("SpitWiseOpts:APIKey").Value;
            });
            _serviceProvider = services.BuildServiceProvider();
        }

        [Fact]
        public async void GetCurrentUserAsyncTest()
        {
            var userClient = _serviceProvider.GetService<IUserService>() ?? throw new ArgumentNullException(nameof(IUserService));
            var currentUser = await userClient.GetCurrentUserAsync();
            Assert.NotNull(currentUser);
            Assert.True(currentUser.Id > 0);
        }
    }
}