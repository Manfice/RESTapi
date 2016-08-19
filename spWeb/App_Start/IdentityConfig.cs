using Microsoft.Owin;
using Owin;

[assembly:OwinStartup(typeof(spWeb.IdentityConfig))]
namespace spWeb
{
    public class IdentityConfig
    {
         public void Configuration(IAppBuilder app) { }
    }
}