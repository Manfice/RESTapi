using System.Threading.Tasks;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;

namespace spWeb.Infrastructure.Identity
{
    public class StoreAuthProvider:OAuthAuthorizationServerProvider
    {
        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            var userManager =
                context.OwinContext.Get<SsUserMeneger>("AspNet.Identity.Owin:" +
                                                       typeof (SsUserMeneger).AssemblyQualifiedName);

            var user = await userManager.FindAsync(context.UserName, context.Password);
            if (user==null)
            {
                context.SetError("invalid_grant", "The user name or password is incorrect");
            }
            else
            {
                var ident = await userManager.CreateIdentityAsync(user, "Custom");
                var authTicket = new AuthenticationTicket(ident, new AuthenticationProperties());
                context.Validated(authTicket);
                context.Request.Context.Authentication.SignIn(ident);
            }
        }

        public override Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
            return Task.FromResult<object>(null);
        }
    }
}