using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Domain.Core.Entities.AbstractEntities;

namespace Domain.Core.Entities.Statistic;
[Table("DailyStatistics", Schema = "CSI")]
public class DailyStatistic : AbstractEntity
{
    [DataType(DataType.Date)]
    public DateTime Date { get; set; } = DateTime.UtcNow.Date;
    public int TotalTasksCreated { get; set; }
    public int TasksCompleted { get; set; }
    public int TasksOverdue { get; set; }
    public int TotalFeedbacks { get; set; }
    public int PositiveFeedbacks { get; set; }
    public int NegativeFeedbacks { get; set; }
    public int SupportRequestsOpened { get; set; }
    public int SupportRequestsResolved { get; set; }
    [StringLength(255)]
    public string? Notes { get; set; }
}
