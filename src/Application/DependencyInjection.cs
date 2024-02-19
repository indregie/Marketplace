using Application.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Application;

public static class DependencyInjection
{
    public static void AddApplication(this IServiceCollection services)
    {
        services.AddScoped<RateService>();
        services.AddScoped<MovieService>();
        services.AddScoped<CommentService>();

        services.AddScoped<ItemService>();
        services.AddScoped<UserService>();
    }
}
