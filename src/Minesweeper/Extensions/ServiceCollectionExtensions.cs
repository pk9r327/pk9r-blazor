using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.FluentUI.AspNetCore.Components;

namespace Pk9r.Blazor.Minesweeper.Components;
public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddPk9rMinesweeperComponents(this IServiceCollection services)
    {
        services.AddFluentUIComponents();
        services.TryAddScoped<GameState>();

        return services;
    }
}
