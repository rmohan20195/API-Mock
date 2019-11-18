using System;
using capredv2.backend.domain.DomainEntities.Projects;
using NUnit.Framework;

namespace capredv2.backend.domain.tests.DomainEntities.Projects
{
    [TestFixture]
    public class PurchaseOrderDTOTests
    {
        PurchaseOrderDTO purchaseOrder = new PurchaseOrderDTO
        {
            ProjectId = new Guid("b58b6a58-2064-4c71-9b3d-c8c4514159a9"),
            PurchaseOrderNumber = "1234",
            OrderTotal = 1078.10,
            AccountingTotal = 1078.10,
            Account = "802-001-5410610-501010-02-00000-000-000",
            Supplier = "FOS TEST VENDOR",
            OrderDate = new DateTime(2019, 08, 01),
            Item = "Item",
            AccountingTotalCurrency = "US Dollars",
            Currency = "US Dollars",
            Commodity = "IT Consulting",
            CostCode = "Drapers Gardens",
            CreatedBy = "Ashleigh Wallace",
            FixedAsset = "HARDWARE - ACCESSORIES",
            LastUpdatedBy = "Baqar Shameem",
            POHeaderId = Guid.NewGuid(),
            ProjectDescription = "PRJ8953 - CacheMatrix Phase 2",
            RequestedBy = "John Shifty",
            ShippingAddress = "400 Howard Street San Francisco, CA 94105, United States",
            ShipTo = "Ashleigh Wallace",
            TargetLocationCode = "Exchange Place 1, 1Semple St., Edinburgh, Scotland - ED2 (FY)"
        };


        [Test]
        public void MapToPOHeaderDTO_ValidEntity_ReturnDTOEntity()
        {
            //Act
            var response = PurchaseOrderDTO.MapToPOHeaderDTO(purchaseOrder);

            //Assert
            Assert.IsNotNull(response);
            Assert.AreEqual(purchaseOrder.ProjectId, response.ProjectId);
            Assert.AreEqual(purchaseOrder.Supplier, response.Supplier);
            Assert.AreEqual(purchaseOrder.PurchaseOrderNumber, response.PurchaseOrderNumber);
            Assert.AreEqual(purchaseOrder.ShippingAddress, response.ShippingAddress);
            Assert.AreEqual(purchaseOrder.OrderDate, response.OrderDate);
            Assert.AreEqual(purchaseOrder.OrderTotal, response.OrderTotal);            
            Assert.AreEqual(purchaseOrder.Currency, response.Currency);
            Assert.AreEqual(purchaseOrder.AccountingTotalCurrency, response.AccountingTotalCurrency);
        }

       
        [Test]
        public void MapToPOHeaderDTO_NullContent_ReturnNull()
        {
            //Act
            var response = PurchaseOrderDTO.MapToPOHeaderDTO(null);

            //Assert
            Assert.IsNull(response);
        }

      
        [Test]
        public void MapToPOLineItemDTO_ValidEntity_ReturnDTOEntity()
        {
            //Act
            var response = PurchaseOrderDTO.MapToPOLineItemDTO(purchaseOrder);

            //Assert
            Assert.IsNotNull(response);
            Assert.AreEqual(purchaseOrder.Id, response.Id);
            Assert.AreEqual(purchaseOrder.Item, response.Item);
            Assert.AreEqual(purchaseOrder.AccountingTotal, response.AccountingTotal);
            Assert.AreEqual(purchaseOrder.ProjectDescription, response.ProjectDescription);
            Assert.AreEqual(purchaseOrder.Commodity, response.Commodity);
            Assert.AreEqual(purchaseOrder.CostCode, response.CostCode);
            Assert.AreEqual(purchaseOrder.FixedAsset, response.FixedAsset);
            Assert.AreEqual(purchaseOrder.TargetLocationCode, response.TargetLocationCode);
            Assert.AreEqual(purchaseOrder.ShipTo, response.ShipTo);
            Assert.AreEqual(purchaseOrder.RequestedBy, response.RequestedBy);
            Assert.AreEqual(purchaseOrder.CreatedBy, response.CreatedBy);
            Assert.AreEqual(purchaseOrder.LastUpdatedBy, response.LastUpdatedBy);
            Assert.AreEqual(purchaseOrder.POHeaderId, response.POHeaderId);
        }

        [Test]
        public void MapToPOLineItemDTO_NullContent_ReturnNull()
        {
            //Act
            var response = PurchaseOrderDTO.MapToPOLineItemDTO(null);

            //Assert
            Assert.IsNull(response);
        }

    }
}
