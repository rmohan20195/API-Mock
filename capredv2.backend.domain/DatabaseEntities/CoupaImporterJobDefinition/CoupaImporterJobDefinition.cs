using System;
using System.Collections.Generic;
using System.Linq;
using capredv2.backend.domain.DatabaseEntities.Projects;
using capredv2.backend.domain.DomainEntities.CoupaImporter;

namespace capredv2.backend.domain.DatabaseEntities.CoupaImporterJobDefinitions
{
    public class CoupaImporterJobDefinition
    {
        public Guid Id { get; set; }
        public string FileName { get; set; }
        public DateTime TimeStamp { get; set; }
        public int Status { get; set; }
        public string FileType { get; set; }

        public ICollection<CoupaImporterJobDefinitionDetail> CoupaImporterJobDefinitionDetails { get; set; }

        public Guid ProjectId { get; set; }
	    public virtual Project Project { get; set; }

        public static CoupaImporterJobDefinition MapFromDomainEntity(CoupaImporterJobDefinitionDTO domainEntity)
        {
            if (domainEntity == null) return null;

            return new CoupaImporterJobDefinition
            {
                Id = domainEntity.Id,
                FileName = domainEntity.FileName,
                TimeStamp = domainEntity.TimeStamp,
                Status = (int)domainEntity.Status,
				ProjectId = domainEntity.ProjectId,
                FileType = domainEntity.FileType,

                CoupaImporterJobDefinitionDetails =
                    domainEntity.CoupaImporterJobDefinitionDetails
                        ?.Select(CoupaImporterJobDefinitionDetail.MapFromDomainEntity).ToList() ??
                    new List<CoupaImporterJobDefinitionDetail>()
            };
        }
    }
}
