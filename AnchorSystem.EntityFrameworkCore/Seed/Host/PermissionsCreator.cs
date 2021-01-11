using AnchorSystem.Core.AnchorSystemAuthDb.Permissions;
using AnchorSystem.EntityFrameworkCore.AnchorSystemAuthDb;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace AnchorSystem.EntityFrameworkCore.Seed.Host
{
    public class PermissionsCreator
    {
        private readonly AnchorSystemAuthDbContext _context;

        public PermissionsCreator(AnchorSystemAuthDbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            CreatePermissions();
        }

        private void CreatePermissions()
        {
            foreach (var menu in AppMenu.Menus)
            {
                if (!_context.Menu.Any(m => m.PerCodeId == menu.PerCodeId))
                {
                    _context.Menu.Add(menu);
                }
                else
                {
                    var menuentity = _context.Menu.Include(m => m.Permissions)
                        .First(m => m.PerCodeId == menu.PerCodeId);
                    menuentity.PerCodeId = menu.PerCodeId;
                    menuentity.Name = menu.Name;

                    foreach (var perentity in menuentity.Permissions)
                    {
                        if (menu.Permissions.All(m => m.PerCodeId != perentity.PerCodeId)) continue;

                        var per = menu.Permissions.First(m => m.PerCodeId == perentity.PerCodeId);
                        perentity.PerCodeId = per.PerCodeId;
                        perentity.Name = per.Name;
                        perentity.PerCodeType = per.PerCodeType;
                        perentity.PerLevel = per.PerLevel;
                        perentity.PerLimit = per.PerLimit;
                        perentity.ParentId = per.ParentId;
                    }

                    foreach (var per in menu.Permissions.Where(per =>
                        !_context.Permission.Any(m => m.PerCodeId == per.PerCodeId)))
                    {
                        menuentity.Permissions.Add(per);
                    }

                    _context.Menu.Update(menuentity);
                }
            }

            _context.SaveChanges();
        }
    }
}
