using capredv2.backend.domain.DomainEntities.Dropdowns;
using System;
using System.Collections.Generic;
using System.Text;

namespace capredv2.backend.domain.DatabaseEntities.Dropdowns
{
    public class BusinessJustification
    {
        public Guid Id { get; set; }
        public string Value { get; set; }
        public int Position { get; set; }

        public static BusinessJustification MapFromDomainEntity(BusinessJustificationDTO businessJustification)
        {
            if (businessJustification == null) return null;

            return new BusinessJustification()
            {
                Id = businessJustification.Id,
                Value = businessJustification.Value,
                Position = businessJustification.Position
            };
        }
    }
}
