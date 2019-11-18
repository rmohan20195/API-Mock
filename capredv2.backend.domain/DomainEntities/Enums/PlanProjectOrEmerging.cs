using System.Runtime.Serialization;

namespace capredv2.backend.domain.DomainEntities.Enums
{
    public enum PlanProjectOrEmerging
    {
        [EnumMember(Value = "Plan Project")]
        PlanProject,
        [EnumMember(Value = "Fiscal rollover project")]
        FiscalRolloverProject,
        [EnumMember(Value = "Canceled")]
        Canceled,
        [EnumMember(Value = "Requested Project")]
        RequestedProject,
        [EnumMember(Value = "Emerging")]
        Emerging
    }
}
