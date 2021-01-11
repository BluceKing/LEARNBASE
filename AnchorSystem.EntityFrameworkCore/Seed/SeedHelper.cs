using AnchorSystem.EntityFrameworkCore.AnchorSystemAuthDb;
using AnchorSystem.EntityFrameworkCore.Seed.Host;

namespace AnchorSystem.EntityFrameworkCore.Seed
{
    public static class SeedHelper
    {
        public static void SeedHostDb(AnchorSystemAuthDbContext context)
        {

            // UserAuth 种子数据
            new InitialHostDbBuilder(context).Create();

            // 生成权限种子数据
            new PermissionsCreator(context).Create();

            // 生成管理员角色权限数据
            new RoleAndUserBuilder(context).Create();

        }
    }
}
