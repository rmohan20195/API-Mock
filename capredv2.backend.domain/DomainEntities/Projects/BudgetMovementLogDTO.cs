using capredv2.backend.domain.DatabaseEntities.Projects;

namespace capredv2.backend.domain.DomainEntities.Projects
{
    public class BudgetMovementLogDTO
    {
        public static BudgetMovementLogDTO MapFromDatabaseEntity(BudgetMovementLog projectBudgetMovementLog)
        {
            return new BudgetMovementLogDTO();
        }
    }
}