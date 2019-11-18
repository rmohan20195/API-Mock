using capredv2.backend.domain.DatabaseEntities.Dropdowns;
using System;
using System.Collections.Generic;
using System.Text;

namespace capredv2.backend.domain.DomainEntities.Dropdowns
{
   public class BudgetItemTypeDTO
    {
        public Guid Id { get; set; }
        public string Value { get; set; }
        public int Position { get; set; }

        public BudgetItemTypeDTO()
        {
            Id = Guid.NewGuid();
        }

        public static BudgetItemTypeDTO MapFromDatabaseEntity(BudgetItemType budgetItemType)
        {
            if (budgetItemType == null) return null;

            return new BudgetItemTypeDTO()
            {
                Id = budgetItemType.Id,
                Value = budgetItemType.Value,
                Position = budgetItemType.Position
            };
        }
    }
}
