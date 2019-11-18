using capredv2.backend.domain.DatabaseEntities.Dropdowns;
using System;
using System.Collections.Generic;
using System.Text;

namespace capredv2.backend.domain.DomainEntities.Dropdowns
{
    public class RolloverCategoryDTO
    {
        public Guid Id { get; set; }
        public string Value { get; set; }
        public int Position { get; set; }

        public RolloverCategoryDTO()
        {
            Id = Guid.NewGuid();
        }

        public static RolloverCategoryDTO MapFromDatabaseEntity(RolloverCategory rolloverCategory)
        {
            if (rolloverCategory == null) return null;

            return new RolloverCategoryDTO()
            {
                Id = rolloverCategory.Id,
                Value = rolloverCategory.Value,
                Position = rolloverCategory.Position
            };
        }
    }
}
