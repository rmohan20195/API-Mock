using capredv2.backend.domain.DatabaseEntities.Dropdowns;
using System;
using System.Collections.Generic;
using System.Text;

namespace capredv2.backend.domain.DomainEntities.Dropdowns
{
    public class ItemCategoryDTO
    {
        public Guid Id { get; set; }
        public string Value { get; set; }
        public int Position { get; set; }

        public ItemCategoryDTO()
        {
            Id = Guid.NewGuid();
        }

        public static ItemCategoryDTO MapFromDatabaseEntity(ItemCategory itemCategory)
        {
            if (itemCategory == null) return null;

            return new ItemCategoryDTO()
            {
                Id = itemCategory.Id,
                Value = itemCategory.Value,
                Position = itemCategory.Position
            };
        }
    }
}
