using System.Data.Entity;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace spWeb.Infrastructure.Identity
{
    public class SsIdentityDbInitializer:CreateDatabaseIfNotExists<SsIdentityDbContext>
    {
        protected override void Seed(SsIdentityDbContext context)
        {
            var usrMeneger = new SsUserMeneger(new UserStore<StoreUser>(context));
            var rlMeneger = new StoreRoleMeneger(new RoleStore<StoreRole>(context));

            var roleName = "Administrator";
            var userName = "Admin";
            var pass = "secret";
            var email = "c592@ya.ru";

            if (!rlMeneger.RoleExists(roleName))
            {
                rlMeneger.Create(new StoreRole(roleName));
            }

            var user = usrMeneger.FindByName(userName);
            if (user == null)
            {
                usrMeneger.Create(new StoreUser()
                {
                    UserName = userName,
                    Email = email
                }, pass);
                user = usrMeneger.FindByName(userName);
            }
            if (!usrMeneger.IsInRole(user.Id, roleName))
            {
                usrMeneger.AddToRole(user.Id, roleName);
            }

            base.Seed(context);
        }
    }
}