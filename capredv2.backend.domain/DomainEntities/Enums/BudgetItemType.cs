using System.Runtime.Serialization;

namespace capredv2.backend.domain.DomainEntities.Enums
{
    public enum BudgetItemType
    {
        [EnumMember(Value = "Original Order")]
        OriginalOrder,
        [EnumMember(Value = "Pending Forecast")]
        PendingForecast,
        [EnumMember(Value = "Pending Change")]
        PendingChange,
        [EnumMember(Value = "Change Order")]
        ChangeOrder,
        [EnumMember(Value = "Budget Item")]
        BudgetItem,
        [EnumMember(Value = "A10")]
        A10,
        [EnumMember(Value = "B10")]
        B10,
        [EnumMember(Value = "C10")]
        C10,
        [EnumMember(Value = "D10")]
        D10,
        [EnumMember(Value = "E10")]
        E10,
        [EnumMember(Value = "E20")]
        E20,
        [EnumMember(Value = "F20")]
        F20,
        [EnumMember(Value = "G10")]
        G10,
        [EnumMember(Value = "Z10")]
        Z10,
        [EnumMember(Value = "Z40")]
        Z40,
        [EnumMember(Value = "Z50")]
        Z50,
        [EnumMember(Value = "Z60")]
        Z60,
        [EnumMember(Value = "Z65")]
        Z65,
        [EnumMember(Value = "Z70")]
        Z70,
        [EnumMember(Value = "Z87")]
        Z87,
        [EnumMember(Value = "Z90")]
        Z90
    }
}
