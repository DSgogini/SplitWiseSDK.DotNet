using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplitWiseSDK.DotNet
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddSplitWise(this IServiceCollection services)
        {
            return services;
        }
    }
}
