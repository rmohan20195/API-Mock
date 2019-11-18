using capredv2.backend.domain.DatabaseEntities.Dropdowns;
using capredv2.backend.domain.DomainEntities.Dropdowns;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace capredv2.backend.domain.tests.DatabaseEntities.Dropdowns
{
    [TestFixture]
    public class ProjectTypeTests
    {
        [Test]
        public void MapFromDomainEntity_ValidEntity_ReturnDTOEntity()
        {
            //Arrange
            var projectType = new ProjectTypeDTO()
            {
                Id = Guid.NewGuid(),
                Value = "Densification",
                Position = 0
            };
            var response = ProjectType.MapFromDomainEntity(projectType);

            Assert.IsNotNull(response);
            Assert.AreEqual(projectType.Id, response.Id);
            Assert.AreEqual(projectType.Value, response.Value);
            Assert.AreEqual(projectType.Position, response.Position);
        }

        [Test]
        public void MapFromDomainEntity_NullContent_ReturnNull()
        {
            //Act
            var response = ProjectType.MapFromDomainEntity(null);

            //Assert
            Assert.IsNull(response);
        }
    }
}
