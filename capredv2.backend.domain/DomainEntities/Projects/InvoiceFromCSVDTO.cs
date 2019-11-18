using System;
using LINQtoCSV;

namespace capredv2.backend.domain.DomainEntities.Projects
{
    public class InvoiceFromCSVDTO
    {
        public InvoiceFromCSVDTO()
        {
            Id = Guid.NewGuid();
        }
        public Guid Id { get; set; }
        public Guid ProjectId { get; set; }

        [CsvColumn(Name = "Invoice #")]
        public string InvoiceNumber { get; set; }

        public double Total { get; set; }

        public string Paid { get; set; }

        
        [CsvColumn(Name = "Billing")]
        public string Account { get; set; }
        public string Supplier { get; set; }

        [CsvColumn(Name = "PO Number")]
        public long? PurchaseOrderNumber { get; set; }

        [CsvColumn(Name = "Invoice Date")]
        public DateTime? InvoiceDate { get; set; }

        public DateTime ReceivedOrCreatedDate { get; set; }

        [CsvColumn(Name = "Header status")]
        public string Status { get; set; }

        [CsvColumn(Name = "Local Payment Date")]
        public DateTime? LocalPaymentDate { get; set; }

        //public static InvoiceFromCSVDTO MapFromDatabaseEntity(Invoice projectInvoice)
        //{
        //    if (projectInvoice == null) return null;

        //    return new InvoiceFromCSVDTO
        //    {
        //        Id = projectInvoice.Id,
        //        ProjectId = projectInvoice.ProjectId,
        //        Status = projectInvoice.Status,
        //        PurchaseOrderNumber = projectInvoice.PurchaseOrderNumber,
        //        Account = projectInvoice.Account,
        //        Supplier = projectInvoice.Supplier,
        //        ReceivedOrCreatedDate = projectInvoice.ReceivedOrCreatedDate,
        //        InvoiceDate = projectInvoice.InvoiceDate,
        //        InvoiceNumber = projectInvoice.InvoiceNumber,
        //        LocalPaymentDate = projectInvoice.LocalPaymentDate,
        //        Paid = projectInvoice.Paid == true ? "YES" : "NO",
        //        Total = projectInvoice.Total
        //    };
        //}

        //public static InvoiceFromCSVDTO MapFromDTO(InvoiceDTO projectInvoice)
        //{
        //    if (projectInvoice == null) return null;

        //    return new InvoiceFromCSVDTO
        //    {
        //        Id = projectInvoice.Id,
        //        ProjectId = projectInvoice.ProjectId,
        //        Status = projectInvoice.Status,
        //        PurchaseOrderNumber = projectInvoice.PurchaseOrderNumber,
        //        Account = projectInvoice.Account,
        //        Supplier = projectInvoice.Supplier,
        //        ReceivedOrCreatedDate = projectInvoice.ReceivedOrCreatedDate,
        //        InvoiceDate = projectInvoice.InvoiceDate,
        //        InvoiceNumber = projectInvoice.InvoiceNumber,
        //        LocalPaymentDate = projectInvoice.LocalPaymentDate,
        //        Paid = projectInvoice.Paid == true ? "YES" : "NO",
        //        Total = projectInvoice.Total
        //    };
        //}
    }
}