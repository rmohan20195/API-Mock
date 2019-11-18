using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading.Tasks;
using capredv2.backend.domain.Exceptions;
using capredv2.backend.domain.Validators.DomainEntities.Interfaces;

namespace capredv2.backend.domain.Validators
{
    public class ValidatorEngine<T>
    {
        private readonly IEnumerable<IDomainEntitiesValidator<T>> _domainEntityValidators;

        public ValidatorEngine(IEnumerable<IDomainEntitiesValidator<T>> domainEntityValidators)
        {
            _domainEntityValidators = domainEntityValidators;
        }

        public void Validate(T entity)
        {
            var messages = new ConcurrentBag<string>();
            var result = true;
            Parallel.ForEach(_domainEntityValidators,
                domainEntityValidator =>
                {
                    var validationResult = domainEntityValidator.Validate(entity);

                    if (validationResult.Item1) return;
                    messages.Add(validationResult.Item2);
                    result = false;
                });

            if (!result)
                throw new BusinessValidationException(string.Join("--", messages));
        }
    }
}
