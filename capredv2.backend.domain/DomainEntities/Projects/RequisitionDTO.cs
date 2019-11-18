using System;
using LINQtoCSV;

namespace capredv2.backend.domain.DomainEntities.Projects
{
    public class RequisitionDTO
    {
        public Guid Id { get; set; }

        public Guid ProjectId { get; set; }

        [CsvColumn(Name = "Req #")]
        public string RequisitionNumber { get; set; }

        [CsvColumn(Name = "Req Line #")]
        public string RequisitionLineNumber { get; set; }

        [CsvColumn(Name = "Total")]
        public string OrderTotal { get; set; }

        [CsvColumn(Name = "Reporting Total")]
        public string ReportingTotal { get; set; }

        public string Account { get; set; }

        public string Supplier { get; set; }

        [CsvColumn(Name = "Created Date (Header)")]
        public string CreatedDate { get; set; }

        [CsvColumn(Name = "Status (Header)")]
        public string Status { get; set; }

        [CsvColumn(Name = "PO Number", CanBeNull = true)]
        public string PurchaseOrderNumber { get; set; }

        public string Item { get; set; }

        public string Currency { get; set; }

        [CsvColumn(Name = "Cost Code")]
        public string CostCode { get; set; }

        [CsvColumn(Name = "Project Description (Code)")]
        public string ProjectDescription { get; set; }

        [CsvColumn(Name = "Target Location Code")]
        public string TargetLocationCode { get; set; }

        [CsvColumn(Name = "Ship To Address Name (Header)")]
        public string ShipToAddressName { get; set; }

        [CsvColumn(Name = "Requested By (Header)")]
        public string RequestedBy { get; set; }

        [CsvColumn(Name = "Current Approver")]
        public string CurrentApprover { get; set; }

        [CsvColumn(Name = "Created By (Header)")]
        public string CreatedBy { get; set; }

        public Guid RequisitionHeaderId { get; set; }


        public static RequisitionHeaderDTO MapToRequisitionHeaderDTO(RequisitionDTO requisitionHeader)
        {
            if (requisitionHeader == null) return null;

            var requisitionHeaderDTO = new RequisitionHeaderDTO
            {
                Id = requisitionHeader.Id,
                Supplier = requisitionHeader.Supplier,
                Status = requisitionHeader.Status,               
                Currency = requisitionHeader.Currency,
                ProjectId = requisitionHeader.ProjectId
            };

            int.TryParse(requisitionHeader.RequisitionNumber, out int requisitionNumber);
            requisitionHeaderDTO.RequisitionNumber = requisitionNumber;

            DateTime.TryParse(requisitionHeader.CreatedDate, out DateTime createdDate);
            requisitionHeaderDTO.CreatedDate = createdDate;

            int.TryParse(requisitionHeader.PurchaseOrderNumber, out int purchaseOrderNumber);
            requisitionHeaderDTO.PurchaseOrderNumber = purchaseOrderNumber;

            return requisitionHeaderDTO;
        }

        public static RequisitionLineItemDTO MapToRequisitionLineItemDTO(RequisitionDTO requisitionLineItem)
        {
            if (requisitionLineItem == null) return null;

            var requisitionLineItemDTO = new RequisitionLineItemDTO
            {
                Id = requisitionLineItem.Id,
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

            int.TryParse(requisitionLineItem.RequisitionLineNumber, out int requisitionLineNumber);
            requisitionLineItemDTO.RequisitionLineNumber = requisitionLineNumber;

            double.TryParse(requisitionLineItem.OrderTotal, out double orderTotal);
            requisitionLineItemDTO.OrderTotal = orderTotal;

            double.TryParse(requisitionLineItem.ReportingTotal, out double reportingTotal);
            requisitionLineItemDTO.ReportingTotal = reportingTotal;

            return requisitionLineItemDTO;
        }
    }
}