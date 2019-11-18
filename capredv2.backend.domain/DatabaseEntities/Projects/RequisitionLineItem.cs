using capredv2.backend.domain.DomainEntities.Projects;
using System;

namespace capredv2.backend.domain.DatabaseEntities.Projects
{
    public class RequisitionLineItem
    {
        public Guid Id { get; set; }
        public int RequisitionLineNumber { get; set; }
        public double? OrderTotal { get; set; }
        public double? ReportingTotal { get; set; }
        public string Item { get; set; }
        public string Account { get; set; }
        public string CostCode { get; set; }
        public string ProjectDescription { get; set; }
        public string TargetLocationCode { get; set; }
        public string ShipToAddressName { get; set; }
        public string RequestedBy { get; set; }
        public string CurrentApprover { get; set; }
        public string CreatedBy { get; set; }

        public Guid RequisitionHeaderId { get; set; }
        public virtual RequisitionHeader RequisitionHeader { get; set; }

        public static RequisitionLineItem MapFromDomainEntity(RequisitionLineItemDTO requisitionLineItem)
        {
            if (requisitionLineItem == null) return null;

            return new RequisitionLineItem
            {
                Id = requisitionLineItem.Id,
                RequisitionLineNumber = requisitionLineItem.RequisitionLineNumber,
                OrderTotal =requisitionLineItem.OrderTotal,
                ReportingTotal = requisitionLineItem.ReportingTotal,
                Item = requisitionLineItem.Item,
                Account = requisitionLineItem.Account,
                CostCode = requisitionLineItem.CostCode,
                ProjectDescription = requisitionLineItem.ProjectDescription,
                TargetLocationCode = requisitionLineItem.TargetLocationCode,
                ShipToAddressName = requisitionLineItem.ShipToAddressName,
                RequestedBy = requisitionLineItem.RequestedBy,
                CurrentApprover = requisitionLineItem.CurrentApprover,
                CreatedBy = requisitionLineItem.CreatedBy,

                RequisitionHeaderId = requisitionLineItem.RequisitionHeaderId
            };
        }
    }
}
