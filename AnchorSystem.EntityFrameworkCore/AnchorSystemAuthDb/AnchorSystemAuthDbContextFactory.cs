using AnchorSystem.Core;
using AnchorSystem.Core.SystemConst;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace AnchorSystem.EntityFrameworkCore.AnchorSystemAuthDb
{
    public class AnchorSystemAuthDbContextFactory : IDesignTimeDbContextFactory<AnchorSystemAuthDbContext>
    {
        public AnchorSystemAuthDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<AnchorSystemAuthDbContext>();
            var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder(), null, true);

            AnchorSystemAuthDbConfigurer.Configure(builder, configuration.GetConnectionString(WebConst.AnchorSystemAuthDb));

            return new AnchorSystemAuthDbContext(builder.Options);
        }
    }
}
