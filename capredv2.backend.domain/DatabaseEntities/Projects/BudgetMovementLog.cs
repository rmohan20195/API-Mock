using capredv2.backend.domain.DomainEntities.Projects;

namespace capredv2.backend.domain.DatabaseEntities.Projects
{
    public class BudgetMovementLog
    {
        public static BudgetMovementLog MapFromDomainEntity(BudgetMovementLogDTO projectBudgetMovementLog)
        {
            return new BudgetMovementLog();
        }
    }
}