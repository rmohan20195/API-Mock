using capredv2.backend.domain.DomainEntities.Dropdowns;
using System;
using System.Collections.Generic;
using System.Text;

namespace capredv2.backend.domain.DatabaseEntities.Dropdowns
{
    public class ItemCategory
    {
        public Guid Id { get; set; }
        public string Value { get; set; }
        public int Position { get; set; }

        public static ItemCategory MapFromDomainEntity(ItemCategoryDTO itemCategory)
        {
            if (itemCategory == null) return null;

            return new ItemCategory()
            {
                Id = itemCategory.Id,
                Value = itemCategory.Value,
                Position = itemCategory.Position
            };
        }
    }
}
