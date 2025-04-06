using System.ComponentModel;

namespace Core.Core.Entities.Enums;

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
