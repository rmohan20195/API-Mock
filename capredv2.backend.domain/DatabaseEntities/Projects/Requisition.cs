using System;
using capredv2.backend.domain.DomainEntities.Projects;

namespace capredv2.backend.domain.DatabaseEntities.Projects
{
    public class Requisition
    {
        public Requisition()
        {
            PurchaseOrderNumber = string.IsNullOrEmpty(this.PurchaseOrderNumber.ToString()) ? 0 : this.PurchaseOrderNumber;
        }
        public Guid Id { get; set; }
        public int RequisitionNumber { get; set; }
        public double OrderTotal { get; set; }
        public double ReportingTotal { get; set; }
        public string Account { get; set; }
        public string Supplier { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Status { get; set; }
        public int PurchaseOrderNumber { get; set; }
        public string Item { get; set; }
        public string Currency { get; set; }

        public Guid ProjectId { get; set; }
        public virtual Project Project { get; set; }

        public static Requisition MapFromDomainEntity(RequisitionDTO projectRequisition)
        {
            if (projectRequisition == null) return null;

            return new Requisition
            {
                Id = projectRequisition.Id,
                ProjectId = projectRequisition.ProjectId,
                Status = projectRequisition.Status,
                Item = projectRequisition.Item,
                OrderTotal = projectRequisition.OrderTotal,
                PurchaseOrderNumber = projectRequisition.PurchaseOrderNumber.GetValueOrDefault(),
                RequisitionNumber = projectRequisition.RequisitionNumber,
                Account = projectRequisition.Account,
                CreatedDate = projectRequisition.CreatedDate,
                Currency = projectRequisition.Currency,
                ReportingTotal = projectRequisition.ReportingTotal,
                Supplier = projectRequisition.Supplier
            };
        }
    }
}