using System;
using System.Collections.Generic;
using System.Linq;
using capredv2.backend.domain.DomainEntities.Projects;
using capredv2.backend.domain.DatabaseEntities.CoupaImporterJobDefinitions;

namespace capredv2.backend.domain.DatabaseEntities.Projects
{
    public class Project
    {
        public Guid Id { get; set; }
        public ProjectInformation ProjectInformation { get; set; }
        public CapitalPlan CapitalPlan { get; set; }
        public ICollection<CoupaImporterJobDefinition> CoupaImporterJobDefinitions { get; set; }
        public ICollection<RequisitionHeader> RequisitionHeaders { get; set; }
        public ICollection<POHeader> POHeaders { get; set; }
        public ICollection<InvoiceHeader> InvoiceHeaders { get; set; }

        //public Estimate Estimate { get; set; }
        //public ScheduleDate ScheduleDate { get; set; }
        //public BudgetMovementLog BudgetMovementLog { get; set; }

        public static Project MapFromDomainEntity(ProjectDTO project)
        {
            if (project == null) return null;

            return new Project
            {
                Id = project.Id,
                ProjectInformation = ProjectInformation.MapFromDomainEntity(project.ProjectInformation),
                CapitalPlan = CapitalPlan.MapFromDomainEntity(project.CapitalPlan),

                CoupaImporterJobDefinitions = project.CoupaImporterJobDefinitions?.Select(CoupaImporterJobDefinition.MapFromDomainEntity).ToList() ??
                               new List<CoupaImporterJobDefinition>(),
                RequisitionHeaders = project.RequisitionHeaders?.Select(RequisitionHeader.MapFromDomainEntity).ToList() ??
                               new List<RequisitionHeader>(),
                POHeaders = project.POHeaders?.Select(POHeader.MapFromDomainEntity).ToList() ??
                                 new List<POHeader>(),
                InvoiceHeaders = project.InvoiceHeaders?.Select(InvoiceHeader.MapFromDomainEntity).ToList() ?? 
                                new List<InvoiceHeader>(),
                //Estimate = Estimate.MapFromDomainEntity(project.Estimate),
                //ScheduleDate = ScheduleDate.MapFromDomainEntity(project.ScheduleDate),
                //BudgetMovementLog = BudgetMovementLog.MapFromDomainEntity(project.BudgetMovementLog)
            };
        }
    }
}
