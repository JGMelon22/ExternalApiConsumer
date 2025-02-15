using ExternalApiConsumer.Core.Shared;
using ExternalApiConsumer.Infrastructure.Interfaces;
using MediatR;

namespace ExternalApiConsumer.Application.People.Commands.Handlers;

public class SeedDataCommandHandler : IRequestHandler<SeedDataCommand, ServiceResponse<bool>>
{
    private readonly IManagePersonService _managePersonService;

    public SeedDataCommandHandler(IManagePersonService managePersonService)
    {
        _managePersonService = managePersonService;
    }

    public async Task<ServiceResponse<bool>> Handle(SeedDataCommand request, CancellationToken cancellationToken)
    {
        var result = await _managePersonService.SeedDataAsync();

        return new ServiceResponse<bool>
        {
            Success = result.Success,
            Message = result.Message,
            Data = result.Data
        };
    }
}
