using capredv2.backend.domain.DatabaseEntities.Dropdowns;
using capredv2.backend.domain.DomainEntities.Dropdowns;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace capredv2.backend.domain.tests.DomainEntities.Dropdowns
{
    [TestFixture]
    public class BudgetItemTypeDTOTests
    {
        [Test]
        public void MapFromDomainEntity_ValidEntity_ReturnDTOEntity()
        {
            //Arrange
            var budgetItemType = new BudgetItemType()
            {
                Id = Guid.NewGuid(),
                Value = "Original Order",
                Position = 0
            };
            var response = BudgetItemTypeDTO.MapFromDatabaseEntity(budgetItemType);

            Assert.IsNotNull(response);
            Assert.AreEqual(budgetItemType.Id, response.Id);
            Assert.AreEqual(budgetItemType.Value, response.Value);
            Assert.AreEqual(budgetItemType.Position, response.Position);
        }

        [Test]
        public void MapFromDomainEntity_NullContent_ReturnNull()
        {
            //Act
            var response = BudgetItemTypeDTO.MapFromDatabaseEntity(null);

            //Assert
            Assert.IsNull(response);
        }
    }
}
