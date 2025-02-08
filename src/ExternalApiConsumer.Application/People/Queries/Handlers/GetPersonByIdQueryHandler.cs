using ExternalApiConsumer.Core.Domains.Peole.Dtos.Responses;
using ExternalApiConsumer.Core.Domains.Peole.Mappings;
using ExternalApiConsumer.Core.Shared;
using ExternalApiConsumer.Infrastructure.Interfaces;
using MediatR;

namespace ExternalApiConsumer.Application.People.Queries.Handlers;

public class GetPersonByIdQueryHandler : IRequestHandler<GetPersonByIdQuery, ServiceResponse<PersonResponse>>
{
    private readonly IManagePersonService _managePersonService;

    public GetPersonByIdQueryHandler(IManagePersonService managePersonService)
    {
        _managePersonService = managePersonService;
    }

    public async Task<ServiceResponse<PersonResponse>> Handle(GetPersonByIdQuery request, CancellationToken cancellationToken)
    {
        var person = await _managePersonService.GetPersonAsync(request.Id);

        return new ServiceResponse<PersonResponse>
        {
            Success = person.Success,
            Message = person.Message,
            Data = person.Data?.ToResponse()
        };

    }
}
