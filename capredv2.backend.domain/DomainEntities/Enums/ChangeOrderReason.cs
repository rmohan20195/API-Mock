using System.Runtime.Serialization;

namespace capredv2.backend.domain.DomainEntities.Enums
{
    public enum ChangeOrderReason
    {
        [EnumMember(Value = "Client Design Change")]
        ClientDesignChange,
        [EnumMember(Value = "Design Omission/Correction")]
        DesignOmissionCorrection,
        [EnumMember(Value = "Statutory Requirement")]
        StatutoryRequirement,
        [EnumMember(Value = "Force Majeure")]
        ForceMajeure,
        [EnumMember(Value = "Acceleration")]
        Acceleration,
        [EnumMember(Value = "Delay by Client Team")]
        DelaybyClientTeam,
        [EnumMember(Value = "Correction of Existing Conditions")]
        CorrectionofExistingConditions,
        [EnumMember(Value = "Scope Addition")]
        ScopeAddition,
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
