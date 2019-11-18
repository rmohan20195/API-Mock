using capredv2.backend.domain.DomainEntities.Dropdowns;
using System;
using System.Collections.Generic;
using System.Text;

namespace capredv2.backend.domain.DatabaseEntities.Dropdowns
{
    public class BudgetItemType
    {
        public Guid Id { get; set; }
        public string Value { get; set; }
        public int Position { get; set; }

        public static BudgetItemType MapFromDomainEntity(BudgetItemTypeDTO budgetItemType)
        {
            if (budgetItemType == null) return null;

            return new BudgetItemType()
            {
                Id = budgetItemType.Id,
                Value = budgetItemType.Value,
                Position = budgetItemType.Position
            };
        }
    }
}
