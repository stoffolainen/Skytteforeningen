using System;

namespace Api.Infrastructure.Auth
{
    public class TokenIssuerOptions
    {
        public string Issuer { get; set; }

        public string Audience { get; set; }

        public string SigningSecret { get; set; }

        public TimeSpan ValidFor { get; set; } = TimeSpan.FromDays(2);
    }
}