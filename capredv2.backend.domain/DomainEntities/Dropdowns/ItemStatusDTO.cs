using capredv2.backend.domain.DatabaseEntities.Dropdowns;
using System;
using System.Collections.Generic;
using System.Text;

namespace capredv2.backend.domain.DomainEntities.Dropdowns
{
    public class ItemStatusDTO
    {
        public Guid Id { get; set; }
        public string Value { get; set; }
        public int Position { get; set; }

        public ItemStatusDTO()
        {
            Id = Guid.NewGuid();
        }

        public static ItemStatusDTO MapFromDatabaseEntity(ItemStatus itemStatus)
        {
            if (itemStatus == null) return null;

            return new ItemStatusDTO()
            {
                Id = itemStatus.Id,
                Value = itemStatus.Value,
                Position = itemStatus.Position
            };
        }
    }
}
