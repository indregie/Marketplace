using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Application.Services;

public class PeriodicHostedService : BackgroundService
{
    private readonly TimeSpan _period;
    private readonly IServiceScopeFactory _scopeFactory;
    public PeriodicHostedService(IServiceScopeFactory scopeFactory)
    {
        _scopeFactory = scopeFactory;
        _period = TimeSpan.FromHours(2);
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        using PeriodicTimer timer = new PeriodicTimer(_period);
        while (!stoppingToken.IsCancellationRequested &&
            await timer.WaitForNextTickAsync(stoppingToken))
        {
            using (IServiceScope scope = _scopeFactory.CreateScope())
            {
                try
                {
                    OrderService _orderService = scope.ServiceProvider.GetRequiredService<OrderService>();
                    DateTime date = DateTime.Now;
                    await _orderService.CleanUp(date);
                    await Console.Out.WriteLineAsync($"Cleanup done at {date}");
                }
                catch (Exception ex)
                {
                    await Console.Out.WriteLineAsync(ex.Message);
                }
            }
        }
    }
}
