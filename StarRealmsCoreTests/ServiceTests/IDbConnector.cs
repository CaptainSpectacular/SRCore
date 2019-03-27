using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using StarRealmsCore.Data;

namespace StarRealmsCoreTests.ServiceTests
{
    public class IDbConnector
    {
        public DbContextOptions<AppDbContext> CreateNewContextOptions()
        {
            var serviceProvider = new ServiceCollection()
                .AddEntityFrameworkInMemoryDatabase()
                .BuildServiceProvider();

            var builder = new DbContextOptionsBuilder<AppDbContext>();

            builder.UseInMemoryDatabase()
                   .UseInternalServiceProvider(serviceProvider);

            return builder.Options;
        }
    }
}
