using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;

namespace spWeb.Infrastructure.Identity
{
    public class StoreRoleMeneger:RoleManager<SsRole>
    {
        public StoreRoleMeneger(IRoleStore<SsRole, string> store):base(store)
        {
            
        }

        public static StoreRoleMeneger Create(IdentityFactoryOptions<StoreRoleMeneger> options, IOwinContext context)
        {
            return new StoreRoleMeneger(new RoleStore<SsRole>(context.Get<SsIdentityDbContext>()));
        }
    }
}