using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CloudService.Configuration
{
    public static class CloudServiceExtensions
    {
        public static IConfigurationBuilder AddCloudServiceConfig(this IConfigurationBuilder builder, IEnumerable<string> settingNames)
        {
            builder.Add(new CloudServiceConfigurationProvider(settingNames));
            return builder;
        }
    }
}
