using System.Runtime.Serialization;

namespace capredv2.backend.domain.DomainEntities.Enums
{
    public enum RestorationRequirements
    {
        [EnumMember(Value = "none")]
        None,
        [EnumMember(Value = "Remove furniture & equipment & special construction")]
        Removefurnitureequipmentspecialconstruction,
        [EnumMember(Value = "Remove furniture & equipment & special construction and make good damaged areas")]
        Removefurnitureequipmentspecialconstructionandmakegooddamagedareas,
        [EnumMember(Value = "Remove all improvements & restore to core + shell")]
        RemoveallimprovementsrestoretocoreShell,
        [EnumMember(Value = "Remove all improvements & restore to Cat A")]
        RemoveallimprovementsrestoretoCatA
    }
}
