using capredv2.backend.domain.DatabaseEntities.Dropdowns;
using System;
using System.Collections.Generic;
using System.Text;

namespace capredv2.backend.domain.DomainEntities.Dropdowns
{
    public class RequiredOrDiscretionaryDTO
    {
        public Guid Id { get; set; }
        public string Value { get; set; }
        public int Position { get; set; }

        public RequiredOrDiscretionaryDTO()
        {
            Id = Guid.NewGuid();
        }

        public static RequiredOrDiscretionaryDTO MapFromDatabaseEntity(RequiredOrDiscretionary requiredOrDiscretionary)
        {
            if (requiredOrDiscretionary == null) return null;

            return new RequiredOrDiscretionaryDTO()
            {
                Id = requiredOrDiscretionary.Id,
                Value = requiredOrDiscretionary.Value,
                Position = requiredOrDiscretionary.Position
            };
        }
    }
}
