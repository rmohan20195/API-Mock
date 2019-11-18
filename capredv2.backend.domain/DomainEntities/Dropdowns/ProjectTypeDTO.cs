using capredv2.backend.domain.DatabaseEntities.Dropdowns;
using System;
using System.Collections.Generic;
using System.Text;

namespace capredv2.backend.domain.DomainEntities.Dropdowns
{
    public class ProjectTypeDTO
    {
        public Guid Id { get; set; }
        public string Value { get; set; }
        public int Position { get; set; }

        public ProjectTypeDTO()
        {
            Id = Guid.NewGuid();
        }

        public static ProjectTypeDTO MapFromDatabaseEntity(ProjectType projectType)
        {
            if (projectType == null) return null;

            return new ProjectTypeDTO()
            {
                Id = projectType.Id,
                Value = projectType.Value,
                Position = projectType.Position
            };
        }
    }
}
