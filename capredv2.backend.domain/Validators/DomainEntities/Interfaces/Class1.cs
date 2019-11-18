using System;

namespace capredv2.backend.domain.Validators.DomainEntities.Interfaces
{
    public interface IDomainEntitiesValidator<in T>
    {
        Tuple<bool, string> Validate(T entity);
    }
}
