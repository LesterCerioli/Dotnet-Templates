using CleanArchitecture1.Application.Interfaces;
using CleanArchitecture1.Infrastructure.Persistence.Contexts;
using CleanArchitecture1.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchitecture1.IntegrationTests.Data
{
    public abstract class BaseEfRepoTestFixture
    {
        protected ApplicationDbContext dbContext;

        protected BaseEfRepoTestFixture()
        {
            var options = CreateNewContextOptions();
            IAuthenticatedUserService authenticatedUserService = new AuthenticatedUserService(Guid.NewGuid().ToString(), "UserName");

            dbContext = new ApplicationDbContext(options, authenticatedUserService);
        }

        protected static DbContextOptions<ApplicationDbContext> CreateNewContextOptions()
        {
            // Create a fresh service provider, and therefore a fresh
            // InMemory database instance.
            var serviceProvider = new ServiceCollection()
                .AddEntityFrameworkInMemoryDatabase()
                .BuildServiceProvider();

            // Create a new options instance telling the context to use an
            // InMemory database and the new service provider.
            var builder = new DbContextOptionsBuilder<ApplicationDbContext>();
            builder.UseInMemoryDatabase(nameof(ApplicationDbContext))
                   .UseInternalServiceProvider(serviceProvider);

            return builder.Options;
        }

        protected GenericRepository<T> GetRepository<T>() where T : class
        {
            return new GenericRepository<T>(dbContext);
        }

        protected IUnitOfWork GetUnitOfWork()
        {
            return new UnitOfWork(dbContext);
        }
    }
    internal record AuthenticatedUserService(string UserId, string UserName) : IAuthenticatedUserService;
}
