using capredv2.backend.domain.DomainEntities.Dropdowns;
using System;
using System.Collections.Generic;
using System.Text;

namespace capredv2.backend.domain.DatabaseEntities.Dropdowns
{
    public class RolloverCategory
    {
        public Guid Id { get; set; }
        public string Value { get; set; }
        public int Position { get; set; }

        public static RolloverCategory MapFromDomainEntity(RolloverCategoryDTO rolloverCategory)
        {
            if (rolloverCategory == null) return null;

            return new RolloverCategory()
            {
                Id = rolloverCategory.Id,
                Value = rolloverCategory.Value,
                Position = rolloverCategory.Position
            };
        }
    }
}
