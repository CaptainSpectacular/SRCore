using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Mvc.Testing;
using StarRealmsCore.Services;
using StarRealmsCore.Data;
using StarRealmsCore.Models.Games;
using System;
using System.Collections.Generic;
using Xunit;

namespace StarRealmsCoreTests.ServiceTests
{
    public class GameServiceTests
    {

        [Fact]
        public void TestWriteToDatabase()
        {
            using (var context = new AppDbContext(CreateNewContextOptions()))
            {
                var service = new GameService(context);
                GameCreateCommand command1 = new GameCreateCommand 
                {
                    PlayerTurn = 1
                };

                GameCreateCommand command2 = new GameCreateCommand();

                service.CreateGame(command1);
                service.CreateGame(command2);

                var result1 = context.Games.Find(1);
                var result2 = context.Games.Find(2);
                
                Assert.Equal(2, context.Games.Count());
                Assert.Equal(1, result1.PlayerTurn); 
                Assert.Equal(0, result2.PlayerTurn); 
            }
        }

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
