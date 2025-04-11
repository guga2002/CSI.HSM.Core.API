using Core.Persistance.MailServices;
using Core.Persistance.PtmsCsi;
using Domain.Core.Data;
using Domain.Core.Entities.Item;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Core.Persistance.BackgroundServices;

public class ItemMonitoring : IHostedService, IDisposable
{
    private readonly IServiceProvider _serviceProvider;
    private readonly ILogger<ItemMonitoring> _logger;
    private Timer _timer;
    private bool _isProcessing = false;

    public ItemMonitoring(IServiceProvider serviceProvider, ILogger<ItemMonitoring> logger)
    {
        _serviceProvider = serviceProvider;
        _logger = logger;
    }
    public Task StartAsync(CancellationToken cancellationToken)
    {
        _logger.LogInformation("NotifyUsersService started.");
        _timer = new Timer(async _ => await ExecuteAsync(), null, TimeSpan.Zero, TimeSpan.FromMinutes(30));
        return Task.CompletedTask;
    }

    public async Task ExecuteAsync()
    {
        Console.WriteLine("Item Monitoring");
        if (_isProcessing) return;

        try
        {
            List<Items> items = new List<Items> { };
            _isProcessing = true;
            var scope = _serviceProvider.CreateScope();
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
                        {
                            var connection = config.GetConnectionString(hotel);
                            if (connection != null)
                            {
                                httpContextAccessor.HttpContext.Items["ConnectionString"] = connection;
                            }
                        }
                    }
                }
            }
            else
            {
                Console.WriteLine("Hotel ID header not found.will take default Db");
            }

            var dbcontext = scope.ServiceProvider.GetRequiredService<GuestSideDb>();
            foreach (var item in dbcontext.Items)
            {
                if (item.Quantity <= 3 && item.IsOrderAble && item.IsActive)
                {
                    items.Add(item);
                }
            }
            if (items.Count > 0)
            {
                dbcontext.StaffInfoAboutRanOutItems.Add(new StaffInfoAboutRanOutItems
                {
                    CreatedAt = DateTime.Now,
                    IsActive = true,
                    ItemIds = items.Select(x => x.Id).ToList(),
                    LanguageCode = "En",
                    RequestTime = DateTime.Now,
                    Resolved = false,
                    Priority = Core.Entities.Enums.PriorityEnum.High,
                    Notes = "THis request was automated made!"
                });
                var smtpService = scope.ServiceProvider.GetRequiredService<SmtpService>();
                var templateGatewayService = scope.ServiceProvider.GetRequiredService<ITemplateGatewayService>();
                var itemRowsHtml = string.Join("", items.Select(item => $@"
    <tr>
        <td style='padding: 10px; border: 1px solid #ddd;'>{item.Name}</td>
        <td style='padding: 10px; border: 1px solid #ddd;'>{item.Quantity}</td>
        <td style='padding: 10px; border: 1px solid #ddd;'>{(item.Quantity == 0 ? "Ran Out" : "Low Stock")}</td>
    </tr>
"));

                var res = await templateGatewayService.RenderTemplateAsFileAsync(new Models.TemplateRenderRequest
                {
                    Language = "En",
                    TemplateKey = "ReStockRequest",
                    Data = new Dictionary<string, string>
                    {
                        { "ITEM_ROWS", itemRowsHtml },
                    }
                });
                var htmlBody = System.Text.Encoding.UTF8.GetString(res.File);
                smtpService.SendMessage("guram.apkhazava908@ens.tsu.ge", $"Please restock it:{DateTime.Now}", htmlBody);
                smtpService.SendMessage("raisa.badalova132@ens.tsu.ge", $"Please restock it:{DateTime.Now}", htmlBody);
            }
        }
        catch (Exception ex)
        {
            _logger.LogCritical(ex.Message);
        }
        finally
        {
            _isProcessing = false;
        }
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        _logger.LogInformation("NotifyUsersService stopped.");
        _timer?.Change(Timeout.Infinite, 0);
        return Task.CompletedTask;
    }

    public void Dispose()
    {
        _timer?.Dispose();
    }
}
