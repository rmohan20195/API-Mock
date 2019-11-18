using capredv2.backend.domain.DatabaseEntities.Projects;

namespace capredv2.backend.domain.DomainEntities.Projects
{
    public class ScheduleDateDTO
    {
        public static ScheduleDateDTO MapFromDatabaseEntity(ScheduleDate projectScheduleDate)
        {
            return new ScheduleDateDTO();
        }
    }
}