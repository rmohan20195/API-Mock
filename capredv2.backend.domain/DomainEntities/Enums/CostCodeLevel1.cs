using System.Runtime.Serialization;

namespace capredv2.backend.domain.DomainEntities.Enums
{
    public enum CostCodeLevel1
    {
        [EnumMember(Value = "A10 - Foundations")]
        A10Foundations,
        [EnumMember(Value = "A20 - Basement Construction")]
        A20BasementConstruction,
        [EnumMember(Value = "B10 - Superstructure")]
        B10Superstructure,
        [EnumMember(Value = "C10 - Interior Construction")]
        C10InteriorConstruction,
        [EnumMember(Value = "D10 - Building Services")]
        D10BuildingServices,
        [EnumMember(Value = "E10 - Equipment ES")]
        E10EquipmentES,
        [EnumMember(Value = "E12 - Equipment Tech")]
        E12EquipmentTech,
        [EnumMember(Value = "E13 - Equipment AV")]
        E13EquipmentAV,
        [EnumMember(Value = "E14 - Equipment Data Center")]
        E14EquipmentDataCenter,
        [EnumMember(Value = "E20 - Furnishings and Furniture")]
        E20FurnishingsandFurniture,
        [EnumMember(Value = "F20 - Demolition")]
        F20Demolition,
        [EnumMember(Value = "G10 - Sitework")]
        G10Sitework,
        [EnumMember(Value = "Z01 - Contractor Indirect Costs and Fee")]
        Z01ContractorIndirectCostsandFee,
        [EnumMember(Value = "Z10 - Design Consultants")]
        Z10DesignConsultants,
        [EnumMember(Value = "Z20 - Project Management and Consultants")]
        Z20ProjectManagementandConsultants,
        [EnumMember(Value = "Z30 - Approvals")]
        Z30Approvals,
        [EnumMember(Value = "Z40 - Migration")]
        Z40Migration,
        [EnumMember(Value = "Z50 - Landlord Costs")]
        Z50LandlordCosts,
        [EnumMember(Value = "Z60 - Sales/Use Tax and VAT")]
        Z60SalesUseTaxandVAT,
        [EnumMember(Value = "Z72 - ARO & Restoration")]
        Z72ARORestoration,
        [EnumMember(Value = "Z80 - Land Purchase")]
        Z80LandPurchase,
        [EnumMember(Value = "Z90 - Contingencies and Allowances")]
        Z90ContingenciesandAllowances,
        [EnumMember(Value = "Furnishings")]
        Furnishings,
        [EnumMember(Value = "Selective Building Demolition")]
        SelectiveBuildingDemolition,
        [EnumMember(Value = "Site Preparation")]
        SitePreparation,
        [EnumMember(Value = "Site Improvements")]
        SiteImprovements,
        [EnumMember(Value = "Site Civil/Mechanical Utilities")]
        SiteCivilMechanicalUtilities,
        [EnumMember(Value = "Site Electrical Utilities")]
        SiteElectricalUtilities,
        [EnumMember(Value = "PreConstruction")]
        PreConstruction,
        [EnumMember(Value = "General Requirements")]
        GeneralRequirements,
        [EnumMember(Value = "Design Consultants")]
        DesignConsultants,
        [EnumMember(Value = "Project Management")]
        ProjectManagement,
        [EnumMember(Value = "Statutory Approvals")]
        StatutoryApprovals,
        [EnumMember(Value = "Move costs")]
        Movecosts,
        [EnumMember(Value = "Landlord Costs")]
        LandlordCosts,
        [EnumMember(Value = "Tax")]
        Tax,
        [EnumMember(Value = "Expensed Project Costs")]
        ExpensedProjectCosts,
        [EnumMember(Value = "Asset Restoration Requirements")]
        AssetRestorationRequirements,
        [EnumMember(Value = "Day Two")]
        DayTwo,
        [EnumMember(Value = "Land & Building Purchase")]
        LandBuildingPurchase,
        [EnumMember(Value = "Contingencies & Allowances")]
        ContingenciesAllowances,
    }
}
