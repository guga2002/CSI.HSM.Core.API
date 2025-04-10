using System.ComponentModel;

namespace Domain.Core.Entities.Enums;

public enum PriorityEnum
{
    [Description("დაბალი პრიორიტეტი")]
    Low,

    [Description("საშუალო პრიორიტეტი")]
    Medium,

    [Description("მაღალი პრიორიტეტი")]
    High,

    [Description("კრიტიკული პრიორიტეტი")]
    Critical
}
