using capredv2.backend.domain.DomainEntities.Dropdowns;
using System;
using System.Collections.Generic;
using System.Text;

namespace capredv2.backend.domain.DatabaseEntities.Dropdowns
{
    public class ProjectTheme
    {
        public Guid Id { get; set; }
        public string Value { get; set; }
        public int Position { get; set; }

        public static ProjectTheme MapFromDomainEntity(ProjectThemeDTO projectTheme)
        {
            if (projectTheme == null) return null;

            return new ProjectTheme()
            {
                Id = projectTheme.Id,
                Value = projectTheme.Value,
                Position = projectTheme.Position
            };
        }
    }
}
