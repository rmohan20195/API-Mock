using System.Runtime.Serialization;

namespace capredv2.backend.domain.DomainEntities.Enums
{
    public enum BusinessJustification
    {
        [EnumMember(Value = "Required for Project Due Diligence")]
        RequiredforProjectDueDiligence,
        [EnumMember(Value = "Project Design Team Component")]
        ProjectDesignTeamComponent,
        [EnumMember(Value = "Project Management Team Component")]
        ProjectManagementTeamComponent,
        [EnumMember(Value = "Project Long Lead Item Procurement")]
        ProjectLongLeadItemProcurement,
        [EnumMember(Value = "Required for Construction or Installation ")]
        RequiredforConstructionorInstallation,
        [EnumMember(Value = "Replacement of Project Team Member")]
        ReplacementofProjectTeamMember
    }
}
