using System.Data.Entity;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;

namespace spWeb.Infrastructure.Identity
{
    public class SsUserMeneger:UserManager<StoreUser>
    {
        public SsUserMeneger(IUserStore<StoreUser> store):base(store)
        {
            
        }

        public static SsUserMeneger Create(IdentityFactoryOptions<SsUserMeneger> options, IOwinContext context)
        {
            var dbContext = context.Get<SsIdentityDbContext>();
            var meneger = new SsUserMeneger(new UserStore<StoreUser>(dbContext));
            return meneger;
        }
    }
}