using Microsoft.AspNet.Identity.EntityFramework;

namespace spWeb.Infrastructure.Identity
{
    public class SsRole:IdentityRole
    {
        public SsRole():base()
        {
            
        }

        public SsRole(string name):base(name)
        {
            
        }
    }
}