using capredv2.backend.domain.DatabaseEntities.Dropdowns;
using capredv2.backend.domain.DomainEntities.Dropdowns;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace capredv2.backend.domain.tests.DomainEntities.Dropdowns
{
    [TestFixture]
    public class ProjectTypeDTOTests
    {
        [Test]
        public void MapFromDomainEntity_ValidEntity_ReturnDTOEntity()
        {
            //Arrange
            var projectType = new ProjectType()
            {
                Id = Guid.NewGuid(),
                Value = "Densification",
                Position = 0
            };
            var response = ProjectTypeDTO.MapFromDatabaseEntity(projectType);

            Assert.IsNotNull(response);
            Assert.AreEqual(projectType.Id, response.Id);
            Assert.AreEqual(projectType.Value, response.Value);
            Assert.AreEqual(projectType.Position, response.Position);
        }

        [Test]
        public void MapFromDomainEntity_NullContent_ReturnNull()
        {
            //Act
            var response = ProjectTypeDTO.MapFromDatabaseEntity(null);

            //Assert
            Assert.IsNull(response);
        }
    }
}
