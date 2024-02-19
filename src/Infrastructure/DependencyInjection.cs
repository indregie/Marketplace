using Domain.Interfaces;
using Infrastructure.Clients;
using Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public static class DependencyInjection
{
    public static void AddInfrastructure(this IServiceCollection services)
    {
        services.AddScoped<ICommentClient, CommentClient>();
        services.AddScoped<IRateRepository, RateRepository>();
        services.AddScoped<IMovieRepository, MovieRepository>();
        services.AddScoped<IItemRepository, ItemRepository>();
    }
}
