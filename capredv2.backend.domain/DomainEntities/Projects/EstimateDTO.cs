using capredv2.backend.domain.DatabaseEntities.Projects;

namespace capredv2.backend.domain.DomainEntities.Projects
{
    public class EstimateDTO
    {
        public static EstimateDTO MapFromDatabaseEntity(Estimate projectEstimate)
        {
            return new EstimateDTO();
        }
    }
}