using capredv2.backend.domain.DomainEntities.Dropdowns;
using System;
using System.Collections.Generic;
using System.Text;

namespace capredv2.backend.domain.DatabaseEntities.Dropdowns
{
    public class LeasedOrOwned
    {
        public Guid Id { get; set; }
        public string Value { get; set; }
        public int Position { get; set; }

        public static LeasedOrOwned MapFromDomainEntity(LeasedOrOwnedDTO leasedOrOwned)
        {
            if (leasedOrOwned == null) return null;

            return new LeasedOrOwned()
            {
                Id = leasedOrOwned.Id,
                Value = leasedOrOwned.Value,
                Position = leasedOrOwned.Position
            };
        }
    }
}
