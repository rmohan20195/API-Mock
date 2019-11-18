using capredv2.backend.domain.DatabaseEntities.Dropdowns;
using System;
using System.Collections.Generic;
using System.Text;

namespace capredv2.backend.domain.DomainEntities.Dropdowns
{
    public class LeasedOrOwnedDTO
    {
        public Guid Id { get; set; }
        public string Value { get; set; }
        public int Position { get; set; }

        public LeasedOrOwnedDTO()
        {
            Id = Guid.NewGuid();
        }

        public static LeasedOrOwnedDTO MapFromDatabaseEntity(LeasedOrOwned leasedOrOwned)
        {
            if (leasedOrOwned == null) return null;

            return new LeasedOrOwnedDTO()
            {
                Id = leasedOrOwned.Id,
                Value = leasedOrOwned.Value,
                Position = leasedOrOwned.Position
            };
        }
    }
}
