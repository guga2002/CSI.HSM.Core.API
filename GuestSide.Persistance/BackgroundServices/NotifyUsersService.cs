using Core.Core.Data;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using Core.Core.Entities.Notification;
using Core.Persistance.PtmsCsi;
using Core.Persistance.MailServices;
using Microsoft.Extensions.DependencyInjection;

namespace Core.Persistance.BackgroundServices
{
    public class NotifyUsersService : IHostedService, IDisposable
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly ILogger<NotifyUsersService> _logger;
        private Timer _timer;
        private bool _isProcessing = false;

        public NotifyUsersService(IServiceProvider serviceProvider, ILogger<NotifyUsersService> logger)
        {
            _serviceProvider = serviceProvider;
            _logger = logger;
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
                var context = scope.ServiceProvider.GetRequiredService<GuestSideDb>();
                var smtpService = scope.ServiceProvider.GetRequiredService<SmtpService>();
                var templateGatewayService = scope.ServiceProvider.GetRequiredService<ITemplateGatewayService>();

                var guestNotifications = await context.GuestNotifications
                    .Where(u => u.IsActive)
                    .ToListAsync();

                foreach (var guestNotification in guestNotifications)
                {
                    await NotifyGuestAsync(guestNotification, smtpService, templateGatewayService);
                    guestNotification.IsActive = false;
                    guestNotification.UpdatedAt = DateTime.UtcNow;
                    guestNotification.SentTime = DateTime.UtcNow;
                }

                var staffNotifications = await context.StaffNotifications
                   .Where(u => u.IsActive)
                   .ToListAsync();

                foreach (var staffNotification in staffNotifications)
                {
                    await NotifyStaffAsync(staffNotification, smtpService, templateGatewayService);
                    staffNotification.IsActive = false;
                    staffNotification.UpdatedAt = DateTime.Now;
                    staffNotification.SentTime = DateTime.Now;
                }

                await context.SaveChangesAsync();
                _logger.LogInformation("Itteration Done, CorrelationId:{Id}",Guid.NewGuid());
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

        private async Task NotifyGuestAsync(GuestNotification user, SmtpService smtpService, ITemplateGatewayService templateGatewayService)
        {
            var data = new Dictionary<string, string>
        {
            { "Title", user.Notifications?.Title??"" },
            { "Message", user.Notifications?.Message??"" },
            { "SentTime", user.SentTime.ToString()},
            { "CompanyName", "LogiXPlore LLC" },
        };

            var res = await templateGatewayService.RenderTemplateAsFileAsync(new Models.TemplateRenderRequest
            {
                Language = "En",
                TemplateKey = "NewNotificationForGuest",
                Data = data
            });

            var htmlBody = System.Text.Encoding.UTF8.GetString(res.File);
            if (!string.IsNullOrWhiteSpace(user?.Guest?.Email))
            {
                smtpService.SendMessage(user.Guest.Email, $"New Message For you {DateTime.Now}", htmlBody);
                _logger.LogInformation($"Notifying user: {user.Guest.Email}");
            }
        }

        private async Task NotifyStaffAsync(
     StaffNotification user,
     SmtpService smtpService,
     ITemplateGatewayService templateGatewayService)
        {
            if (user?.StaffMember == null || user.Notifications == null)
            {
                _logger.LogWarning("Staff or Notification is null, skipping notification.");
                return;
            }

            var data = new Dictionary<string, string>
    {
        { "StaffFirstName", user.StaffMember.FirstName },
        { "StaffLastName", user.StaffMember.LastName },
        { "Title", user.Notifications.Title },
        { "Message", user.Notifications.Message },
        { "PriorityLevel", user.Notifications.PriorityLevel.ToString() },
        { "NotificationType", user.Notifications.NotificationType.ToString() },
        { "SentTime", user.SentTime.ToString("f") }, // e.g., Monday, 7 April 2025 10:00
        { "IsImportant", user.IsImportant ? "true" : "false" },
        { "ReadTime", user.ReadTime?.ToString("f") ?? "" }
    };

            var res = await templateGatewayService.RenderTemplateAsFileAsync(new Models.TemplateRenderRequest
            {
                Language = "En",
                TemplateKey = "NewNotificationForStaff",
                Data = data
            });

            var htmlBody = System.Text.Encoding.UTF8.GetString(res.File);

            if (!string.IsNullOrWhiteSpace(user.StaffMember.Email))
            {
                string subject = $"📢 New Notification: {user.Notifications.Title}";
                smtpService.SendMessage(user.StaffMember.Email, subject, htmlBody);
                _logger.LogInformation($"Notified staff member: {user.StaffMember.Email}");
            }
            else
            {
                _logger.LogWarning("No email found for staff member.");
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

}
