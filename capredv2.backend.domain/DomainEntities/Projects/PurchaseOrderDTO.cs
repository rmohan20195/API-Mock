using System;
using LINQtoCSV;

namespace capredv2.backend.domain.DomainEntities.Projects
{
    public class PurchaseOrderDTO
    {
        public Guid Id { get; set; }

        public Guid POHeaderId { get; set; }

        public Guid ProjectId { get; set; }

        public string Supplier { get; set; }

        [CsvColumn(Name = "PO Number (Header)")]
        public string PurchaseOrderNumber { get; set; }

        [CsvColumn(Name = "Shipping Address (Header)")]
        public string ShippingAddress { get; set; }

        [CsvColumn(Name = "Order Date (Header)")]
        public DateTime OrderDate { get; set; }

        public string Item { get; set; }

        [CsvColumn(Name = "Order Total (Header)")]
        public double OrderTotal { get; set; }

        public string Currency { get; set; }

        [CsvColumn(Name = "Accounting Total")]
        public double AccountingTotal { get; set; }

        [CsvColumn(Name = "Accounting Total Currency")]
        public string AccountingTotalCurrency { get; set; }

        [CsvColumn(Name = "Project Description (Code)")]
        public string ProjectDescription { get; set; }

        public string Commodity { get; set; }

        public string Account { get; set; }

        [CsvColumn(Name = "Cost Code")]
        public string CostCode { get; set; }

        [CsvColumn(Name = "Fixed Asset / CIP Category")]
        public string FixedAsset { get; set; }

        [CsvColumn(Name = "Target Location Code")]
        public string TargetLocationCode { get; set; }

        [CsvColumn(Name = "Ship To (Header)")]
        public string ShipTo { get; set; }

        [CsvColumn(Name = "Requested By (Header)")]
        public string RequestedBy { get; set; }

        [CsvColumn(Name = "Created By")]
        public string CreatedBy { get; set; }

        [CsvColumn(Name = "Last Updated By")]
        public string LastUpdatedBy { get; set; }


        public static POHeaderDTO MapToPOHeaderDTO(PurchaseOrderDTO projectPurchaseOrder)
        {
            if (projectPurchaseOrder == null) return null;

            return new POHeaderDTO
            {
                Id = projectPurchaseOrder.Id,
                Supplier = projectPurchaseOrder.Supplier,
                PurchaseOrderNumber = projectPurchaseOrder.PurchaseOrderNumber,
                ShippingAddress = projectPurchaseOrder.ShippingAddress,
                OrderDate = projectPurchaseOrder.OrderDate,
                OrderTotal = projectPurchaseOrder.OrderTotal,
                Currency = projectPurchaseOrder.Currency,
                AccountingTotalCurrency = projectPurchaseOrder.AccountingTotalCurrency,

                ProjectId = projectPurchaseOrder.ProjectId,
            };
        }

        public static POLineItemDTO MapToPOLineItemDTO(PurchaseOrderDTO projectPurchaseOrder)
        {
            if (projectPurchaseOrder == null) return null;

            return new POLineItemDTO
            {
                Id = projectPurchaseOrder.Id,
                Item = projectPurchaseOrder.Item,
                AccountingTotal = projectPurchaseOrder.AccountingTotal,
                ProjectDescription = projectPurchaseOrder.ProjectDescription,
                Commodity = projectPurchaseOrder.Commodity,
                Account = projectPurchaseOrder.Account,
                CostCode = projectPurchaseOrder.CostCode,
                FixedAsset = projectPurchaseOrder.FixedAsset,
                TargetLocationCode = projectPurchaseOrder.TargetLocationCode,
                ShipTo = projectPurchaseOrder.ShipTo,
                RequestedBy = projectPurchaseOrder.RequestedBy,
                CreatedBy = projectPurchaseOrder.CreatedBy,
                LastUpdatedBy = projectPurchaseOrder.LastUpdatedBy,

                POHeaderId = projectPurchaseOrder.POHeaderId
            };
        }

    }
}