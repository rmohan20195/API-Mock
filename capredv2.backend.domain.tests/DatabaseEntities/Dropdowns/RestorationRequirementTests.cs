using capredv2.backend.domain.DatabaseEntities.Dropdowns;
using capredv2.backend.domain.DomainEntities.Dropdowns;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace capredv2.backend.domain.tests.DatabaseEntities.Dropdowns
{
    [TestFixture]
    public class RestorationRequirementTests
    {
        [Test]
        public void MapFromDomainEntity_ValidEntity_ReturnDTOEntity()
        {
            //Arrange
            var restorationRequirement = new RestorationRequirementDTO()
            {
                Id = Guid.NewGuid(),
                Value = "Remove furniture & equipment & special construction",
                Position = 1
            };
            var response = RestorationRequirement.MapFromDomainEntity(restorationRequirement);

            Assert.IsNotNull(response);
            Assert.AreEqual(restorationRequirement.Id, response.Id);
            Assert.AreEqual(restorationRequirement.Value, response.Value);
            Assert.AreEqual(restorationRequirement.Position, response.Position);
        }

        [Test]
        public void MapFromDomainEntity_NullContent_ReturnNull()
        {
            //Act
            var response = RestorationRequirement.MapFromDomainEntity(null);

            //Assert
            Assert.IsNull(response);
        }
    }
}
