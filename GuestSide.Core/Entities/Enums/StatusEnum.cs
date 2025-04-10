using System.ComponentModel;

namespace Domain.Core.Entities.Enums;

public enum StatusEnum
{
    [Description("გახსნილი")]
    Open,

    [Description("მიმდინარე პროცესშია")]
    InProgress,

    [Description("დასრულებულია (გადაწყვეტილია პრობლემა)")]
    Resolved,

    [Description("დახურულია")]
    Closed,

    [Description("მოლოდინშია")]
    Pending,

    [Description("შესრულებულია")]
    Completed,

    [Description("გაუქმებულია")]
    Canceled
}
