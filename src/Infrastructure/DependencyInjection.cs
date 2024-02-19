using Domain.Interfaces;
using Infrastructure.Clients;
using Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public static class DependencyInjection
{
    public static void AddInfrastructure(this IServiceCollection services)
    {
        services.AddScoped<IItemRepository, ItemRepository>();
        services.AddScoped<IUserClient, UserClient>();
        services.AddScoped<IOrderRepository, OrderRepository>();
    }
}
