using capredv2.backend.domain.DatabaseEntities.Projects;
using LINQtoCSV;
using System;

namespace capredv2.backend.domain.DomainEntities.Projects
{
    public class InvoiceLineItemDTO
    {
        public InvoiceLineItemDTO()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }

        public double? Total { get; set; }

        [CsvColumn(Name = "Total tax(Header)")]
        public double? TotalTax { get; set; }

        [CsvColumn(Name = "Accounting Total")]
        public double? AccountingTotal { get; set; }

        [CsvColumn(Name = "Project Description(Code)")]
        public string ProjectDescription { get; set; }

        public string Commodity { get; set; }

        [CsvColumn(Name = "Workflow Code")]
        public string WorkflowCode { get; set; }

        [CsvColumn(Name = "PO Number")]
        public double? PONumber { get; set; }

        [CsvColumn(Name = "Requested By")]
        public string RequestedBy { get; set; }

        [CsvColumn(Name = "Target Location Code")]
        public string TargetLocationCode { get; set; }

        [CsvColumn(Name = "PO Ship-To City")]
        public string POShipToCity { get; set; }

        [CsvColumn(Name = "PO Ship-To Country")]
        public string POShipToCountry { get; set; }

        [CsvColumn(Name = "PO Ship-To Name")]
        public string POShipToName { get; set; }

        [CsvColumn(Name = "Current Approver")]
        public string CurrentApprover { get; set; }

        [CsvColumn(Name = "Created By")]
        public string CreatedBy { get; set; }

        public string Paid { get; set; }

        [CsvColumn(Name = "Payment Notes")]
        public string PaymentNotes { get; set; }

        [CsvColumn(Name = "Local Payment Date")]
        public DateTime? LocalPaymentDate { get; set; }

        [CsvColumn(Name = "Req #")]
        public string ReqNumber { get; set; }

        [CsvColumn(Name = "Req Line #")]
        public double? ReqLineNumber { get; set; }

        [CsvColumn(Name = "Req Line Total")]
        public double? ReqLineTotal { get; set; }

        [CsvColumn(Name = "PO Line Total")]
        public double? POLineTotal { get; set; }

        public Guid InvoiceHeaderId { get; set; }

        public static InvoiceLineItemDTO MapFromDomainEntity(InvoiceLineItem projectInvoiceLineItem)
        {
            if (projectInvoiceLineItem == null) return null;

            return new InvoiceLineItemDTO
            {
                Id = projectInvoiceLineItem.Id,
                AccountingTotal = projectInvoiceLineItem.AccountingTotal,
                Commodity = projectInvoiceLineItem.Commodity,
                CreatedBy = projectInvoiceLineItem.CreatedBy,
                CurrentApprover = projectInvoiceLineItem.CurrentApprover,
                InvoiceHeaderId = projectInvoiceLineItem.InvoiceHeaderId,
                LocalPaymentDate = projectInvoiceLineItem.LocalPaymentDate,
                Paid = projectInvoiceLineItem.Paid,
                PaymentNotes = projectInvoiceLineItem.PaymentNotes,
                POLineTotal = projectInvoiceLineItem.POLineTotal,
                PONumber = projectInvoiceLineItem.PONumber,
                POShipToCity = projectInvoiceLineItem.POShipToCity,
                POShipToCountry = projectInvoiceLineItem.POShipToCountry,
                POShipToName = projectInvoiceLineItem.POShipToName,
                ProjectDescription = projectInvoiceLineItem.ProjectDescription,
                ReqLineNumber = projectInvoiceLineItem.ReqLineNumber,
                ReqLineTotal = projectInvoiceLineItem.ReqLineTotal,
                ReqNumber = projectInvoiceLineItem.ReqNumber,
                RequestedBy = projectInvoiceLineItem.RequestedBy,
                TargetLocationCode = projectInvoiceLineItem.TargetLocationCode,
                Total = projectInvoiceLineItem.Total,
                TotalTax = projectInvoiceLineItem.TotalTax,
                WorkflowCode = projectInvoiceLineItem.WorkflowCode
            };
        }
    }
}
