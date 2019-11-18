using capredv2.backend.domain.DomainEntities.Dropdowns;
using System;
using System.Collections.Generic;
using System.Text;

namespace capredv2.backend.domain.DatabaseEntities.Dropdowns
{
    public class ChangeOrderReason
    {
        public Guid Id { get; set; }
        public string Value { get; set; }
        public int Position { get; set; }

        public static ChangeOrderReason MapFromDomainEntity(ChangeOrderReasonDTO changeOrderReason)
        {
            if (changeOrderReason == null) return null;

            return new ChangeOrderReason()
            {
                Id = changeOrderReason.Id,
                Value = changeOrderReason.Value,
                Position = changeOrderReason.Position
            };
        }
    }
}
