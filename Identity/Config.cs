// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityModel;
using IdentityServer4;
using IdentityServer4.Models;
using IdentityServer4.Test;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Security.Claims;

namespace Identity
{
    public class Config
    {
        static string[] allowedClientOrigins;

        public Config(IConfiguration configuration)
        {
            allowedClientOrigins = configuration.GetSection("Security:AllowedClientOrigins").Get<string[]>();
        }

        public static IEnumerable<IdentityResource> Ids =>
            new IdentityResource[]
            {
                new IdentityResources.OpenId(),
                new IdentityResource("basicInfo", new List<string>()
                {
                    JwtClaimTypes.Role,
                    JwtClaimTypes.Name
                })
            };

        public static IEnumerable<ApiResource> Apis =>
            new ApiResource[]
            {
                new ApiResource("apigateway.webusers", "API gateway for web users")
            };

        public static IEnumerable<Client> Clients =>
            new Client[]
            {
                new Client()
                {
                    ClientId = "client",
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    ClientSecrets =
                    {
                        new Secret("secret".Sha256())
                    },
                    AllowedScopes = {"apigateway.web"}
                },
                new Client()
                {
                    ClientId = "vue",
                    AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
                    ClientSecrets =
                    {
                        new Secret("secret".Sha256())
                    },
                    AllowedScopes = new List<string>()
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        "basicInfo",
                        "apigateway.webusers"
                    },
                    AllowedCorsOrigins = allowedClientOrigins
                }
            };

        public static List<TestUser> TestUsers =>
        new List<TestUser>
        {
            new TestUser()
            {
                SubjectId = Guid.NewGuid().ToString(),
                Username = "WS",
                Password = "WS",
                Claims = new List<Claim>()
                {
                    new Claim(JwtClaimTypes.Name, "my name"),
                    new Claim(JwtClaimTypes.Role, "my role")
                }
            }
        };
    }
}