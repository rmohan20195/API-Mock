using System.Runtime.Serialization;

namespace capredv2.backend.domain.DomainEntities.Enums
{
    public enum FacilityType
    {
        Headquarters = 1,
        [EnumMember(Value = "iHub")]
        IHub,
        [EnumMember(Value = "Regional Office")]
        RegionalOffice,
        [EnumMember(Value = "Local Sales Office")]
        LocalSalesOffice,
        [EnumMember(Value = "BCM Site")]
        BCMSite,
        [EnumMember(Value = "Data Center")]
        DataCenter,
        [EnumMember(Value = "Recovery Sites")]
        RecoverySites,
        [EnumMember(Value = "Executive Suite")]
        ExecutiveSuite
    }
}
