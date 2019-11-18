using System.Runtime.Serialization;

namespace capredv2.backend.domain.DomainEntities.Enums
{
    public enum ProjectType
    {
        [EnumMember(Value = "Densification")]
        Densification,
        [EnumMember(Value = "Renovation")]
        Renovation,
        [EnumMember(Value = "Expansion/Contraction of Office")]
        ExpansionContractionofOffice,
        [EnumMember(Value = "Infrastructure Upgrades")]
        InfrastructureUpgrades,
        [EnumMember(Value = "Existing Office Relocation")]
        ExistingOfficeRelocation,
        [EnumMember(Value = "New Location")]
        NewLocation,
        [EnumMember(Value = "Executive Suite")]
        ExecutiveSuite
    }
}
