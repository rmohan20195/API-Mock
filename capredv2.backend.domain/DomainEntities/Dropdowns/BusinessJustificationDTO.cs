using capredv2.backend.domain.DatabaseEntities.Dropdowns;
using System;
using System.Collections.Generic;
using System.Text;

namespace capredv2.backend.domain.DomainEntities.Dropdowns
{
    public class BusinessJustificationDTO
    {
        public Guid Id { get; set; }
        public string Value { get; set; }
        public int Position { get; set; }

        public BusinessJustificationDTO()
        {
            Id = Guid.NewGuid();
        }

        public static BusinessJustificationDTO MapFromDatabaseEntity(BusinessJustification businessJustification)
        {
            if (businessJustification == null) return null;

            return new BusinessJustificationDTO()
            {
                Id = businessJustification.Id,
                Value = businessJustification.Value,
                Position = businessJustification.Position
            };
        }
    }
}
