﻿using Microsoft.IdentityModel.Tokens;
using System;

namespace Dream.Middleware
{
    public class TokenProviderOptions
    {
        public string Path { get; set; } = "/token";

        public string Issuer { get; set; }

        public string Audience { get; set; }

        public TimeSpan Expiration { get; set; } = TimeSpan.FromMinutes(3600);

        public SigningCredentials SigningCredentials { get; set; }
    }
}
