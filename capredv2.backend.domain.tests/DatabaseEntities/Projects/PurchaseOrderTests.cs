using System;
using capredv2.backend.domain.DatabaseEntities.Projects;
using capredv2.backend.domain.DomainEntities.Projects;
using NUnit.Framework;

namespace capredv2.backend.domain.tests.DatabaseEntities.Projects
{
    [TestFixture]
    public class PurchaseOrderTests
    {
        [Test]
        public void MapFromDomainEntity_ValidEntity_ReturnDTOEntity()
        {
            //Arrange
            var purchaseOrder = new PurchaseOrderDTO
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

            //Act
            var response = PurchaseOrder.MapFromDomainEntity(purchaseOrder);

            //Assert
            Assert.IsNotNull(response);
            Assert.AreEqual(purchaseOrder.ProjectId, response.ProjectId);
            Assert.AreEqual(purchaseOrder.PurchaseOrderNumber, response.PurchaseOrderNumber);
            Assert.AreEqual(purchaseOrder.OrderTotal, response.OrderTotal);
            Assert.AreEqual(purchaseOrder.AccountingTotal, response.AccountingTotal);
            Assert.AreEqual(purchaseOrder.Account, response.Account);
            Assert.AreEqual(purchaseOrder.Supplier, response.Supplier);
            Assert.AreEqual(purchaseOrder.OrderDate, response.OrderDate);
            Assert.AreEqual(purchaseOrder.Item, response.Item);
            Assert.AreEqual(purchaseOrder.AccountingTotalCurrency, response.AccountingTotalCurrency);
            Assert.AreEqual(purchaseOrder.Currency, response.Currency);
        }

        [Test]
        public void MapFromDomainEntity_NullContent_ReturnNull()
        {
            //Act
            var response = PurchaseOrderDTO.MapFromDatabaseEntity(null);

            //Assert
            Assert.IsNull(response);
        }
    }
}
