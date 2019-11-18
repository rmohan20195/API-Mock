using System;
using System.Collections.Generic;
using System.Linq;
using capredv2.backend.domain.DatabaseEntities.Projects;
using capredv2.backend.domain.DomainEntities.CoupaImporter;
using Microsoft.AspNetCore.Http;

namespace capredv2.backend.domain.DomainEntities.Projects
{
    public class ProjectDTO
    {
        public Guid Id{ get; set; }
        public ProjectInformationDTO ProjectInformation { get; set; }
        public CapitalPlanDTO CapitalPlan { get; set; }
        public IEnumerable<CoupaImporterJobDefinitionDTO> CoupaImporterJobDefinitions { get; set; }
        public IEnumerable<RequisitionHeaderDTO> RequisitionHeaders { get; set; }
        public IEnumerable<POHeaderDTO> POHeaders { get; set; }
        public IEnumerable<InvoiceHeaderDTO> InvoiceHeaders { get; set; }
        
        //public EstimateDTO Estimate { get; set; }
        //public ScheduleDateDTO ScheduleDate { get; set; }
        //public BudgetMovementLogDTO BudgetMovementLog { get; set; }

        public static ProjectDTO MapFromDatabaseEntity(Project project)
        {
            if (project == null) return null;

            return new ProjectDTO
            {
                Id = project.Id,
                ProjectInformation = ProjectInformationDTO.MapFromDatabaseEntity(project.ProjectInformation),
                CapitalPlan = CapitalPlanDTO.MapFromDatabaseEntity(project.CapitalPlan),

                CoupaImporterJobDefinitions = project.CoupaImporterJobDefinitions?.Select(CoupaImporterJobDefinitionDTO.MapFromDatabaseEntity).ToList() ??
                               new List<CoupaImporterJobDefinitionDTO>(),

                RequisitionHeaders = project.RequisitionHeaders?.Select(RequisitionHeaderDTO.MapFromDatabaseEntity).ToList() ??
                               new List<RequisitionHeaderDTO>(),
                POHeaders = project.POHeaders?.Select(POHeaderDTO.MapFromDatabaseEntity).ToList() ??
                                 new List<POHeaderDTO>(),
                InvoiceHeaders =
                    project.InvoiceHeaders?.Select(InvoiceHeaderDTO.MapFromDomainEntity).ToList() ?? new List<InvoiceHeaderDTO>(),

                //Estimate = EstimateDTO.MapFromDatabaseEntity(project.Estimate),
                //ScheduleDate = ScheduleDateDTO.MapFromDatabaseEntity(project.ScheduleDate),
                //BudgetMovementLog = BudgetMovementLogDTO.MapFromDatabaseEntity(project.BudgetMovementLog)
            };
        }
    }
}
