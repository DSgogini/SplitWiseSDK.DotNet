using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SplitwiseSDK.DotNet.Abstract;
using System;
using System.IO;
using Xunit;

namespace SplitwiseSDK.DotNet.UnitTests
{
    public class UserClientTest
    {
        private readonly ServiceProvider _serviceProvider;
        private readonly IConfiguration _configuration;
        private readonly IUserService _userService;
        public UserClientTest()
        {
            _configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", false, false)
                .AddEnvironmentVariables()
                .Build();

            var services = new ServiceCollection();
            services.AddSplitwise(x =>
            {
                x.Version = _configuration.GetSection("SpitwiseOpts:Version").Value;// "v3.0";
                x.ApiKey = _configuration.GetSection("SpitwiseOpts:APIKey").Value;
            });
            _serviceProvider = services.BuildServiceProvider();

            _userService = _serviceProvider.GetService<IUserService>() ?? throw new ArgumentNullException(nameof(IUserService));
        }

        [Fact]
        public async void GetCurrentUserAsync_Test()
        {
            var currentUser = await _userService.GetCurrentUserAsync();
            Assert.NotNull(currentUser);
            Assert.True(currentUser.Id > 0);
        }

        [Fact]
        public async void GetUserByIdAsync_Test()
        {
            int id = 14398256;
            var user = await _userService.GetUserByIdAsync(id);
            Assert.NotNull(user);
            Assert.True(user.Id > 0);
        }
    }
}