// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.Extensions.Configuration;
using System.IO;
using System.Text.Json.Serialization;

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
        [JsonPropertyName("TenantId")]
        public string TenantId { get; set; }

        [JsonPropertyName("AppId")]
        public string AppId { get; set; }

        [JsonPropertyName("ClientSecret")]
        public string ClientSecret { get; set; }

        [JsonPropertyName("B2cExtensionAppClientId")]
        public string B2cExtensionAppClientId { get; set; }

        [JsonPropertyName("UsersFileName")]
        public string UsersFileName { get; set; }

    }
}
