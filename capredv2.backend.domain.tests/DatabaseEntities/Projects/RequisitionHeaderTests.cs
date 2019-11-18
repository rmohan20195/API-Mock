using capredv2.backend.domain.DatabaseEntities.Projects;
using capredv2.backend.domain.DomainEntities.Projects;
using NUnit.Framework;
using System;

namespace capredv2.backend.domain.tests.DatabaseEntities.Projects
{
    public class RequisitionHeaderTests
    {
        [Test]
        public void MapFromDomainEntity_ValidEntity_ReturnDTOEntity()
        {
            //Arrange
            var requisition = new RequisitionHeaderDTO
            {
                ProjectId = new Guid("b58b6a58-2064-4c71-9b3d-c8c4514159a9"),
                RequisitionNumber = 1001,
                Supplier = "Supplier",
                CreatedDate = new DateTime(2019, 08, 01),
                Status = "Status",
                PurchaseOrderNumber = 1234,
                Currency = "US Dollar",
                Id = Guid.NewGuid(),
            };

            //Act
            var response = RequisitionHeader.MapFromDomainEntity(requisition);

            //Assert
            Assert.IsNotNull(response);
            Assert.AreEqual(requisition.ProjectId, response.ProjectId);
            Assert.AreEqual(requisition.RequisitionNumber, response.RequisitionNumber);
            Assert.AreEqual(requisition.Supplier, response.Supplier);
            Assert.AreEqual(requisition.CreatedDate, response.CreatedDate);
            Assert.AreEqual(requisition.Status, response.Status);
            Assert.AreEqual(requisition.PurchaseOrderNumber, response.PurchaseOrderNumber);
            Assert.AreEqual(requisition.Currency, response.Currency);
            Assert.AreEqual(requisition.Id, response.Id);
        }

        [Test]
        public void MapFromDomainEntity_NullContent_ReturnNull()
        {
            //Act
            var response = RequisitionHeader.MapFromDomainEntity(null);

            //Assert
            Assert.IsNull(response);
        }
    }
}
