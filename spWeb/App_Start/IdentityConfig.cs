using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.OAuth;
using Owin;
using spWeb.Infrastructure.Identity;

[assembly:OwinStartup(typeof(spWeb.IdentityConfig))]
namespace spWeb
{
    public class IdentityConfig
    {
        public void Configuration(IAppBuilder app)
        {
            app.CreatePerOwinContext<SsIdentityDbContext>(SsIdentityDbContext.Create);
            app.CreatePerOwinContext<SsUserMeneger>(SsUserMeneger.Create);
            app.CreatePerOwinContext<StoreRoleMeneger>(StoreRoleMeneger.Create);

            //app.UseCookieAuthentication(new CookieAuthenticationOptions() {AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie});

            app.UseOAuthBearerTokens(new OAuthAuthorizationServerOptions()
            {
                Provider = new StoreAuthProvider(),
                AllowInsecureHttp = true,
                TokenEndpointPath = new PathString("/Authenticate")
            });
        }
    }
}