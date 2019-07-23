using System.Collections.Generic;
using System.Security.Claims;
using IdentityServer4;
using IdentityServer4.Models;
using IdentityServer4.Test;

namespace Wallet.Services.Identity
{
    public class InMemoryConfiguration
    {
        public static IEnumerable<ApiResource> ApiResources()
        {
            return new[] {
                new ApiResource("walletkeeper", "walletkeeper")
                {
                    UserClaims = new [] { "email" }
                }
            };
        }


        public static IEnumerable<IdentityResource> IdentityResources()
        {
            return new IdentityResource[] {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
                new IdentityResources.Email()
            };
        }

        public static IEnumerable<Client> Clients()
        {
            return new[] {
                new Client
                {
                    ClientId = "walletkeeper",  
                    ClientSecrets = new [] { new Secret("secret".Sha256()) },
                    AllowedGrantTypes = GrantTypes.ResourceOwnerPasswordAndClientCredentials,
                    AllowedScopes = new [] { "walletkeeper" },
                    AllowAccessTokensViaBrowser = true,
                    //RedirectUris = new [] { "http://localhost:28849/signin-oidc" },
                    //PostLogoutRedirectUris = { "http://localhost:28849/signout-callback-oidc" },
                }
            };
        }
    }
}
