﻿using System;
using capredv2.backend.domain.DatabaseEntities.Projects;

namespace capredv2.backend.domain.Repositories.Interfaces
{
    public interface IProjectInformationRepository
    {
        object Get(Guid id);
        void Update(Guid id, ProjectInformation projectInformation);
    }
}
