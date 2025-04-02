using Bogus;
using FamilyTree.Infrastructure.Databases;
using Microsoft.Extensions.DependencyInjection;

namespace FamilyTree.IntegrationTests;

[Collection(nameof(IntegrationTestCollection))]
public abstract class BaseIntegrationTest : IDisposable
{
    private readonly IServiceScope _scope;
    protected readonly EntityFrameworkDbContext DbContext;
    protected readonly IServiceProvider ServiceProvider;
    protected Faker Faker = new();

    protected BaseIntegrationTest(IntegrationTestWebAppFactory factory)
    {
        _scope = factory.Services.CreateScope();

        ServiceProvider = _scope.ServiceProvider;
        DbContext = _scope.ServiceProvider.GetRequiredService<EntityFrameworkDbContext>();
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected async Task AddEntities(params object[] entities)
    {
        await DbContext.AddRangeAsync(entities);

        await DbContext.SaveChangesAsync();
    }

    protected virtual void Dispose(bool disposing)
    {
        if (!disposing)
        {
            return;
        }

        _scope.Dispose();
        DbContext.Dispose();
    }

    ~BaseIntegrationTest()
    {
        Dispose(false);
    }
}
