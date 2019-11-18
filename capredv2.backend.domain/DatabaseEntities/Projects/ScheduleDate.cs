using capredv2.backend.domain.DomainEntities.Projects;

namespace capredv2.backend.domain.DatabaseEntities.Projects
{
    public class ScheduleDate
    {
        public static ScheduleDate MapFromDomainEntity(ScheduleDateDTO projectScheduleDate)
        {
            return new ScheduleDate();
        }
    }
}