using Domain.Core.Data;
using Core.Persistance.MailServices;
using Core.Persistance.PtmsCsi;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Core.Persistance.BackgroundServices;

public class PromoCodeMonitoring : IHostedService, IDisposable
{
    private readonly IServiceProvider _serviceProvider;
    private readonly ILogger<PromoCodeMonitoring> _logger;
    private Timer _timer;
    private bool _isProcessing = false;

    public PromoCodeMonitoring(IServiceProvider serviceProvider, ILogger<PromoCodeMonitoring> logger)
    {
        _serviceProvider = serviceProvider;
        _logger = logger;
    }

    public void Dispose()
    {
        _timer?.Dispose();
    }

    public Task StartAsync(CancellationToken cancellationToken)
    {
        _logger.LogInformation("NotifyUsersService started.");
        _timer = new Timer(async _ => await ExecuteAsync(), null, TimeSpan.Zero, TimeSpan.FromMinutes(1));
        return Task.CompletedTask;
    }

    private async Task ExecuteAsync()
    {
        Console.WriteLine("Notification Background Service is Alive!");
        if (_isProcessing) return;

        try
        {
            _isProcessing = true;

            using var scope = _serviceProvider.CreateScope();

            var httpContextAccessor = scope.ServiceProvider.GetRequiredService<IHttpContextAccessor>();
            if (httpContextAccessor.HttpContext == null)
            {
                httpContextAccessor.HttpContext = new DefaultHttpContext();
            }

            var httpContext = httpContextAccessor.HttpContext;

            if (httpContext != null && httpContext.Request.Headers.TryGetValue("X-Hotel-Id", out var hotelId))
            {
                var config = scope.ServiceProvider.GetRequiredService<IConfiguration>();
                if (config != null)
                {
                    var hotel = (string)hotelId;
                    if (!string.IsNullOrEmpty(hotel))
                    {
                        var connection = config.GetConnectionString(hotel);
                        if (connection != null)
                        {
                            httpContextAccessor.HttpContext.Items["ConnectionString"] = connection;
                        }
                    }
                }
            }
            else
            {
                Console.WriteLine("Hotel ID header not found.will take default Db");
            }

            var context = scope.ServiceProvider.GetRequiredService<GuestSideDb>();
            foreach (var item in context.PromoCodes.ToList())
            {
                if (item.ValidUntil <= DateTime.UtcNow)
                {
                    item.IsActive = false;
                    item.UpdatedAt = DateTime.UtcNow;
                }
            }
            await context.SaveChangesAsync();
            _logger.LogInformation("Itteration Done,promo expiration, CorrelationId:{Id}", Guid.NewGuid());
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error notifying users.");
        }
        finally
        {
            _isProcessing = false;
        }
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        _logger.LogInformation("PromoCode stopped.");
        _timer?.Change(Timeout.Infinite, 0);
        return Task.CompletedTask;
    }
}
