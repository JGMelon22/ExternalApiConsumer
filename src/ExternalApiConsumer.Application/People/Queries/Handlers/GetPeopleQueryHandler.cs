using ExternalApiConsumer.Core.Domains.Peole.Dtos.Responses;
using ExternalApiConsumer.Core.Domains.Peole.Mappings;
using ExternalApiConsumer.Core.Domains.People.Entities;
using ExternalApiConsumer.Core.Shared;
using ExternalApiConsumer.Infrastructure.Interfaces;
using MediatR;

namespace ExternalApiConsumer.Application.People.Queries.Handlers;

public class GetPeopleQueryHandler : IRequestHandler<GetPeopleQuery, ServiceResponse<IEnumerable<PersonResponse>>>
{
    private readonly IManagePersonService _managePersonService;

    public GetPeopleQueryHandler(IManagePersonService managePersonService)
    {
        _managePersonService = managePersonService;
    }

    public async Task<ServiceResponse<IEnumerable<PersonResponse>>> Handle(GetPeopleQuery request, CancellationToken cancellationToken)
    {
        ServiceResponse<IEnumerable<Person>> people = await _managePersonService.GetPeopleAsync();

        return new ServiceResponse<IEnumerable<PersonResponse>>
        {
            Success = people.Success,
            Message = people.Message,
            Data = people.Data?.ToResponse()
        };
    }
}
