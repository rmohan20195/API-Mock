using System.Runtime.Serialization;

namespace capredv2.backend.domain.DomainEntities.Enums
{
    public enum AssetCategories
    {
        [EnumMember(Value = "5410105 Amortization lease improvements")]
        C5410105Amortizationleaseimprovements,
        [EnumMember(Value = "5410505 Depreciation - furniture & fixtures")]
        C5410505Depreciationfurniturefixtures,
        [EnumMember(Value = "5410330 Firm Moving")]
        C5410330FirmMoving,
        [EnumMember(Value = "5415610 Art")]
        C5415610Art,
        [EnumMember(Value = "5410115 Core and Shell")]
        C5410115CoreandShell,
        [EnumMember(Value = "5410120 Infrastructure/Personal Property")]
        C5410120InfrastructurePersonalProperty,
        [EnumMember(Value = "5411105 Hardware")]
        C5411105Hardware,
        [EnumMember(Value = "5410310 Repairs & Maintenance")]
        C5410310RepairsMaintenance,
        [EnumMember(Value = "5410311 Repairs and Maintenance - Contract")]
        C5410311RepairsandMaintenanceContract,
        [EnumMember(Value = "5415610 Consulting Other - TandM")]
        C5415610ConsultingOtherTandM,
        [EnumMember(Value = "5415611 Consulting - Fixed Price SOW (stmt of work)")]
        C5415611ConsultingFixedPriceSOWstmtofwork,
        [EnumMember(Value = "5411220 Hardware < $25,000 (APAC < $5,000)")]
        C5411220Hardware25000APAC5000,
        [EnumMember(Value = "5410610 Furniture and equipment <$25,000 (APAC < $5,000)")]
        C5410610Furnitureandequipment25000APAC5000,
        [EnumMember(Value = "5411115 Capitalization Technology")]
        C5411115CapitalizationTechnology,
        [EnumMember(Value = "5411110 Computer Software")]
        C5411110ComputerSoftware,
        [EnumMember(Value = "Software License")]
        SoftwareLicense,
        [EnumMember(Value = "Travel & Expenses")]
        TravelExpenses
    }
}
