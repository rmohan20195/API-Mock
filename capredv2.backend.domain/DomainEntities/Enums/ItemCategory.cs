using System.Runtime.Serialization;

namespace capredv2.backend.domain.DomainEntities.Enums
{
    public enum ItemCategory
    {
        [EnumMember(Value = "Consultancy Fees")]
        ConsultancyFees,
        [EnumMember(Value = "Consultancy Expenses")]
        ConsultancyExpenses,
        [EnumMember(Value = "Consultancy Fees and Expenses")]
        ConsultancyFeesandExpenses,
        [EnumMember(Value = "Subconsultant fees and expenses")]
        Subconsultantfeesandexpenses,
        [EnumMember(Value = "Equipment Purchase & Install")]
        EquipmentPurchaseInstall,
        [EnumMember(Value = "Furniture Purchase & Install")]
        FurniturePurchaseInstall,
        [EnumMember(Value = "CM/GC Fees and Trades")]
        CMGCFeesandTrades,
        [EnumMember(Value = "Permitting/Authorities")]
        PermittingAuthorities,
        [EnumMember(Value = "Foundations")]
        Foundations,
        [EnumMember(Value = "Superstructure")]
        Superstructure,
        [EnumMember(Value = "Interior Construction")]
        InteriorConstruction,
        [EnumMember(Value = "MEP Systems")]
        MEPSystems,
        [EnumMember(Value = "Equipment")]
        Equipment,
        [EnumMember(Value = "Furnishings")]
        Furnishings,
        [EnumMember(Value = "Selective Building Demolition")]
        SelectiveBuildingDemolition,
        [EnumMember(Value = "Siteworks")]
        Siteworks,
        [EnumMember(Value = "CM/GC Costs")]
        CMGCCosts,
        [EnumMember(Value = "Design Consultants")]
        DesignConsultants,
        [EnumMember(Value = "Project Management ")]
        ProjectManagement,
        [EnumMember(Value = "Statutory Approvals")]
        StatutoryApprovals,
        [EnumMember(Value = "Move costs")]
        Movecosts,
        [EnumMember(Value = "Landlord Costs")]
        LandlordCosts,
        [EnumMember(Value = "Land & Building Purchase")]
        LandBuildingPurchase,
        [EnumMember(Value = "Contingencies & Allowances")]
        ContingenciesAllowances
    }
}
