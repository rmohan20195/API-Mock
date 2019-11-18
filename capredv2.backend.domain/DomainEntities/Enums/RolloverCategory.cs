using System.Runtime.Serialization;

namespace capredv2.backend.domain.DomainEntities.Enums
{
    public enum RolloverCategory
    {
        [EnumMember(Value = "Pending Submission")]
        PendingSubmission,
        [EnumMember(Value = "Presented for Approval")]
        PresentedforApproval,
        [EnumMember(Value = "Onboarded")]
        Onboarded,
        [EnumMember(Value = "Completed project with spend in following year")]
        Completedprojectwithspendinfollowingyear
    }
}
