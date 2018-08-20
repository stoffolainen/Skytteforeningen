using System;
using Newtonsoft.Json;

namespace Api.Infrastructure.Auth
{
    public class TokenResponse
    {
        [JsonProperty(PropertyName = "access_token")]
        public string AccessToken { get; }

        [JsonProperty(PropertyName = "expires_at")]
        public DateTime ExpiresAt { get; }

        public TokenResponse(string accessToken, DateTime expiresAt)
        {
            AccessToken = accessToken;
            ExpiresAt = expiresAt;
        }
    }
}