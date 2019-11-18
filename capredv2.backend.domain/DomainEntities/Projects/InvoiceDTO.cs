using System;
using LINQtoCSV;

namespace capredv2.backend.domain.DomainEntities.Projects
{
    public class InvoiceDTO
    {
        public Guid ProjectId { get; set; }

        [CsvColumn(Name = "Invoice #")]
        public string InvoiceNumber { get; set; }

        public string Supplier { get; set; }

        [CsvColumn(Name = "Invoice Date")]
        public DateTime? InvoiceDate { get; set; }

        [CsvColumn(Name = "Header status")]
        public string Status { get; set; }

        public string Currency { get; set; }

        [CsvColumn(Name = "Accounting Total Currency")]
        public string AccountingTotalCurrency { get; set; }

        public string Billing { get; set; }

        public string Total { get; set; }

        [CsvColumn(Name = "Total tax(Header)")]
        public string TotalTax { get; set; }

        [CsvColumn(Name = "Accounting Total")]
        public string AccountingTotal { get; set; }

        [CsvColumn(Name = "Project Description(Code)")]
        public string ProjectDescription { get; set; }

        public string Commodity { get; set; }

        [CsvColumn(Name = "Workflow Code")]
        public string WorkflowCode { get; set; }

        [CsvColumn(Name = "PO Number")]
        public string PONumber { get; set; }

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
        public string LocalPaymentDate { get; set; }

        [CsvColumn(Name = "Req #")]
        public string ReqNumber { get; set; }

        [CsvColumn(Name = "Req Line #")]
        public string ReqLineNumber { get; set; }

        [CsvColumn(Name = "Req Line Total")]
        public string ReqLineTotal { get; set; }

        [CsvColumn(Name = "PO Line Total")]
        public string POLineTotal { get; set; }

        public Guid InvoiceHeaderId { get; set; }

        public static InvoiceHeaderDTO MapToInvoiceHeaderDTO(InvoiceDTO invoiceHeaderDTO)
        {
            if (invoiceHeaderDTO == null) return null;

            return new InvoiceHeaderDTO
            {
                ProjectId = invoiceHeaderDTO.ProjectId,
                AccountingTotalCurrency = invoiceHeaderDTO.AccountingTotalCurrency,
                Billing = invoiceHeaderDTO.Billing,
                Currency = invoiceHeaderDTO.Currency,
                InvoiceDate = invoiceHeaderDTO.InvoiceDate,
                InvoiceNumber = invoiceHeaderDTO.InvoiceNumber,
                Status = invoiceHeaderDTO.Status,
                Supplier = invoiceHeaderDTO.Supplier
            };
        }

        public static InvoiceLineItemDTO MapToInvoiceLineItemDTO(InvoiceDTO invoiceDTO)
        {
            if (invoiceDTO == null) return null;

            InvoiceLineItemDTO invoiceLineItemDTO = new InvoiceLineItemDTO
            {
                Commodity = invoiceDTO.Commodity,
                CreatedBy = invoiceDTO.CreatedBy,
                CurrentApprover = invoiceDTO.CurrentApprover,
                Paid = invoiceDTO.Paid,
                PaymentNotes = invoiceDTO.PaymentNotes,
                
                POShipToCity = invoiceDTO.POShipToCity,
                POShipToCountry = invoiceDTO.POShipToCountry,
                POShipToName = invoiceDTO.POShipToName,
                ProjectDescription = invoiceDTO.ProjectDescription,
                ReqNumber = invoiceDTO.ReqNumber,
                RequestedBy = invoiceDTO.RequestedBy,
                TargetLocationCode = invoiceDTO.TargetLocationCode,
                
                WorkflowCode = invoiceDTO.WorkflowCode
            };

            double.TryParse(invoiceDTO.AccountingTotal, out double accTotal);
            invoiceLineItemDTO.AccountingTotal = accTotal;

            double.TryParse(invoiceDTO.POLineTotal, out double poLineTotal);
            invoiceLineItemDTO.POLineTotal = poLineTotal;

            double.TryParse(invoiceDTO.PONumber, out double poNo);
            invoiceLineItemDTO.PONumber = poNo;

            double.TryParse(invoiceDTO.ReqLineNumber, out double reqLineNo);
            invoiceLineItemDTO.ReqLineNumber = reqLineNo;

            double.TryParse(invoiceDTO.ReqLineTotal, out double reqLineTotal);
            invoiceLineItemDTO.ReqLineTotal = reqLineTotal;

            double.TryParse(invoiceDTO.Total, out double total);
            invoiceLineItemDTO.Total = total;

            double.TryParse(invoiceDTO.TotalTax, out double totalTax);
            invoiceLineItemDTO.TotalTax = totalTax;

            DateTime.TryParse(invoiceDTO.LocalPaymentDate, out DateTime localPayDate);
            invoiceLineItemDTO.LocalPaymentDate = localPayDate;

            return invoiceLineItemDTO;
        }
    }
}