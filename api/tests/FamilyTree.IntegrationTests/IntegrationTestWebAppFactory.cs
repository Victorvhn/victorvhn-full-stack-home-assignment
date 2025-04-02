using FamilyTree.Infrastructure.Databases;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Testcontainers.PostgreSql;

namespace FamilyTree.IntegrationTests;

public sealed class IntegrationTestWebAppFactory : WebApplicationFactory<Api.Program>, IAsyncLifetime
{
    private readonly PostgreSqlContainer _postgreSqlContainer = new PostgreSqlBuilder().Build();

    public async Task InitializeAsync()
    {
        await _postgreSqlContainer.StartAsync();

        await EnsureDatabaseCreatedAsync();
    }

    public new async Task DisposeAsync()
    {
        await _postgreSqlContainer.StopAsync();
    }

    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        Environment.SetEnvironmentVariable("ConnectionStrings:DefaultConnection",
            _postgreSqlContainer.GetConnectionString());
    }

    private async Task EnsureDatabaseCreatedAsync()
    {
        await using AsyncServiceScope scope = Services.CreateAsyncScope();
        await using EntityFrameworkDbContext dbContext =
            scope.ServiceProvider.GetRequiredService<EntityFrameworkDbContext>();
        await dbContext.Database.MigrateAsync();
    }
}
