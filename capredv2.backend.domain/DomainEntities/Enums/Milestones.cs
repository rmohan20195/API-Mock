using System.Runtime.Serialization;

namespace capredv2.backend.domain.DomainEntities.Enums
{
    public enum Milestones
    {
        [EnumMember(Value = "Project Start/Receive Business Request")]
        ProjectStartReceiveBusinessRequest,
        [EnumMember(Value = "Complete Project Analysis")]
        CompleteProjectAnalysis,
        [EnumMember(Value = "Submit Project Request for Approval")]
        SubmitProjectRequestforApproval,
        [EnumMember(Value = "Receive Business Approval")]
        ReceiveBusinessApproval,
        [EnumMember(Value = "Design Brief Gateway Document Approval")]
        DesignBriefGatewayDocumentApproval,
        [EnumMember(Value = "Lease Execution")]
        LeaseExecution,
        [EnumMember(Value = "Design Development Complete")]
        DesignDevelopmentComplete,
        [EnumMember(Value = "Construction Document complete/issue for Bid")]
        ConstructionDocumentcompleteissueforBid,
        [EnumMember(Value = "Complete Purchase of long lead CE/AV/Tech/Circuits/Security Equipment")]
        CompletePurchaseoflongleadCEAVTechCircuitsSecurityEquipment,
        [EnumMember(Value = "Award Office Furniture Contracts")]
        AwardOfficeFurnitureContracts,
        [EnumMember(Value = "Start on Site")]
        StartonSite,
        [EnumMember(Value = "MDF/IDF MEP Commissioning and IST")]
        MDFIDFMEPCommissioningandIST,
        [EnumMember(Value = "MDF/IDF Handover to Technology")]
        MDFIDFHandovertoTechnology,
        [EnumMember(Value = "Commence Install Desktop and AV Equipment")]
        CommenceInstallDesktopandAVEquipment,
        [EnumMember(Value = "Handover to Facilities - Construction Substantial Completion")]
        HandovertoFacilitiesConstructionSubstantialCompletion,
        [EnumMember(Value = "Commence Move-In")]
        CommenceMoveIn,
        [EnumMember(Value = "Installation Complete incl. Punchlist - Final Acceptance")]
        InstallationCompleteinclPunchlistFinalAcceptance,
        [EnumMember(Value = "Receive Closeout Documentation and Final Accounts")]
        ReceiveCloseoutDocumentationandFinalAccounts,
        [EnumMember(Value = "Project Complete")]
        ProjectComplete
    }
}
