using capredv2.backend.domain.DomainEntities.Dropdowns;
using System;
using System.Collections.Generic;
using System.Text;

namespace capredv2.backend.domain.DatabaseEntities.Dropdowns
{
    public class ItemStatus
    {
        public Guid Id { get; set; }
        public string Value { get; set; }
        public int Position { get; set; }

        public static ItemStatus MapFromDomainEntity(ItemStatusDTO itemStatus)
        {
            if (itemStatus == null) return null;

            return new ItemStatus()
            {
                Id = itemStatus.Id,
                Value = itemStatus.Value,
                Position = itemStatus.Position
            };
        }
    }
}
