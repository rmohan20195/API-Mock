using System.Runtime.Serialization;

namespace capredv2.backend.domain.DomainEntities.Enums
{
    public enum ProjectTheme
    {
        [EnumMember(Value = "BAU")]
        BAU,
        [EnumMember(Value = "Corporate Platform")]
        CorporatePlatform,
        [EnumMember(Value = "CSO")]
        CSO,
        [EnumMember(Value = "Real Estate")]
        RealEstate,
        [EnumMember(Value = "Aladdin Platform")]
        AladdinPlatform,
        [EnumMember(Value = "Employee Experience")]
        EmployeeExperience,
        [EnumMember(Value = "External Business Request - Aladdin Platform")]
        ExternalBusinessRequestAladdinPlatform,
        [EnumMember(Value = "External Business Request - Aladdin Client")]
        ExternalBusinessRequestAladdinClient,
        [EnumMember(Value = "Information Security")]
        InformationSecurity
    }
}
