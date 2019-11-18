using System;
using capredv2.backend.domain.DatabaseEntities.Projects;
using capredv2.backend.domain.DomainEntities.Projects;
using NUnit.Framework;

namespace capredv2.backend.domain.tests.DomainEntities.Projects
{
    [TestFixture]
    public class InvoiceHeaderDTOTests
    {
        [Test]
        public void MapFromDomainEntity_ValidEntity_ReturnDTOEntity()
        {
            //Arrange
            var invoiceHeader = new InvoiceHeader
            {
                Id = new Guid("110a0a30-3097-471b-962b-1d690c2ea8c6"),
                ProjectId = new Guid("b58b6a58-2064-4c71-9b3d-c8c4514159a9"),
                InvoiceNumber = "5555",
                AccountingTotalCurrency = "USD",
                Billing = "802-001-5415610-502025-PS-00000-000-000",
                Currency = "INR",
                InvoiceDate = new DateTime(2019, 4, 1),
                Status = "Approved",
                Supplier = "ABC CORPORATION"
            };

            //Act
            var response = InvoiceHeaderDTO.MapFromDomainEntity(invoiceHeader);

            //Assert
            Assert.IsNotNull(response);
            Assert.AreEqual(invoiceHeader.Id, response.Id);
            Assert.AreEqual(invoiceHeader.ProjectId, response.ProjectId);
	        Assert.AreEqual(invoiceHeader.InvoiceNumber, response.InvoiceNumber);
            Assert.AreEqual(invoiceHeader.AccountingTotalCurrency, response.AccountingTotalCurrency);
            Assert.AreEqual(invoiceHeader.Billing, response.Billing);
            Assert.AreEqual(invoiceHeader.Currency, response.Currency);
            Assert.AreEqual(invoiceHeader.InvoiceDate, response.InvoiceDate);
            Assert.AreEqual(invoiceHeader.Status, response.Status);
            Assert.AreEqual(invoiceHeader.InvoiceDate, response.InvoiceDate);
            Assert.AreEqual(invoiceHeader.Supplier, response.Supplier);
        }

        [Test]
        public void MapFromDomainEntity_NullContent_ReturnNull()
        {
            //Act
            var response = InvoiceHeaderDTO.MapFromDomainEntity(null);

            //Assert
            Assert.IsNull(response);
        }
    }
}
