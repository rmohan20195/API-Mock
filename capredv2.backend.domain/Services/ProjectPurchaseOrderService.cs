using System;
using capredv2.backend.domain.DatabaseEntities.Projects;
using capredv2.backend.domain.DomainEntities;
using capredv2.backend.domain.DomainEntities.Projects;
using capredv2.backend.domain.Exceptions;
using capredv2.backend.domain.Repositories.Interfaces;
using capredv2.backend.domain.Services.Interfaces;

namespace capredv2.backend.domain.Services
{
    public class ProjectPurchaseOrderService : IProjectPurchaseOrderService
    {
        private readonly IProjectPurchaseOrderRepository _projectPurchaseOrderRepository;

        public ProjectPurchaseOrderService(IProjectPurchaseOrderRepository projectPurchaseOrderRepository)
        {
            _projectPurchaseOrderRepository = projectPurchaseOrderRepository ?? throw new ArgumentNullException(nameof(projectPurchaseOrderRepository));
        }

        public POHeaderDTO Add(POHeaderDTO pOHeader)
        {
            var response = _projectPurchaseOrderRepository.Add(POHeader.MapFromDomainEntity(pOHeader));

            return POHeaderDTO.MapFromDatabaseEntity(response);
        }

        public POLineItemDTO AddLineItem(POLineItemDTO poLineItemDTO)
        {
            var response = _projectPurchaseOrderRepository.AddLineItem(POLineItem.MapFromDomainEntity(poLineItemDTO));

            return POLineItemDTO.MapFromDatabaseEntity(response);
        }

        public GenericPagedCollection<object> GetHeaders(Guid projectId, int pageSize, int pageNumber)
        {
            var data = _projectPurchaseOrderRepository.GetHeaders(projectId, pageNumber, pageSize);

            return new GenericPagedCollection<object>
            {
                Count = 0,
                CurrentPage = pageNumber,
                PageSize = pageSize,
                Data = data
            };
        }

        public GenericPagedCollection<object> GetLineItems(Guid poHeaderId)
        {
            var data = _projectPurchaseOrderRepository.GetLineItems(poHeaderId);

            return new GenericPagedCollection<object>
            {
                Count = 0,
                CurrentPage = 0,
                PageSize = 0,
                Data = data
            };
        }
    }
}
