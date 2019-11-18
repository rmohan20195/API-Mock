using capredv2.backend.domain.DomainEntities.Dropdowns;
using System;
using System.Collections.Generic;
using System.Text;

namespace capredv2.backend.domain.DatabaseEntities.Dropdowns
{
   public class BusinessDriver
    {
        public Guid Id { get; set; }
        public string Value { get; set; }
        public int Position { get; set; }

        public static BusinessDriver MapFromDomainEntity(BusinessDriverDTO businessDriver)
        {
            if (businessDriver == null) return null;

            return new BusinessDriver()
            {
                Id = businessDriver.Id,
                Value = businessDriver.Value,
                Position = businessDriver.Position
            };
        }
    }
}
