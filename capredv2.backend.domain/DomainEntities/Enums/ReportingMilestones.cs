using System.Runtime.Serialization;

namespace capredv2.backend.domain.DomainEntities.Enums
{
    public enum ReportingMilestones
    {
        [EnumMember(Value = "Receive Business Approval")]
        ReceiveBusinessApproval,
        [EnumMember(Value = "Lease Execution")]
        LeaseExecution,
        [EnumMember(Value = "Design Development Complete")]
        DesignDevelopmentComplete,
        [EnumMember(Value = "Construction Document complete/issue for Bid")]
        ConstructionDocumentcompleteissueforBid,
        [EnumMember(Value = "Start on Site")]
        StartonSite,
        [EnumMember(Value = "Commence Move-In")]
        CommenceMoveIn
    }
}
