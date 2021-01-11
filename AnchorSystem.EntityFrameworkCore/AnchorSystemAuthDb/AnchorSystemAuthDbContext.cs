using AnchorSystem.Core.AnchorSystemAuthDb;
using AnchorSystem.Core.AnchorSystemAuthDb.LoginLogs;
using AnchorSystem.Core.AnchorSystemAuthDb.OperationRecords;
using AnchorSystem.Core.AnchorSystemAuthDb.Permissions;
using AnchorSystem.Core.AnchorSystemAuthDb.Roles;
using AnchorSystem.Core.AnchorSystemAuthDb.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AnchorSystem.EntityFrameworkCore.AnchorSystemAuthDb
{
    /// <summary>
    /// 系统后台 
    /// </summary>
    public class AnchorSystemAuthDbContext : IdentityDbContext<AdminUser, AdminRole, int>
    {
        /// <summary>
        /// 注册
        /// </summary>
        /// <param name="options"></param>
        public AnchorSystemAuthDbContext(DbContextOptions<AnchorSystemAuthDbContext> options)
            : base(options)
        {

        }
        /// <summary>
        /// 页面权限
        /// </summary>
        public DbSet<Permission> Permission { get; set; }

        /// <summary>
        /// 最上级菜单
        /// </summary>
        public DbSet<Menu> Menu { get; set; }

        /// <summary>
        /// 操作记录
        /// </summary>
        public DbSet<OperationRecord> OperationRecord { get; set; }

        /// <summary>
        /// 登陆日志
        /// </summary>
        public DbSet<LoginLog> LoginLogs { get; set; }

        /// <summary>
        /// IP白名单管理表
        /// </summary>
        public DbSet<IpWhitelist> IpWhitelist { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="connectionString"></param>
        /// <returns></returns>
        private static DbContextOptions GetOptions(string connectionString)
        {
            return new DbContextOptionsBuilder().UseSqlServer(connectionString).Options;
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<AdminUser>(ConfigureAdminUser);
            builder.Entity<AdminRole>(ConfigureAdminRole);
            builder.Entity<Menu>(ConfigureMenu);
            builder.Entity<OperationRecord>(ConfigureOperationRecord);
            builder.Entity<LoginLog>(ConfigureLoginLog);
            builder.Entity<Permission>(ConfigurePermission);
            builder.Entity<IpWhitelist>(ConfigureIpWhitelist);

            builder.Entity<IdentityUserRole<int>>(entity => { entity.ToTable(name: "AdminUserRoles"); });
            builder.Entity<IdentityUserLogin<int>>(entity => { entity.ToTable(name: "AdminUserLogins"); });
            builder.Entity<IdentityUserClaim<int>>(entity => { entity.ToTable(name: "AdminUserClaims"); });
            builder.Entity<IdentityRoleClaim<int>>(entity => { entity.ToTable(name: "AdminRoleClaims"); });
            builder.Entity<IdentityUserToken<int>>(entity => { entity.ToTable(name: "AdminUserTokens"); });
        }


        private void ConfigureIpWhitelist(EntityTypeBuilder<IpWhitelist> builder)
        {
            builder.ToTable("IpWhitelist");
            builder.HasIndex(m => new {m.IpAddress }).IsUnique();  //唯一索引
        }

        /// <summary>
        /// 页面权限
        /// </summary>
        /// <param name="builder"></param>
        private void ConfigurePermission(EntityTypeBuilder<Permission> builder)
        {
            builder.ToTable("Permission");
            builder.HasKey(m => m.Id);
            builder.HasOne(p => p.Menu)
                .WithMany(b => b.Permissions);
        }

        /// <summary>
        /// 登录日志
        /// </summary>
        /// <param name="builder"></param>
        private void ConfigureLoginLog(EntityTypeBuilder<LoginLog> builder)
        {
            builder.ToTable("LoginLogs");
            builder.HasOne(m => m.User).WithMany()
                .HasForeignKey(m => m.UserId).HasPrincipalKey(m => m.Id);
            builder.HasIndex(m => new { m.TenantId, m.LoginTime });
        }

        /// <summary>
        /// 操作日志
        /// </summary>
        /// <param name="builder"></param>
        private void ConfigureOperationRecord(EntityTypeBuilder<OperationRecord> builder)
        {
            builder.ToTable("OperationRecord");
            builder.HasIndex(m => new { m.OperatingTime });
        }

        /// <summary>
        /// 菜单
        /// </summary>
        /// <param name="builder"></param>
        private void ConfigureMenu(EntityTypeBuilder<Menu> builder)
        {
            builder.ToTable("Menu");
            builder.HasIndex(m => m.Name).IsUnique();
        }

        /// <summary>
        /// 后台角色
        /// </summary>
        /// <param name="builder"></param>
        private void ConfigureAdminRole(EntityTypeBuilder<AdminRole> builder)
        {
            builder.ToTable("AdminRole");
            builder.HasIndex(m => m.NormalizedName).IsUnique(false);
            builder.HasIndex(m => new { m.NormalizedName }).IsUnique();
            builder.HasIndex(m => new { m.Name }).IsUnique();
        }

        /// <summary>
        /// 后台账号
        /// </summary>
        /// <param name="builder"></param>
        private void ConfigureAdminUser(EntityTypeBuilder<AdminUser> builder)
        {
            builder.ToTable("AdminUser");
            builder.Property(m => m.UserName).IsRequired();
            builder.Property(m => m.NormalizedUserName).IsRequired();
            builder.HasIndex(m => m.NormalizedUserName).IsUnique(false);
        }

    }
}
