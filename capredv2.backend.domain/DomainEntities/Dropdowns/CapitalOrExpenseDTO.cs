using capredv2.backend.domain.DatabaseEntities.Dropdowns;
using System;
using System.Collections.Generic;
using System.Text;

namespace capredv2.backend.domain.DomainEntities.Dropdowns
{
    public class CapitalOrExpenseDTO
    {
        public Guid Id { get; set; }
        public string Value { get; set; }
        public int Position { get; set; }

        public CapitalOrExpenseDTO()
        {
            Id = Guid.NewGuid();
        }

        public static CapitalOrExpenseDTO MapFromDatabaseEntity(CapitalOrExpense capitalOrExpense)
        {
            if (capitalOrExpense == null) return null;

            return new CapitalOrExpenseDTO()
            {
                Id = capitalOrExpense.Id,
                Value = capitalOrExpense.Value,
                Position = capitalOrExpense.Position
            };
        }
    }
}
