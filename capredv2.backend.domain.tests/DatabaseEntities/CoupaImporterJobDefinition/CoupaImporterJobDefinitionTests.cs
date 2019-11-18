using System;
using System.Collections.Generic;
using capredv2.backend.domain.DomainEntities.CoupaImporter;
using NUnit.Framework;

namespace capredv2.backend.domain.tests.DatabaseEntities.CoupaImporterJobDefinition
{
    [TestFixture]
    public class CoupaImporterJobDefinitionTests
    {
        [Test]
        public void MapFromDomainEntity_ValidEntity_ReturnDatabaseEntity()
        {
            //Arrange
            var domainEntity = new CoupaImporterJobDefinitionDTO
            {
                Id = new Guid("45744a2e-3dc1-472f-9bb5-378a0a9eeda4"),
                FileName = "fileTest.csv",
                Status = CoupaImporterStatus.Pending,
                TimeStamp = DateTime.UtcNow,
				ProjectId = new  Guid("4d75753e-618d-4067-9019-f91a64407bca"),
                CoupaImporterJobDefinitionDetails = new List<CoupaImporterJobDefinitionDetailDTO>
                {
                    new CoupaImporterJobDefinitionDetailDTO
                    {
                        Id = new Guid("dd797697-6e95-4175-9637-f84ee3002088"),
                        IsProcessed = true,
                        IsSuccessful = false
                    }
                }
            };

            //Act
            var result = domain.DatabaseEntities.CoupaImporterJobDefinitions.CoupaImporterJobDefinition.MapFromDomainEntity(domainEntity);

            //Assert
            Assert.AreEqual(domainEntity.Id, result.Id);
            Assert.AreEqual(domainEntity.ProjectId, result.ProjectId);
	        Assert.AreEqual(domainEntity.FileName, result.FileName);
            Assert.AreEqual(domainEntity.TimeStamp, result.TimeStamp);
            Assert.AreEqual(domainEntity.Status, (CoupaImporterStatus)result.Status);
            Assert.IsNotNull(result.CoupaImporterJobDefinitionDetails);
            Assert.AreEqual(1, result.CoupaImporterJobDefinitionDetails.Count);
        }
    }
}
