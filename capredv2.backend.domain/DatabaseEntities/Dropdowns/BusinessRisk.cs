using capredv2.backend.domain.DomainEntities.Dropdowns;
using System;
using System.Collections.Generic;
using System.Text;

namespace capredv2.backend.domain.DatabaseEntities.Dropdowns
{
    public class BusinessRisk
    {
        public Guid Id { get; set; }
        public string Value { get; set; }
        public int Position { get; set; }

        public static BusinessRisk MapFromDomainEntity(BusinessRiskDTO businessRisk)
        {
            if (businessRisk == null) return null;

            return new BusinessRisk()
            {
                Id = businessRisk.Id,
                Value = businessRisk.Value,
                Position = businessRisk.Position
            };
        }
    }
}
