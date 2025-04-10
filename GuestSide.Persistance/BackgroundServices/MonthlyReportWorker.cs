using ClosedXML.Excel;
using Domain.Core.Data;
using Core.Persistance.MailServices;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Core.Persistance.BackgroundServices;

public class MonthlyReportWorker : IHostedService, IDisposable
{

    private readonly IServiceProvider _serviceProvider;
    private readonly ILogger<DailyStatisticWorker> _logger;
    private Timer _timer;
    private bool _isProcessing = false;

    public MonthlyReportWorker(IServiceProvider serviceProvider, ILogger<DailyStatisticWorker> logger)
    {
        _serviceProvider = serviceProvider;
        _logger = logger;
    }

    public Task StartAsync(CancellationToken cancellationToken)
    {
        _logger.LogInformation("DailyStatisticWorker started.");
        _timer = new Timer(async _ => await ExecuteAsync(), null, TimeSpan.Zero, TimeSpan.FromDays(30));
        return Task.CompletedTask;
    }

    private async Task ExecuteAsync()
    {
        if (_isProcessing) return;
        _isProcessing = true;

        try
        {
            using var scoped = _serviceProvider.CreateScope();
            var db = scoped.ServiceProvider.GetRequiredService<GuestSideDb>();

            var today = DateTime.Now.Date;
            var lastMonth = today.AddDays(-30);

            using var workBook = new XLWorkbook();
            var worksheet = workBook.AddWorksheet("Staff Tasks");

            worksheet.Cell(1, 1).Value = "Id";
            worksheet.Cell(1, 2).Value = "Name";
            worksheet.Cell(1, 3).Value = "LastName";
            worksheet.Cell(1, 4).Value = "Completed Tasks";
            worksheet.Cell(1, 5).Value = "Open Tasks";

            var taskToStaff =  db.TaskToStaffs.GroupBy(staff => staff.Id);
            var staffs = db.Staffs.Where(staff => staff.IsActive).ToList();

            int currectRow = 2;

            foreach (var staff in taskToStaff)
            {
                worksheet.Cell(currectRow, 1).Value = staff.Key;
                worksheet.Cell(currectRow, 2).Value = staffs.FirstOrDefault(id => id.Id == staff.Key)?.FirstName ?? "Unknown";
                worksheet.Cell(currectRow, 3).Value = staffs.FirstOrDefault(id => id.Id == staff.Key)?.LastName ?? "Unknown";
                worksheet.Cell(currectRow, 4).Value = staff.Where(date => date.CreatedAt >= lastMonth && date.CreatedAt <= today).Count(id => id.IsCompleted);
                worksheet.Cell(currectRow, 5).Value = staff.Where(date => date.CreatedAt >= lastMonth && date.CreatedAt <= today).Count(id => id.StatusId == 1); //open tasksId
                currectRow++;
            }

            worksheet.Columns().AdjustToContents();
            using var stream = new MemoryStream();
            workBook.SaveAs(stream);

            var excelFileBytes = stream.ToArray(); 

            var smtpService = scoped.ServiceProvider.GetRequiredService<SmtpService>();

            var to = "raya.badalova@gmail.com";
            var subject = "Monthly reports";
            var body = "Please find the attached monthly report.";

            smtpService.SendMessage(to, subject, body, excelFileBytes, "MonthlyReport.xlsx");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed to generate monthly statistics.");
        }
        finally
        {
            _isProcessing = false;
        }
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        _logger.LogInformation("Monthly Statistic Worker stopped.");
        _timer?.Change(Timeout.Infinite, 0);
        return Task.CompletedTask;
    }

    public void Dispose()
    {
        _timer?.Dispose();
    }
}