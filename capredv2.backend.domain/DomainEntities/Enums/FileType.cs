using System.Runtime.Serialization;

namespace capredv2.backend.domain.DomainEntities.Enums
{
    public enum FileType
    {
        Undefined,
        [EnumMember(Value = "Invoice")]
        Invoice,
        [EnumMember(Value = "Purchase Order")]
        PurchaseOrder,
        [EnumMember(Value = "Requisition")]
        Requisition
    }
    
}
