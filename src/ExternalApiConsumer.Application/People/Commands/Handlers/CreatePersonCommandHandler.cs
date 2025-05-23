using ExternalApiConsumer.Core.Domains.Peole.Mappings;
using ExternalApiConsumer.Core.Shared;
using ExternalApiConsumer.Infrastructure.Interfaces;
using MediatR;

namespace ExternalApiConsumer.Application.People.Commands.Handlers;

public class CreatePersonCommandHandler : IRequestHandler<CreatePersonCommand, ServiceResponse<bool>>
{
    private readonly IManagePersonService _managePersonService;

    public CreatePersonCommandHandler(IManagePersonService managePersonService)
    {
        _managePersonService = managePersonService;
    }

    public async Task<ServiceResponse<bool>> Handle(CreatePersonCommand request, CancellationToken cancellationToken)
    {
        var person = request.PersonRequest.ToDomain();
        var result = await _managePersonService.CreatePersonAsync(person);

        return new ServiceResponse<bool>
        {
            Success = result.Success,
            Message = result.Message,
            Data = result.Data
        };
    }
}