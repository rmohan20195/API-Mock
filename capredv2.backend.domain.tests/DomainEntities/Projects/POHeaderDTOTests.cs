using capredv2.backend.domain.DatabaseEntities.Projects;
using capredv2.backend.domain.DomainEntities.Projects;
using NUnit.Framework;
using System;

namespace capredv2.backend.domain.tests.DomainEntities.Projects
{
    [TestFixture]
    public class POHeaderDTOTests
    {
        [Test]
        public void MapFromDomainEntity_ValidEntity_ReturnDTOEntity()
        {
            //Arrange
            var pOHeader = new POHeader
            {
                Id = Guid.NewGuid(),
                Supplier = "MEDIALINK PRINTING SERVICES PTE LTD",
                PurchaseOrderNumber = "7116",
                ShippingAddress = "601 Union Street",
                OrderDate = new DateTime(2019, 4, 1),
                Currency = "USD",
                AccountingTotalCurrency = "2,052.22",
                OrderTotal = 209.78,
                ProjectId = Guid.NewGuid()
            };

            //Act
            var response = POHeaderDTO.MapFromDatabaseEntity(pOHeader);

            //Assert
            Assert.IsNotNull(response);
            Assert.AreEqual(pOHeader.Id, response.Id);
            Assert.AreEqual(pOHeader.Supplier, response.Supplier);
            Assert.AreEqual(pOHeader.PurchaseOrderNumber, response.PurchaseOrderNumber);
            Assert.AreEqual(pOHeader.ShippingAddress, response.ShippingAddress);
            Assert.AreEqual(pOHeader.OrderDate, response.OrderDate);
            Assert.AreEqual(pOHeader.Currency, response.Currency);
            Assert.AreEqual(pOHeader.AccountingTotalCurrency, response.AccountingTotalCurrency);
            Assert.AreEqual(pOHeader.OrderTotal, response.OrderTotal);
            Assert.AreEqual(pOHeader.ProjectId, response.ProjectId);            
        }

        [Test]
        public void MapFromDomainEntity_NullContent_ReturnNull()
        {
            //Act
            var response = POHeaderDTO.MapFromDatabaseEntity(null);

            //Assert
            Assert.IsNull(response);
        }
    }
}
