using capredv2.backend.domain.DatabaseEntities.Dropdowns;
using capredv2.backend.domain.DomainEntities.Dropdowns;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace capredv2.backend.domain.tests.DatabaseEntities.Dropdowns
{
    [TestFixture]
    public class BudgetItemTypeTests
    {
        [Test]
        public void MapFromDomainEntity_ValidEntity_ReturnDTOEntity()
        {
            //Arrange
            var budgetItemType = new BudgetItemTypeDTO()
            {
                Id = Guid.NewGuid(),
                Value = "Original Order",
                Position = 0
            };
            var response = BudgetItemType.MapFromDomainEntity(budgetItemType);

            Assert.IsNotNull(response);
            Assert.AreEqual(budgetItemType.Id, response.Id);
            Assert.AreEqual(budgetItemType.Value, response.Value);
            Assert.AreEqual(budgetItemType.Position, response.Position);
        }

        [Test]
        public void MapFromDomainEntity_NullContent_ReturnNull()
        {
            //Act
            var response = BudgetItemType.MapFromDomainEntity(null);

            //Assert
            Assert.IsNull(response);
        }
    }
}
