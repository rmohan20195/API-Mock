using System.Runtime.Serialization;

namespace capredv2.backend.domain.DomainEntities.Enums
{
    public enum ItemStatus
    {
        [EnumMember(Value = "Approved")]
        Approved,
        [EnumMember(Value = "In Review")]
        InReview,
        [EnumMember(Value = "Pending")]
        Pending,
        [EnumMember(Value = "Forecast")]
        Forecast
    }
}
