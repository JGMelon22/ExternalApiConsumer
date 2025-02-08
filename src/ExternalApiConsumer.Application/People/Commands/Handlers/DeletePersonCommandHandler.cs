using ExternalApiConsumer.Core.Shared;
using ExternalApiConsumer.Infrastructure.Interfaces;
using MediatR;

namespace ExternalApiConsumer.Application.People.Commands.Handlers;

public class DeletePersonCommandHandler : IRequestHandler<DeletePersonCommand, ServiceResponse<bool>>
{
    private readonly IManagePersonService _managePersonService;

    public DeletePersonCommandHandler(IManagePersonService managePersonService)
    {
        _managePersonService = managePersonService;
    }

    public async Task<ServiceResponse<bool>> Handle(DeletePersonCommand request, CancellationToken cancellationToken)
    {
        ServiceResponse<bool> result = await _managePersonService.DeletePeopleAsync();

        return new ServiceResponse<bool>
        {
            Success = result.Success,
            Message = result.Message,
            Data = result.Data
        };
    }
}
