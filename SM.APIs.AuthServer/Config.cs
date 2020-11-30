// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityServer4.Models;
using System.Collections.Generic;

namespace SM.APIs.AuthServer
{
    public static class Config
    {
        public static IEnumerable<IdentityResource> IdentityResources =>
            new IdentityResource[]
            {
                new IdentityResources.OpenId(),
                new IdentityResource(name: "profile", userClaims: new []{"name", "email" }, displayName: "Profile data")
            };


        public static IEnumerable<Client> Clients =>
            new Client[]
            { 
            // m2m client credentials flow client
                new Client
                {
                    ClientId = "webclient",
                    ClientName = "Web client with public client credentials",

                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    ClientSecrets = { new Secret("secret".Sha256()) },

                    AllowedScopes = { "story.read", "story-category.read" }
                },

                // interactive client using code flow + pkce
                new Client
                {
                    ClientId = "interactive",
                    ClientSecrets = { new Secret("secret".Sha256()) },

                    AllowedGrantTypes = GrantTypes.Code,

                    RedirectUris = { "https://localhost:44300/signin-oidc" },
                    FrontChannelLogoutUri = "https://localhost:44300/signout-oidc",
                    PostLogoutRedirectUris = { "https://localhost:44300/signout-callback-oidc" },

                    AllowOfflineAccess = true,
                    AllowedScopes = { "story.read", "story-category.read", }
                },
            };
        public static IEnumerable<ApiScope> ApiScopes =>
            new ApiScope[]
            { 
            // invoice API specific scopes
                new ApiScope(name: "story.read",   displayName: "Reads stories."),

                // customer API specific scopes
                new ApiScope(name: "story-category.read",    displayName: "Reads story's category."),

                // shared scope
                new ApiScope(name: "manage", displayName: "Provides administrative access to story and category data.")
            };

        public static IEnumerable<ApiResource> ApiResources =>
             new List<ApiResource>
             {
                 new ApiResource("story", "Story API")
                 {
                     Scopes = { "story.read", "manage" }
                 },

                 new ApiResource("story-category", "Story's category API")
                 {
                     Scopes = { "story-category.read", "manage" }
                 }
             };
    }
}