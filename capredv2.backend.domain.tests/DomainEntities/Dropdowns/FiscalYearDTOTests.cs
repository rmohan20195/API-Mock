using capredv2.backend.domain.DatabaseEntities.Dropdowns;
using capredv2.backend.domain.DomainEntities.Dropdowns;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace capredv2.backend.domain.tests.DomainEntities.Dropdowns
{
    [TestFixture]
    public class FiscalYearDTOTests
    {
        [Test]
        public void MapFromDomainEntity_ValidEntity_ReturnDTOEntity()
        {
            //Arrange
            var fiscalYear = new FiscalYear()
            {
                Id = Guid.NewGuid(),
                Value = "2016",
                Position = 0
            };
            var response = FiscalYearDTO.MapFromDatabaseEntity(fiscalYear);

            Assert.IsNotNull(response);
            Assert.AreEqual(fiscalYear.Id, response.Id);
            Assert.AreEqual(fiscalYear.Value, response.Value);
            Assert.AreEqual(fiscalYear.Position, response.Position);
        }

        [Test]
        public void MapFromDomainEntity_NullContent_ReturnNull()
        {
            //Act
            var response = FiscalYearDTO.MapFromDatabaseEntity(null);

            //Assert
            Assert.IsNull(response);
        }
    }
}
