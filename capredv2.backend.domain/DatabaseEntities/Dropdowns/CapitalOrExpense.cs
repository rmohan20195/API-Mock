using capredv2.backend.domain.DomainEntities.Dropdowns;
using System;
using System.Collections.Generic;
using System.Text;

namespace capredv2.backend.domain.DatabaseEntities.Dropdowns
{
    public class CapitalOrExpense
    {
        public Guid Id { get; set; }
        public string Value { get; set; }
        public int Position { get; set; }

        public static CapitalOrExpense MapFromDomainEntity(CapitalOrExpenseDTO capitalOrExpense)
        {
            if (capitalOrExpense == null) return null;

            return new CapitalOrExpense()
            {
                Id = capitalOrExpense.Id,
                Value = capitalOrExpense.Value,
                Position = capitalOrExpense.Position
            };
        }
    }
}
