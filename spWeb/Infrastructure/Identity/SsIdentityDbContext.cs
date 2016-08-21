using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace spWeb.Infrastructure.Identity
{
    public class SsIdentityDbContext:IdentityDbContext<StoreUser>
    {
        public SsIdentityDbContext():base("ssDB")
        {
            Database.SetInitializer<SsIdentityDbContext>(new SsIdentityDbInitializer());
        }

        public static SsIdentityDbContext Create()
        {
            return new SsIdentityDbContext();
        }
    }
}