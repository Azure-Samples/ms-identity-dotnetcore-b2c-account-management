// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;
using System.Text.Json.Serialization;

namespace b2c_ms_graph
{
    public class UsersModel
    {
        [JsonPropertyName("users")]
        public UserModel[] Users { get; set; }

        public static UsersModel Parse(string JSON)
        {
            return JsonSerializer.Deserialize<UsersModel>(JSON);
        }
    }
}