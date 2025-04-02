using FamilyTree.Domain.Persons;
using FamilyTree.Domain.Trees;
using FamilyTree.Infrastructure.Authentication;
using FamilyTree.Infrastructure.Databases;
using FamilyTree.Infrastructure.Persons;
using FamilyTree.Infrastructure.Trees;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FamilyTree.Infrastructure;

public static class Configuration
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddAuthentication();
        services.AddSqlDatabase(configuration);

        services.AddScoped<ITreeRepository, TreeRepository>();
        services.AddScoped<IPersonRepository, PersonRepository>();

        return services;
    }

    public static async Task<WebApplication> ApplyMigrations(this WebApplication app)
    {
        await using AsyncServiceScope scope = app.Services.CreateAsyncScope();
        await using EntityFrameworkDbContext dbContext =
            scope.ServiceProvider.GetRequiredService<EntityFrameworkDbContext>();
        await dbContext.Database.MigrateAsync();

        return app;
    }

    private static IServiceCollection AddAuthentication(this IServiceCollection services)
    {
        services.AddOptions<AuthenticationOptions>()
            .BindConfiguration(AuthenticationOptions.SectionName)
            .ValidateDataAnnotations()
            .ValidateOnStart();

        services.AddSingleton<ApiAuthenticationFilter>();

        return services;
    }

    private static IServiceCollection AddSqlDatabase(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<EntityFrameworkDbContext>((_, options) =>
            options
                .UseNpgsql(configuration.GetConnectionString("DefaultConnection"))
                .UseSnakeCaseNamingConvention()
                .UseAsyncSeeding(async (context, _, cancellationToken) =>
                {
                    bool anyTree = await context.Set<Tree>().AnyAsync(cancellationToken);
                    if (!anyTree)
                    {
                        context.Set<Tree>().AddRange(SeedData.GenerateTrees());
                    }

                    bool anyPerson = await context.Set<Person>().AnyAsync(cancellationToken);
                    if (!anyPerson)
                    {
                        context.Set<Person>().AddRange(SeedData.GeneratePersons());
                    }

                    await context.SaveChangesAsync(cancellationToken);
                })
        );

        return services;
    }
}
