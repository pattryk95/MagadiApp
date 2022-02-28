using Duende.IdentityServer;
using Duende.IdentityServer.Models;

namespace Magadi.Services.Identity
{
    public class SD
    {
        public const string Admin = "Admin";
        public const string Employee = "Employee";
        public const string Manager = "Manager";
        public const string Customer = "Customer";

        public static IEnumerable<IdentityResource> IdentityResources =>
            new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Email(),
                new IdentityResources.Profile()
            };

        public static IEnumerable<ApiScope> ApiScopes =>
            new List<ApiScope> {
                new ApiScope("magadi", "MagadiServer"),
                new ApiScope(name: "read", "MagadiServer"),
                new ApiScope(name: "write", "MagadiServer"),
                new ApiScope(name: "delete", "MagadiServer")
            };

        public static IEnumerable<Client> Clients =>
            new List<Client>
            {
                new Client
                {
                    ClientId ="client",
                    ClientSecrets = {new Secret("secret".Sha256())},
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    AllowedScopes = {"read", "write", "profile"}
                },
                new Client
                {
                    ClientId ="magadi",
                    ClientSecrets = {new Secret("secret".Sha256())},
                    AllowedGrantTypes = GrantTypes.Code,
                    RedirectUris = { "http://localhost:44372/signin-oidc" },
                    PostLogoutRedirectUris = { "http://localhost:44372/signout-callback-oidc" },
                    AllowedScopes = new List<string>
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        IdentityServerConstants.StandardScopes.Email,
                        "magadi"
                    }
                }
            };
    }
}
