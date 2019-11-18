using capredv2.backend.domain.DomainEntities.Projects;
using System;

namespace capredv2.backend.domain.DatabaseEntities.Projects
{
    public class InvoiceLineItem
    {
        public Guid Id { get; set; }
        public double? Total { get; set; }
        public double? TotalTax { get; set; }
        public double? AccountingTotal { get; set; }
        public string ProjectDescription { get; set; }
        public string Commodity { get; set; }
        public string WorkflowCode { get; set; }
        public double? PONumber { get; set; }
        public string RequestedBy { get; set; }
        public string TargetLocationCode { get; set; }
        public string POShipToCity { get; set; }
        public string POShipToCountry { get; set; }
        public string POShipToName { get; set; }
        public string CurrentApprover { get; set; }
        public string CreatedBy { get; set; }
        public string Paid { get; set; }
        public string PaymentNotes { get; set; }
        public DateTime? LocalPaymentDate { get; set; }
        public string ReqNumber { get; set; }
        public double? ReqLineNumber { get; set; }
        public double? ReqLineTotal { get; set; }
        public double? POLineTotal { get; set; }

        public Guid InvoiceHeaderId { get; set; }
        public virtual InvoiceHeader InvoiceHeader { get; set; }

        public static InvoiceLineItem MapFromDomainEntity(InvoiceLineItemDTO projectInvoiceLineItem)
        {
            if (projectInvoiceLineItem == null) return null;

            InvoiceLineItem invoiceLineItem = new InvoiceLineItem
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
            return invoiceLineItem;
        }

    }
}
