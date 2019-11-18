using capredv2.backend.domain.DomainEntities.Dropdowns;
using System;
using System.Collections.Generic;
using System.Text;

namespace capredv2.backend.domain.DatabaseEntities.Dropdowns
{
    public class AssetCategory
    {
        public Guid Id { get; set; }
        public string Value { get; set; }
        public int Position { get; set; }

        public static AssetCategory MapFromDomainEntity(AssetCategoryDTO assetCategory)
        {
            if (assetCategory == null) return null;

            return new AssetCategory()
            {
                Id = assetCategory.Id,
                Value = assetCategory.Value,
                Position = assetCategory.Position
            };
        }
    }
}
