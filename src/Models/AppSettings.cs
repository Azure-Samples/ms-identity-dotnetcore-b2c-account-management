using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.IO;

namespace b2c_ms_graph
{
    public class AppSettingsFile
    {
        public AppSettings AppSettings { get; set; }

        public static AppSettings ReadFromJsonFile()
        {
            IConfigurationRoot Configuration;

            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");

            Configuration = builder.Build();
            return Configuration.Get<AppSettingsFile>().AppSettings;
        }
    }

    public class AppSettings
    {
        [JsonProperty(PropertyName = "tenantId")]
        public string TenantId { get; set; }

        [JsonProperty(PropertyName = "appId")]
        public string AppId { get; set; }

        [JsonProperty(PropertyName = "appSecret")]
        public string AppSecret { get; set; }

        [JsonProperty(PropertyName = "usersFileName")]
        public string UsersFileName { get; set; }

    }
}

