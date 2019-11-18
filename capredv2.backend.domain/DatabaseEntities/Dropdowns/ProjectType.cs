using capredv2.backend.domain.DomainEntities.Dropdowns;
using System;
using System.Collections.Generic;
using System.Text;

namespace capredv2.backend.domain.DatabaseEntities.Dropdowns
{
    public class ProjectType
    {
        public Guid Id { get; set; }
        public string Value { get; set; }
        public int Position { get; set; }

        public static ProjectType MapFromDomainEntity(ProjectTypeDTO projectType)
        {
            if (projectType == null) return null;

            return new ProjectType()
            {
                Id = projectType.Id,
                Value = projectType.Value,
                Position = projectType.Position
            };
        }
    }
}
