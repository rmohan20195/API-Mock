using System;
using capredv2.backend.domain.DatabaseEntities.Projects;
using capredv2.backend.domain.DomainEntities.Projects;
using NUnit.Framework;

namespace capredv2.backend.domain.tests.DatabaseEntities.Projects
{
    [TestFixture]
    public class RequisitionTests
    {
        [Test]
        public void MapFromDomainEntity_ValidEntity_ReturnDTOEntity()
        {
            //Arrange
            var requisition = new RequisitionDTO
            {
                ProjectId = new Guid("b58b6a58-2064-4c71-9b3d-c8c4514159a9"),
                RequisitionNumber = "1001",
                OrderTotal = 50000D,
                ReportingTotal = 60000D,
                Account = "Account",
                Supplier = "Supplier",
                CreatedDate = new DateTime(2019, 08, 01),
                Status = "Status",
                PurchaseOrderNumber = "1234",
                Item = "Item",
                Currency = "US Dollar"
            };

            //Act
            var response = Requisition.MapFromDomainEntity(requisition);

            //Assert
            Assert.IsNotNull(response);
            Assert.AreEqual(requisition.ProjectId, response.ProjectId);
            Assert.AreEqual(requisition.RequisitionNumber, response.RequisitionNumber);
            Assert.AreEqual(requisition.OrderTotal, response.OrderTotal);
            Assert.AreEqual(requisition.ReportingTotal, response.ReportingTotal);
            Assert.AreEqual(requisition.Account, response.Account);
            Assert.AreEqual(requisition.Supplier, response.Supplier);
            Assert.AreEqual(requisition.CreatedDate, response.CreatedDate);
            Assert.AreEqual(requisition.Status, response.Status);
            Assert.AreEqual(requisition.PurchaseOrderNumber, response.PurchaseOrderNumber);
            Assert.AreEqual(requisition.Item, response.Item);
            Assert.AreEqual(requisition.Currency, response.Currency);
        }

        [Test]
        public void MapFromDomainEntity_NullContent_ReturnNull()
        {
            //Act
            var response = Requisition.MapFromDomainEntity(null);

            //Assert
            Assert.IsNull(response);
        }
    }
}
