using AnchorSystem.Core.AnchorSystemAuthDb.Permissions;
using AnchorSystem.Core.SystemConst;
using AnchorSystem.EntityFrameworkCore.AnchorSystemAuthDb;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace AnchorSystem.EntityFrameworkCore.Seed.Host
{
    public class RoleAndUserBuilder
    {
        private readonly AnchorSystemAuthDbContext _context;

        public RoleAndUserBuilder(AnchorSystemAuthDbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            RoleAndUserBuilders();
        }

        private void RoleAndUserBuilders()
        {
            var adminRole = _context.Roles.IgnoreQueryFilters().FirstOrDefault(r =>r.Name == "Admin");
            if (adminRole == null)
            {
                return;
            }

            var perList = new List<IdentityRoleClaim<int>>();
            foreach (var menu in AppMenu.Menus)
            {


                if (menu.Permissions == null) continue;
                perList.AddRange(from permission in menu.Permissions
                    where !_context.RoleClaims.Any(m => m.ClaimValue == permission.PerCodeId)
                          && permission.PerLimit != PerLimit.Clients
                    select new IdentityRoleClaim<int>()
                        { RoleId = adminRole.Id, ClaimValue = permission.PerCodeId, ClaimType = WebConst.系统权限 });
            }
            _context.RoleClaims.AddRange(perList);
            _context.SaveChanges();
        }
    }
}
