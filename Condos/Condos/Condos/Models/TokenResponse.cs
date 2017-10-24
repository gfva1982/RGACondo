using System;
using Newtonsoft.Json;

namespace Condos.Models
{
    public class TokenResponse
    {
        [JsonProperty(PropertyName = "access_token")]
        public string AccessToken
        {
            get;
            set;
        }

        [JsonProperty(PropertyName = "token_type")]
        public string TokenType
        {
            get;
            set;
        }

        [JsonProperty(PropertyName = "expires_in")]
        public int ExpiresIn
        {
            get;
            set;
        }

        [JsonProperty(PropertyName = "userName")]
        public string UserName
        {
            get;
            set;
        }

        [JsonProperty(PropertyName = ".ussuded")]
        public DateTime Ussuded
        {
            get;
            set;
        }

        [JsonProperty(PropertyName = ".expires")]
        public DateTime Expires
        {
            get;
            set;
        }

        [JsonProperty(PropertyName = "error_description")]
        public string ErrorDescription
        {
            get;
            set;
        }

    }
}
