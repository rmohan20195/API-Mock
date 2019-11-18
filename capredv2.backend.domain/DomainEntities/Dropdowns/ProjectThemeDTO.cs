using capredv2.backend.domain.DatabaseEntities.Dropdowns;
using System;
using System.Collections.Generic;
using System.Text;

namespace capredv2.backend.domain.DomainEntities.Dropdowns
{
    public class ProjectThemeDTO
    {
        public Guid Id { get; set; }
        public string Value { get; set; }
        public int Position { get; set; }

        public ProjectThemeDTO()
        {
            Id = Guid.NewGuid();
        }

        public static ProjectThemeDTO MapFromDatabaseEntity(ProjectTheme projectTheme)
        {
            if (projectTheme == null) return null;

            return new ProjectThemeDTO()
            {
                Id = projectTheme.Id,
                Value = projectTheme.Value,
                Position = projectTheme.Position
            };
        }
    }
}
