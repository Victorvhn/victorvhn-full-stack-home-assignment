using FamilyTree.Application.Trees;
using Microsoft.Extensions.DependencyInjection;

namespace FamilyTree.Application;

public static class Configuration
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<ITreeService, TreeService>();

        return services;
    }
}
