using Microsoft.EntityFrameworkCore;
using System.Data.Common;

namespace AnchorSystem.EntityFrameworkCore.AnchorSystemAuthDb
{
    public class AnchorSystemAuthDbConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<AnchorSystemAuthDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString, b => b.MigrationsAssembly("AnchorSystem.EntityFrameworkCore"));
        }

        public static void Configure(DbContextOptionsBuilder<AnchorSystemAuthDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection, b => b.MigrationsAssembly("AnchorSystem.EntityFrameworkCore"));
        }
    }
}
