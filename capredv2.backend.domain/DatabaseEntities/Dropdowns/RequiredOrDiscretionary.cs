using capredv2.backend.domain.DomainEntities.Dropdowns;
using System;
using System.Collections.Generic;
using System.Text;

namespace capredv2.backend.domain.DatabaseEntities.Dropdowns
{
    public class RequiredOrDiscretionary
    {
        public Guid Id { get; set; }
        public string Value { get; set; }
        public int Position { get; set; }

        public static RequiredOrDiscretionary MapFromDomainEntity(RequiredOrDiscretionaryDTO requiredOrDiscretionary)
        {
            if (requiredOrDiscretionary == null) return null;

            return new RequiredOrDiscretionary()
            {
                Id = requiredOrDiscretionary.Id,
                Value = requiredOrDiscretionary.Value,
                Position = requiredOrDiscretionary.Position
            };
        }
    }
}
