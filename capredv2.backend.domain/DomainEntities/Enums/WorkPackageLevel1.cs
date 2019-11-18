using System.Runtime.Serialization;

namespace capredv2.backend.domain.DomainEntities.Enums
{
    public enum WorkPackageLevel1
    {
        [EnumMember(Value = "Design Consultants")]
        DesignConsultants,
        [EnumMember(Value = "Project Management")]
        ProjectManagement,
        [EnumMember(Value = "Permitting and Legal")]
        PermittingandLegal,
        [EnumMember(Value = "Main Contractor/CM")]
        MainContractorCM,
        [EnumMember(Value = "BlackRock Direct Purchases - Equipment ES")]
        BlackRockDirectPurchasesEquipmentES,
        [EnumMember(Value = "BlackRock Direct Purchases - Equipment Tech")]
        BlackRockDirectPurchasesEquipmentTech,
        [EnumMember(Value = "BlackRock Direct Purchases - Equipment AV")]
        BlackRockDirectPurchasesEquipmentAV,
        [EnumMember(Value = "BlackRock Direct Purchases - Equipment Data Center")]
        BlackRockDirectPurchasesEquipmentDataCenter,
        [EnumMember(Value = "BlackRock Direct Purchases - Furniture")]
        BlackRockDirectPurchasesFurniture,
        [EnumMember(Value = "BlackRock Direct Purchases - Signage and Misc.")]
        BlackRockDirectPurchasesSignageandMisc,
        [EnumMember(Value = "Migration Management")]
        MigrationManagement,
        [EnumMember(Value = "Landlord Costs")]
        LandlordCosts,
        [EnumMember(Value = "Land Purchase")]
        LandPurchase,
        [EnumMember(Value = "Sales/Use Tax and VAT")]
        SalesUseTaxandVAT,
        [EnumMember(Value = "Non-CIP")]
        NonCIP,
        [EnumMember(Value = "ARO & Restoration")]
        ARORestoration,
        [EnumMember(Value = "Contingency")]
        Contingency,
        [EnumMember(Value = "Day Two")]
        DayTwo
    }
}
