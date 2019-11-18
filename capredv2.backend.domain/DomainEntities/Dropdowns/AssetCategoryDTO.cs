using capredv2.backend.domain.DatabaseEntities.Dropdowns;
using System;
using System.Collections.Generic;
using System.Text;

namespace capredv2.backend.domain.DomainEntities.Dropdowns
{
   public class AssetCategoryDTO
    {
        public Guid Id { get; set; }
        public string Value { get; set; }
        public int Position { get; set; }

        public AssetCategoryDTO()
        {
            Id = Guid.NewGuid();
        }

        public static AssetCategoryDTO MapFromDatabaseEntity(AssetCategory assetCategory)
        {
            if (assetCategory == null) return null;

            return new AssetCategoryDTO()
            {
                Id = assetCategory.Id,
                Value = assetCategory.Value,
                Position = assetCategory.Position
            };
        }
    }
}
