using capredv2.backend.domain.DomainEntities.Projects;

namespace capredv2.backend.domain.DatabaseEntities.Projects
{
    public class Estimate
    {
        public static Estimate MapFromDomainEntity(EstimateDTO projectEstimate)
        {
            return new Estimate();
        }
    }
}