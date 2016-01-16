using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.WindowsAzure.ServiceRuntime;

namespace CloudService.Configuration
{
    public class CloudServiceConfigurationProvider : ConfigurationProvider
    {
        public CloudServiceConfigurationProvider(IEnumerable<string> settingNames)
        {
            if (settingNames == null)
            {
                throw new ArgumentNullException(nameof(settingNames));
            }

            SettingNames = settingNames;
        }

        protected IEnumerable<string> SettingNames { get; private set; }

        public override void Load()
        {
            var data = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);

            foreach (var settingName in SettingNames)
            {
                var value = RoleEnvironment.GetConfigurationSettingValue(settingName);
                if (!string.IsNullOrEmpty(value))
                {
                    data.Add(settingName, value);
                }
            }

            Data = data;
        }
    }
}
